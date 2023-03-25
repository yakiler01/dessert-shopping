using Front_End;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;


namespace Front_End
{
    public partial class order_cart : Form
    {
        //string connectionString = ConfigurationManager.ConnectionStrings["linq3.Properties.Settings.mydbConnectionString"].ToString();
        //mydbDataClassesDataContext mydb = new mydbDataClassesDataContext(connectionString);
        //int 訂單筆數 = 0;
        Form1 form1;
        public order_cart()
        {
            InitializeComponent();

        }

        private void order_cart_Load(object sender, EventArgs e)
        {
            groupBox訂單0.Visible = false;
            groupBox訂單1.Visible = false;
            groupBox訂單2.Visible = false;
            groupBox訂單3.Visible = false;
            groupBox訂單4.Visible = false;

            lbl訂購人.Text = Form1.訂購人;
            lbl電話.Text = Form1.電話;
            ((CheckBox)this.Controls.Find("chk外帶0" , true)[0]).Checked = Form1.is外帶;
            加載();
            chk外帶0.Enabled = false;
        }
        void 加載()
        {
            for (int i = 0; i < Form1.listname.Count; i++)
            {
                (this.Controls.Find("groupBox訂單" + i.ToString(), true)[0]).Visible = true;

                ((Label)this.Controls.Find("lbl姓名" + i.ToString(), true)[0]).Text = Form1.listname.ElementAt(i);
                ((Label)this.Controls.Find("lbl價格" + i.ToString(), true)[0]).Text = Form1.listPrice.ElementAt(i).ToString();
                ((Label)this.Controls.Find("lbl數量" + i.ToString(), true)[0]).Text = Form1.listQuantity.ElementAt(i).ToString();
            }
        }
        private void btn移除0_Click(object sender, EventArgs e)
        {

            Form1.listname.RemoveAt(0);
            Form1.listPrice.RemoveAt(0);
            Form1.listQuantity.RemoveAt(0);
            form1 = new Form1();
            form1.顯示總數(-(Int32.Parse(lbl數量0.Text)));
            form1.顯示總價(-((Int32.Parse(lbl數量0.Text))*(Int32.Parse(lbl價格0.Text))));
            int temp = Form1.listname.Count;
            (this.Controls.Find("groupBox訂單" + Form1.listname.Count.ToString(), true)[0]).Visible = false;
            加載();
        }

        private void btn移除1_Click(object sender, EventArgs e)
        {
            Form1.listname.RemoveAt(1);
            Form1.listPrice.RemoveAt(1);
            Form1.listQuantity.RemoveAt(1);
            form1 = new Form1();
            form1.顯示總數(-(Int32.Parse(lbl數量1.Text)));
            form1.顯示總價(-((Int32.Parse(lbl數量1.Text)) * (Int32.Parse(lbl價格1.Text))));
            (this.Controls.Find("groupBox訂單" + Form1.listname.Count.ToString(), true)[0]).Visible = false;
            加載();
        }

        private void btn移除2_Click(object sender, EventArgs e)
        {
            Form1.listname.RemoveAt(2);
            Form1.listPrice.RemoveAt(2);
            Form1.listQuantity.RemoveAt(2);
            form1 = new Form1();
            form1.顯示總數(-(Int32.Parse(lbl數量2.Text)));
            form1.顯示總價(-((Int32.Parse(lbl數量2.Text)) * (Int32.Parse(lbl價格2.Text))));
            (this.Controls.Find("groupBox訂單" + Form1.listname.Count.ToString(), true)[0]).Visible = false;
            加載();
        }

        private void btn移除3_Click(object sender, EventArgs e)
        {
            Form1.listname.RemoveAt(3);
            Form1.listPrice.RemoveAt(3);
            Form1.listQuantity.RemoveAt(3);
            form1 = new Form1();
            form1.顯示總數(-(Int32.Parse(lbl數量3.Text)));
            form1.顯示總價(-((Int32.Parse(lbl數量3.Text)) * (Int32.Parse(lbl價格3.Text))));
            (this.Controls.Find("groupBox訂單" + Form1.listname.Count.ToString(), true)[0]).Visible = false;
            加載();
        }

        private void btn移除4_Click(object sender, EventArgs e)
        {
            Form1.listname.RemoveAt(4);
            Form1.listPrice.RemoveAt(4);
            Form1.listQuantity.RemoveAt(4);
            form1 = new Form1();
            form1.顯示總數(-(Int32.Parse(lbl數量4.Text)));
            form1.顯示總價(-((Int32.Parse(lbl數量4.Text)) * (Int32.Parse(lbl價格4.Text))));
            (this.Controls.Find("groupBox訂單" + Form1.listname.Count.ToString(), true)[0]).Visible = false;
            加載();
        }

    }
}
