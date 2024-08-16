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
    public partial class THONGTINNHANVIEN : Form
    {
        public THONGTINNHANVIEN()
        {
            InitializeComponent();
        }

        private void THONGTINNHANVIEN_Load(object sender, EventArgs e)
        {

            // Gọi phương thức để lấy thông tin từ cơ sở dữ liệu
            LoadEmployeeInfo(Properties.Settings.Default.MaNV);
        }

        // Phương thức để lấy thông tin từ cơ sở dữ liệu dựa trên Username
        private void LoadEmployeeInfo(string username)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.ConStr))
                {
                    con.Open();
                    string sql = "SELECT * FROM [USER] WHERE MaNV = '" + username + "'";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Lấy thông tin từ cơ sở dữ liệu
                        string maNV = reader["MaNV"].ToString();
                        string hoTen = reader["HoTen"].ToString();
                        string gioiTinh = reader["GioiTinh"].ToString();
                        string sdt = reader["SDT"].ToString();
                        string diaChi = reader["DiaChi"].ToString();

                        // Xuất thông tin vào các Label
                        label1.Text = "Mã NV: " + maNV;
                        label2.Text = "Họ tên: " + hoTen;
                        label3.Text = "Giới tính: " + gioiTinh;
                        label4.Text = "Số điện thoại: " + sdt;
                        label5.Text = "Địa chỉ: " + diaChi;
                        // Lấy và xuất thông tin chức vụ dựa trên IDQuyen
                        int idQuyen = Convert.ToInt32(reader["IDQuyen"]);
                        LoadChucVu(idQuyen);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

        // Phương thức để lấy và xuất thông tin chức vụ từ cơ sở dữ liệu
        private void LoadChucVu(int idQuyen)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.ConStr))
                {
                    con.Open();
                    string sql = "SELECT Name FROM PHANQUYEN WHERE IDQuyen = " + idQuyen;
                    SqlCommand cmd = new SqlCommand(sql, con);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        // Xuất thông tin chức vụ vào Label
                        label6.Text = "Chức vụ: " + result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
