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
        quantity_of_purchased qp;

        public PurchaseInvoiceForm()
        {
            InitializeComponent();
            myEnt = new LinqProjectEntities();
            qp = new quantity_of_purchased();

        }

        private void PurchaseInvoiceForm_Load(object sender, EventArgs e)
        {
            var purchase = from p in myEnt.purchase_invoice select p;
            foreach (var p in purchase)
            {
                comboBox1.Items.Add(p.no.ToString());
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
            dataGridView1.DataSource = myEnt.purchase_invoice.ToList();
            dataGridView2.DataSource = myEnt.quantity_of_purchased.ToList();
            var purchase = from p in myEnt.purchase_invoice select p;
            foreach (var p in purchase)
            {
                comboBox1.Items.Add(p.no.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Insert
            purchase_invoice purchase = new purchase_invoice();

            purchase.no = int.Parse(textBox1.Text);
            purchase.supplier_id = int.Parse(textBox2.Text);
            purchase.item_code = int.Parse(textBox3.Text);
            purchase.warehouse_id = int.Parse(textBox4.Text);
            purchase.date = DateTime.Parse(textBox5.Text);
            myEnt.purchase_invoice.Add(purchase);

            quantity_of_purchased qp = new quantity_of_purchased();
            qp.quantity = int.Parse(textBox6.Text);
            qp.item_code = int.Parse(textBox3.Text);
            qp.purchase_no= int.Parse(textBox1.Text);
            myEnt.quantity_of_purchased.Add(qp);

            myEnt.SaveChanges();
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = string.Empty;
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
                textBox2.Text = invoice.supplier_id.ToString();
                textBox3.Text = invoice.item_code.ToString();
                textBox4.Text = invoice.warehouse_id.ToString();
                textBox5.Text = invoice.date.ToString();

            }
            var quantity = (from q in myEnt.quantity_of_purchased
                            where q.purchase_no == no
                            select q).First();

            if (quantity != null)
            {
                textBox6.Text = quantity.quantity.ToString();


            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //update
            int qua = 0;
            int itemcode = 0;
            int purchaseno = 0;
            int no = int.Parse(textBox1.Text);
            var purchase = (from p in myEnt.purchase_invoice
                         where p.no == no
                         select p).First();
            if (purchase != null)
            {
                purchase.supplier_id= int.Parse(textBox2.Text);
                purchase.item_code = int.Parse(textBox3.Text);
                purchase.warehouse_id = int.Parse(textBox4.Text);
                purchase.date = DateTime.Parse(textBox5.Text);

                qp.quantity = int.Parse(textBox6.Text);
                qp.item_code = int.Parse(textBox3.Text);
                qp.purchase_no = int.Parse(textBox1.Text);
                qua = int.Parse(textBox6.Text);
                itemcode = int.Parse(textBox3.Text);
                purchaseno = int.Parse(textBox1.Text);
                myEnt.SaveChanges();
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = string.Empty;


            }

            var quantity = (from q in myEnt.quantity_of_purchased
                            where q.item_code == itemcode
                            where q.purchase_no == purchaseno
                            select q).FirstOrDefault();

            if (quantity != null)
            {
                myEnt.quantity_of_purchased.Remove(quantity);
                myEnt.SaveChanges();
            }

            myEnt.quantity_of_purchased.Add(qp);

            myEnt.SaveChanges();

        }
    }
}
