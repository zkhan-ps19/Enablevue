using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Novacode;
using System.Diagnostics;
using System.Web;
using System.Net;


namespace EnableVue.ProcessLayers
{

    static class Processes
    {

        #region variables for use
        private static EV_Db.SharedData.ApplicationData AppData;
        private static EV_Db.Batch currentBatch;
        private static List<EV_Db.FilesProcessed> currentBatchFilesList;
        private static bool new_Files = false;
        #endregion

        /// <summary>
        /// Check for last used information that worked .. 
        /// ...with the service
        /// retrieve the information from DB and get it ..
        /// ...loaded in memory
        /// </summary>
        public static void Initial_Loading()
        {
            WriteLog_DBandEvent("Initial Loading of Shared data");
            AppData = new EV_Db.SharedData.ApplicationData();
            EV_Db.SharedData.LoadData(AppData);
        }

        /// <summary>
        /// Main Functionalities are listed below
        /// -check log in info or Token
        /// -check web url
        /// -check folder path
        /// - Check for Application is running or not
        /// after that 
        /// -make Batch
        /// -add batch files
        /// -parse files
        /// -upload files
        /// -create a log
        /// 
        /// validate
        /// </summary>
        public static void ExecuteProcesses()
        {
            WriteLog_DBandEvent("in processes execution.");

            //check all APPDATA is true to start work
            if (CheckAppDataALLtrue())
            {
                //if true then Make a batch on the Folder path
                WriteLog_DBandEvent("Started batch making");
                MakeBatch();

                // when batch done start parsing and uploading one by one
                WriteLog_DBandEvent("Started file parsing and upload");
                ParseAndUPload_CurrentBatchFiles();


                //make batch log and email it
                Make_SimpleLogInfoAndEmail();

                //reload values for next batch
                WriteLog_DBandEvent("Updating weburl and folder path settings for Next Batch");
                EV_Db.SharedData.LoadData(AppData);

            }
            else
            {

                if (!AppData.isLoggedIn)
                {
                    SetState_Halted_NotLoggedIn(GetServiceState_Object("waitig for log in status.", false));
                    WriteLog_DBandEvent("waitig for log in status.");
                    EV_Db.SharedData.LoadData(AppData, 2);
                }
                else
                {
                    if (!AppData.folderpathWokring)
                    {
                        SetState_Halted_FolderPathNotCorrect(GetServiceState_Object("waiting for correct folder path", false));
                        WriteLog_DBandEvent("waiting for correct folder path");
                    }
                    else if (!AppData.webUrlWorking)
                    {
                        SetState_Halted_WebURLNotWorking(GetServiceState_Object("waiting for correct web url", false));
                        WriteLog_DBandEvent("waiting for correct web url");
                    }

                    EV_Db.SharedData.LoadData(AppData, 2);
                }
            }



            ThreadSleep();

        }

        #region Batch Functions

        private static void MakeBatch()
        {
            currentBatch = new EV_Db.Batch();
            currentBatch.folderpath = EV_Db.SharedData.serviceSettings.folderpath;
            EV_Db.ServiceCallsManager.InsertNewBatch(currentBatch);
            new_Files = false;

            while (!new_Files)
            {
                makeListofFiles();
                if (!new_Files)
                {
                    // insert state
                    SetState_waitingforFiles(GetServiceState_Object(" Waiting for new Files", false));

                    //write Logs
                    WriteLog_DBandEvent(" Waiting for new Files");

                    ThreadSleep();
                }
            }
        }

        private static void makeListofFiles()
        {
            currentBatchFilesList = new List<EV_Db.FilesProcessed>();
            List<EV_Db.FilesProcessed> lstOLDProcessed = EV_Db.ServiceCallsManager.GetAllPreviouslyFilesProcessed() as List<EV_Db.FilesProcessed>;

            //@"C:\Users\hsiddique\Desktop\Projects Data\EnableVue\files and data"
            foreach (string file in Directory.EnumerateFiles(EV_Db.SharedData.serviceSettings.folderpath, "*.*",
                                  SearchOption.AllDirectories)
                                  .Where(s => s.ToLower().EndsWith(".doc") || s.ToLower().EndsWith(".docx")))
            {


                string fileName = file.Replace(EV_Db.SharedData.serviceSettings.folderpath, "");
                int index = lstOLDProcessed.FindIndex(s => s.fileName.Equals(fileName));

                if (index < 0) // file not found 
                {
                    EV_Db.FilesProcessed objFile = new EV_Db.FilesProcessed();
                    objFile.fileName = fileName;
                    objFile.batchNumber = currentBatch.Batch_Number;
                    objFile.parsed = false;

                    currentBatchFilesList.Add(objFile);
                }
            }


            if (currentBatchFilesList.Count > 0)
            {

                WriteLog_DBandEvent(" " + currentBatchFilesList.Count.ToString() + " New Files");
                new_Files = true;

                //insert all files
                EV_Db.ServiceCallsManager.insertBatchedFiles(currentBatchFilesList);
            }

        }

        #endregion

        #region Parsing Steps

        private static void ParseAndUPload_CurrentBatchFiles()
        {
            currentBatch.startTime = DateTime.Now;
            foreach (var objFile in currentBatchFilesList)
            {



                try
                {
                    // notify log for event start parsing
                    WriteLog_DBandEvent("Started Processing File : " + objFile.fileName);
                    SetState_processingFile(GetServiceState_Object("Started Processing File : " + objFile.fileName, true, objFile.Id));


                    //start parsing
                    #region Parsing
                    using (DocX document = DocX.Load(currentBatch.folderpath + "\\" + objFile.fileName))
                    {
                        List<Novacode.Paragraph> lstParas = document.Paragraphs;

                        //  0 for title 
                        //count -1 for tags
                        //count -2 for category
                        //count -3 for source
                        //  from 1 to count-4  all is part of content

                        int count = lstParas.Count;

                        objFile.title = lstParas[0].Text;
                        objFile.author = document.CoreProperties["dc:creator"];


                        Novacode.Paragraph categpara = lstParas[count - 2];
                        Novacode.Paragraph srcpara = lstParas[count - 3];

                        objFile.category = ReturnRemovedkeywordText(categpara, "Category");
                        objFile.source = ReturnRemovedkeywordText(srcpara, "Source");

                        if (srcpara.Hyperlinks.Count > 0)
                        {
                            foreach (var HyperLnk in srcpara.Hyperlinks)
                            {
                                objFile.source = objFile.source.Replace(HyperLnk.Text, "<a href=\"" + HyperLnk.Uri.AbsoluteUri + "\">" + HyperLnk.Text + "</a>");
                            }
                        }

                        string content = "";

                        bool isListItem = false;
                        bool isNumberedList = false;
                        bool isUnOrderedList = false;

                        for (int i = 1; i < (count - 3); i++)
                        {
                            Novacode.Paragraph localpara = lstParas[i];
                            string text = localpara.Text;

                            #region List Items
                            if (localpara.IsListItem && !isListItem)
                            {
                                isListItem = true;
                                if (localpara.ListItemType.ToString() == "Numbered")
                                {
                                    isNumberedList = true;
                                    content = content + "<ol>";
                                }
                                else
                                {
                                    isUnOrderedList = true;
                                    content = content + "<ul>";
                                }
                            }
                            else if (isListItem && !localpara.IsListItem)
                            {
                                if (isNumberedList)
                                {
                                    content = content + "</ol>";
                                }
                                else
                                {
                                    content = content + "</ul>";
                                }

                                isNumberedList = false;
                                isUnOrderedList = false;
                                isListItem = false;
                            }
                            #endregion

                            #region Bold Italic and Underline Tags
                            int added_tags = 0;
                            foreach (var magicprt in localpara.MagicText)
                            {
                                if (magicprt.formatting.Bold || magicprt.formatting.Italic || magicprt.formatting.UnderlineStyle.ToString() != "none")
                                {
                                    string start = text.Substring(0, magicprt.index + added_tags);
                                    string middle = "";
                                    string end = text.Substring(magicprt.index + magicprt.text.Length + added_tags);
                                    if (magicprt.formatting.Bold)
                                    {
                                        middle = "<b>" + magicprt.text + "</b>";
                                    }
                                    else if (magicprt.formatting.Italic)
                                    {
                                        middle = "<i>" + magicprt.text + "</i>";
                                    }
                                    else if (magicprt.formatting.UnderlineStyle.ToString() != "none")
                                    {
                                        middle = "<u>" + magicprt.text + "</u>";
                                    }
                                    text = start + middle + end;
                                    added_tags = added_tags + 7;
                                }
                            }
                            text = text.Replace("</b><b>", "").Replace("</u><u>", "").Replace("</i><i>", "");
                            #endregion

                            #region Content Hyperlinks
                            if (localpara.Hyperlinks.Count > 0)
                            {
                                foreach (var HyperLnk in localpara.Hyperlinks)
                                {
                                    text = text.Replace(HyperLnk.Text, "<a href=\"" + HyperLnk.Uri.AbsoluteUri + "\">" + HyperLnk.Text + "</a>");

                                    //category.Replace(HyperLnk.
                                }
                            }
                            #endregion

                            if (!localpara.IsListItem) // if its not list item
                                content = content + "<p>" + text + "<p>" + System.Environment.NewLine;
                            else // for list items
                                content = content + "<li>" + text + "</li>" + System.Environment.NewLine;

                        }


                        objFile.contentData1 = content;
                        if (content.Length > 3999)
                        {
                            objFile.contentData1 = content.Substring(0, 4000);
                            objFile.contentData2 = content.Substring(4000);
                        }

                        objFile.tag = "parse process completed @ " + DateTime.Now.ToString();

                    }
                    #endregion


                    #region Smart Quotes
                    objFile.category = objFile.category.Replace('\u201b', '\'')
                             .Replace('\u201c', '\"')
                             .Replace('\u201d', '\"')
                             .Replace('\u201e', '\"');

                    objFile.contentData1 = objFile.contentData1.Replace('\u201b', '\'')
                                     .Replace('\u201c', '\"')
                                     .Replace('\u201d', '\"')
                                     .Replace('\u201e', '\"');

                    objFile.contentData2 = objFile.contentData2.Replace('\u201b', '\'')
                                     .Replace('\u201c', '\"')
                                     .Replace('\u201d', '\"')
                                     .Replace('\u201e', '\"');


                    objFile.source = objFile.source.Replace('\u201b', '\'')
                                     .Replace('\u201c', '\"')
                                     .Replace('\u201d', '\"')
                                     .Replace('\u201e', '\"');

                    objFile.title = objFile.title.Replace('\u201b', '\'')
                                     .Replace('\u201c', '\"')
                                     .Replace('\u201d', '\"')
                                     .Replace('\u201e', '\"');

                    #endregion

                    WriteLog_DBandEvent("updating File : " + objFile.fileName + " parsing complete with smart quotes.");
                    //updateDocument to DB
                    EV_Db.ServiceCallsManager.updateBatch_FileProcessed(objFile);


                    //upload
                    if (UploadCurrentBatch_File(objFile))
                    {
                        WriteLog_DBandEvent("Uploading of Processed File : " + objFile.fileName);
                        //when done increase acount and persist to DB
                        currentBatch.fileProcessed++;
                    }
                    else
                    {
                        //when done increase acount and persist to DB
                        currentBatch.filesFailed++;
                    }

                    EV_Db.ServiceCallsManager.updateBatchObject(currentBatch);
                    WriteLog_DBandEvent("Processing completed File : " + objFile.fileName);

                }
                catch (Exception ex)
                {
                    currentBatch.filesFailed++;
                }

            }


        }

        #endregion

        #region Upload Files

        private static bool UploadCurrentBatch_File(EV_Db.FilesProcessed objFile)
        {
            try
            {

                string content;
                string Method = "POST";

                string uri = "http://shahid/RESTfulAWS/apihome/content/";

                HttpWebRequest req = WebRequest.Create(uri.Trim()) as HttpWebRequest;
                req.KeepAlive = false;
                req.Method = Method.ToUpper();

                if (("POST,PUT").Split(',').Contains(Method.ToUpper()))
                {
                    // Console.WriteLine("Enter XML FilePath:");
                    // string FilePath = Console.ReadLine();
                    content = FileToXML(objFile);

                    byte[] buffer = Encoding.ASCII.GetBytes(content);
                    req.ContentLength = buffer.Length;
                    req.ContentType = "text/xml";
                    Stream PostData = req.GetRequestStream();
                    PostData.Write(buffer, 0, buffer.Length);
                    PostData.Close();

                }

                HttpWebResponse resp = req.GetResponse() as HttpWebResponse;


                Encoding enc = System.Text.Encoding.GetEncoding(1252);
                StreamReader loResponseStream = new StreamReader(resp.GetResponseStream(), enc);
                //resp.GetResponseStream() StreamReader ls = new StreamReader(
                string Response = loResponseStream.ReadToEnd();
                if (Response.Contains("201"))
                {
                    WriteLog_DBandEvent("Upload success File : " + objFile.fileName);
                    return true;
                }
                else
                {
                    WriteLog_DBandEvent("Upload Failure File : " + objFile.fileName + ".  Error detail " + Response);
                    return false;
                }


            }
            catch (Exception ex)
            {
                WriteLog_DBandEvent("Upload Failure File : " + objFile.fileName + ".  Exception occured [ " + ex.Message + " ]");
                return false;
                //Console.WriteLine(ex.Message.ToString());

            }
        }

        private static string FileToXML(EV_Db.FilesProcessed objFile)
        {



            String contentId = objFile.fileName.Substring(0, objFile.fileName.IndexOf('_'));

            var t = "http://schemas.datacontract.org/2004/07/Model";
            string txt = "<Content xmlns=\"" + t + "\">" +
                      "<AuthorName>" + objFile.author + "</AuthorName>" +
                      "<Category>" + HttpUtility.HtmlEncode(objFile.category) + "</Category>" +
                      "<Contentdetail>" + HttpUtility.HtmlEncode(objFile.contentData1 + objFile.contentData2) + "</Contentdetail>" +
                      "<Source>" + HttpUtility.HtmlEncode(objFile.source) + "</Source>" +
                      "<SubscriptionId>" + objFile.contentID + "</SubscriptionId>" +
                      "<Title>" + HttpUtility.HtmlEncode(objFile.title) + "</Title>" +
                      "</Content>";

            return txt;

        }

        #endregion

        #region ServiceStates Functions

        #region ServiceStates Create Methods

        private static EV_Db.ServiceState GetServiceState_Object()
        {
            EV_Db.ServiceState objServ = new EV_Db.ServiceState();
            objServ.isrunning = true;
            objServ.processignbatch = false;
            objServ.waitingforfiles = false;

            objServ.currentState = "undefined";



            return objServ;
        }

        private static EV_Db.ServiceState GetServiceState_Object(string currentstate, bool isbatchProcessing, int fileID = 0)
        {
            EV_Db.ServiceState objServ = new EV_Db.ServiceState();
            objServ.isrunning = true;
            objServ.processignbatch = isbatchProcessing;
            objServ.waitingforfiles = false;
            if (currentBatch == null)
                objServ.batchId = -1;
            else
                objServ.batchId = currentBatch.Batch_Number;

            objServ.currentState = currentstate;

            if (fileID > 0)
            {
                objServ.fileid = fileID;
            }

            return objServ;
        }

        #endregion

        private static void SetState_processingBatch(EV_Db.ServiceState objState)
        {
            objState.processignbatch = true;
            EV_Db.ServiceCallsManager.InsertServiceState(objState);
        }

        private static void SetState_processingBatchwithID(EV_Db.ServiceState objState)
        {
            objState.processignbatch = true;
            objState.batchId = currentBatch.Batch_Number;
            EV_Db.ServiceCallsManager.InsertServiceState(objState);
        }

        private static void SetState_processingFile(EV_Db.ServiceState objState)
        {
            if (objState.fileid > 0 && objState.batchId > 0)
                EV_Db.ServiceCallsManager.InsertServiceState(objState);
            else
                WriteLog_DBandEvent("method processing_file with missing values of File or batch");
        }

        private static void SetState_waitingforFiles(EV_Db.ServiceState objState)
        {
            objState.waitingforfiles = true;
            if (objState.batchId > 0)
                EV_Db.ServiceCallsManager.InsertServiceState(objState);
            else
                WriteLog_DBandEvent("method waiting_for_files with missing value of batch");
        }

        private static void SetState_Halted_NotLoggedIn(EV_Db.ServiceState objState)
        {
            objState.isHalted = true;
            objState.isNotLoggedIn = true;

            EV_Db.ServiceCallsManager.InsertServiceState(objState);

        }

        private static void SetState_Halted_FolderPathNotCorrect(EV_Db.ServiceState objState)
        {
            objState.isHalted = true;
            objState.isNotFolderPathCorrect = true;

            EV_Db.ServiceCallsManager.InsertServiceState(objState);

        }

        private static void SetState_Halted_WebURLNotWorking(EV_Db.ServiceState objState)
        {
            objState.isHalted = true;
            objState.isNotWebURLWorking = true;

            EV_Db.ServiceCallsManager.InsertServiceState(objState);

        }
        #endregion

        #region Usefull Funtions

        private static void CheckiffApplicationRunning()
        {
            if (!IsApplicationRunning())
            {
                string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                Process.Start(path + "\\EnableVue.exe");
            }
        }


        private static bool IsApplicationRunning(string name = "EnableVue")
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.Contains(name))
                {
                    return true;
                }
            }
            return false;
        }
        private static string ReturnRemovedkeywordText(Novacode.Paragraph para, string keyword)
        {
            char[] arr = para.Text.Trim().ToCharArray();
            int length = keyword.Length;
            if (arr[length] == ':')
            {
                length = length + 1;
            }
            else if (arr[length + 1] == ':')
            {
                length = length + 2;
            }

            return para.Text.Substring(length).Trim();
        }

        private static bool CheckAppDataALLtrue()
        {
            return (AppData.folderpathWokring && AppData.isLoggedIn && AppData.webUrlWorking);
        }

        public static void ThreadSleep(int value = 2000)
        {
            WriteLog_DBandEvent(" thread sleep");
            System.Threading.Thread.Sleep(value);
        }

        public static void WriteLog_DBandEvent(string value)
        {
            EventLog.WriteEntry("Application", " EnableVue_Service : " + value);
            EV_Db.ServiceCallsManager.InsertDetailed_DBLog(value);
        }

        private static void Make_SimpleLogInfoAndEmail()
        {
            // here it comes
            string value = " here is the detail ";


            EV_Db.ServiceCallsManager.InsertSimple_DBLog(value);
        }

        #endregion

    }
}
