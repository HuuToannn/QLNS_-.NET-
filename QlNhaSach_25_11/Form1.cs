using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QlNhaSach_25_11
{
    public partial class Form1 : Form
    {
        public string conStr = Properties.Settings.Default.ConStr;
        SqlConnection con;
        public Form1()
        {
            con = new SqlConnection(conStr);
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string username = txtTenDN.Text;
            string password = txtMK.Text;

            try
            {
                con.Open();
                string sql = "SELECT * FROM [USER] WHERE MaNV = '" + username + "' AND PassWord = '" + password + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dta = cmd.ExecuteReader();

                if (dta.Read())
                {
                    int role = Convert.ToInt32(dta["IDQuyen"]);
                    Properties.Settings.Default.MaNV = username;
                    Properties.Settings.Default.Password = password;
                    if (checkBox1.Checked)
                    {
                        
                        Properties.Settings.Default.Save();
                    }

                    Properties.Settings.Default.Role = role;

                    this.Hide();  // Ẩn form đăng nhập

                    if (role == 1)
                    {
                        // Hiển thị form cho vai trò 1
                        FrmMain quanli = new FrmMain();
                        quanli.Show();
                    }
                    else if (role == 2)
                    {
                        // Hiển thị form cho vai trò 2
                        FrmMainNV Nhanvien = new FrmMainNV();
                        Nhanvien.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu !!!");
                    con.Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtTenDN.Text = Properties.Settings.Default.MaNV;
            txtMK.Text = Properties.Settings.Default.Password;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtMK_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
