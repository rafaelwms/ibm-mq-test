using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesteIbmMQ.Domain.Settings;

namespace TesteIbmMQ.WinFormApp.Forms
{
    public partial class MainForm : Form
    {

        public WinAppSettings AppSettings { get; set; }
        public MainForm()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
