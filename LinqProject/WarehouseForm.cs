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
    public partial class WarehouseForm : Form
    {
        LinqProjectEntities myEnt;
        public WarehouseForm()
        {
            InitializeComponent();
            myEnt = new LinqProjectEntities();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Display
            comboBox1.Items.Clear();
            dataGridView1.DataSource = myEnt.warehouses.ToList();
            var houses = from w in myEnt.warehouses select w;
            foreach (var house in houses)
            {
                comboBox1.Items.Add(house.id.ToString());
            }
        }

        private void WarehouseForm_Load(object sender, EventArgs e)
        {
            //on_load
            comboBox1.Items.Clear();
            var houses = from w in myEnt.warehouses select w;
            foreach (var house in houses)
            {
                comboBox1.Items.Add(house.id.ToString());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Insert
            warehouse house = new warehouse();
            house.id = int.Parse(textBox1.Text);
            house.name = textBox2.Text;
            house.manager = textBox3.Text;
            house.address = textBox4.Text;
            myEnt.warehouses.Add(house);
            myEnt.SaveChanges();
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = string.Empty;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Selected_Index
            int ID = int.Parse(comboBox1.Text);
            var house = (from w in myEnt.warehouses
                         where w.id == ID
                         select w).First();
            if(house != null)
            {
                textBox1.Text = house.id.ToString();
                textBox2.Text = house.name.ToString();
                textBox3.Text = house.manager.ToString();
                textBox4.Text = house.address.ToString();
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //update
            int ID = int.Parse(textBox1.Text);
            var house = (from w in myEnt.warehouses where w.id == ID select w).First();
            if(house != null)
            {
                house.name = textBox2.Text;
                house.manager = textBox3.Text;
                house.address = textBox4.Text;
                myEnt.SaveChanges();
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = string.Empty;


            }
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Database db = new Database();
            db.Show();
        }
    }
}
