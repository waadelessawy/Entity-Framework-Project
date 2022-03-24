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
    public partial class SalesInvoiceForm : Form
    {
        LinqProjectEntities myEnt;
        //quantity_of_sold qs;
        public SalesInvoiceForm()
        {
            InitializeComponent();
            myEnt = new LinqProjectEntities();
            //qs = new quantity_of_sold();
        }

        private void SalesInvoiceForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'linqProjectDataSet4.sales_invoice' table. You can move, or remove it, as needed.
            this.sales_invoiceTableAdapter.Fill(this.linqProjectDataSet4.sales_invoice);

            //onload

            var sales = from s in myEnt.sales_invoice select s;
            foreach (var s in sales)
            {
                comboBox1.Items.Add(s.no.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Back
            this.Close();
            Database db = new Database();
            db.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Display

            comboBox1.Items.Clear();
            dataGridView1.DataSource = myEnt.sales_invoice.ToList();
            //dataGridView2.DataSource = myEnt.quantity_of_sold.ToList();
            var si = from s in myEnt.sales_invoice select s;
            foreach (var s in si)
            {
                comboBox1.Items.Add(s.no.ToString());
            }



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //selecteditems

            int no = int.Parse(comboBox1.Text);
            var invoice = (from i in myEnt.sales_invoice
                           where i.no == no
                           select i).First();
            if (invoice != null)
            {
                textBox1.Text = invoice.no.ToString();
                textBox2.Text = invoice.customer_id.ToString();
                textBox3.Text = invoice.item_code.ToString();
                textBox4.Text = invoice.warehouse_id.ToString();
                DateTime t = invoice.date.Value;
                textBox5.Text = t.ToShortDateString().ToString();

            }
            //var quantity = (from q in myEnt.quantity_of_sold
            //                where q.sales_no == no
            //                select q).First();

            //if (quantity != null)
            //{
            //    textBox6.Text = quantity.quatity.ToString();


            //}


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //insert
            sales_invoice sales = new sales_invoice();
           
            sales.no = int.Parse(textBox1.Text);
            sales.customer_id = int.Parse(textBox2.Text);
            sales.item_code = int.Parse(textBox3.Text);
            sales.warehouse_id = int.Parse(textBox4.Text);
            sales.date = DateTime.Parse(textBox5.Text);
            myEnt.sales_invoice.Add(sales);

            //quantity_of_sold qs = new quantity_of_sold();
            //qs.quatity= int.Parse(textBox6.Text);
            //qs.item_code= int.Parse(textBox3.Text);
            //qs.sales_no = int.Parse(textBox1.Text);
            //myEnt.quantity_of_sold.Add(qs);
           
            myEnt.SaveChanges();
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text=textBox6.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //update
            int qua=0;
            int itemcode = 0;
            int salesno = 0;
            int no = int.Parse(textBox1.Text);
            var sales = (from s in myEnt.sales_invoice
                            where s.no == no
                            select s).First();
            if (sales != null)
            {
                sales.customer_id = int.Parse(textBox2.Text);
                sales.item_code = int.Parse(textBox3.Text);
                sales.warehouse_id = int.Parse(textBox4.Text);
                sales.date = DateTime.Parse(textBox5.Text);
              
                //qs.quatity = int.Parse(textBox6.Text);
                //qs.item_code = int.Parse(textBox3.Text);
                //qs.sales_no = int.Parse(textBox1.Text);
                qua = int.Parse(textBox6.Text);
                itemcode = int.Parse(textBox3.Text);
                salesno = int.Parse(textBox1.Text);
                myEnt.SaveChanges();
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = string.Empty;


            }

            //var quantity= (from q in myEnt.quantity_of_sold
            //               where q.item_code==itemcode
            //               where q.sales_no==salesno
            //               select q).FirstOrDefault();

            //if (quantity != null)
            //{
            //    myEnt.quantity_of_sold.Remove(quantity);
            //    myEnt.SaveChanges();
            //}
           
            //myEnt.quantity_of_sold.Add(qs);

            //myEnt.SaveChanges();

        }
    }
}