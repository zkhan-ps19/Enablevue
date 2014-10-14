using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
//using Toolkit;
using System.Net.Mail;
using System.Net;
using System.Configuration;
using System.Security;

namespace EnableVue
{
    public partial class Service1 : ServiceBase
    {


        private ManualResetEvent _shutdownEvent = new ManualResetEvent(false);
        private Thread _thread;

        private static DateTime AppStopped;
        private static bool isStopped = false;
        private static DateTime lastEmail;
        private static bool isSentbefore = false;

        public bool normFlag;
        private string mode = "";

        public Service1()
        {
            InitializeComponent();
            // this.ServiceName = "EnableVue";


            //   Processes.WriteLog_DBandEvent(" service" + this.ServiceName + " says @ " + DateTime.Now.ToShortTimeString() + " started [" + mode + "]");

            //  BusinessLogic.ConnectionString = @"Data Source=EnableVue_DB.sdf";
        }

        protected override void OnStart(string[] args)
        {
            _thread = new Thread(WorkerThreadFunc);
            _thread.Name = "My Worker Thread";
            _thread.IsBackground = true;
            _thread.Start();

        }

        private void WorkerThreadFunc()
        {
            //if (normFlag)
            //{
            //    mode = " in Normal Mode";
            //}
            //else
            //{
            //    mode = " in Debug Mode";
            //}
         //   int counter = 0;
            // EV_Db.ServiceCallsManager.testing();
            while (!_shutdownEvent.WaitOne(0))
            {
                try
                {
                    Thread.Sleep(7000);
                    CheckiffApplicationRunning();
             //       writeLog(" service" + this.ServiceName + " [" + mode + "] says @ " + DateTime.Now.ToShortTimeString() + " counter value is " + counter);
                    // Replace the Sleep() call with the work you need to do
                    Thread.Sleep(7000);
                //    counter++;
                }
                catch (Exception ex)
                {
                    writeLog(ex.Message + ex.StackTrace + ex.InnerException);
                }
            }

        }

        protected override void OnStop()
        {
            _shutdownEvent.Set();
            if (!_thread.Join(3000))
            { // give the thread 3 seconds to stop
                _thread.Abort();
            }
        }



        public void onDebug()
        {
            OnStart(null);
        }

        private static void CheckiffApplicationRunning()
        {
            if (!IsApplicationRunning())
            {
                ////////////string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                //////////////Process.Start(path + "\\EnableVue.exe");
                ////////////String applicationName = path + "\\EnableVue.exe";
                //////////// launch the application
                ////////////ApplicationLoader.PROCESS_INFORMATION procInfo;
                ////////////ApplicationLoader.StartProcessAndBypassUAC(applicationName, out procInfo);

                sendMail();
        
            }
        }

        private static bool IsApplicationRunning(string name = "EnableVue")
        {
            // Thread.Sleep(10000);

            Process[] processlist = Process.GetProcessesByName(name);

            if (processlist.Length > 0)
            {
                if (isStopped) isStopped = false;
                return true;
            }

            if (isStopped == false)
            {
                AppStopped = DateTime.Now;
                isStopped = true;
            }

            return false;



            //Process[] processlist = Process.GetProcesses();

            //foreach (Process clsProcess in processlist)
            //{
            //    if (clsProcess.ProcessName.ToLower().Contains(name))
            //    {
            //        return true;
            //    }
            //}
            //return false;
        }

        private static void sendMail()
        {
            int minutes = 8;
            try
            {
                minutes = int.Parse(ConfigurationSettings.AppSettings["emailMinutes"]);
            }
            catch
            {
                minutes = 8;
            }


            if (isSentbefore)
            {
                TimeSpan t = DateTime.Now - lastEmail;
                if (t.Minutes < minutes)
                {
                    return;
                }
            }

            isSentbefore = true;
            lastEmail = DateTime.Now;

            TimeSpan x = DateTime.Now - AppStopped;
            sendMail("EnableVue Application is not Running since " + x.Minutes.ToString() + " minutes.");
        }



        public static void sendMail(string body)
        {
            string mailto = ConfigurationSettings.AppSettings["SendMailTo"];
            string smtpPassword = ConfigurationSettings.AppSettings["smtpPassword"];

            MailMessage mail = new MailMessage();
            mail.To.Add(mailto);
            
            string pcName = System.Environment.MachineName;
            
            mail.Subject = "[EnableVue Service] Desktop Application has stopped [" + pcName + "]";
            mail.Body = body;

            SmtpClient smtp = new SmtpClient();

            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(mail.From.Address, smtpPassword);

            //let her rip 
            smtp.Send(mail);
        }
        private static void writeLog(string value)
        {
            try
            {
                EventLog.WriteEntry("Application", " EnableVue_Service : " + value);
            }
            catch
            { }
        }


    }
}
