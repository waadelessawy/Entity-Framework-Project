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
        quantity_of_purchased qp;
        purchase_invoice pi;
        warehouse warehouse;
        public ChanegeWarehouseForm()
        {
            InitializeComponent();
            myEnt = new LinqProjectEntities();
            item = new item();
            qp = new quantity_of_purchased();
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

            int w1_id = int.Parse(textBox1.Text);
            int w2_id = int.Parse(textBox2.Text);
            int i_id = int.Parse(textBox3.Text);
            int q = int.Parse(textBox4.Text);


            var item1 = (from i in myEnt.quantity_at_warehouse
                         where i.item_code == i_id
                         where i.warehouse_id == w1_id
                         select i).FirstOrDefault();
            var item2 = (from i in myEnt.quantity_at_warehouse
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
                    myEnt.quantity_at_warehouse.Remove(item1);
                    //myEnt.SaveChanges();

                }
                myEnt.SaveChanges();
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = string.Empty;
            }
            else if(item1 !=null && item2 == null)
            {
                item1.quantity = item1.quantity - q;
               
                //insert new row
                quantity_at_warehouse qw = new quantity_at_warehouse();
                qw.item_code =i_id;
                qw.warehouse_id = w2_id;
                qw.quantity = q;

                myEnt.quantity_at_warehouse.Add(qw);
                if (item1.quantity == 0)
                {
                    //remove row
                    myEnt.quantity_at_warehouse.Remove(item1);
                    //myEnt.SaveChanges();

                }
                myEnt.SaveChanges();
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = string.Empty;
            }

            


        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = myEnt.quantity_at_warehouse.ToList();
           
        }

        private void ChanegeWarehouseForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'linqProjectDataSet2.quantity_at_warehouse' table. You can move, or remove it, as needed.
            this.quantity_at_warehouseTableAdapter.Fill(this.linqProjectDataSet2.quantity_at_warehouse);

        }
    }
}
