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

namespace back_end
{
    public partial class FormLogin : Form
    {
        SqlConnectionStringBuilder sccb;
        string strDBConnectString = "";
        bool is驗證 = false;
        public static string 姓名;
        string 密碼;
        string 帳號;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            sccb = new SqlConnectionStringBuilder();
            sccb.DataSource = @".";
            sccb.InitialCatalog = "order-shopping";
            sccb.IntegratedSecurity = true;
            strDBConnectString = sccb.ToString();
            
        }
        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (is驗證)
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void btn登入_Click(object sender, EventArgs e)
        {
            if (txt帳號.Text != "" && txt密碼.Text != "")
            {
                string 帳號 = txt帳號.Text;
                string 密碼 = txt密碼.Text;
                SqlConnection conn = new SqlConnection(strDBConnectString);
                conn.Open();
                string strSQL = $"select * from member where account = '{帳號}' and password = '{密碼}'";
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    if (帳號 == reader["account"].ToString() && 密碼 == reader["password"].ToString())
                    {
                        姓名 = reader["name"].ToString();
                        MessageBox.Show("登入成功");
                        is驗證 =true;
                        Close();
                    }
                }else
                    MessageBox.Show("帳號或密碼錯誤!");

            }
            else
                MessageBox.Show("請輸入帳號密碼");
        }
    }
}
