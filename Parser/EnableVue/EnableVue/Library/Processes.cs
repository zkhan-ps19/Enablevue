using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Novacode;
using System.Diagnostics;
using System.Web;
using System.Net;
using EnableVue;
using Library.POCO;

namespace Library
{

    //[Ver 1.0 methods closed]


    //static class Processes
    //{




    //    #region variables for use

    //   // private static ApplicationData.ApplicationData AppData;
    //    private static Batch currentBatch;
    //    private static List<FilesProcessed> currentBatchFilesList;
    //    public static bool new_Files = false;


    //    public static volatile bool is_halt, is_makingBatch, is_ParsingUploading, is_sendingEmail;

    //    #endregion

    //    #region Properties of AppData variables
    //    public static bool is_waitingForFolderpath
    //    {
    //        get { return !AppData.folderpathWokring; }
    //    }

    //    public static bool is_waitingforLogin
    //    {
    //        get { return !AppData.isLoggedIn; }
    //    }

    //    public static bool is_waitingforURL
    //    {
    //        get { return !AppData.webUrlWorking; }
    //    }
    //    #endregion


    //    /// <summary>
    //    /// Check for last used information that worked .. 
    //    /// ...with the service
    //    /// retrieve the information from DB and get it ..
    //    /// ...loaded in memory
    //    /// </summary>
    //    public static void Initial_Loading()
    //    {
    //        WriteLog_DBandEvent("Initial Loading of Shared data");
    //        AppData = new ApplicationData.ApplicationData();
    //        ApplicationData.LoadData();
    //    }

    //    /// <summary>
    //    /// Main Functionalities are listed below
    //    /// -check log in info or Token
    //    /// -check web url
    //    /// -check folder path
    //    /// - Check for Application is running or not
    //    /// after that 
    //    /// -make Batch
    //    /// -add batch files
    //    /// -parse files
    //    /// -upload files
    //    /// -create a log
    //    /// 
    //    /// validate
    //    /// </summary>
    //    public static void ExecuteProcesses()
    //    {
    //        try
    //        {
    //            WriteLog_DBandEvent("in processes execution.");
    //            is_halt = !CheckAppDataALLtrue();
    //            //check all APPDATA is true to start work
    //            if (CheckAppDataALLtrue())
    //            {
    //                //if true then Make a batch on the Folder path
    //                is_makingBatch = true;
    //                WriteLog_DBandEvent("Started batch making");
    //                MakeBatch();
    //                is_makingBatch = false;

    //                // when batch done start parsing and uploading one by one
    //                is_ParsingUploading = true;
    //                WriteLog_DBandEvent("Started file parsing and upload");
    //                ParseAndUPload_CurrentBatchFiles();
    //                is_ParsingUploading = false;

    //                is_sendingEmail = true;
    //                //make batch log and email it
    //                Make_SimpleLogInfoAndEmail();
    //                is_sendingEmail = false;

    //                //reload values for next batch
    //                WriteLog_DBandEvent("Updating weburl and folder path settings for Next Batch");
    //                ApplicationData.LoadData();

    //            }
    //            else
    //            {
    //                if (!AppData.webUrlWorking)
    //                {
    //                    SetState_Halted_WebURLNotWorking(GetServiceState_Object("waiting for correct web url", false));
    //                    WriteLog_DBandEvent("waiting for correct web url");
    //                    ApplicationData.LoadData(1);
    //                }
    //                else if (!AppData.isLoggedIn)
    //                {
    //                    SetState_Halted_NotLoggedIn(GetServiceState_Object("waitig for log in status.", false));
    //                    WriteLog_DBandEvent("waitig for log in status.");
    //                    ApplicationData.LoadData( 2);
    //                }
    //                else if (!AppData.folderpathWokring)
    //                {
    //                    SetState_Halted_FolderPathNotCorrect(GetServiceState_Object("waiting for correct folder path", false));
    //                    WriteLog_DBandEvent("waiting for correct folder path");
    //                    ApplicationData.LoadData(1);
    //                }

    //            }

    //            ThreadSleep();
    //        }
    //        catch (Exception ex)
    //        {
    //            WriteLog_DBandEvent(" Processes error starting service <<innerexception>>" + ex.InnerException + " <<message>> " + ex.Message + " <<stack>>" + ex.StackTrace);
    //        }
    //    }
    //    public static IList<FilesProcessed_GridView> GetLatestFilesProcessed()
    //    {
    //        if (currentBatchFilesList == null || currentBatchFilesList.Count == 0)
    //            return null;


    //        return currentBatchFilesList.Select(u => new FilesProcessed_GridView
    //        {
    //            SubscriptionID = u.contentID,
    //            FileName = u.fileName,
    //            Title = u.title,
    //            Category = u.category,
    //            parsed = u.parsed,
    //            uploaded = u.uploaded,
    //            error = u.error
    //        }).ToList();
    //    }

    //    public static int getBacthID()
    //    {
    //        if (currentBatch == null)
    //            return 0;
    //        return currentBatch.Batch_Number;
    //    }

    //    public static void ForceFullyCheck_AppData()
    //    {
    //        ApplicationData.LoadData();
    //    }

    //    #region Batch Functions

    //    private static void MakeBatch()
    //    {
    //        if (!System.IO.Directory.Exists(ApplicationData.serviceSettings.folderpath))
    //            ApplicationData.LoadData();

    //        else
    //            throw new Exception("Folder path not found when making batch");


            
    //        // if(fold_path)
            



    //        currentBatch = new Batch();
    //        currentBatch.folderpath = ApplicationData.serviceSettings.folderpath;
    //        currentBatch.fileProcessed = 0;
    //        currentBatch.filesFailed = 0;
    //        DBCallsManager.InsertNewBatch(currentBatch);
    //        new_Files = false;

    //        while (!new_Files)
    //        {
    //            makeListofFiles();
    //            if (!new_Files)
    //            {
    //                // insert state
    //                SetState_waitingforFiles(GetServiceState_Object(" Waiting for new Files", false));

    //                //write Logs
    //                WriteLog_DBandEvent(" Waiting for new Files");

    //                ThreadSleep();
    //            }
    //        }
    //    }

    //    private static void makeListofFiles()
    //    {
    //        currentBatchFilesList = new List<FilesProcessed>();
    //        List<FilesProcessed> lstOLDProcessed = DBCallsManager.GetAllPreviouslyFilesProcessed() as List<FilesProcessed>;

    //        //@"C:\Users\hsiddique\Desktop\Projects Data\EnableVue\files and data"
    //        foreach (string file in Directory.EnumerateFiles(ApplicationData.serviceSettings.folderpath, "*.*",
    //                              SearchOption.AllDirectories)
    //                              .Where(s => s.ToLower().EndsWith(".doc") || s.ToLower().EndsWith(".docx")))
    //        {


    //            string fileName = file.Replace(ApplicationData.serviceSettings.folderpath, "").Replace("\\", "").Replace("/", "");
    //            int index = lstOLDProcessed.FindIndex(s => s.fileName.Equals(fileName));

    //            if (index < 0) // file not found 
    //            {
    //                FilesProcessed objFile = new FilesProcessed();
    //                objFile.fileName = fileName.Replace("\\", "").Replace("/", "");
    //                objFile.batchNumber = currentBatch.Batch_Number;
    //                objFile.parsed = false;
    //                objFile.contentID = objFile.fileName.Substring(0, objFile.fileName.IndexOf("_"));

    //                currentBatchFilesList.Add(objFile);
    //            }
    //        }


    //        if (currentBatchFilesList.Count > 0)
    //        {

    //            WriteLog_DBandEvent(" " + currentBatchFilesList.Count.ToString() + " New Files");
    //            new_Files = true;

    //            //insert all files
    //            DBCallsManager.insertBatchedFiles(currentBatchFilesList);
    //        }

    //    }

    //    #endregion

    //    #region Parsing Steps

    //    private static void ParseAndUPload_CurrentBatchFiles()
    //    {
    //        currentBatch.startTime = DateTime.Now;
    //        foreach (var objFile in currentBatchFilesList)
    //        {



    //            try
    //            {
    //                // notify log for event start parsing
    //                WriteLog_DBandEvent("Started Processing File : " + objFile.fileName);
    //                SetState_processingFile(GetServiceState_Object("Started Processing File : " + objFile.fileName, true, objFile.Id));


    //                //start parsing
    //                #region Parsing
    //                using (DocX document = DocX.Load(currentBatch.folderpath + "\\" + objFile.fileName))
    //                {
    //                    List<Novacode.Paragraph> lstParas = document.Paragraphs;

    //                    //  0 for title 
    //                    //count -1 for tags
    //                    //count -2 for category
    //                    //count -3 for source
    //                    //  from 1 to count-4  all is part of content

    //                    int count = lstParas.Count;

    //                    objFile.title = lstParas[0].Text;
    //                    objFile.author = document.CoreProperties["dc:creator"];


    //                    Novacode.Paragraph categpara = lstParas[count - 2];
    //                    Novacode.Paragraph srcpara = lstParas[count - 3];

    //                    objFile.category = ReturnRemovedkeywordText(categpara, "Category");
    //                    objFile.source = ReturnRemovedkeywordText(srcpara, "Source");

    //                    if (srcpara.Hyperlinks.Count > 0)
    //                    {
    //                        foreach (var HyperLnk in srcpara.Hyperlinks)
    //                        {
    //                            objFile.source = objFile.source.Replace(HyperLnk.Text, "<a href=\"" + HyperLnk.Uri.AbsoluteUri + "\">" + HyperLnk.Text + "</a>");
    //                        }
    //                    }

    //                    string content = "";

    //                    bool isListItem = false;
    //                    bool isNumberedList = false;
    //                    bool isUnOrderedList = false;

    //                    for (int i = 1; i < (count - 3); i++)
    //                    {
    //                        Novacode.Paragraph localpara = lstParas[i];
    //                        string text = localpara.Text;

    //                        #region List Items
    //                        if (localpara.IsListItem && !isListItem)
    //                        {
    //                            isListItem = true;
    //                            if (localpara.ListItemType.ToString() == "Numbered")
    //                            {
    //                                isNumberedList = true;
    //                                content = content + "<ol>";
    //                            }
    //                            else
    //                            {
    //                                isUnOrderedList = true;
    //                                content = content + "<ul>";
    //                            }
    //                        }
    //                        else if (isListItem && !localpara.IsListItem)
    //                        {
    //                            if (isNumberedList)
    //                            {
    //                                content = content + "</ol>";
    //                            }
    //                            else
    //                            {
    //                                content = content + "</ul>";
    //                            }

    //                            isNumberedList = false;
    //                            isUnOrderedList = false;
    //                            isListItem = false;
    //                        }
    //                        #endregion

    //                        #region Bold Italic and Underline Tags
    //                        int added_tags = 0;
    //                        foreach (var magicprt in localpara.MagicText)
    //                        {
    //                            if (magicprt.formatting.Bold || magicprt.formatting.Italic || magicprt.formatting.UnderlineStyle.ToString() != "none")
    //                            {
    //                                string start = text.Substring(0, magicprt.index + added_tags);
    //                                string middle = "";
    //                                string end = text.Substring(magicprt.index + magicprt.text.Length + added_tags);
    //                                if (magicprt.formatting.Bold)
    //                                {
    //                                    middle = "<b>" + magicprt.text + "</b>";
    //                                }
    //                                else if (magicprt.formatting.Italic)
    //                                {
    //                                    middle = "<i>" + magicprt.text + "</i>";
    //                                }
    //                                else if (magicprt.formatting.UnderlineStyle.ToString() != "none")
    //                                {
    //                                    middle = "<u>" + magicprt.text + "</u>";
    //                                }
    //                                text = start + middle + end;
    //                                added_tags = added_tags + 7;
    //                            }
    //                        }
    //                        text = text.Replace("</b><b>", "").Replace("</u><u>", "").Replace("</i><i>", "");
    //                        #endregion

    //                        #region Content Hyperlinks
    //                        if (localpara.Hyperlinks.Count > 0)
    //                        {
    //                            foreach (var HyperLnk in localpara.Hyperlinks)
    //                            {
    //                                text = text.Replace(HyperLnk.Text, "<a href=\"" + HyperLnk.Uri.AbsoluteUri + "\">" + HyperLnk.Text + "</a>");

    //                                //category.Replace(HyperLnk.
    //                            }
    //                        }
    //                        #endregion

    //                        if (!localpara.IsListItem) // if its not list item
    //                            content = content + "<p>" + text + "<p>" + System.Environment.NewLine;
    //                        else // for list items
    //                            content = content + "<li>" + text + "</li>" + System.Environment.NewLine;

    //                    }


    //                    objFile.contentData1 = content;
    //                    if (content.Length > 3999)
    //                    {
    //                        objFile.contentData1 = content.Substring(0, 4000);
    //                        objFile.contentData2 = content.Substring(4000);
    //                    }

    //                    objFile.tag = "parse process completed @ " + DateTime.Now.ToString();

    //                }
    //                #endregion


    //                #region Smart Quotes
    //                objFile.category = objFile.category.Replace('\u201b', '\'')
    //                         .Replace('\u201c', '\"')
    //                         .Replace('\u201d', '\"')
    //                         .Replace('\u201e', '\"');

    //                objFile.contentData1 = objFile.contentData1.Replace('\u201b', '\'')
    //                                 .Replace('\u201c', '\"')
    //                                 .Replace('\u201d', '\"')
    //                                 .Replace('\u201e', '\"');
    //                if (objFile.contentData2 != null)
    //                {
    //                    objFile.contentData2 = objFile.contentData2.Replace('\u201b', '\'')
    //                                     .Replace('\u201c', '\"')
    //                                     .Replace('\u201d', '\"')
    //                                     .Replace('\u201e', '\"');
    //                }

    //                objFile.source = objFile.source.Replace('\u201b', '\'')
    //                                 .Replace('\u201c', '\"')
    //                                 .Replace('\u201d', '\"')
    //                                 .Replace('\u201e', '\"');

    //                objFile.title = objFile.title.Replace('\u201b', '\'')
    //                                 .Replace('\u201c', '\"')
    //                                 .Replace('\u201d', '\"')
    //                                 .Replace('\u201e', '\"');

    //                #endregion
    //                objFile.parsed = true;
    //                WriteLog_DBandEvent("updating File : " + objFile.fileName + " parsing complete with smart quotes.");
    //                //updateDocument to DB
    //                DBCallsManager.updateBatch_FileProcessed(objFile);


    //                //upload
    //                if (UploadCurrentBatch_File(objFile))
    //                {
    //                    WriteLog_DBandEvent("Uploading of Processed File : " + objFile.fileName);
    //                    //when done increase acount and persist to DB
    //                    objFile.uploaded = true;
    //                    currentBatch.fileProcessed++;
    //                }
    //                else
    //                {
    //                    objFile.error = true;
    //                    //when done increase acount and persist to DB
    //                    currentBatch.filesFailed++;
    //                }

    //                if (currentBatchFilesList.Count == currentBatch.filesFailed + currentBatch.fileProcessed)
    //                {
    //                    currentBatch.endTime = DateTime.Now;
    //                }
    //                DBCallsManager.updateBatchObject(currentBatch);
    //                WriteLog_DBandEvent("Processing completed File : " + objFile.fileName);

    //            }
    //            catch (Exception ex)
    //            {
    //                currentBatch.filesFailed++;
    //            }

    //        }


    //    }

    //    #endregion

    //    #region Upload Files

    //    private static bool UploadCurrentBatch_File(FilesProcessed objFile)
    //    {
    //        try
    //        {
    //            string content = FileToXML(objFile); ;
    //            string response = ApplicationData.UploadContent(content);


    //            if (response.Contains("201"))
    //            {
    //                WriteLog_DBandEvent("Upload success File : " + objFile.fileName);
    //                return true;
    //            }
    //            else
    //            {
    //                WriteLog_DBandEvent("Upload Failure File : " + objFile.fileName + ".  Error detail " + response);
    //                return false;
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            WriteLog_DBandEvent("Upload Failure File : " + objFile.fileName + ".  Exception occured [ " + ex.Message + " ]");
    //            return false;
    //            //Console.WriteLine(ex.Message.ToString());

    //        }
    //    }

    //    private static string FileToXML(FilesProcessed objFile)
    //    {



    //        String contentId = objFile.fileName.Substring(0, objFile.fileName.IndexOf('_'));

    //        var t = "http://schemas.datacontract.org/2004/07/Model";
    //        string txt = "<Content xmlns=\"" + t + "\">" +
    //                  "<AuthorName>" + objFile.author + "</AuthorName>" +
    //                  "<Category>" + HttpUtility.HtmlEncode(objFile.category) + "</Category>" +
    //                  "<Contentdetail>" + HttpUtility.HtmlEncode(objFile.contentData1 + objFile.contentData2) + "</Contentdetail>" +
    //                  "<Source>" + HttpUtility.HtmlEncode(objFile.source) + "</Source>" +
    //                  "<SubscriptionId>" + objFile.contentID + "</SubscriptionId>" +
    //                  "<Title>" + HttpUtility.HtmlEncode(objFile.title) + "</Title>" +
    //                  "</Content>";

    //        return txt;

    //    }

    //    #endregion

    //    #region ServiceStates Functions

    //    #region ServiceStates Create Methods

    //    private static ServiceState GetServiceState_Object()
    //    {
    //        ServiceState objServ = new ServiceState();
    //        objServ.isrunning = true;
    //        objServ.processignbatch = false;
    //        objServ.waitingforfiles = false;

    //        objServ.currentState = "undefined";



    //        return objServ;
    //    }

    //    private static ServiceState GetServiceState_Object(string currentstate, bool isbatchProcessing, int fileID = 0)
    //    {
    //        ServiceState objServ = new ServiceState();
    //        objServ.isrunning = true;
    //        objServ.processignbatch = isbatchProcessing;
    //        objServ.waitingforfiles = false;
    //        if (currentBatch == null)
    //            objServ.batchId = -1;
    //        else
    //            objServ.batchId = currentBatch.Batch_Number;

    //        objServ.currentState = currentstate;

    //        if (fileID > 0)
    //        {
    //            objServ.fileid = fileID;
    //        }

    //        return objServ;
    //    }

    //    #endregion

    //    private static void SetState_processingBatch(ServiceState objState)
    //    {
    //        objState.processignbatch = true;
    //        DBCallsManager.InsertServiceState(objState);
    //    }

    //    private static void SetState_processingBatchwithID(ServiceState objState)
    //    {
    //        objState.processignbatch = true;
    //        objState.batchId = currentBatch.Batch_Number;
    //        DBCallsManager.InsertServiceState(objState);
    //    }

    //    private static void SetState_processingFile(ServiceState objState)
    //    {
    //        if (objState.fileid > 0 && objState.batchId > 0)
    //            DBCallsManager.InsertServiceState(objState);
    //        else
    //            WriteLog_DBandEvent("method processing_file with missing values of File or batch");
    //    }

    //    private static void SetState_waitingforFiles(ServiceState objState)
    //    {
    //        objState.waitingforfiles = true;
    //        if (objState.batchId > 0)
    //            DBCallsManager.InsertServiceState(objState);
    //        else
    //            WriteLog_DBandEvent("method waiting_for_files with missing value of batch");
    //    }

    //    private static void SetState_Halted_NotLoggedIn(ServiceState objState)
    //    {
    //        objState.isHalted = true;
    //        objState.isNotLoggedIn = true;

    //        DBCallsManager.InsertServiceState(objState);

    //    }

    //    private static void SetState_Halted_FolderPathNotCorrect(ServiceState objState)
    //    {
    //        objState.isHalted = true;
    //        objState.isNotFolderPathCorrect = true;

    //        DBCallsManager.InsertServiceState(objState);

    //    }

    //    private static void SetState_Halted_WebURLNotWorking(ServiceState objState)
    //    {
    //        objState.isHalted = true;
    //        objState.isNotWebURLWorking = true;

    //        DBCallsManager.InsertServiceState(objState);

    //    }
    //    #endregion

    //    #region Usefull Funtions




    //    private static string ReturnRemovedkeywordText(Novacode.Paragraph para, string keyword)
    //    {
    //        char[] arr = para.Text.Trim().ToCharArray();
    //        int length = keyword.Length;
    //        if (arr[length] == ':')
    //        {
    //            length = length + 1;
    //        }
    //        else if (arr[length + 1] == ':')
    //        {
    //            length = length + 2;
    //        }

    //        return para.Text.Substring(length).Trim();
    //    }

    //    private static bool CheckAppDataALLtrue()
    //    {
    //        return (AppData.folderpathWokring && AppData.isLoggedIn && AppData.webUrlWorking);
    //    }

    //    public static void ThreadSleep(int value = 2000)
    //    {
    //        WriteLog_DBandEvent(" thread sleep");
    //        System.Threading.Thread.Sleep(value);
    //    }

    //    public static void WriteLog_DBandEvent(string value)
    //    {
    //        EventLog.WriteEntry("Application", " EnableVue App : " + value);
    //        DBCallsManager.InsertDetailed_DBLog(value);
    //    }

    //    private static void Make_SimpleLogInfoAndEmail()
    //    {
    //        // here it comes
    //        //string datetime = DateTime.Now.ToString("[MMM dd,yyyy hh24:mm]");
    //        string str = "<div style=\"width: 450px; height: 100px; padding: 1px 1px 6px 40px;\">"
    //             + "<h3>Batch Log</h3>"
    //             + "<table border=\"1\" cellpadding=\"1\" cellspacing=\"1\" style=\"padding: 1px 1px 1px 1px;\">"
    //             + "<tr><th>Batch Number</th><th>Start Time</th><th>Files Processed</th><th>Files Failed</th><th>End Time</th></tr>"
    //             + "<tr align=\"center\"><td>" + currentBatch.Batch_Number + "</td><td>" + currentBatch.startTime.ToString() + "</td>"
    //             + "<td>" + currentBatch.fileProcessed + "</td><td>" + currentBatch.filesFailed + "</td><td>"
    //                    + currentBatch.endTime.ToString() + "</td></tr>"
    //             + "</table></div><br/><br/><br/>Log Utility<br/>EnableVue Windows Application";

    //        // string value = " here is the detail ";

    //        ApplicationData.SendMailData("Batch Log " + DateTime.Now.ToString("[ MMM dd,yyyy  HH:mm ]"), str);
    //        DBCallsManager.InsertSimple_DBLog(str);
    //    }

    //    #endregion

    //}
}


