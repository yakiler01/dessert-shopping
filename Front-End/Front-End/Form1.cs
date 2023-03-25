using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Front_End
{
    public partial class Form1 : Form
    {
        order_cart order_Cart;
        string strDBConnectString = "";
        bool txtInputHasText0 = false;
        bool txtInputHasText1 = false;
        
        public static List<string> listname = new List<string>();
        public static List<string> listPrice = new List<string>();
        public static List<string> listQuantity = new List<string>();
        public static int Num = 0;
        public static int AllPrice = 0;
        public static bool is外帶 = false;
        public static string 訂購人;
        public static string 電話;
        public Form1()
        {
            InitializeComponent();
        }
        dessert1 dessert;
        private void btn查看圖片1_Click(object sender, EventArgs e)
        {
            dessert = new dessert1();
            dessert.BackgroundImage = global::Front_End.Properties.Resources.甜點1;
            dessert.Show();
        }
        private void btn查看圖片2_Click(object sender, EventArgs e)
        {
            dessert = new dessert1();
            dessert.BackgroundImage = global::Front_End.Properties.Resources.甜點2;
            dessert.Show();
        }
        private void btn查看圖片3_Click_1(object sender, EventArgs e)
        {
            dessert = new dessert1();
            dessert.BackgroundImage = global::Front_End.Properties.Resources.甜點3;
            dessert.Show();
        }
        private void btn查看圖片4_Click(object sender, EventArgs e)
        {
            dessert = new dessert1();
            dessert.BackgroundImage = global::Front_End.Properties.Resources.甜點4;
            dessert.Show();
        }
        private void btn查看圖片5_Click(object sender, EventArgs e)
        {
            dessert = new dessert1();
            dessert.BackgroundImage = global::Front_End.Properties.Resources.甜點5;
            dessert.Show();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            lbl警示.Hide();
            groupBox內用.Hide();
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "order-shopping";
            scsb.IntegratedSecurity = true;
            strDBConnectString = scsb.ToString();
            dateTimePicker預約時間.MinDate = DateTime.Now;
            textBox電話.Text = "請輸入電話";
            textBox電話.ForeColor = Color.Gray;
            textBox姓名.Text = "請輸入姓名";
            textBox姓名.ForeColor = Color.Gray;
        }

        private void btn查看介紹1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("入口前段為史多倫麵團獨特發酵層次中段帶出加了台灣純龍眼蜂蜜、法國Negrita深色蘭姆酒、日本梅乃宿柚子酒浸泡水果香氣為主調、尾端味覺帶出輕盈絲綢般日本柚子的清香感受。\r\n不放香料、希望以果香主調加上發酵香氣、德國杏仁糕不同的層層感受來呈現！\r\n絕對不會讓您失望！！");
        }

        private void textBox姓名_Enter(object sender, EventArgs e)
        {
            if (txtInputHasText0 == false)
                textBox姓名.Text = "";
            textBox姓名.ForeColor = Color.Black;
        }

        private void textBox姓名_Leave(object sender, EventArgs e)
        {
            if (textBox姓名.Text == "")
            {
                textBox姓名.Text = "請輸入姓名";
                textBox姓名.ForeColor = Color.Gray;
                txtInputHasText0 = false;
            }
            else
                txtInputHasText0 = true;
        }

        private void textBox電話_Enter(object sender, EventArgs e)
        {
            if (txtInputHasText1 == false)
                textBox電話.Text = "";
            textBox電話.ForeColor = Color.Black;
        }

        private void textBox電話_Leave(object sender, EventArgs e)
        {
            if (textBox電話.Text == "" )
            {
                textBox電話.Text = "請輸入電話";
                textBox電話.ForeColor = Color.Gray;
                txtInputHasText1 = false;
            }
            else
                txtInputHasText1 = true;
        }

        

        private void btn查看訂單_Click(object sender, EventArgs e)
        {
            order_Cart = new order_cart();
            訂購人 = textBox姓名.Text;
            電話 = textBox電話.Text;
            order_Cart.Show();
        }

        private void chk外帶0_CheckedChanged(object sender, EventArgs e)
        {
            is外帶 = chk外帶0.Checked;
            if (chk外帶0.Checked)
                groupBox內用.Show();
            else
                groupBox內用.Hide();

        }
        private void btn添加_Click(object sender, EventArgs e)
        {
            if (listname.IndexOf(lab姓名0.Text) == -1 && textBox姓名.Text !="" &&textBox電話.Text != "" && listname.IndexOf(lab姓名0.Text+",") == -1 && textBox姓名.Text != "請輸入姓名" && textBox電話.Text != "請輸入電話")
            {
                    listname.Add(lab姓名0.Text);
                    listPrice.Add(lab價格0.Text);
                    listQuantity.Add(numericUpDown數量0.Value.ToString());
                    顯示總價(int.Parse(lab價格0.Text) * (int)numericUpDown數量0.Value);
                    顯示總數((int)numericUpDown數量0.Value);
                    MessageBox.Show("添加訂單成功!");
            }
            else MessageBox.Show("未填姓名電話，或已加入訂單了!");
        }
        private void btn添加1_Click(object sender, EventArgs e)
        {
            if (listname.IndexOf(lab姓名1.Text) == -1 && textBox姓名.Text != "" && textBox電話.Text != "" && listname.IndexOf(lab姓名1.Text + ",") == -1 && textBox姓名.Text != "請輸入姓名" && textBox電話.Text != "請輸入電話") {

                    listname.Add(lab姓名1.Text);
                    listPrice.Add(lab價格1.Text);
                    listQuantity.Add(numericUpDown數量1.Value.ToString());
                    顯示總價(int.Parse(lab價格1.Text) * (int)numericUpDown數量1.Value);
                    顯示總數((int)numericUpDown數量1.Value);
                    MessageBox.Show("添加訂單成功!");

            }
            else MessageBox.Show("未填姓名電話，或已加入訂單了!");
        }

        private void btn添加2_Click(object sender, EventArgs e)
        {
            if (listname.IndexOf(lab姓名2.Text) == -1 && textBox姓名.Text != "" && textBox電話.Text != "" && listname.IndexOf(lab姓名2.Text + ",") == -1 && textBox姓名.Text != "請輸入姓名" && textBox電話.Text != "請輸入電話")
            {
                    listname.Add(lab姓名2.Text);
                    listPrice.Add(lab價格2.Text);
                    listQuantity.Add(numericUpDown數量2.Value.ToString());
                    顯示總價(int.Parse(lab價格2.Text) * (int)numericUpDown數量2.Value);
                    顯示總數((int)numericUpDown數量2.Value);
                    MessageBox.Show("添加訂單成功!");

            }
            else MessageBox.Show("未填姓名電話，或已加入訂單了!");
        }

        private void btn添加3_Click(object sender, EventArgs e)
        {
            if (listname.IndexOf(lab姓名3.Text) == -1 && textBox姓名.Text != "" && textBox電話.Text != "" && listname.IndexOf(lab姓名3.Text + ",") == -1 && textBox姓名.Text != "請輸入姓名" && textBox電話.Text != "請輸入電話")
            {
                    listname.Add(lab姓名3.Text);
                    listPrice.Add(lab價格3.Text);
                    listQuantity.Add(numericUpDown數量3.Value.ToString());
                    顯示總價(int.Parse(lab價格3.Text) * (int)numericUpDown數量3.Value);
                    顯示總數((int)numericUpDown數量3.Value);
                    MessageBox.Show("添加訂單成功!");

            }
            else MessageBox.Show("未填姓名電話，或已加入訂單了!");
        }

        private void btn添加4_Click(object sender, EventArgs e)
        {
           
            if (listname.IndexOf(lab姓名4.Text) == -1 && textBox姓名.Text != "" && textBox電話.Text != "" && listname.IndexOf(lab姓名4.Text + ",") == -1 && textBox姓名.Text != "請輸入姓名" && textBox電話.Text != "請輸入電話")
            {
                    listname.Add(lab姓名4.Text);
                    listPrice.Add(lab價格4.Text);
                    listQuantity.Add(numericUpDown數量4.Value.ToString());
                    顯示總價(int.Parse(lab價格4.Text) * (int)numericUpDown數量4.Value);
                    顯示總數((int)numericUpDown數量4.Value);
                    MessageBox.Show("添加訂單成功!");

            }
            else MessageBox.Show("未填姓名電話，或已加入訂單了!");
        }
        public void 顯示總數(int x)
        {
            Num += x;
            lbl數量.Text = Num.ToString();
        }
        
        public void 顯示總價(int x)
        {
            AllPrice += x;
            lbl總價.Text = AllPrice.ToString();
        }

        private void btn送出訂單_Click(object sender, EventArgs e)
        {
            if(listname.Count != 0) {
                if (is外帶 && numericUpDown預約人數.Value != 0)
                {
                    SqlConnection con = new SqlConnection(strDBConnectString);
                    con.Open();
                    string strSQL = "insert into order_cart values(@NewProductName,@NewProductQuantity,@NewProductPrice,@NewProductSum,@NewIsTakeAway,@NewIsState)";
                    string strSQL2 = "insert into customers values(@NewUserName,@NewUserPhone,@NewUserSum,@NewUserTime)";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    SqlCommand cmd2 = new SqlCommand(strSQL2, con);
                    string 訂單名字 = "";
                    foreach (string str訂單名字 in listname)
                    {
                        if (訂單名字 == "")
                            訂單名字 += str訂單名字;
                        else
                            訂單名字 += "," + str訂單名字;
                    }
                    string 訂單數量 = "";
                    foreach (string str訂單數量 in listQuantity)
                    {
                        if (訂單數量 == "")
                            訂單數量 += str訂單數量;
                        else
                            訂單數量 += "," + str訂單數量;
                    }
                    string 訂單價格 = "";
                    foreach (string str訂單價格 in listPrice)
                    {
                        if (訂單價格 == "")
                            訂單價格 += str訂單價格;
                        else
                            訂單價格 += "," + str訂單價格;
                    }
                    cmd.Parameters.AddWithValue("@NewProductName", 訂單名字);
                    cmd.Parameters.AddWithValue("@NewProductQuantity", 訂單數量);
                    cmd.Parameters.AddWithValue("@NewProductPrice", 訂單價格);
                    cmd.Parameters.AddWithValue("@NewProductSum", Num);
                    cmd.Parameters.AddWithValue("@NewIsTakeAway", chk外帶0.Checked);
                    cmd.Parameters.AddWithValue("@NewIsState", false);
                    cmd2.Parameters.AddWithValue("@NewUserName", textBox姓名.Text);
                    cmd2.Parameters.AddWithValue("@NewUserPhone", textBox電話.Text);
                    cmd2.Parameters.AddWithValue("@NewUserSum", (int)numericUpDown預約人數.Value);
                    cmd2.Parameters.AddWithValue("@NewUserTime", dateTimePicker預約時間.Value.Year.ToString() + dateTimePicker預約時間.Value.Month.ToString() + dateTimePicker預約時間.Value.Day.ToString()+ dateTimePicker預約時間.Value.Hour.ToString());
                    int row = cmd.ExecuteNonQuery();
                    int row2 = cmd2.ExecuteNonQuery();
                    con.Close();
                    if (row != 0 && row2 != 0)
                        MessageBox.Show($"新增訂單成功!");
                }
                //Application.Restart();
                else if(!is外帶){ 
                    SqlConnection con = new SqlConnection(strDBConnectString);
                    con.Open();
                    string strSQL = "insert into order_cart values(@NewProductName,@NewProductQuantity,@NewProductPrice,@NewProductSum,@NewIsTakeAway,@NewIsState)";
                    string strSQL2 = "insert into customers values(@NewUserName,@NewUserPhone,@NewUserSum,@NewUserTime)";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    SqlCommand cmd2 = new SqlCommand(strSQL2, con);
                    string 訂單名字 = "";
                    foreach (string str訂單名字 in listname)
                {
                    if (訂單名字 == "")
                        訂單名字 += str訂單名字;
                    else
                        訂單名字 += "," + str訂單名字;
                }
                string 訂單數量 = "";
                foreach (string str訂單數量 in listQuantity)
                {
                    if (訂單數量 == "")
                        訂單數量 += str訂單數量;
                    else
                        訂單數量 += "," + str訂單數量;
                }
                string 訂單價格 = "";
                foreach (string str訂單價格 in listPrice)
                {
                    if (訂單價格 == "")
                        訂單價格 += str訂單價格;
                    else
                        訂單價格 += "," + str訂單價格;
                }
                cmd.Parameters.AddWithValue("@NewProductName", 訂單名字);
                cmd.Parameters.AddWithValue("@NewProductQuantity", 訂單數量);
                cmd.Parameters.AddWithValue("@NewProductPrice", 訂單價格);
                cmd.Parameters.AddWithValue("@NewProductSum", Num);
                cmd.Parameters.AddWithValue("@NewIsTakeAway", chk外帶0.Checked);
                cmd.Parameters.AddWithValue("@NewIsState", false);
                cmd2.Parameters.AddWithValue("@NewUserName", textBox姓名.Text);
                cmd2.Parameters.AddWithValue("@NewUserPhone", textBox電話.Text);
                cmd2.Parameters.AddWithValue("@NewUserSum", 0);
                cmd2.Parameters.AddWithValue("@NewUserTime", dateTimePicker預約時間.Value.Year.ToString() + dateTimePicker預約時間.Value.Month.ToString() + dateTimePicker預約時間.Value.Day.ToString() + dateTimePicker預約時間.Value.Hour.ToString());
                int row = cmd.ExecuteNonQuery();
                int row2 = cmd2.ExecuteNonQuery();
                con.Close();
                if (row != 0 && row2 != 0)
                    MessageBox.Show($"新增訂單成功!");
                }
                else
                {
                    MessageBox.Show($"請選擇內用時間與人數!");
                }
            }
            else MessageBox.Show($"請添加訂單!");
        }
        private void Form1_Activated(object sender, EventArgs e)
        {
            lbl總價.Text = AllPrice.ToString();
            lbl數量.Text = Num.ToString();
        }

        private void numericUpDown預約人數_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown預約人數.Value == 4)
                lbl警示.Show();
            else
                lbl警示.Hide();
        }

        private void btn查看介紹4_Click(object sender, EventArgs e)
        {
            if (!chk外帶0.Checked && numericUpDown預約人數.Value == 0)
                Console.WriteLine("OK");
            else
                Console.WriteLine("以勾選內用，請選擇預約時間與人數");
        }
    }
}
