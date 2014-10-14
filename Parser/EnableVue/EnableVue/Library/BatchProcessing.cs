using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Novacode;
using Library;
using System.Web;
using System.Collections;
using Library.POCO;
using EnableVue;


namespace Library
{
    public class BatchProcessing : IDisposable
    {

        private const char tab = '\u0009';

        private List<ContentDocument> lstDocs;
        private int _currentProcessingFileNumber = 0;
        private Batch currentBatch;
        private List<FilesProcessed> currentBatchFilesList;

        public BatchProcessing(List<ContentDocument> lstContentDocs)
        {
            this.lstDocs = lstContentDocs;
            _currentProcessingFileNumber = 0;
        }

        public int CurrentProcessingFileNumber()
        {
            return _currentProcessingFileNumber;
        }


        public int Current_BatchNumber()
        {
            if (currentBatch == null)
            {
                return -1;
            }
            return currentBatch.Batch_Number;
        }

        public int FilesCount()
        {
            return lstDocs.Count;
        }

        public IList<FilesProcessed_GridView> GetLatestFilesProcessed()
        {
            if (currentBatchFilesList == null || currentBatchFilesList.Count == 0)
                return null;


            return currentBatchFilesList.Select(u => new FilesProcessed_GridView
            {
                SubscriptionID = u.contentID,
                FileName = u.fileName,
                Title = u.title,
                Category = u.category,
                parsed = u.parsed,
                uploaded = u.uploaded,
                error = u.error
            }).ToList();
        }

        public void MakeBatch()
        {

            currentBatch = new Batch();
            currentBatch.folderpath = ApplicationData.serviceSettings.folderpath;
            currentBatch.fileProcessed = 0;
            currentBatch.filesFailed = 0;

            DBCallsManager.InsertNewBatch(currentBatch);

            GenerateProcessingFiles();

        }

        private void GenerateProcessingFiles()
        {
            currentBatchFilesList = new List<FilesProcessed>();

            foreach (ContentDocument contentFile in lstDocs)
            {
                FilesProcessed objFile = new FilesProcessed();
                objFile.fileName = contentFile.fileName;
                objFile.batchNumber = currentBatch.Batch_Number;
                objFile.parsed = false;

                string[] str_arr = objFile.fileName.Split('_');

                int subscription_ID = int.Parse(str_arr[0]);
                try
                {
                    int SubscriptionID_2 = int.Parse(str_arr[1]);
                    objFile.contentID = subscription_ID.ToString() + "_" + SubscriptionID_2.ToString();
                }
                catch
                {
                    objFile.contentID = subscription_ID.ToString();
                }






                currentBatchFilesList.Add(objFile);
            }

            //insert all files
            DBCallsManager.insertBatchedFiles(currentBatchFilesList);

        }

        public void ParseNextDocument()
        {

            var objFile = currentBatchFilesList[_currentProcessingFileNumber];
            try
            {
                if (_currentProcessingFileNumber == 0)
                {
                    // batch is starting
                    currentBatch.startTime = DateTime.Now;
                }

                Parse_FILE_USING_NovaCode(objFile);
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("file contains corrupted data"))
                {
                    objFile.tag = "File cannot be parsed. Try saving it again as 2007(.Docx) format, also disable 'Track Changes'.";
                }
                //   currentBatch.filesFailed++;
            }

            _currentProcessingFileNumber++;

            //if (_currentProcessingFileNumber == FilesCount())
            //{
            //    //Batch Complete
            //    currentBatch.endTime = DateTime.Now;
            //}




        }
        public void resetCounter()
        {
            _currentProcessingFileNumber = 0;
        }

        public void UPload_NextDocument()
        {

            var objFile = currentBatchFilesList[_currentProcessingFileNumber];
            //try
            //{
            if (_currentProcessingFileNumber == 0)
            {
                // batch is starting
                currentBatch.startTime = DateTime.Now;
            }

            uploadFile_toWEB(objFile);
            //    }
            //catch (Exception ex)
            //{
            //    currentBatch.filesFailed++;
            //}

            _currentProcessingFileNumber++;

            if (_currentProcessingFileNumber == FilesCount())
            {
                //Batch Complete
                currentBatch.endTime = DateTime.Now;
            }

        }

        private void uploadFile_toWEB(FilesProcessed objFile)
        {
            //upload
            if (objFile.parsed == true && UploadCurrentBatch_File(objFile))
            {
                UtilityClass.WriteLog_DBandEvent("Uploading of Processed File : " + objFile.fileName);
                //when done increase acount and persist to DB
                objFile.uploaded = true;
                currentBatch.fileProcessed++;
                objFile.tag = "Upload Successfull";
            }
            else
            {

                objFile.error = true;
                //when done increase acount and persist to DB
                currentBatch.filesFailed++;
                //if (!objFile.parsed)
                //{
                //    objFile.tag = "Upload Failed Reason (Not Parsed)";
                //}
            }

            if (currentBatchFilesList.Count == currentBatch.filesFailed + currentBatch.fileProcessed)
            {
                currentBatch.endTime = DateTime.Now;
            }
            DBCallsManager.updateBatchObject(currentBatch);
            UtilityClass.WriteLog_DBandEvent("Processing completed File : " + objFile.fileName);
        }

        #region UPload Methods



        private bool UploadCurrentBatch_File(FilesProcessed objFile)
        {
            try
            {
                string content = FileToXML(objFile); ;
                string response = ApplicationData.UploadContent(content);
                int count = (UtilityClass.MAX_FILE_COUNT > 0) ? UtilityClass.MAX_FILE_COUNT : 1;
                // UtilityClass.createHTMLPage(objFile, ((currentBatch.Batch_Number - 1) * count) + _currentProcessingFileNumber + 1);
                if (response.Contains("201"))
                {

                    UtilityClass.WriteLog_DBandEvent("Upload success File : " + objFile.fileName);
                    return true;
                }
                else
                {
                    objFile.tag = "Upload Failed Reason (" + response + ")";
                    UtilityClass.WriteLog_DBandEvent("Upload Failure File : " + objFile.fileName + ".  Error detail " + response);
                    return false;
                }
            }
            catch (Exception ex)
            {
                objFile.tag = "Upload Failed Reason (EXCEPTION : " + ex.Message + ")";
                UtilityClass.WriteLog_DBandEvent("Upload Failure File : " + objFile.fileName + ".  Exception occured [ " + ex.Message + " ]");
                return false;
                //Console.WriteLine(ex.Message.ToString());

            }
        }

        private string FileToXML(FilesProcessed objFile)
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

        #region Parse Methods
        private void Parse_FILE_USING_NovaCode(FilesProcessed objFile)
        {
            objFile.parsed = false;
            objFile.tag = "";
            // notify log for event start parsing
            UtilityClass.WriteLog_DBandEvent("Started Processing File : " + objFile.fileName);
            //SetState_processingFile(GetServiceState_Object("Started Processing File : " + objFile.fileName, true, objFile.Id));

            //start parsing
            #region Parsing
            using (DocX document = DocX.Load(UtilityClass.NewDirectoryPath() + "\\" + objFile.fileName))
            {
                List<Novacode.Paragraph> lstParas = null;
                try
                {
                    lstParas = document.Paragraphs;
                }
                catch
                {
                    AddExceptionDetail(ref objFile, "reading data from file.");
                }
                //  0 for title 
                //count -1 for tags
                //count -2 for category
                //count -3 for source
                //  from 1 to count-4  all is part of content

                int count = lstParas.Count;
                int content_Start_Para = 0;
                #region Title and Author

                while (lstParas[content_Start_Para].Text.Trim(tab).Trim().Trim(tab) == "")
                {
                    content_Start_Para++;
                }
                objFile.title = lstParas[content_Start_Para].Text.Trim(tab).Trim().Trim(tab);
                content_Start_Para++;
                try
                {

                    objFile.author = document.CoreProperties["dc:creator"];

                    if (objFile.author.Length == 0)
                        objFile.author = "EnableVue";
                }
                catch
                {
                    objFile.author = "EnableVue";
                }
                #endregion

                #region Category and Source
                int content_last_para = 0;
                try
                {

                    Novacode.Paragraph categpara = lstParas[0];
                    Novacode.Paragraph srcpara = lstParas[0];

                    int selected_Para_count = 0;

                    for (int p = lstParas.Count - 1; p > content_Start_Para; p--)
                    {
                        if (lstParas[p].Text.Trim(tab).Trim().Trim(tab).Contains("Category"))
                        {
                            categpara = lstParas[p];
                            selected_Para_count++;
                        }
                        else if (lstParas[p].Text.Trim(tab).Trim().Trim(tab).Contains("Source"))
                        {
                            srcpara = lstParas[p];
                            selected_Para_count++;
                        }

                        if (selected_Para_count == 2)
                        {
                            content_last_para = p;
                            p = 2;
                        }

                    }

                    objFile.category = ReturnRemovedkeywordText(categpara, "Category");
                    objFile.source = ReturnRemovedkeywordText(srcpara, "Source");

                    if (srcpara.Hyperlinks.Count > 0)
                    {
                        foreach (var HyperLnk in srcpara.Hyperlinks)
                        {
                            if (HyperLnk.Text != null && HyperLnk.Text != "")
                                objFile.source = objFile.source.Replace(HyperLnk.Text, "<a href=\"" + HyperLnk.Uri.AbsoluteUri + "\" target=\"_blank\" >" + HyperLnk.Text + "</a>");
                        }
                    }
                }
                catch
                {
                    AddExceptionDetail(ref objFile, "Category and Source of File");
                }
                #endregion

                #region Paragraphs
                string content = "";

                bool isListItem = false;
                bool isNumberedList = false;
                bool isUnOrderedList = false;

                if (content_Start_Para == content_last_para || content_Start_Para + 1 == content_last_para)
                    AddExceptionDetail(ref objFile, "Content Paragraph not found between Title and Source");

                for (int i = content_Start_Para; i < content_last_para; i++)
                {
                    Novacode.Paragraph localpara = lstParas[i];
                    string text = localpara.Text.Trim(tab).Trim().Trim(tab);
                    if (text != "")
                    {
                        #region List Items
                        try
                        {
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

                        }
                        catch
                        {
                            AddExceptionDetail(ref objFile, "Content List Items in the File");

                        }
                        #endregion

                        #region Bold Italic and Underline Tags
                        try
                        {
                            int added_tags = 0;
                            if (localpara.MagicText != null)
                            {
                                foreach (var magicprt in localpara.MagicText)
                                {
                                    if (magicprt.formatting != null)
                                    {
                                        if (magicprt.formatting.Bold || magicprt.formatting.Italic || magicprt.formatting.UnderlineStyle.ToString() != "none")
                                        {
                                            string start = text.Substring(0, magicprt.index + added_tags);
                                            string middle = "";
                                            string end = text.Substring(magicprt.index + magicprt.text.Trim(tab).Trim().Trim(tab).Length + added_tags);
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
                                }
                                text = text.Replace("</b><b>", "").Replace("</u><u>", "").Replace("</i><i>", "");
                            }
                        }
                        catch
                        {
                            AddExceptionDetail(ref objFile, "Content Bold/Italic/Underline Words in the File");

                        }
                        #endregion

                        #region Content Hyperlinks
                        try
                        {
                            if (localpara.Hyperlinks.Count > 0)
                            {
                                foreach (var HyperLnk in localpara.Hyperlinks)
                                {
                                    if (HyperLnk.Text != null && HyperLnk.Text != "")
                                        text = text.Replace(HyperLnk.Text, "<a href=\"" + HyperLnk.Uri.AbsoluteUri + "\" target=\"_blank\"  >" + HyperLnk.Text + "</a>");
                                    //category.Replace(HyperLnk.
                                }
                            }
                        }
                        catch
                        {
                            AddExceptionDetail(ref objFile, "Content Hyperlink in the File");

                        }
                        #endregion

                        try
                        {
                            if (!localpara.IsListItem) // if its not list item
                                content = content + "<p>" + text + "<p>" + System.Environment.NewLine;
                            else // for list items
                                content = content + "<li>" + text + "</li>" + System.Environment.NewLine;
                        }
                        catch
                        {
                            AddExceptionDetail(ref objFile, "Content Ending para/list tags in the File");
                        }
                    }
                }
                #endregion
                try
                {
                    objFile.contentData1 = content;
                    if (content.Length > 3999)
                    {
                        objFile.contentData1 = content.Substring(0, 4000);
                        objFile.contentData2 = content.Substring(4000);
                    }
                }
                catch
                {
                    AddExceptionDetail(ref objFile, "Content Division for storage in DB");

                }
                //  objFile.tag = "parse process completed @ " + DateTime.Now.ToString();

            }
            #endregion


            #region Smart Quotes
            try
            {
                objFile.category = objFile.category.Replace('\u201b', '\'')
                         .Replace('\u201c', '\"')
                         .Replace('\u201d', '\"')
                         .Replace('\u201e', '\"');

                objFile.contentData1 = objFile.contentData1.Replace('\u201b', '\'')
                                 .Replace('\u201c', '\"')
                                 .Replace('\u201d', '\"')
                                 .Replace('\u201e', '\"');
                if (objFile.contentData2 != null)
                {
                    objFile.contentData2 = objFile.contentData2.Replace('\u201b', '\'')
                                     .Replace('\u201c', '\"')
                                     .Replace('\u201d', '\"')
                                     .Replace('\u201e', '\"');
                }

                objFile.source = objFile.source.Replace('\u201b', '\'')
                                 .Replace('\u201c', '\"')
                                 .Replace('\u201d', '\"')
                                 .Replace('\u201e', '\"');

                objFile.title = objFile.title.Replace('\u201b', '\'')
                                 .Replace('\u201c', '\"')
                                 .Replace('\u201d', '\"')
                                 .Replace('\u201e', '\"');
            }
            catch
            {
                AddExceptionDetail(ref objFile, " Removing smart quotes from Parsed Data.");
            }
            #endregion

            if (objFile.tag == "") objFile.parsed = true;
            else throw new Exception();

            UtilityClass.WriteLog_DBandEvent("updating File : " + objFile.fileName + " parsing complete with smart quotes.");
            //updateDocument to DB
            DBCallsManager.updateBatch_FileProcessed(objFile);
        }

        private string ReturnRemovedkeywordText(Novacode.Paragraph para, string keyword)
        {
            char[] arr = para.Text.Trim(tab).Trim().Trim(tab).ToCharArray();
            int length = keyword.Length;
            if (arr[length] == ':')
            {
                length = length + 1;
            }
            else if (arr[length + 1] == ':')
            {
                length = length + 2;
            }
            else
            {
                length = para.Text.IndexOf(keyword) + keyword.Length;
            }

            return para.Text.Trim(tab).Trim().Trim(tab).Substring(length).Trim();
        }

        private void AddExceptionDetail(ref FilesProcessed objFile, string txt)
        {

            if (objFile.tag == "")
            {
                objFile.tag = " Parsing Exception in " + txt;
            }
            //else if (!objFile.tag.Contains("Parsing Exception in " + txt))
            //{
            //    objFile.tag += ", Parsing Exception in " + txt;
            //}
            throw new Exception();
        }

        #endregion

        public void Make_SimpleLogInfoAndEmail()
        {
            UtilityClass.processList_and_CreateHTMLPAge(currentBatchFilesList);

            // here it comes
            //string datetime = DateTime.Now.ToString("[MMM dd,yyyy hh24:mm]");
            string str1 = "<div style=\"width: 450px; height: 100px; padding: 1px 1px 6px 40px;\">"
                 + "<h3>Batch Log</h3>"
                 + "<table border=\"1\" cellpadding=\"1\" cellspacing=\"1\" style=\"padding: 1px 1px 1px 1px;\">"
                 + "<tr><th>Batch Number</th><th>Total Files</th><th>Start Time</th><th>Successfully Uploaded</th><th>Upload Failed</th><th>End Time</th></tr>"
                 + "<tr align=\"center\"><td>" + currentBatch.Batch_Number + "</td><td>" + currentBatchFilesList.Count + "</td><td>" + currentBatch.startTime.ToString() + "</td>"
                 + "<td>" + currentBatch.fileProcessed + "</td><td>" + currentBatch.filesFailed + "</td><td>"
                 + currentBatch.endTime.ToString() + "</td></tr></table>";


            string str2 = "<br/><br /><h4>File Log Details</h4><table border=\"1\" cellpadding=\"1\" cellspacing=\"1\" style=\"padding: 1px 1px 1px 1px;font-family:Arial;font-size:8pt;\">"
            + "<tr><th style=\"width: 42%\">File Name</th><th style=\"width: 4%\">Parsed</th><th style=\"width: 4%\">Uploaded</th>"
            + "<th style=\"width: 4%\">Error</th><th style=\"width: 46%\">Comments</th></tr>";

            for (int i = 0; i < currentBatchFilesList.Count; i++)
            {

                str2 = str2 + "<tr><td>" + currentBatchFilesList[i].fileName + "</td>";
                if (currentBatchFilesList[i].parsed)
                {
                    str2 = str2 + "<td>Yes</td>";
                }
                else
                {
                    str2 = str2 + "<td>No</td>";
                }

                if (currentBatchFilesList[i].uploaded)
                {
                    str2 = str2 + "<td>Yes</td>";
                }
                else
                {
                    str2 = str2 + "<td>No</td>";
                }

                if (currentBatchFilesList[i].error)
                {
                    str2 = str2 + "<td>Yes</td>";
                }
                else
                {
                    str2 = str2 + "<td>No</td>";
                }



                str2 = str2 + "<td>" + currentBatchFilesList[i].tag + "</td></tr>";
            }

            str2 = str1 + str2 + "</table>"
                + "</div><br/><br/><br/>Log Utility<br/>EnableVue Windows Application";

            // string value = " here is the detail ";

            ApplicationData.SendMailData("Batch Log " + DateTime.Now.ToString("[ MMM dd,yyyy  HH:mm ]"), str2);
            DBCallsManager.InsertSimple_DBLog(str2);
        }

        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(lstDocs);
            lstDocs.Clear();
            currentBatch = null;
            currentBatchFilesList.Clear();
        }


    }
}
