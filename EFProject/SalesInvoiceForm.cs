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

        public SalesInvoiceForm()
        {
            InitializeComponent();
            myEnt = new LinqProjectEntities();
        
        }

        private void SalesInvoiceForm_Load(object sender, EventArgs e)
        {
            //onload
            var invoice = from p in myEnt.sales_invoice select p;
            foreach (var i in invoice)
            {
                dataGridView1.Rows.Add(i.no, i.customer_id, i.item_code,  i.warehouse_id,i.date,i.quantity);
            }

            var sales = from s in myEnt.sales_invoice select s;
            foreach (var s in sales)
            {
                comboBox1.Items.Add(s.no.ToString());
            }

            var customer = from s in myEnt.customers select s;
            foreach (var c in customer)
            {
                comboBox2.Items.Add(c.name.ToString());
            }
            var item = from i in myEnt.items select i;
            foreach (var i in item)
            {
                comboBox3.Items.Add(i.name.ToString());
            }
            var house = from h in myEnt.warehouses select h;
            foreach (var h in house)
            {
                comboBox4.Items.Add(h.name.ToString());
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

            dataGridView1.Rows.Clear();

            var invoice = from p in myEnt.sales_invoice select p;
            foreach (var i in invoice)
            {
                dataGridView1.Rows.Add(i.no, i.customer_id, i.item_code, i.warehouse_id, i.date, i.quantity);
            }
            comboBox1.Items.Clear();
           

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
                var customer = (from c in myEnt.customers
                                where invoice.customer_id == c.id
                                select c).First();

                var item1 = (from i in myEnt.items
                             where invoice.item_code == i.code
                             select i).First();

                var house1 = (from h in myEnt.warehouses
                              where invoice.warehouse_id == h.id
                              select h).First();


                textBox1.Text = invoice.no.ToString();

                comboBox2.Text = customer.name.ToString();
                comboBox3.Text = item1.name.ToString();
                comboBox4.Text = house1.name.ToString();
                DateTime t = invoice.date.Value;
                textBox6.Text = invoice.quantity.ToString();
                textBox5.Text = t.ToShortDateString().ToString();

            }
            
      


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //insert
            sales_invoice sales = new sales_invoice();
           
            sales.no = int.Parse(textBox1.Text);
            sales.customer_id = comboBox2.SelectedIndex+1;
            sales.item_code = comboBox3.SelectedIndex+1;
            sales.warehouse_id = comboBox4.SelectedIndex+1;
            sales.date = DateTime.Parse(textBox5.Text);
            sales.quantity = int.Parse(textBox6.Text);
            var quantity = (from q in myEnt.warehouse_quantity_items
                            where q.item_code == sales.item_code
                            where q.warehouse_id == sales.warehouse_id
                            select q).FirstOrDefault();
            quantity.quantity = quantity.quantity - sales.quantity;

            myEnt.sales_invoice.Add(sales);

           
            myEnt.SaveChanges();
            textBox1.Text = comboBox2.Text = comboBox3.Text=comboBox4.Text = textBox5.Text=textBox6.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //update
       
            int no = int.Parse(textBox1.Text);
            var sales = (from s in myEnt.sales_invoice
                            where s.no == no
                            select s).First();

            var quantity = (from qa in myEnt.warehouse_quantity_items
                            where qa.item_code == sales.item_code
                            where qa.warehouse_id == sales.warehouse_id
                            select qa).FirstOrDefault();

            int q = (int)sales.quantity;
            if (sales != null)
            {
                sales.customer_id = comboBox2.SelectedIndex+1;
                sales.item_code = comboBox3.SelectedIndex+1;
                sales.warehouse_id = comboBox4.SelectedIndex+1;
                sales.date = DateTime.Parse(textBox5.Text);

                if (q == int.Parse(textBox6.Text))
                {
                    sales.quantity = int.Parse(textBox6.Text);

                }

                else if (q != int.Parse(textBox6.Text))
                {

                    sales.quantity = int.Parse(textBox6.Text);
                    q = int.Parse(textBox6.Text) - q;
                    quantity.quantity = quantity.quantity - q;

                }


                myEnt.SaveChanges();
                textBox1.Text = comboBox2.Text = comboBox3.Text = comboBox4.Text = comboBox1.Text= textBox5.Text = textBox6.Text = string.Empty;


            }

            
        }
    }
}