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
    public partial class PurchaseInvoiceForm : Form
    {
        LinqProjectEntities myEnt;
        purchase_invoice purchase ;
    

        public PurchaseInvoiceForm()
        {
            InitializeComponent();
            myEnt = new LinqProjectEntities();
      
            purchase = new purchase_invoice();

        }

        private void PurchaseInvoiceForm_Load(object sender, EventArgs e)
        {
            //onLoad
            var invoice = from p in myEnt.purchase_invoice select p;
            foreach(var i in invoice)
            {
                dataGridView1.Rows.Add(i.no,i.supplier_id,i.item_code,i.warehouse_id,i.date,i.quantity,i.prod_date,i.exp_date);
            }

            var purchase = from p in myEnt.purchase_invoice select p;
            foreach (var p in purchase)
            {
                comboBox1.Items.Add(p.no.ToString());
            }
            var supplier = from s in myEnt.suppliers select s;
            foreach (var s in supplier)
            {
                comboBox3.Items.Add(s.name.ToString());
            }
            var item = from i in myEnt.items select i;
            foreach (var i in item)
            {
                comboBox2.Items.Add(i.name.ToString());
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
            var invoice = from p in myEnt.purchase_invoice select p;
            foreach (var i in invoice)
            {
                dataGridView1.Rows.Add(i.no, i.supplier_id, i.item_code, i.warehouse_id, i.date, i.quantity, i.prod_date, i.exp_date);
            }

            comboBox1.Items.Clear();
       
          
            var purchase = from p in myEnt.purchase_invoice select p;
            foreach (var p in purchase)
            {
                comboBox1.Items.Add(p.no.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Insert

            purchase.no = int.Parse(textBox1.Text);
    
            purchase.supplier_id = comboBox3.SelectedIndex + 1;
            purchase.item_code = comboBox2.SelectedIndex + 1;
            purchase.warehouse_id = comboBox4.SelectedIndex + 1;
         
            purchase.date = DateTime.Parse(textBox5.Text);
          
            purchase.quantity =int.Parse( textBox6.Text);
            purchase.prod_date = DateTime.Parse(textBox7.Text);
            purchase.exp_date = DateTime.Parse(textBox8.Text);

            myEnt.purchase_invoice.Add(purchase);


            myEnt.SaveChanges();
            textBox1.Text = textBox5.Text = textBox6.Text=textBox7.Text=textBox8.Text=comboBox1.Text =comboBox3.Text = comboBox2.Text = comboBox4.Text = string.Empty;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //selectedindex

            int no = int.Parse(comboBox1.Text);
            var invoice = (from i in myEnt.purchase_invoice
                           where i.no == no
                           select i).First();
            if (invoice != null)
            {

                textBox1.Text = invoice.no.ToString();
                var supplier1 = (from s in myEnt.suppliers 
                               where invoice.supplier_id == s.id
                               select s).First();
                var item1 = (from i in myEnt.items
                                 where invoice.item_code ==  i.code
                                 select i ).First();
                var house1= (from h in myEnt.warehouses
                             where invoice.warehouse_id==h.id
                             select h).First();


                comboBox3.Text = supplier1.name;
                comboBox2.Text = item1.name.ToString();
                comboBox4.Text = house1.name.ToString();

                textBox6.Text = invoice.quantity.ToString();
                DateTime t = invoice.date.Value;
                textBox5.Text = t.ToShortDateString().ToString();
                DateTime pd = invoice.prod_date.Value;
                textBox7.Text = t.ToShortDateString().ToString();
                DateTime ed = invoice.exp_date.Value;
                textBox8.Text = t.ToShortDateString().ToString();



            }
    

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //update

            int no = int.Parse(textBox1.Text);
            var purchase = (from p in myEnt.purchase_invoice
                         where p.no == no
                         select p).First();
            if (purchase != null)
            {
                purchase.supplier_id = comboBox3.SelectedIndex + 1;
                purchase.item_code = comboBox2.SelectedIndex+1;
                purchase.warehouse_id = comboBox4.SelectedIndex+1;
                purchase.date = DateTime.Parse(textBox5.Text);

                purchase.quantity = int.Parse(textBox6.Text);
                purchase.prod_date= DateTime.Parse(textBox7.Text);
                purchase.exp_date = DateTime.Parse(textBox8.Text);
             
                myEnt.SaveChanges();
                textBox1.Text = textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text=comboBox1.Text = comboBox3.Text = comboBox2.Text = comboBox4.Text = string.Empty;


            }

      
            myEnt.SaveChanges();

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Supplier_Selected_Index
         

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            //int no = int.Parse(comboBox1.Text);
            
            //int no = int.Parse((string)Cells[0].Value );
            ////int no = int.Parse(dataGridView1.SelectedRows[0]);
            //var invoice = (from i in myEnt.purchase_invoice
            //               where i.no == no
            //               select i).First();
            //if (invoice != null)
            //{

            //    textBox1.Text = invoice.no.ToString();
            //    var supplier1 = (from s in myEnt.suppliers
            //                     where invoice.supplier_id == s.id
            //                     select s).First();
            //    var item1 = (from i in myEnt.items
            //                 where invoice.item_code == i.code
            //                 select i).First();
            //    var house1 = (from h in myEnt.warehouses
            //                  where invoice.warehouse_id == h.id
            //                  select h).First();


            //    comboBox3.Text = supplier1.name;
            //    comboBox2.Text = item1.name.ToString();
            //    comboBox4.Text = house1.name.ToString();

            //    textBox6.Text = invoice.quantity.ToString();
            //    DateTime t = invoice.date.Value;
            //    textBox5.Text = t.ToShortDateString().ToString();
            //    DateTime pd = invoice.prod_date.Value;
            //    textBox7.Text = t.ToShortDateString().ToString();
            //    DateTime ed = invoice.exp_date.Value;
            //    textBox8.Text = t.ToShortDateString().ToString();



            //}
        }
    }
}
