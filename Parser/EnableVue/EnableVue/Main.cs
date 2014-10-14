using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Threading;
using System.Diagnostics;
using Library.POCO;
using Library;
using Novacode;
using System.IO;



namespace EnableVue
{
    public partial class Main : Form
    {

        //private System.Windows.Forms.NotifyIcon notifyIcon1 = new NotifyIcon();


        #region variables for use

        private Thread _thread;
        public bool isSettingsWindowOpen = false;

        #region new Variables ver 1.1
        private bool is_batchReady = false;
        #endregion

        #endregion

        /// <summary>
        /// Check for last used information that worked .. 
        /// ...with the service
        /// retrieve the information from DB and get it ..
        /// ...loaded in memory
        /// </summary>


        public Main()
        {
            InitializeComponent();

            lbProcessing.Text = "Initializing Tasks Execution List";

            this.notifyIcon1.Icon = global::EnableVue.Properties.Resources.EnableVue_;
            notifyIcon1.BalloonTipText = "EnableVue App is running Minimized...";
            notifyIcon1.BalloonTipTitle = "EnableVue App";
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            pnlWaiting.Visible = false;

            //   setImageOnPictureBox();
            //Thread.Sleep(2000);
            // ApplicationData.performCompleteProcess_LoadandCheck();
            string htmlfolder = UtilityClass.CurrenDirectoryPath() + "htmlpages\\";
            if (System.IO.Directory.Exists(htmlfolder))
            {
                Array.ForEach(Directory.GetFiles(htmlfolder), File.Delete);
            }

            DBCallsManager.InsertSimple_DBLog("error");
            Configuration_timer.Enabled = true;
        }


        #region Timer and Thread

        private void processes_timer_Tick(object sender, EventArgs e)
        {

            if (!this.Enabled) return;
            lbProcessing.Text = "Processing ...";


            if (!ApplicationData.CheckAllFlags())
            {
                processes_timer.Enabled = false;
                lbProcessing.Text = "Configuration Error ... Check Settings form";
                Application.DoEvents();


                Configuration_timer.Enabled = true;
                return;
            }

            #region Step 1 - Check Service and Configuration Check

            Service_and_ConfigurationCheck();

            #endregion

            if (!_thread.IsAlive && !is_batchReady)
            {

                #region Step 2 - Check For New Files

                lbProcessing.Text = "Checking for New Files ...";
                List<ContentDocument> lstDocs = UtilityClass.makeListofFiles();
                #endregion

                if (lstDocs != null && lstDocs.Count > 0)
                {
                    pnlWaiting.Visible = false;
                    lbProcessing.Text = "Creating Batch... ";
                    #region Step 3- Make Batch & Start Thread

                    try
                    {
                        _thread.Start(lstDocs as Object);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message != null) //can also place actual message recieved 
                        {
                            _thread = new Thread(WorkerThreadFunc);
                            _thread.Name = "My Worker Thread";
                            _thread.IsBackground = true;
                            _thread.Start(lstDocs as Object);
                        }
                    }
                    // processes_timer.Enabled = false;
                    #endregion
                }
                else
                {
                    dataGridView1.DataSource = null;
                    pnlWaiting.Visible = true;
                    lbProcessing.Text = "Waiting ...";
                }

            }

            //else if (is_batchReady)
            //{
            //    #region Step 4 - Fill Grid
            //    lbProcessing.Text = "Parsing & Uploading... ";
            //    FillData();
            //    #endregion
            //}

        }

        private void WorkerThreadFunc(Object Data)
        {
            if (ApplicationData.CheckAllFlags())
            {
                try
                {
                    //  List<Library.ContentDocument> lst = Data as List<Library.ContentDocument>;
                    UpdatingGenericLabel(lbProcessing, "Starting Batch Processing");

                    Application.DoEvents();
                    Thread.Sleep(500);
                    Application.DoEvents();

                    using (BatchProcessing btchProcess = new BatchProcessing(Data as List<ContentDocument>))
                    {

                        UpdatingGenericLabel(lbProcessing, "Parsing Process Started");
                        Application.DoEvents();


                        btchProcess.MakeBatch();
                        UpdatingGenericLabel(lbBatch, "Current Batch # : " + (btchProcess.Current_BatchNumber()).ToString());
                        is_batchReady = true;
                        //Processes.Initial_Loading();

                        for (int i = 0; i < btchProcess.FilesCount(); i++)
                        {
                            try
                            {
                                // Processes.ExecuteProcesses();
                                UpdatingGenericLabel(lbProcessing, "Parsing  Document # " + (btchProcess.CurrentProcessingFileNumber() + 1).ToString());
                                Select_DataGridView_ROWbyIndex(btchProcess.CurrentProcessingFileNumber());
                                btchProcess.ParseNextDocument();
                            }
                            catch (Exception ex)
                            {
                                UtilityClass.WriteLog_DBandEvent("Error : " + ex.Message + "  Stack Trace " + ex.StackTrace);
                            }

                            UpdatingGridViewData(btchProcess.GetLatestFilesProcessed());
                            Application.DoEvents();
                        }

                        UpdatingGenericLabel(lbProcessing, "Parsing Process Completed");
                        Application.DoEvents();

                        Thread.Sleep(500);
                        btchProcess.resetCounter();
                        UpdatingGenericLabel(lbProcessing, "Initiating Upload Process");
                        Application.DoEvents();



                        for (int i = 0; i < btchProcess.FilesCount(); i++)
                        {
                            try
                            {
                                UpdatingGenericLabel(lbProcessing, "Uploading  Document # " + (btchProcess.CurrentProcessingFileNumber() + 1).ToString());
                                Select_DataGridView_ROWbyIndex(btchProcess.CurrentProcessingFileNumber());
                                btchProcess.UPload_NextDocument();
                            }
                            catch (Exception ex)
                            {
                                UtilityClass.WriteLog_DBandEvent("Error : " + ex.Message + "  Stack Trace " + ex.StackTrace);
                            }
                            UpdatingGridViewData(btchProcess.GetLatestFilesProcessed());
                            Application.DoEvents();
                        }

                        UpdatingGenericLabel(lbProcessing, "Upload Completed... Generating Log");
                        Application.DoEvents();

                        btchProcess.Make_SimpleLogInfoAndEmail();


                    }
                    UpdatingGenericLabel(lbProcessing, "Processing");
                }
                catch (Exception ex)
                {
                    UtilityClass.WriteLog_DBandEvent("Error : " + ex.Message + "  Stack Trace " + ex.StackTrace);
                }
            }
            is_batchReady = false;
            //string CopiedPath = System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("EnableVue.exe", "") + "Copied\\";
            Array.ForEach(Directory.GetFiles(UtilityClass.NewDirectoryPath()), File.Delete);
            //   _thread.Abort();
            //  processes_timer.Enabled = true;


            //these are being done in the else of process timer 
            UpdatingGridViewData(null);
            PanelViewShowMethod();
            UpdatingGenericLabel(lbProcessing, "Waiting ...");


        }

        private void Configuration_timer_Tick(object sender, EventArgs e)
        {
            if (!this.Enabled) return;

            Configuration_timer.Enabled = false;
            lbProcessing.Text = "Configuring Resources...";
            if (_thread == null)
            {
                _thread = new Thread(WorkerThreadFunc);
                _thread.Name = "My Worker Thread";
                _thread.IsBackground = true;
                //_thread.Start();

            }

            Application.DoEvents();
            ApplicationData.performSettingProcess_FolderPath_LoadandCheck();
            Application.DoEvents();
            ApplicationData.performSettingProcess_WebURL_LoadandCheck();
            Application.DoEvents();
            ApplicationData.performTokenProcess_LoadandCheck();
            Application.DoEvents();


            if (!ApplicationData.Is_FolderPath_correct())
            {
                lbProcessing.Text = "Folder path incorrect... assign new Folder path";
                showSettingsFormwithError(" FolderPath is incorrect.");
            }
            else if (!ApplicationData.is_WebURL_working)
            {
                lbProcessing.Text = "URL Incorrect ... waiting for correct URL";
                showSettingsFormwithError(" Web URL is incorrect.");
            }
            else if (!ApplicationData.is_Loggedin)
            {
                lbProcessing.Text = "Login Failure ... waiting for Credentials";
                showSettingsFormwithError(" Incorrect Username or Password.");

            }

            Configuration_timer.Enabled = true;


            if (ApplicationData.CheckAllFlags())
            {
                Configuration_timer.Enabled = false;
                processes_timer.Enabled = true;
            }

            // if (!Service_timer_Check.Enabled) Service_timer_Check.Enabled = true;
        }

        delegate void AsyncMethodDelegate();

        private void Service_and_ConfigurationCheck()
        {
            Application.DoEvents();
            ApplicationData.performSettingProcess_FolderPath_LoadandCheck();
            Application.DoEvents();
            ApplicationData.performSettingProcess_WebURL_LoadandCheck();
            Application.DoEvents();
            ApplicationData.performTokenProcess_LoadandCheck();
            Application.DoEvents();

            AsyncMethodDelegate dlgt = new AsyncMethodDelegate(this.check_Service);
            //string s;
            //int iExecThread;

            // Initiate the asynchronous call.
            IAsyncResult ar = dlgt.BeginInvoke(null, null);

            //check_Service();
        }

        #endregion

        #region Delegate Methods for Controls

        delegate void GridViewDelegate(IList<FilesProcessed_GridView> lstFile);

        private void UpdatingGridViewData(IList<FilesProcessed_GridView> lstFile)
        {
            if (this.dataGridView1.InvokeRequired)
                this.dataGridView1.Invoke(new GridViewDelegate(UpdatingGridViewData), new object[] { lstFile });
            else
                this.dataGridView1.DataSource = lstFile;

            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    row.HeaderCell.Value = row.Index + 1;
            //}

        }

        delegate void GridView_SelectROWbyIndex_Delegate(int index);

        private void Select_DataGridView_ROWbyIndex(int index)
        {
            if (this.dataGridView1.InvokeRequired)
                this.dataGridView1.Invoke(new GridView_SelectROWbyIndex_Delegate(Select_DataGridView_ROWbyIndex), new object[] { index });
            else
                if (dataGridView1.RowCount > index) this.dataGridView1.Rows[index].Selected = true;
        }

        delegate void GenericLabelDelegate(Label genlabel, string message);

        private void UpdatingGenericLabel(Label genlabel, string msg)
        {
            if (genlabel.InvokeRequired)
                genlabel.Invoke(new GenericLabelDelegate(UpdatingGenericLabel), new object[] { genlabel, msg });
            else
                genlabel.Text = msg;
        }


        delegate void PanelViewShow();

        private void PanelViewShowMethod()
        {
            if (this.pnlWaiting.InvokeRequired)
                this.pnlWaiting.Invoke(new PanelViewShow(PanelViewShowMethod));
            else
                this.pnlWaiting.Visible = true;

            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    row.HeaderCell.Value = row.Index + 1;
            //}

        }


        #endregion

        #region Service Check and Service State Methods

        private void check_Service()
        {

            int count = DBCallsManager.GetLatestFilesProcessed().Count;
            ServiceController ctl = ServiceController.GetServices()
                                       .FirstOrDefault(s => s.ServiceName == "EnableVue_Service");

            if (ctl == null)
            {
                //label1.Text = "Not Installed";
                UpdatingGenericLabel(label1, "Not Installed");
            }
            else
            {
                // label1.Text = ctl.Status.ToString();
                UpdatingGenericLabel(label1, ctl.Status.ToString());
                if (ctl.Status.ToString() == "Stopped")
                {
                    try
                    {
                        ctl.Start();
                    }
                    catch (Exception ex)
                    {
                        UpdatingGenericLabel(label1, "Error Starting Service");
                        UtilityClass.WriteLog_DBandEvent(" Error starting service <<innerexception>>" + ex.InnerException + " <<message>> " + ex.Message + " <<stack>>" + ex.StackTrace);
                        //ApplicationData.SendMailData("Enablvue Application Error", " error starting service <<innerexception>>" + ex.InnerException + " <<message>> " + ex.Message + " <<stack>>" + ex.StackTrace);
                    }
                }
            }
        }



        /// <summary>
        /// Old method from ver 1.0 
        /// Not being used any more
        /// </summary>
        //private void check_ServiceState()
        //{

        //    // ServiceState objServSt = ApplicationCallsManager.Fetch_ServiceState();

        //    if (Library.UtilityClass.is_halt)
        //    {
        //        lbProcessing.Text = "Processing Stopped";

        //        if (Library.UtilityClass.is_waitingforURL == true)
        //        {
        //            lbProcessing.Text = "URL Incorrect ... waiting for correct URL";
        //            showSettingsFormwithError(" Web URL is incorrect.");
        //        }
        //        else if (Library.UtilityClass.is_waitingforLogin == true)
        //        {
        //            lbProcessing.Text = "Login Failure ... waiting for Credentials";
        //            showSettingsFormwithError(" Incorrect Username or Password.");
        //        }
        //        else if (Library.UtilityClass.is_waitingForFolderpath == true)
        //        {
        //            lbProcessing.Text = "Folder path incorrect... assign new Folder path";
        //            showSettingsFormwithError(" FolderPath is incorrect.");
        //        }

        //    }
        //    else if (Processes.is_makingBatch)
        //    {
        //        if (Processes.new_Files)
        //        {
        //            lbProcessing.Text = "Creating Batch with files";
        //            pnlWaiting.Visible = false;
        //        }
        //        else
        //        {
        //            pnlWaiting.Visible = true;
        //            lbProcessing.Text = "Waiting ...";
        //        }
        //    }
        //    else if (Processes.is_ParsingUploading)
        //    {
        //        lbProcessing.Text = "Parsing and Uploading Files";
        //        pnlWaiting.Visible = false;
        //    }
        //    else if (Processes.is_sendingEmail)
        //    {
        //        lbProcessing.Text = " Making Batch Log and Sending Email";
        //        pnlWaiting.Visible = false;
        //    }


        //}

        #endregion

        #region DataGrid

        private void FillData()
        {
            //lbBatch.Text = "Current Batch # : " + (Library.Processes.getBacthID()).ToString();
            //dataGridView1.DataSource = Library.Processes.GetLatestFilesProcessed();
        }

        #endregion

        #region Menu buttons
        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(500);

                this.Hide();
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(500);

            this.Hide();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Settings frm = new Settings();
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            //frm.StartPosition = FormStartPosition.CenterParent;
            //frm.Show(this);

            ShowFORM((Form)frm);
        }

        private void viewLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logs frm = new Logs();
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            //frm.StartPosition = FormStartPosition.CenterParent;
            //frm.Show(this);

            ShowFORM((Form)frm);

        }

        private void aboutEnableVueAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutWindow frm = new AboutWindow();
            //frm.StartPosition = FormStartPosition.CenterParent;
            //frm.Show(this);
            ShowFORM((Form)frm);

        }
        private void showSettingsFormwithError(string errorMsg)
        {

            this.Show();
            this.WindowState = FormWindowState.Normal;

            Settings frm = new Settings();
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;

            ShowFORM(frm);

            frm.SetErrorLabel(errorMsg);
        }
        private void ShowFORM(Form frm)
        {
            if (this.Enabled == false) return;
            //frm.Location = new Point(this.Location.X + this.Width - 3 *
            //        frm.Width / 2, this.Location.Y + this.Height - 3 * frm.Height / 2);
            //frm.StartPosition = FormStartPosition.Manual;

            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(this.Location.X + (this.Width - frm.Width) / 2, this.Location.Y + (this.Height - frm.Height) / 2);

            frm.Show(this);
        }
        #endregion

        #region Settings Button, Form Resize, Close & NotifyIcon Click
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            WindowState = FormWindowState.Minimized;
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(500);

            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            settingsToolStripMenuItem_Click(null, null);
        }
        #endregion




        #region Depricated Methods

        #endregion



    }
}
