using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqProject
{
    public partial class Report5Form : Form
    {
        public Report5Form()
        {
            InitializeComponent();
        }

        private void Report5Form_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Back
            this.Close();
            ReportsForm rf = new ReportsForm();
            rf.Show();
        }
    }
}
