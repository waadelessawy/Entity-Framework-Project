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
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            WarehouseReportForm wrf = new WarehouseReportForm();
            wrf.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Back
            this.Close();
            Home h = new Home();
            h.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Report2Form RF2 = new Report2Form();
            RF2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //ItemMovement
            this.Hide();
            Report3Form rf3 = new Report3Form();
            rf3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Report4Form rf = new Report4Form();
            rf.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Report5Form rf = new Report5Form();
            rf.Show();
        }
    }
}
