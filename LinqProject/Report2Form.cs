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
    public partial class Report2Form : Form
    {
        public Report2Form()
        {
            InitializeComponent();
        }

        private void Report2Form_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            //Back
            this.Close();
            ReportsForm rf = new ReportsForm();
            rf.Show();
        }
    }
}
