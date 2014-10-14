using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Net.Mail;
using System.Reflection;
using System.IO;
using System.Net;
using System.Security.Principal;
using Library;


namespace EnableVue
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1) System.Diagnostics.Process.GetCurrentProcess().Kill();
            try
            {
                Application.ThreadException += new ThreadExceptionEventHandler(Form1_UIThreadException);

                // Set the unhandled exception mode to force all Windows Forms errors to go through 
                // our handler.
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

                // Add the event handler for handling non-UI thread exceptions to the event. 
                AppDomain.CurrentDomain.UnhandledException +=
                    new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);


                if (args.Length == 0)
                {
                    WindowsPrincipal pricipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
                    bool hasAdministrativeRight = pricipal.IsInRole(WindowsBuiltInRole.Administrator);


                    if (!hasAdministrativeRight)
                    {

                        try
                        {
                            ProcessStartInfo prInfo = new ProcessStartInfo(Application.ExecutablePath);
                            prInfo.Arguments = "1";
                            prInfo.Verb = "runas";
                            Process.Start(prInfo);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        return;
                    }
                    else
                    {

                        //SharedData.sendMail("has admin rights");
                    }

                }


                // Handle the ApplicationExit event to know when the application is exiting.
              //  Application.ApplicationExit += new EventHandler(OnApplicationExit);
                //Application.Run(new Admin());

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Main form1 = new Main();
                ApplicationContext applicationContext = new ApplicationContext();
                applicationContext.MainForm = form1;


                Application.Run(applicationContext);
            }
            catch (Exception ex)
            {
                ApplicationData.sendExceptionEmail(ex, "[Application Exception] Application Start Exception");

            }
        }


        public static void Form1_UIThreadException(object sender, ThreadExceptionEventArgs t)
        {

            ApplicationData.sendExceptionEmail(t.Exception, "[Application Exception] Application Form Thread Exception");
            // Application.Exit();
            DialogResult result = DialogResult.Cancel;
            try
            {
                //result = ShowThreadExceptionDialog("Windows Forms Error", t.Exception);
                MessageBox.Show("Fatal Windows Forms Error",
                       "Fatal Windows Forms Error" + t.Exception, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                //MessageBox.Show("here");
            }
            catch (Exception x)
            {
                try
                {
                    MessageBox.Show("Fatal Windows Forms Error",
                        "Fatal Windows Forms Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                }
                finally
                {

                    Application.Exit();
                }
            }

            // Exits the program when the user clicks Abort. 
            if (result == DialogResult.Abort)
                Application.Exit();
        }

        public static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {

            try
            {
                Exception ex = (Exception)e.ExceptionObject;
                ApplicationData.sendExceptionEmail(ex,"[Application Exception] Unhandled Exception");
                string errorMsg = "An application error occurred. Please contact the adminstrator " +
                    "with the following information:\n\n";

                // Since we can't prevent the app from terminating, log this to the event log. 
                if (!EventLog.SourceExists("ThreadException"))
                {
                    EventLog.CreateEventSource("ThreadException", "Application");
                }

                // Create an EventLog instance and assign its source.
                EventLog myLog = new EventLog();
                myLog.Source = "ThreadException";
                myLog.WriteEntry(errorMsg + ex.Message + "\n\nStack Trace:\n" + ex.StackTrace);
            }
            catch (Exception exc)
            {
                try
                {
                    MessageBox.Show("Fatal Non-UI Error",
                        "Fatal Non-UI Error. Could not write the error to the event log. Reason: "
                        + exc.Message, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    ApplicationData.sendExceptionEmail(exc, "[Application Exception] Unhandled Exception");
                    Application.Exit();
                }
            }
        }
        private static void OnApplicationExit(object sender, EventArgs e)
        {
            // When the application is exiting, write the application data to the 
            // user file and close it.
            string txt = Application.StartupPath;
            
            try
            {
                // Ignore any errors that might occur while closing the file handle.
            
            }
            catch { }
        }


    }
}
