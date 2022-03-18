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
    public partial class Database : Form
    {
        public Database()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Warehouse
            this.Hide();
            WarehouseForm wf = new WarehouseForm();
            wf.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //item
            this.Hide();
            itemForm i = new itemForm();
            i.Show();
          
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Back
            this.Close();
            Home h = new Home();
            h.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //sales invoice
            this.Hide();
            SalesInvoiceForm sif = new SalesInvoiceForm();
            sif.Show();
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Subblier
            this.Hide();
            SupplierForm sf = new SupplierForm();
            sf.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Customer
            this.Hide();
            CustomerForm cf = new CustomerForm();
            cf.Show();

        }
    }
}
