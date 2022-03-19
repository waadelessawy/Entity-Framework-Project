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
    public partial class ViewWarehousesAndItemsForm : Form
    {
        LinqProjectEntities myEnt;
    
        CheckBox [] box;
        int count = 0;
        int idno = 0;
        public ViewWarehousesAndItemsForm()
        {
            InitializeComponent();
            myEnt = new LinqProjectEntities();
            box= new CheckBox[10];
            
        }

        private void ViewWarehousesAndItemsForm_Load(object sender, EventArgs e)
        {
            var warehouse = from w in myEnt.warehouses select w;
        
            foreach (var w in warehouse)
            {
                box[w.id - 1] = new CheckBox();
                box[w.id - 1].Tag = w.id.ToString();
                box[w.id - 1].Text =w.id.ToString();
                box[w.id - 1].AutoSize = true;
                box[w.id - 1].Location = new Point(90, 40/2* w.id);                              
                groupBox1.Controls.Add(box[w.id - 1]);
                count++;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Display
          
            listBox1.Items.Clear();

            
                for (int i=0; i < count; i++)
                {
                    if (box[i].Checked == true) //0
                    {
                    var purchase = from w in myEnt.purchase_invoice select w; //warehouserows
                  
                    foreach (var p in purchase)
                    {
                        if (p.warehouse_id == i+1)
                        {
                            
                            idno = p.no;
                          
                            var invoice= (from pi in myEnt.purchase_invoice
                                          where pi.no == idno
                                      select pi).FirstOrDefault();
                            string str = invoice.item_code.ToString() + "   " + invoice.warehouse_id.ToString();
                            listBox1.Items.Add(str);
                        }

                    }

                }

                }

            
        }
    }
}
