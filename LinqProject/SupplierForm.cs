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
    public partial class SupplierForm : Form
    {
        LinqProjectEntities myEnt;
        public SupplierForm()
        {
            InitializeComponent();
            myEnt = new LinqProjectEntities();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SelectedIndex
            int id = int.Parse(comboBox1.Text);
            var supplier = (from s in myEnt.suppliers
                        where s.id == id
                        select s).First();
            if (supplier != null)
            {
                textBox1.Text = supplier.id.ToString();
                textBox2.Text = supplier.name.ToString();
                textBox3.Text = supplier.mobile.ToString();
                textBox4.Text = supplier.email.ToString();
                textBox5.Text = supplier.website.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Back
            this.Close();
            Database db = new Database();
            db.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Insert
            supplier supplier = new supplier();
            supplier.id = int.Parse(textBox1.Text);
            supplier.name = textBox2.Text;
            supplier.mobile = int.Parse(textBox3.Text);
            supplier.email = textBox4.Text;
            supplier.website = textBox5.Text;
            myEnt.suppliers.Add(supplier);
            myEnt.SaveChanges();
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = string.Empty;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Update
            int id = int.Parse(textBox1.Text);
            var supplier = (from s in myEnt.suppliers
                            where s.id == id
                            select s).First();
            if (supplier != null)
            {
                supplier.name = textBox2.Text;
                supplier.mobile = int.Parse(textBox3.Text);
                supplier.email = textBox4.Text;
                supplier.website = textBox5.Text;
                myEnt.SaveChanges();
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = string.Empty;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Display
            comboBox1.Items.Clear();
            dataGridView1.DataSource = myEnt.suppliers.ToList();
            var supplier= from s in myEnt.suppliers select s;
            foreach (var i in supplier)
            {
                comboBox1.Items.Add(i.id.ToString());
            }

        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'linqProjectDataSet8.supplier' table. You can move, or remove it, as needed.
            this.supplierTableAdapter.Fill(this.linqProjectDataSet8.supplier);
            //onload
            var supplier = from s in myEnt.suppliers select s;
            foreach (var i in supplier)
            {
                comboBox1.Items.Add(i.id.ToString());
            }
        }
    }
}
