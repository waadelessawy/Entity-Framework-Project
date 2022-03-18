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
    public partial class itemForm : Form
    {
        LinqProjectEntities myEnt;

        public itemForm()
        {
            InitializeComponent();
            myEnt = new LinqProjectEntities();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //back
            this.Close();
            Database db = new Database();
            db.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Display
            comboBox1.Items.Clear();
            dataGridView1.DataSource = myEnt.items.ToList();
            var item = from i in myEnt.items select i;
            foreach (var i in item)
            {
                comboBox1.Items.Add(i.code.ToString());
            }  
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //selectedindex
            int code= int.Parse(comboBox1.Text);
            var item = (from i in myEnt.items
                         where i.code== code
                         select i).First();
            if (item != null)
            {
                textBox1.Text = item.code.ToString();
                textBox2.Text = item.name.ToString();
                textBox3.Text = item.prod_date.ToString();
                textBox4.Text = item.exp_date.ToString();
            }

        }

        private void itemForm_Load(object sender, EventArgs e)
        {
            //onload
            var item = from i in myEnt.items select i;
            foreach (var i in item)
            {
                comboBox1.Items.Add(i.code.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //insert
            item item = new item();
            item.code = int.Parse(textBox1.Text);
            item.name = textBox2.Text;
            item.prod_date =DateTime.Parse(textBox3.Text);
            item.exp_date = DateTime.Parse(textBox4.Text);
            myEnt.items.Add(item);
            myEnt.SaveChanges();
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = string.Empty;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //update
            int code = int.Parse(textBox1.Text);
            var item = (from i in myEnt.items
                        where i.code == code
                        select i).First();
            if (item != null)
            {
                item.name = textBox2.Text;
                item.prod_date = DateTime.Parse(textBox3.Text);
                item.exp_date = DateTime.Parse(textBox4.Text);
                myEnt.SaveChanges();
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = string.Empty;


            }


        }
    }
}
