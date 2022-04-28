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
    public partial class ChanegeWarehouseForm : Form
    {
        LinqProjectEntities myEnt;
        item item;
        purchase_invoice pi;
        warehouse warehouse;
        public ChanegeWarehouseForm()
        {
            InitializeComponent();
            myEnt = new LinqProjectEntities();
            item = new item();
            pi = new purchase_invoice();
            warehouse = new warehouse();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Back
            this.Close();
            Database db = new Database();
            db.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Change

            int w1_id = comboBox1.SelectedIndex+1;
            int w2_id = comboBox2.SelectedIndex+1;
            int i_id = comboBox3.SelectedIndex+1;
            int q = int.Parse(textBox4.Text);
  

            var item1 = (from i in myEnt.warehouse_quantity_items
                         where i.item_code == i_id
                         where i.warehouse_id == w1_id
                         select i).FirstOrDefault();

            var item2 = (from i in myEnt.warehouse_quantity_items
                         where i.item_code == i_id
                         where i.warehouse_id == w2_id
                         select i).FirstOrDefault();

            if (item1 != null && item2 != null )
            {
                item1.quantity = item1.quantity - q;
                item2.quantity = item2.quantity + q;

                if (item1.quantity == 0)
                {
                    //remove row
                    myEnt.warehouse_quantity_items.Remove(item1);
                    //myEnt.SaveChanges();

                }
                myEnt.SaveChanges();
                comboBox1.Text = comboBox2.Text = comboBox3.Text = textBox4.Text = string.Empty;
            }
            else if(item1 !=null && item2 == null)
            {
                item1.quantity = item1.quantity - q;
               
                //insert new row
                warehouse_quantity_items qw = new warehouse_quantity_items();
                qw.item_code =i_id;
                qw.warehouse_id = w2_id;
                qw.quantity = q;

                myEnt.warehouse_quantity_items.Add(qw);
                if (item1.quantity == 0)
                {
                    //remove row
                    myEnt.warehouse_quantity_items.Remove(item1);
                    //myEnt.SaveChanges();

                }
                myEnt.SaveChanges();
                comboBox1.Text = comboBox2.Text = comboBox3.Text = textBox4.Text = string.Empty;
               
            }

           


        }

        private void button3_Click(object sender, EventArgs e)
        {
            //refresh
            dataGridView1.Rows.Clear();
            var hq = from house in myEnt.warehouse_quantity_items select house;


            foreach (var h in hq)
            {
                dataGridView1.Rows.Add(h.item_code, h.warehouse_id, h.quantity);

            }


        }

        private void ChanegeWarehouseForm_Load(object sender, EventArgs e)
        {

          
            var hq = from house in myEnt.warehouse_quantity_items select house;
     

            foreach (var h in hq)
            {
                dataGridView1.Rows.Add(h.item_code,h.warehouse_id,h.quantity);

            }
            var houses = from house in myEnt.warehouses select house;
            foreach (var h in houses)
            {
                comboBox2.Items.Add(h.name);
                comboBox1.Items.Add(h.name);

            }
            
            var items = from item in myEnt.items select item;
            foreach(var i in items)
            {
                comboBox3.Items.Add(i.name);

            }
          
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
