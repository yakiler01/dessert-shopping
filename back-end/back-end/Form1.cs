using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace back_end
{
    public partial class Form1 : Form
    {
        SqlConnectionStringBuilder sccb;
        string strDBConnectString = "";

        List<string> listname = new List<string>();
        List<string> listPrice = new List<string>();
        List<string> listQuantity = new List<string>();
        bool isState = false;



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            texBox修改數量.Text = "1";
            FormLogin formLogin = new FormLogin();
            formLogin.ShowDialog();
            if (chk外帶.Checked)
                groupBox內用.Show();
            else
                groupBox內用.Hide();
            lbl會員名稱.Text = FormLogin.姓名;
            comboBox新增品項.Items.Add("史多倫蛋糕");
            comboBox新增品項.Items.Add("法國歌劇巧克力可頌");
            comboBox新增品項.Items.Add("法國國王派");
            comboBox新增品項.Items.Add("法式純巧克力蛋糕");
            comboBox新增品項.Items.Add("寇露蕾派捲");
            comboBox新增品項.SelectedIndex = 0;
            groupBox0.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            sccb = new SqlConnectionStringBuilder();
            sccb.DataSource = @".";
            sccb.InitialCatalog = "order-shopping";
            sccb.IntegratedSecurity = true;
            strDBConnectString = sccb.ToString();
            產生會員資料列表();
        }
        void 產生會員資料列表()
        {
            SqlConnection con = new SqlConnection(strDBConnectString);
            con.Open();
            string strSQL = "select * from order_cart as ord inner join customers as cut on ord.user_id=cut.user_id";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)//判斷有沒有資料
            {
                DataTable dt = new DataTable();
                dt.Load(reader);//匯入資料
                dgv訂單詳情.DataSource = dt;
                //DGV會員資料.DataSource = dt;
            }
            reader.Close();
            con.Close();

        }

        private void dgv訂單詳情_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                groupBox0.Visible = false;
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                groupBox3.Visible = false;
                groupBox4.Visible = false;
                string strSelectedID = dgv訂單詳情.Rows[e.RowIndex].Cells[0].Value.ToString();
                int intSelectedID = 0;
                bool isID = Int32.TryParse(strSelectedID, out intSelectedID);
                //if (isID = true)
                if (isID)
                {
                    SqlConnection conn = new SqlConnection(strDBConnectString);
                    conn.Open();
                    string strSQL = "select * from order_cart as ord inner join customers as cut on ord.user_id=cut.user_id where ord.user_id =@SearchID;";
                    SqlCommand cmd = new SqlCommand(strSQL, conn);
                    cmd.Parameters.AddWithValue("@SearchID", intSelectedID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read() == true)
                    {
                        lblID.Text = reader["user_id"].ToString();
                        txt訂購人.Text = reader["user_name"].ToString();
                        txt電話.Text = reader["user_phone"].ToString();
                        chk外帶.Checked = Convert.ToBoolean(reader["istakeaway"]);
                        isState = Convert.ToBoolean(reader["isstate"]);
                        //Console.WriteLine(reader["user_time"].ToString()); 

                        DateTime dateTime = DateTime.ParseExact(reader["user_time"].ToString(), "yyyyMMddHH", null); ;
                        Console.WriteLine(dateTime);
                        dateTimePicker預約時間.Value = dateTime;

                        numericUpDown預約人數.Value = (int)reader["user_sum"];
                        if (isState)
                        {
                            lbl是否結單.Text = "已結單";
                        }
                        else
                        {
                            lbl是否結單.Text = "未結單";
                        }
                        string 單價;
                        string 數量;
                        string 名稱;
                        int 總價 = 0;
                        數量 = reader["product_quantity"].ToString();
                        單價 = reader["product_price"].ToString();
                        名稱 = reader["product_name"].ToString();
                        lbl總數量.Text = reader["product_sum"].ToString();
                        listname = 名稱?.Split(',').ToList();
                        listQuantity =數量?.Split(',').ToList();
                        listPrice = 單價?.Split(',').ToList();
                        for (int i = 0 ; i < listPrice.Count; i++){
                            //txt訂單名稱 txt數量
                            (this.Controls.Find("lbl訂單名稱" + i.ToString(), true)[0]).Text = listname.ElementAt(i).ToString();
                            (this.Controls.Find("lbl數量" + i.ToString(), true)[0]).Text = listQuantity.ElementAt(i).ToString();
                            ((Label)this.Controls.Find("lbl單價" + i.ToString(), true)[0]).Text = listPrice.ElementAt(i).ToString();
                            (this.Controls.Find("groupBox" + i.ToString(), true)[0]).Visible = true;
                            
                            總價 += Int32.Parse(listQuantity.ElementAt(i)) * Int32.Parse(listPrice.ElementAt(i));
                        }
                        
                        lbl總價.Text = 總價.ToString();


                    }
                    else
                    {
                        //清空欄位();
                        MessageBox.Show("查無此人");
                    }
                    reader.Close();
                    conn.Close();
                }
            }
        }

        private void groupBox資料欄位_Enter(object sender, EventArgs e)
        {

        }

        private void btn新增資料_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            //int intID = 0;
            //Int32.TryParse(lblID.Text, out intID);
            ////intID > 0 && txt訂購人.Text != ""
            //if (txt訂購人.Text != "" && txt電話.Text != "")
            //{
            //    //listname.Count != 0
            //    if (listname.Count != 0)
            //    {
            //        SqlConnection con = new SqlConnection(strDBConnectString);
            //        con.Open();
            //        string strSQL = "insert into order_cart values(@NewProductName,@NewProductQuantity,@NewProductPrice,@NewProductSum,@NewIsTakeAway,@NewIsState)";
            //        string strSQL2 = "insert into customers values(@NewUserName,@NewUserPhone)";
            //        SqlCommand cmd = new SqlCommand(strSQL, con);
            //        SqlCommand cmd2 = new SqlCommand(strSQL2, con);
            //        string 訂單名字 = "";
            //        foreach (string str訂單名字 in listname)
            //        {
            //            if (訂單名字 == "")
            //                訂單名字 += str訂單名字;
            //            else
            //                訂單名字 += "," + str訂單名字;
            //        }
            //        string 訂單數量 = "";
            //        foreach (string str訂單數量 in listQuantity)
            //        {
            //            if (訂單數量 == "")
            //                訂單數量 += str訂單數量;
            //            else
            //                訂單數量 += "," + str訂單數量;
            //        }
            //        string 訂單價格 = "";
            //        foreach (string str訂單價格 in listPrice)
            //        {
            //            if (訂單價格 == "")
            //                訂單價格 += str訂單價格;
            //            else
            //                訂單價格 += "," + str訂單價格;
            //        }
            //        cmd.Parameters.AddWithValue("@NewProductName", 訂單名字);
            //        cmd.Parameters.AddWithValue("@NewProductQuantity", 訂單數量);
            //        cmd.Parameters.AddWithValue("@NewProductPrice", 訂單價格);
            //        cmd.Parameters.AddWithValue("@NewProductSum", lbl總數量);
            //        cmd.Parameters.AddWithValue("@NewIsTakeAway", chk外帶.Checked);
            //        cmd.Parameters.AddWithValue("@NewIsState", false);
            //        cmd2.Parameters.AddWithValue("@NewUserName", txt訂購人.Text);
            //        cmd2.Parameters.AddWithValue("@NewUserPhone", txt電話.Text);
            //        int row = cmd.ExecuteNonQuery();
            //        int row2 = cmd2.ExecuteNonQuery();
            //        con.Close();
            //        if (row != 0 && row2 != 0)
            //            MessageBox.Show($"新增訂單成功!");
            //    }
            //    else MessageBox.Show($"請添加訂單!");
            //}
        }

        private void btn修改資料_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(texBox修改數量.Text) != 0 )
            {
                int ID = Int32.Parse(lblID.Text);
                int temp = listname.IndexOf(comboBox新增品項.Text);
                if (temp != -1)
                {
                    listQuantity[temp] = (Int32.Parse(listQuantity[temp]) + Int32.Parse(texBox修改數量.Text)).ToString();

                    if (Int32.Parse(listQuantity[temp]) <= 0)
                    {
                        listname.RemoveAt(temp);
                        listQuantity.RemoveAt(temp);
                        listPrice.RemoveAt(temp);
                    }
                }
                else
                {
                    listname.Add(comboBox新增品項.Text);
                    listQuantity.Add(texBox修改數量.Text);
                    listPrice.Add(lbl新增價格.Text);
                }

                SqlConnection con = new SqlConnection(strDBConnectString);
                con.Open();
                string strSQL = "update order_cart set product_name=@NewProductName,product_quantity=@NewProductQuantity,product_price=@NewProductPrice,product_sum=@NewProductSum,istakeaway=@NewIsTakeAway where user_id =@NewUserID";
                string strSQL2 = "update customers set user_name=@NewUserName,user_phone=@NewUserPhone,user_sum=@NewUserSum,user_time=@NewUserTime where user_id =@NewUserID";
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
                //
                int 總數量 = 0;
                for (int i = 0; i < listQuantity.Count; i++)
                {
                    lbl總價.Text = (Int32.Parse(listPrice[i]) * Int32.Parse(listQuantity[i])).ToString();
                    總數量 += Int32.Parse(listQuantity[i]);
                    lbl總數量.Text = 總數量.ToString();
                    Console.WriteLine(lbl總數量.Text);
                }

                cmd.Parameters.AddWithValue("@NewUserID", lblID.Text);
                cmd.Parameters.AddWithValue("@NewProductName", 訂單名字);
                cmd.Parameters.AddWithValue("@NewProductQuantity", 訂單數量);
                cmd.Parameters.AddWithValue("@NewProductPrice", 訂單價格);
                cmd.Parameters.AddWithValue("@NewProductSum", lbl總數量.Text);
                cmd.Parameters.AddWithValue("@NewIsTakeAway", chk外帶.Checked);
                cmd2.Parameters.AddWithValue("@NewUserID", lblID.Text);
                cmd2.Parameters.AddWithValue("@NewUserName", txt訂購人.Text);
                cmd2.Parameters.AddWithValue("@NewUserPhone", txt電話.Text);
                cmd2.Parameters.AddWithValue("@NewUserSum", (int)numericUpDown預約人數.Value);
                cmd2.Parameters.AddWithValue("@NewUserTime", dateTimePicker預約時間.Value.Year.ToString() + dateTimePicker預約時間.Value.Month.ToString() + dateTimePicker預約時間.Value.Day.ToString() + dateTimePicker預約時間.Value.Hour.ToString());
                int row = cmd.ExecuteNonQuery();
                int row2 = cmd2.ExecuteNonQuery();
                con.Close();
                if (row != 0 && row2 != 0)
                {
                    MessageBox.Show($"修改訂單成功!");
                    刷新頁面(ID);
                }
                else MessageBox.Show($"修改訂單失敗!");

            }
            else if (chk外帶.Checked)
            {
                int ID = Int32.Parse(lblID.Text);
                int temp = listname.IndexOf(comboBox新增品項.Text);
                if (temp != -1)
                {
                    listQuantity[temp] = (Int32.Parse(listQuantity[temp]) + Int32.Parse(texBox修改數量.Text)).ToString();

                    if (Int32.Parse(listQuantity[temp]) <= 0)
                    {
                        listname.RemoveAt(temp);
                        listQuantity.RemoveAt(temp);
                        listPrice.RemoveAt(temp);
                    }
                }
                else
                {
                    listname.Add(comboBox新增品項.Text);
                    listQuantity.Add(texBox修改數量.Text);
                    listPrice.Add(lbl新增價格.Text);
                }

                SqlConnection con = new SqlConnection(strDBConnectString);
                con.Open();
                string strSQL = "update order_cart set product_name=@NewProductName,product_quantity=@NewProductQuantity,product_price=@NewProductPrice,product_sum=@NewProductSum,istakeaway=@NewIsTakeAway where user_id =@NewUserID";
                string strSQL2 = "update customers set user_name=@NewUserName,user_phone=@NewUserPhone,user_sum=@NewUserSum,user_time=@NewUserTime where user_id =@NewUserID";
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
                //
                int 總數量 = 0;
                for (int i = 0; i < listQuantity.Count; i++)
                {
                    lbl總價.Text = (Int32.Parse(listPrice[i]) * Int32.Parse(listQuantity[i])).ToString();
                    總數量 += Int32.Parse(listQuantity[i]);
                    lbl總數量.Text = 總數量.ToString();
                    Console.WriteLine(lbl總數量.Text);
                }

                cmd.Parameters.AddWithValue("@NewUserID", lblID.Text);
                cmd.Parameters.AddWithValue("@NewProductName", 訂單名字);
                cmd.Parameters.AddWithValue("@NewProductQuantity", 訂單數量);
                cmd.Parameters.AddWithValue("@NewProductPrice", 訂單價格);
                cmd.Parameters.AddWithValue("@NewProductSum", lbl總數量.Text);
                cmd.Parameters.AddWithValue("@NewIsTakeAway", chk外帶.Checked);
                cmd2.Parameters.AddWithValue("@NewUserID", lblID.Text);
                cmd2.Parameters.AddWithValue("@NewUserName", txt訂購人.Text);
                cmd2.Parameters.AddWithValue("@NewUserPhone", txt電話.Text);
                cmd2.Parameters.AddWithValue("@NewUserSum", (int)numericUpDown預約人數.Value);
                cmd2.Parameters.AddWithValue("@NewUserTime", dateTimePicker預約時間.Value.Year.ToString() + dateTimePicker預約時間.Value.Month.ToString() + dateTimePicker預約時間.Value.Day.ToString() + dateTimePicker預約時間.Value.Hour.ToString());
                int row = cmd.ExecuteNonQuery();
                int row2 = cmd2.ExecuteNonQuery();
                con.Close();
                if (row != 0 && row2 != 0)
                {
                    MessageBox.Show($"修改訂單成功!");
                    刷新頁面(ID);
                }
                else MessageBox.Show($"修改訂單失敗!");
            }
            else MessageBox.Show("請輸入修改數量!");
        }


        private void btn刪除資料_Click(object sender, EventArgs e)
        {
            //DELETE FROM table_name
            //WHERE column_name operator value;
            int ID = Int32.Parse(lblID.Text);
            if (ID >= 0)
            {
                SqlConnection con = new SqlConnection(strDBConnectString);
                con.Open();
                string strSQL = "delete from order_cart where user_id =@NewUserID";
                string strSQL2 = "delete from customers where user_id =@NewUserID";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                SqlCommand cmd2 = new SqlCommand(strSQL2, con);
                cmd.Parameters.AddWithValue("@NewUserID", ID);
                cmd2.Parameters.AddWithValue("@NewUserID", ID);
                int row = cmd.ExecuteNonQuery();
                int row2 = cmd2.ExecuteNonQuery();
                con.Close();
                if (row != 0 && row2 != 0)
                {
                    MessageBox.Show($"刪除訂單成功!");
                    產生會員資料列表();
                }
                else MessageBox.Show($"刪除訂單失敗!");
            }
            else
                MessageBox.Show("請選擇一個訂單");
        }

        private void btn取消訂單_Click(object sender, EventArgs e)
        {
            if(isState == true)
            {
                
                SqlConnection con = new SqlConnection(strDBConnectString);
                con.Open();
                string strSQL = "update order_cart set isstate=@NewIsState where user_id =@NewUserID";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@NewIsState", false);
                cmd.Parameters.AddWithValue("@NewUserID", lblID.Text);
                int row = cmd.ExecuteNonQuery();
                if (row != 0)
                {
                    isState = false;
                    lbl是否結單.Text = "未結單";
                    MessageBox.Show("已取消該筆訂單!");
                }
            }
            else
            {
                MessageBox.Show("此訂單未審核");
            }
        }

        private void btn確認資料_Click(object sender, EventArgs e)
        {
            if (isState == false)
            {
                SqlConnection con = new SqlConnection(strDBConnectString);
                con.Open();
                string strSQL = "update order_cart set isstate=@NewIsState where user_id =@NewUserID";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@NewIsState", true);
                cmd.Parameters.AddWithValue("@NewUserID", lblID.Text);
                int row = cmd.ExecuteNonQuery();
                if (row != 0)
                {
                    isState = true;
                    lbl是否結單.Text = "已結單";
                    MessageBox.Show("審核訂單成功!!");
                }
            }
            else
            {
                MessageBox.Show("此訂單已審核過了");
            }
        }

        private void comboBox名稱_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox新增品項.SelectedIndex == 0)
            {
                lbl新增價格.Text = "480";
            }
            else if(comboBox新增品項.SelectedIndex == 1)
            {
                lbl新增價格.Text = "150";
            }
            else if (comboBox新增品項.SelectedIndex == 2)
            {
                lbl新增價格.Text = "980";
            }
            else if (comboBox新增品項.SelectedIndex == 3)
            {
                lbl新增價格.Text = "620";
            }
            else if (comboBox新增品項.SelectedIndex == 4)
            {
                lbl新增價格.Text = "120";
            }

        }

        void 刷新頁面(int index)
        {
                groupBox0.Visible = false;
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                groupBox3.Visible = false;
                groupBox4.Visible = false;
                if (index > 0)
                {
                    SqlConnection conn = new SqlConnection(strDBConnectString);
                    conn.Open();
                    string strSQL = "select * from order_cart as ord inner join customers as cut on ord.user_id=cut.user_id where ord.user_id =@SearchID;";
                    SqlCommand cmd = new SqlCommand(strSQL, conn);
                    cmd.Parameters.AddWithValue("@SearchID", index);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read() == true)
                    {
                        lblID.Text = reader["user_id"].ToString();
                        txt訂購人.Text = reader["user_name"].ToString();
                        txt電話.Text = reader["user_phone"].ToString();
                        chk外帶.Checked = Convert.ToBoolean(reader["istakeaway"]);
                        //dateTimePicker預約時間.Value = Convert.ToDateTime(reader["user_time"]);
                        //numericUpDown預約人數.Value = (int)reader["user_sum"];
                        string 單價;
                        string 數量;
                        string 名稱;
                        int 總價 = 0;
                        數量 = reader["product_quantity"].ToString();
                        單價 = reader["product_price"].ToString();
                        名稱 = reader["product_name"].ToString();
                        lbl總數量.Text = reader["product_sum"].ToString();
                        listname = 名稱?.Split(',').ToList();
                        listQuantity = 數量?.Split(',').ToList();
                        listPrice = 單價?.Split(',').ToList();
                        for (int i = 0; i < listPrice.Count; i++)
                        {
                            (this.Controls.Find("lbl訂單名稱" + i.ToString(), true)[0]).Text = listname.ElementAt(i).ToString();
                            (this.Controls.Find("lbl數量" + i.ToString(), true)[0]).Text = listQuantity.ElementAt(i).ToString();
                            ((Label)this.Controls.Find("lbl單價" + i.ToString(), true)[0]).Text = listPrice.ElementAt(i).ToString();
                            (this.Controls.Find("groupBox" + i.ToString(), true)[0]).Visible = true;

                            總價 += Int32.Parse(listQuantity.ElementAt(i)) * Int32.Parse(listPrice.ElementAt(i));
                        }

                        lbl總價.Text = 總價.ToString();


                    
                    
                    reader.Close();
                    conn.Close();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //pictureBox1.Image.
        }

        private void chk外帶_CheckedChanged(object sender, EventArgs e)
        {
            if (chk外帶.Checked)
                groupBox內用.Show();
            else
                groupBox內用.Hide();
        }
    }
}
