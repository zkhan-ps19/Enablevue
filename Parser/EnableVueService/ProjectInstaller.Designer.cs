namespace EnableVue
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.EVserviceInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.EVserviceIsntall = new System.ServiceProcess.ServiceInstaller();
            // 
            // EVserviceInstaller
            // 
            this.EVserviceInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.EVserviceInstaller.Password = null;
            this.EVserviceInstaller.Username = null;
            // 
            // EVserviceIsntall
            // 
            this.EVserviceIsntall.DisplayName = "EnableVue_Service";
            this.EVserviceIsntall.ServiceName = "EnableVue_Service";
            this.EVserviceIsntall.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.EVserviceInstaller,
            this.EVserviceIsntall});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller EVserviceInstaller;
        public System.ServiceProcess.ServiceInstaller EVserviceIsntall;
    }
}