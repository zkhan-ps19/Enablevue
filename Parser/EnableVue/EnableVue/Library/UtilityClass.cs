using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library;
using System.IO;
using Novacode;
using System.Diagnostics;
using EnableVue;



namespace Library
{
    // addded in ver 2.0 to deprecate the Processes class
    public static class UtilityClass
    {
        public const int MAX_FILE_COUNT = 15;

        public static List<ContentDocument> makeListofFiles()
        {
            List<ContentDocument> lstContDoc = new List<ContentDocument>();


            List<FilesProcessed> lstOLDProcessed = DBCallsManager.GetAllPreviouslyFilesProcessed() as List<FilesProcessed>;

            //@"C:\Users\hsiddique\Desktop\Projects Data\EnableVue\files and data"
            foreach (string file in Directory.EnumerateFiles(ApplicationData.serviceSettings.folderpath, "*.*",
                                  SearchOption.TopDirectoryOnly)
                                  .Where(s => s.ToLower().EndsWith(".doc") || s.ToLower().EndsWith(".docx")))
            {


                string fileName = file.Replace(ApplicationData.serviceSettings.folderpath, "").Replace("\\", "").Replace("/", "");
                int index = lstOLDProcessed.FindIndex(s => s.fileName.Equals(fileName));

                if (index < 0) // file not found 
                {
                    int readCount = 0;


                    while (readCount < 3)
                    {
                        try
                        {

                            //load the file and get it copied
                            ContentDocument obj = new ContentDocument(file, fileName.Replace("\\", "").Replace("/", ""));

                            //check if it is not open or being used
                            try
                            {
                                DocX doc = obj.DocumentDataOld;
                            }
                            catch (Exception exOLD)
                            {
                                if (exOLD.Message.Contains("The process cannot access the file") && exOLD.Message.Contains("because it is being used by another proces"))
                                {
                                    readCount = 3; // skip the reading process and fetch next file
                                    throw new Exception();
                                }
                            }


                            //put the name removing the directory path from it
                            obj.fileName = fileName.Replace("\\", "").Replace("/", "");

                            int SubscriptionID = int.Parse(obj.fileName.Substring(0, obj.fileName.IndexOf("_")));

                            //add it to the list
                            lstContDoc.Add(obj);
                            readCount = 3;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        readCount++;
                    }

                    if (lstContDoc.Count == MAX_FILE_COUNT)
                    {
                        return lstContDoc;
                    }
                }
            }

            return lstContDoc;
        }

        public static void ThreadSleep(int value = 2000)
        {
            WriteLog_DBandEvent(" thread sleep");
            System.Threading.Thread.Sleep(value);
        }

        public static void WriteLog_DBandEvent(string value)
        {
            EventLog.WriteEntry("Application", " EnableVue App : " + value);
            //     DBCallsManager.InsertDetailed_DBLog(value);
        }

        public static string CurrenDirectoryPath()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("EnableVue.exe", "");
        }

        public static string NewDirectoryPath()
        {
            return CurrenDirectoryPath() + "Copied\\";
        }

        public static void processList_and_CreateHTMLPAge(List<FilesProcessed> currentBatchFilesList)
        {
            string pcName = System.Environment.MachineName;
            if (pcName.ToLower() != "hsiddique") return;


            string name = CurrenDirectoryPath() + "htmlpages\\";
            if (!System.IO.Directory.Exists(name))
            {
                System.IO.Directory.CreateDirectory(name);
            }



            for (int i = 0; i < currentBatchFilesList.Count; i++)
            {
                using (FileStream fs = new FileStream(name + currentBatchFilesList[i].fileName + ".htm", FileMode.Create))
                {
                    using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                    {//"<a href=\"" + HyperLnk.Uri.AbsoluteUri + "\">" + HyperLnk.Text + "</a>"
                        w.WriteLine("<br/><b>FileName</b> : " + currentBatchFilesList[i].fileName);
                        w.WriteLine("<br/><b>Title</b> : " + currentBatchFilesList[i].title);
                        w.WriteLine("<br/><b>Content</b> : " + currentBatchFilesList[i].contentData1 + currentBatchFilesList[i].contentData2);
                        w.WriteLine("<br/><b>Source</b> : " + currentBatchFilesList[i].source);
                        w.WriteLine("<br/><b>Category</b> : " + currentBatchFilesList[i].category);
                        if (i + 1 < currentBatchFilesList.Count) w.WriteLine("<br/><br/><a href=\"" + (currentBatchFilesList[i + 1].fileName) + ".htm\"> next page </a>");
                    }
                }


            }

        }

        public static void createHTMLPage(FilesProcessed objFile, int id = 0)
        {
            string name = CurrenDirectoryPath() + "htmlpages\\";
            if (!System.IO.Directory.Exists(name))
            {
                System.IO.Directory.CreateDirectory(name);
            }

            if (id == -1)
            {
                name += objFile.contentID;
            }
            else
                name += id;


            using (FileStream fs = new FileStream(name + ".htm", FileMode.Create))
            {
                using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                {//"<a href=\"" + HyperLnk.Uri.AbsoluteUri + "\">" + HyperLnk.Text + "</a>"
                    w.WriteLine("<br/><b>FileName</b> : " + objFile.fileName);
                    w.WriteLine("<br/><b>Title</b> : " + objFile.title);
                    w.WriteLine("<br/><b>Content</b> : " + objFile.contentData1 + objFile.contentData2);
                    w.WriteLine("<br/><b>Source</b> : " + objFile.source);
                    w.WriteLine("<br/><b>Category</b> : " + objFile.category);
                    if (id != -1) w.WriteLine("<br/><br/><a href=\"" + (id + 1) + ".htm\"> next page </a>");
                }
            }
        }
    }

    public class ContentDocument : IDisposable
    {
        // removed in ver 1.2 coz of improving the memory management issue
        // private DocX _documentData;

        public DocX DocumentData
        {
            get { return DocX.Load(_newPath); }
        }

        public DocX DocumentDataOld
        {
            get { return DocX.Load(_oldPath); }
        }
        public string fileName;

        private string _oldPath;
        private string _newPath = UtilityClass.NewDirectoryPath();

        public ContentDocument(string oldPath, string Name)
        {
            try
            {
                if (!System.IO.Directory.Exists(_newPath))
                {
                    System.IO.Directory.CreateDirectory(_newPath);
                }
            }
            catch
            {
                System.IO.Directory.CreateDirectory(_newPath);
            }

            _oldPath = oldPath;
            _newPath = _newPath + Name;

            File.Delete(_newPath);
            File.Copy(_oldPath, _newPath);


        }

        void IDisposable.Dispose()
        {
            File.Delete(_newPath);
        }

    }



}
