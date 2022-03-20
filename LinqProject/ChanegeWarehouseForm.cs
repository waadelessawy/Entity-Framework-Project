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
            int qua = 0;
            int itemcode = 0;
            int purchaseno = 0;
            int w_id = int.Parse(textBox1.Text);
            int i_id = int.Parse(textBox3.Text);
            int s_id = int.Parse(textBox5.Text);
            var items = (from i in myEnt.items
                         where i.code == i_id
                         select i).First();
            if (items != null)
            {
                items.prod_date = DateTime.Parse(textBox6.Text);
                items.exp_date = DateTime.Parse(textBox7.Text);
            }
            var purchase = (from p in myEnt.purchase_invoice
                         where p.warehouse_id == w_id
                         where p.item_code == i_id
                         where p.supplier_id == s_id
                         select p).First();
            if (purchase != null)
            {
                purchase.warehouse_id = int.Parse(textBox2.Text);
            
            }
            var quantity = (from q in myEnt.quantity_of_purchased
                            where q.item_code == i_id
                            select q).First();

            qp.quantity = int.Parse(textBox4.Text);
            qp.item_code = int.Parse(textBox3.Text);
            qp.purchase_no = int.Parse(textBox8.Text);

            qua = int.Parse(textBox4.Text);
            itemcode = int.Parse(textBox3.Text);
            purchaseno = int.Parse(textBox8.Text);

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
