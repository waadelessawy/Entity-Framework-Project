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
    public partial class CustomerForm : Form
    {
    
        LinqProjectEntities myEnt;
        public CustomerForm()
        {
            InitializeComponent();
            myEnt = new LinqProjectEntities();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            

            //onload


            var customer = from c in myEnt.customers select c;
            foreach (var i in customer)
            {
                dataGridView1.Rows.Add(i.id,i.name,i.mobile,i.email,i.website);
                comboBox1.Items.Add(i.id.ToString());
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Back
            this.Close();
            Database db = new Database();
            db.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //selectedIndex
            int id = int.Parse(comboBox1.Text);
            var customer = (from c in myEnt.customers
                            where c.id == id
                            select c).First();
            if (customer != null)
            {
                textBox1.Text = customer.id.ToString();
                textBox2.Text = customer.name.ToString();
                textBox3.Text = customer.mobile.ToString();
                textBox4.Text = customer.email.ToString();
                textBox5.Text = customer.website.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Display
            dataGridView1.Rows.Clear();

            comboBox1.Items.Clear();
        
            var customer = from c in myEnt.customers select c;
            foreach (var i in customer)
            {

                dataGridView1.Rows.Add(i.id, i.name, i.mobile, i.email, i.website);
                comboBox1.Items.Add(i.id.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //insert

            customer customer = new customer();
            customer.id = int.Parse(textBox1.Text);
            customer.name = textBox2.Text;
            customer.mobile = int.Parse(textBox3.Text);
            customer.email = textBox4.Text;
            customer.website = textBox5.Text;
            myEnt.customers.Add(customer);
            myEnt.SaveChanges();
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = string.Empty;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //update
            int id = int.Parse(textBox1.Text);
            var customer = (from c in myEnt.customers
                            where c.id == id
                            select c).First();
            if (customer != null)
            {
                customer.name = textBox2.Text;
                customer.mobile = int.Parse(textBox3.Text);
                customer.email = textBox4.Text;
                customer.website = textBox5.Text;
                myEnt.SaveChanges();
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = string.Empty;
            }
        }
    }
}
