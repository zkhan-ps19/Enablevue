using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Reflection;
using System.IO;
using System.Net;
using Library.POCO;
using EnableVue;

namespace Library
{
    public static class DBCallsManager
    {

        /*   public IList<TblProjectInfoInfo> GetAllProjects()
           {
               using (Viva_schduler_EF.Data.viva_exam_schedulerEntities3 objEntities = new Viva_schduler_EF.Data.viva_exam_schedulerEntities3())
               {

                   return objEntities.tbl_project_info.Select(u => new TblProjectInfoInfo
                   {

                       ProjectId = u.project_id,
                       ProjectName = u.project_name,
                       SupervisorName = u.tbl_person_info.first_name + " " + (u.tbl_person_info.middle_name.Length > 0 ? u.tbl_person_info.middle_name + " " : " ") + " " + u.tbl_person_info.last_name


                   }).ToList();
               }

           }
           */

        //         connectionString="metadata=res://*/EV_DB.csdl|res://*/EV_DB.ssdl|res://*/EV_DB.msl;provider=System.Data.SqlServerCe.3.5;provider connection string=&quot;Data Source=|Data Directory|\EnableVue_DB.sdf&quot;"
        // private static string connectionString = "metadata=res://*/EV_DB.csdl|res://*/EV_DB.ssdl|res://*/EV_DB.msl;provider=System.Data.SqlServerCe.3.5;provider connection string=Data Source=|Data Directory|\\EnableVue_DB.sdf;";
        //public static void testing()
        //{
        //    EV_DBEntities objCtx = new EV_DBEntities();

        //    var obj = from fp in objCtx.FilesProcesseds
        //              select fp;

        //    FilesProcessed ob = obj.FirstOrDefault<FilesProcessed>();




        //    List<FilesProcessed> fpList2 = objCtx.FilesProcesseds.ToList<FilesProcessed>();
        //    if (fpList2.Count > 0)
        //    {

        //    }
        //    //IList<FilesProcessed> fpList = objCtx.FilesProcesseds.All(u=> u.Id > 0);
        //}

        // return the main and only Settings data for path and url
        public static Setting getMainSettings()
        {
            using (var objCtx = new EV_DBEntities())
            {
                Setting ob = objCtx.Settings.FirstOrDefault<Setting>();
                return ob;
            }
        }

        public static UserToken getlastUsedTokenOrUserData()
        {
            using (var objCtx = new EV_DBEntities())
            {
                UserToken ob = objCtx.UserTokens.FirstOrDefault<UserToken>();
                return ob;
            }
        }

        public static void InsertDetailed_DBLog(string Log_Data)
        {

            DetailedLOG obj = new DetailedLOG();
            obj.id = getDetailedLogCountNewID();
            obj.Log = Log_Data;

            if (Log_Data.Length > 500)
                obj.Log = Log_Data.Substring(0, 500);

            obj.time = DateTime.Now;

            //return;
            using (var ctx = new EV_DBEntities())
            {

                //ctx.AddToDetailedLOGs(obj);
                ctx.DetailedLOGs.AddObject(obj);
                ctx.SaveChanges();
            }

        }

        #region Generate New ID values

        public static int getDetailedLogCountNewID()
        {
            using (var objCtx = new EV_DBEntities())
            {
                return objCtx.DetailedLOGs.ToList<DetailedLOG>().Count + 1;
            }
        }

        public static int getSimpleLogCountnewID()
        {
            using (var objCtx = new EV_DBEntities())
            {
                return objCtx.SimpleLogs.ToList<SimpleLog>().Count + 1;
            }
        }

        public static int getServiceStateCountnewID()
        {
            using (var objCtx = new EV_DBEntities())
            {
                return objCtx.ServiceStates.ToList<ServiceState>().Count + 1;
            }
        }

        public static int getFilesProcessedCountnewID()
        {
            using (var objCtx = new EV_DBEntities())
            {
                return objCtx.FilesProcesseds.ToList<FilesProcessed>().Count + 1;
            }
        }


        public static int getBatchCountnewID()
        {
            using (var objCtx = new EV_DBEntities())
            {
                return objCtx.Batches.ToList<Batch>().Count + 1;
            }
        }

        #endregion

        public static void InsertSimple_DBLog(string Log_Data)
        {
            using (var ctx = new EV_DBEntities())
            {
                SimpleLog obj = new SimpleLog();
                obj.id = getSimpleLogCountnewID();
                obj.log = Log_Data;
                obj.time = DateTime.Now;

                ctx.SimpleLogs.AddObject(obj);
                ctx.SaveChanges();
            }

        }

        public static void InsertServiceState(ServiceState objServState)
        {
            objServState.time = DateTime.Now;
            objServState.Id = getServiceStateCountnewID();
            using (var ctx = new EV_DBEntities())
            {
                ctx.ServiceStates.AddObject(objServState);
                ctx.SaveChanges();
            }

        }

        public static void insertBatchedFiles(List<FilesProcessed> lstBatchFiles)
        {
            int id_count = getFilesProcessedCountnewID();
            foreach (var objFile in lstBatchFiles)
            {
                try
                {
                    objFile.Id = id_count;
                    using (var ctx = new EV_DBEntities())
                    {
                        ctx.FilesProcesseds.AddObject(objFile);
                        ctx.SaveChanges();
                    }
                    id_count++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + ex.StackTrace);

                }
            }
        }

        public static void updateBatch_FileProcessed(FilesProcessed obj)
        {
            try
            {
                using (EV_DBEntities newCtx = new EV_DBEntities())
                {
                    newCtx.FilesProcesseds.Attach(obj);
                    newCtx.ObjectStateManager.ChangeObjectState(obj, System.Data.EntityState.Modified);
                    newCtx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.InnerException + ex.StackTrace);
            }


        }

        public static IList<FilesProcessed> GetAllPreviouslyFilesProcessed()
        {
            using (var objCtx = new EV_DBEntities())
            {
                return objCtx.FilesProcesseds.ToList<FilesProcessed>();
            }
        }

        public static void InsertNewBatch(Batch obj)
        {


            obj.Batch_Number = getBatchCountnewID();

            using (var ctx = new EV_DBEntities())
            {
                ctx.Batches.AddObject(obj);
                ctx.SaveChanges();
            }
         //  return obj.Batch_Number;
        }

        public static void updateBatchObject(Batch obj)
        {
            using (EV_DBEntities newCtx = new EV_DBEntities())
            {
                newCtx.Batches.Attach(obj);
                newCtx.ObjectStateManager.ChangeObjectState(obj, System.Data.EntityState.Modified);
                newCtx.SaveChanges();
            }

        }

        public static IList<POCO.FilesProcessed_GridView> GetLatestFilesProcessed()
        {
            using (var objCtx = new EV_DBEntities())
            {
                int last_batch = DBCallsManager.getBatchCountnewID() - 1;
                // return objCtx.FilesProcesseds.Where(a => a.batchNumber == last_batch).ToList<FilesProcessed>();


                return objCtx.FilesProcesseds.Where(a => a.batchNumber == last_batch).Select(u => new FilesProcessed_GridView
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



        }

        public static IList<Log_GridView> GetSimpleLOG()
        {
            using (var objCtx = new EV_DBEntities())
            {
                return objCtx.SimpleLogs.OrderByDescending(a => a.time).Select(u => new Log_GridView
                {
                    Id = u.id,
                    Timestamp = u.time ?? DateTime.Now,
                    Log = u.log
                }).ToList();
            }
        }

        public static IList<Log_GridView> GetDetailedLOG()
        {
            using (var objCtx = new EV_DBEntities())
            {
                IList<Log_GridView> lst = objCtx.DetailedLOGs.OrderByDescending(a => a.time).Select(u => new Log_GridView
                {
                    Id = u.id,
                    Timestamp = u.time ?? DateTime.Now,
                    Log = u.Log
                }).ToList();
                return lst;
            }
        }

        public static void UpdateFolderPath(string folderpath)
        {
            ApplicationData.serviceSettings.folderpath = folderpath;
            //{
            //    addSettingsInfo("", folderpath);
            //    return;
            //}
            using (EV_DBEntities newCtx = new EV_DBEntities())
            {
                newCtx.Settings.Attach(ApplicationData.serviceSettings);
                newCtx.ObjectStateManager.ChangeObjectState(ApplicationData.serviceSettings, System.Data.EntityState.Modified);
                newCtx.SaveChanges();
            }
        }

        public static void UpdateWebURL(string webURL)
        {
            //if (SharedData.serviceSettings == null)
            //{
            //    addSettingsInfo(webURL);
            //    return;
            //}

            ApplicationData.serviceSettings.weburl = webURL;
            using (EV_DBEntities newCtx = new EV_DBEntities())
            {
                newCtx.Settings.Attach(ApplicationData.serviceSettings);
                newCtx.ObjectStateManager.ChangeObjectState(ApplicationData.serviceSettings, System.Data.EntityState.Modified);
                newCtx.SaveChanges();
            }
        }
        public static void addSettingsInfo(string webURL = "", string folderpath = "")
        {
            ApplicationData.serviceSettings = new Setting();

            ApplicationData.serviceSettings.weburl = webURL;
            ApplicationData.serviceSettings.folderpath = folderpath;
            ApplicationData.serviceSettings.id = 1;



            using (var ctx = new EV_DBEntities())
            {
                ctx.Settings.AddObject(ApplicationData.serviceSettings);
                ctx.SaveChanges();
            }
        }


        public static void UpdateUsernamePassword(string username, string password)
        {
            if (ApplicationData.serviceToken == null)
            {
                addUserToken(username, password);
                return;
            }

            ApplicationData.serviceToken.username = username;
            ApplicationData.serviceToken.password = password;
            using (EV_DBEntities newCtx = new EV_DBEntities())
            {
                newCtx.UserTokens.Attach(ApplicationData.serviceToken);
                newCtx.ObjectStateManager.ChangeObjectState(ApplicationData.serviceToken, System.Data.EntityState.Modified);
                newCtx.SaveChanges();
            }
        }

        public static void addUserToken(string username, string password)
        {
            ApplicationData.serviceToken = new UserToken();

            ApplicationData.serviceToken.username = username;
            ApplicationData.serviceToken.password = password;
            ApplicationData.serviceToken.user_id = 1;



            using (var ctx = new EV_DBEntities())
            {
                ctx.UserTokens.AddObject(ApplicationData.serviceToken);
                ctx.SaveChanges();
            }
        }

        public static void UpdateToken(string Token)
        {
            ApplicationData.serviceToken.token = Token;
            using (EV_DBEntities newCtx = new EV_DBEntities())
            {
                newCtx.UserTokens.Attach(ApplicationData.serviceToken);
                newCtx.ObjectStateManager.ChangeObjectState(ApplicationData.serviceToken, System.Data.EntityState.Modified);
                newCtx.SaveChanges();
            }

        }

        public static ServiceState Fetch_ServiceState()
        {

            using (EV_DBEntities newCtx = new EV_DBEntities())
            {
                try
                {
                    int id = DBCallsManager.getServiceStateCountnewID() - 1;
                    List<ServiceState> objList = newCtx.ServiceStates.Where(a => a.Id == id).ToList<ServiceState>();
                    return newCtx.ServiceStates.Where(a => a.Id == id).ToList<ServiceState>()[0];
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

    }
}
