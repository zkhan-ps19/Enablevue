using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library;
using Library.POCO;

namespace EnableVue
{
    public partial class Logs : Form
    {
        public Logs()
        {
            InitializeComponent();

        }

        private void Logs_Load(object sender, EventArgs e)
        {
            this.Owner.Enabled = false;
            timer1_Tick(null,null);
            timer1_Tick(null, null);

            timer1.Enabled = true;
        }

        private void Logs_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Enabled = true;
            timer1.Enabled = false;
        }
        private bool turn = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (turn)
            {
                dtgrdSimpleLog.DataSource = DBCallsManager.GetSimpleLOG();
            }
            else
            {
                dtgrdDetailedLog.DataSource = DBCallsManager.GetDetailedLOG();
            }
            turn = !turn;

        }
    }
}
