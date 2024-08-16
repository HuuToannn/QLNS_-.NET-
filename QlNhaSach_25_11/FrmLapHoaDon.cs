using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace QlNhaSach_25_11
{
    public partial class FrmLapHoaDon : Form
    {
        public FrmLapHoaDon()
        {
            InitializeComponent();
        }
        SqlConnection connection;
        SqlCommand command;
        string connectionString = Properties.Settings.Default.ConStr;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        private string selectedCustomerID;
        private string selectedBookID;
        private string selectedMaKH;
        private int soluongcu;
        private string SelectedMaSach;
        private void FrmLapHoaDon_Load_1(object sender, EventArgs e)
        {
            txtMaSach.Enabled = false;
            txtTenSach.Enabled = false;
            txtDonGia.Enabled = false;
            txtSoLuongTon.Enabled = false;
            txt_MaKH_LapHD.Enabled = false;
            dateTimePicker1.Enabled = false;
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                // Initialize the connection object
                connection = new SqlConnection(connectionString);

                // Open the connection here
                connection.Open();

                txt_MaNV.Text = Properties.Settings.Default.MaNV;
                txt_MaNV.Enabled = false;

                // Use using to automatically release resources of adapter and connection
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM HOADON", connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView3.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                // Log the error and display an error message
                System.IO.File.WriteAllText("error_log.txt", ex.ToString());
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the connection in the finally block to ensure it is closed even if an exception occurs
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }


        private void dataGridView3_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i = dataGridView3.CurrentRow.Index;
                txtMaHD.Text = dataGridView3.Rows[i].Cells[0].Value.ToString();
                txt_MaNV.Text = dataGridView3.Rows[i].Cells[1].Value.ToString();
                txt_MaKH_LapHD.Text = dataGridView3.Rows[i].Cells[2].Value.ToString();
                txtMaSach.Text = dataGridView3.Rows[i].Cells[3].Value.ToString();
                dateTimePicker1.Text = dataGridView3.Rows[i].Cells[4].Value.ToString();
                txt_SoLuong.Text = dataGridView3.Rows[i].Cells[5].Value.ToString();
                txtDonGia.Text = dataGridView3.Rows[i].Cells[6].Value.ToString();
                // Add other fields as needed

                // Update the selected IDs
                selectedCustomerID = txt_MaKH_LapHD.Text;
                selectedMaKH = txt_MaKH_LapHD.Text;
                selectedBookID = txtMaSach.Text;
                soluongcu = Convert.ToInt32(txt_SoLuong.Text);
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.ConStr))
                {
                    con.Open();
                    string sql = "SELECT * FROM SACH WHERE MaSach = '" + selectedBookID + "'";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Lấy thông tin từ cơ sở dữ liệu
                        string masach = reader["MaSach"].ToString();
                        string tensach = reader["TenSach"].ToString();
                        decimal GiaBan = Convert.ToInt32(reader["GiaBan"]);
                        int soluongton = Convert.ToInt32(reader["SoLuongTon"]);

                        txtMaSach.Text = masach;
                        txtTenSach.Text = tensach;
                        txtDonGia.Text = GiaBan.ToString();
                        txtSoLuongTon.Text = soluongton.ToString();
                        // Xuất thông tin vào các Label

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        

        

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHD.Text))
            {
                // Nếu txt_Tim trở thành rỗng, hiển thị lại tất cả sản phẩm
                LoadData();
            }
        }








      

        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_TimHD_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Open connection
                connection.Open();

                // Get MaHD from the text box
                string maHD = txtMaHD.Text.Trim();

                // Create a SqlCommand to select data from the HOADON table based on MaHD
                string query = "SELECT * FROM HOADON WHERE MaHD = @MaHD";
                using (command = new SqlCommand(query, connection))
                {
                    // Add a parameter to the SqlCommand
                    command.Parameters.AddWithValue("@MaHD", maHD);

                    // Create a SqlDataAdapter to fetch data from the database
                    using (adapter = new SqlDataAdapter(command))
                    {
                        // Create a DataTable to store the retrieved data
                        DataTable resultTable = new DataTable();

                        // Fill the DataTable with data from the SqlDataAdapter
                        adapter.Fill(resultTable);

                        // Attach the DataTable to the DataGridView
                        dataGridView3.DataSource = resultTable;

                        // Display a message if no records are found
                        if (resultTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Không tìm thấy bản ghi cho MaHD: " + maHD);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., display an error message)
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the connection in the finally block to ensure it is closed even if an exception occurs
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }


        private void btn_ThemHD_Click_1(object sender, EventArgs e)
        {
            try
            {
                int soluongton = Convert.ToInt32(txtSoLuongTon.Text);
                int quantity = 0;

                // Kiểm tra xem số lượng nhập vào có phải là số nguyên hợp lệ hay không
                if (!int.TryParse(txt_SoLuong.Text, out quantity) || quantity <= 0)
                {
                    MessageBox.Show("Vui lòng nhập số lượng hợp lệ.");
                    return;
                }

                // Kiểm tra xem số lượng nhập vào có lớn hơn số lượng tồn không
                if (quantity > soluongton)
                {
                    MessageBox.Show("Số lượng nhập vào vượt quá số lượng tồn. Vui lòng nhập số lượng hợp lệ.");
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Bắt đầu một giao dịch SQL
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            decimal donGia;
                            string insertHoaDonQuery = "INSERT INTO HOADON (MaHD, MaNV, MaKH, MaSach, NgayLap, SoLuong, DonGia, ThanhTien) " +
                                                       "VALUES (@MaHD, @MaNV, @MaKH, @MaSach, @NgayLap, @SoLuong, @DonGia, @ThanhTien);";

                            using (SqlCommand insertHoaDonCommand = new SqlCommand(insertHoaDonQuery, connection, transaction))
                            {
                                // Gán giá trị cho các tham số
                                insertHoaDonCommand.Parameters.AddWithValue("@MaHD", txtMaHD.Text);
                                insertHoaDonCommand.Parameters.AddWithValue("@MaNV", txt_MaNV.Text);
                                insertHoaDonCommand.Parameters.AddWithValue("@MaKH", txt_MaKH_LapHD.Text);
                                insertHoaDonCommand.Parameters.AddWithValue("@MaSach", txtMaSach.Text);
                                insertHoaDonCommand.Parameters.AddWithValue("@NgayLap", DateTime.Now);
                                insertHoaDonCommand.Parameters.AddWithValue("@SoLuong", quantity);
                                donGia = Convert.ToDecimal(txtDonGia.Text);
                                insertHoaDonCommand.Parameters.AddWithValue("@DonGia", donGia);

                                // Chuyển đổi và tính toán giá trị tổng tiền
                                decimal thanhTien = donGia * quantity;
                                insertHoaDonCommand.Parameters.AddWithValue("@ThanhTien", thanhTien);

                                // Thực thi truy vấn thêm
                                insertHoaDonCommand.ExecuteNonQuery();
                            }

                            string insertChiTietHoaDonQuery = "INSERT INTO CHITIETHOADON (MaHD, MaSach, SoLuong, GiaTien, ThanhTien) " +
                                                             "VALUES (@MaHD, @MaSach, @SoLuong, @GiaTien, @ThanhTien);";

                            using (SqlCommand insertChiTietHoaDonCommand = new SqlCommand(insertChiTietHoaDonQuery, connection, transaction))
                            {
                                // Gán giá trị cho các tham số
                                insertChiTietHoaDonCommand.Parameters.AddWithValue("@MaHD", txtMaHD.Text);
                                insertChiTietHoaDonCommand.Parameters.AddWithValue("@MaSach", txtMaSach.Text);
                                insertChiTietHoaDonCommand.Parameters.AddWithValue("@SoLuong", quantity);
                                insertChiTietHoaDonCommand.Parameters.AddWithValue("@GiaTien", donGia);

                                // Chuyển đổi và tính toán giá trị tổng tiền cho chi tiết hoá đơn
                                decimal thanhTien = donGia * quantity;
                                insertChiTietHoaDonCommand.Parameters.AddWithValue("@ThanhTien", thanhTien);

                                // Thực thi truy vấn thêm
                                insertChiTietHoaDonCommand.ExecuteNonQuery();
                            }

                            // Cập nhật SoLuongTon trong bảng SACH
                            string updateSoLuongTonQuery = "UPDATE SACH SET SoLuongTon = SoLuongTon - @SoLuong WHERE MaSach = @MaSach;";
                            using (SqlCommand updateSoLuongTonCommand = new SqlCommand(updateSoLuongTonQuery, connection, transaction))
                            {
                                // Gán giá trị cho các tham số
                                updateSoLuongTonCommand.Parameters.AddWithValue("@SoLuong", quantity);
                                updateSoLuongTonCommand.Parameters.AddWithValue("@MaSach", txtMaSach.Text);

                                // Thực thi truy vấn cập nhật
                                updateSoLuongTonCommand.ExecuteNonQuery();
                            }

                            // Commit giao dịch
                            transaction.Commit();

                            MessageBox.Show("Hoá đơn đã được tạo thành công.");
                            LoadData(); // Nạp lại dữ liệu để cập nhật DataGridView3
                        }
                        catch (Exception ex)
                        {
                            // Có lỗi xảy ra, rollback giao dịch
                            transaction.Rollback();
                            MessageBox.Show("Lỗi: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            txtMaHD.Text = "";
            txt_MaNV.Text = "";
            txt_MaKH_LapHD.Text = "";
            txtMaSach.Text = "";
            txtDonGia.Text = "";
            txtSoLuongTon.Text = "";
            txtTenSach.Text = "";
            txt_SoLuong.Text = "";
        }

        private void btn_XoaHD_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if a row is selected
                if (string.IsNullOrEmpty(txtMaHD.Text))
                {
                    MessageBox.Show("Vui lòng chọn một hoá đơn để xoá.");
                    return;
                }

                // Ask for confirmation
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xoá hoá đơn này?", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Begin a SQL transaction
                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                // Delete from CHITIETHOADON table
                                string deleteChiTietHoaDonQuery = "DELETE FROM CHITIETHOADON WHERE MaHD = @MaHD;";
                                using (SqlCommand deleteChiTietHoaDonCommand = new SqlCommand(deleteChiTietHoaDonQuery, connection, transaction))
                                {
                                    deleteChiTietHoaDonCommand.Parameters.AddWithValue("@MaHD", txtMaHD.Text);
                                    deleteChiTietHoaDonCommand.ExecuteNonQuery();
                                }

                                // Delete from HOADON table
                                string deleteHoaDonQuery = "DELETE FROM HOADON WHERE MaHD = @MaHD;";
                                using (SqlCommand deleteHoaDonCommand = new SqlCommand(deleteHoaDonQuery, connection, transaction))
                                {
                                    deleteHoaDonCommand.Parameters.AddWithValue("@MaHD", txtMaHD.Text);
                                    deleteHoaDonCommand.ExecuteNonQuery();
                                }

                                // Commit the transaction
                                transaction.Commit();

                                MessageBox.Show("Hoá đơn đã được xoá thành công.");
                                LoadData(); // Refresh the data
                            }
                            catch (Exception ex)
                            {
                                // Rollback the transaction in case of an error
                                transaction.Rollback();
                                MessageBox.Show("Lỗi: " + ex.Message);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

            // Clear the textboxes after deletion
            txtMaHD.Text = "";
            txt_MaNV.Text = "";
            txt_MaKH_LapHD.Text = "";

            txtMaSach.Text = "";
            txtDonGia.Text = "";
            txtSoLuongTon.Text = "";
            txtTenSach.Text = "";
            txt_SoLuong.Text = "";
        }

        private void btx_SuaHoaDon_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Check if a row is selected
                if (string.IsNullOrEmpty(txtMaHD.Text))
                {
                    MessageBox.Show("Vui lòng chọn một hoá đơn để sửa.");
                    return;
                }

                int soluongton = Convert.ToInt32(txtSoLuongTon.Text);
                int quantity = 0;

                // Validate the quantity
                if (!int.TryParse(txt_SoLuong.Text, out quantity) || quantity <= 0)
                {
                    MessageBox.Show("Vui lòng nhập số lượng hợp lệ.");
                    return;
                }

                // Check if the quantity is within the available stock
                if (quantity > soluongton)
                {
                    MessageBox.Show("Số lượng nhập vào vượt quá số lượng tồn. Vui lòng nhập số lượng hợp lệ.");
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Begin a SQL transaction
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        decimal donGia;
                        try
                        {
                            // Update the HOADON table
                            string updateHoaDonQuery = "UPDATE HOADON SET MaNV = @MaNV, MaKH = @MaKH, MaSach = @MaSach, NgayLap = @NgayLap, " +
                                                       "SoLuong = @SoLuong, DonGia = @DonGia, ThanhTien = @ThanhTien " +
                                                       "WHERE MaHD = @MaHD;";

                            using (SqlCommand updateHoaDonCommand = new SqlCommand(updateHoaDonQuery, connection, transaction))
                            {
                                // Set parameters
                                updateHoaDonCommand.Parameters.AddWithValue("@MaHD", txtMaHD.Text);
                                updateHoaDonCommand.Parameters.AddWithValue("@MaNV", txt_MaNV.Text);
                                updateHoaDonCommand.Parameters.AddWithValue("@MaKH", txt_MaKH_LapHD.Text);
                                updateHoaDonCommand.Parameters.AddWithValue("@MaSach", txtMaSach.Text);
                                updateHoaDonCommand.Parameters.AddWithValue("@NgayLap", DateTime.Now);
                                updateHoaDonCommand.Parameters.AddWithValue("@SoLuong", quantity);
                                donGia = Convert.ToDecimal(txtDonGia.Text);
                                updateHoaDonCommand.Parameters.AddWithValue("@DonGia", donGia);

                                // Calculate and set ThanhTien
                                decimal thanhTien = donGia * quantity;
                                updateHoaDonCommand.Parameters.AddWithValue("@ThanhTien", thanhTien);

                                // Execute the update query
                                updateHoaDonCommand.ExecuteNonQuery();
                            }

                            // Update the CHITIETHOADON table
                            string updateChiTietHoaDonQuery = "UPDATE CHITIETHOADON SET MaSach = @MaSach, SoLuong = @SoLuong, " +
                                                              "GiaTien = @GiaTien, ThanhTien = @ThanhTien " +
                                                              "WHERE MaHD = @MaHD;";

                            using (SqlCommand updateChiTietHoaDonCommand = new SqlCommand(updateChiTietHoaDonQuery, connection, transaction))
                            {
                                // Set parameters
                                updateChiTietHoaDonCommand.Parameters.AddWithValue("@MaHD", txtMaHD.Text);
                                updateChiTietHoaDonCommand.Parameters.AddWithValue("@MaSach", txtMaSach.Text);
                                updateChiTietHoaDonCommand.Parameters.AddWithValue("@SoLuong", quantity);
                                updateChiTietHoaDonCommand.Parameters.AddWithValue("@GiaTien", donGia);

                                // Calculate and set ThanhTien
                                decimal thanhTien = donGia * quantity;
                                updateChiTietHoaDonCommand.Parameters.AddWithValue("@ThanhTien", thanhTien);

                                // Execute the update query
                                updateChiTietHoaDonCommand.ExecuteNonQuery();
                            }

                            // Update the SACH table
                            string updateSoLuongTonQuery = "UPDATE SACH SET SoLuongTon = SoLuongTon + @SoLuong WHERE MaSach = @MaSach;";
                            using (SqlCommand updateSoLuongTonCommand = new SqlCommand(updateSoLuongTonQuery, connection, transaction))
                            {
                                // Set parameters
                                updateSoLuongTonCommand.Parameters.AddWithValue("@SoLuong", soluongcu);
                                updateSoLuongTonCommand.Parameters.AddWithValue("@MaSach", selectedBookID);

                                // Execute the update query
                                updateSoLuongTonCommand.ExecuteNonQuery();
                            }
                            string updateSoLuongTonQuery1 = "UPDATE SACH SET SoLuongTon = SoLuongTon - @SoLuong WHERE MaSach = @MaSach;";
                            using (SqlCommand updateSoLuongTonCommand = new SqlCommand(updateSoLuongTonQuery1, connection, transaction))
                            {
                                // Set parameters
                                updateSoLuongTonCommand.Parameters.AddWithValue("@SoLuong", txt_SoLuong.Text);
                                updateSoLuongTonCommand.Parameters.AddWithValue("@MaSach", txtMaSach.Text);

                                // Execute the update query
                                updateSoLuongTonCommand.ExecuteNonQuery();
                            }

                            // Commit the transaction
                            transaction.Commit();

                            MessageBox.Show("Hoá đơn đã được cập nhật thành công.");
                            LoadData(); // Refresh the data
                        }
                        catch (Exception ex)
                        {
                            // Rollback the transaction in case of an error
                            transaction.Rollback();
                            MessageBox.Show("Lỗi: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void txtMaHD_TextChanged_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHD.Text))
            {
                // Nếu txt_Tim trở thành rỗng, hiển thị lại tất cả sản phẩm
                LoadData();
            }
        }

       



        private void txtMaSach_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtMaSach.Text))
            {
                // Nếu txt_Tim trở thành rỗng, hiển thị lại tất cả sản phẩm
                LoadData();
            }
        }

        private void btn_Thoat_HD_Click(object sender, EventArgs e)
        {
            int idQuyen = Properties.Settings.Default.Role; // Thay thế hàm này bằng cách lấy IDQuyen của người dùng

            if (idQuyen == 1)
            {
                // Nếu là quản trị (IDQuyen == 1), mở FormMain
                FrmMain formMain = new FrmMain();
                formMain.Show();
            }
            else
            {
                // Nếu không phải quản trị, mở FormMainNV
                FrmMainNV formMainNV = new FrmMainNV();
                formMainNV.Show();
            }

            // Đóng form hiện tại
            this.Close();
        }

        

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            txtMaHD.Text = "";
            txt_MaNV.Text = "";
            txt_MaKH_LapHD.Text = "";

            txtMaSach.Text = "";
            txtDonGia.Text = "";
            txtSoLuongTon.Text = "";
            txtTenSach.Text = "";
            txt_SoLuong.Text = "";
            LoadData();
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            FrmKhachHang frmKH = new FrmKhachHang();
            frmKH.Show();
        }

        private void btn_SuaKH_Click(object sender, EventArgs e)
        {
            FrmKhachHang frmKH = new FrmKhachHang();
            frmKH.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if a row is selected
                if (string.IsNullOrEmpty(txt_MaKH_LapHD.Text))
                {
                    MessageBox.Show("Vui lòng chọn một khách hàng để xoá.");
                    return;
                }

                // Ask for confirmation
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xoá khách hàng này?", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Begin a SQL transaction
                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {

                                // Delete from HOADON table
                                string deleteHoaDonQuery = "DELETE FROM KHACHHANG WHERE MaKH = @MaKH;";
                                using (SqlCommand deleteKHCommand = new SqlCommand(deleteHoaDonQuery, connection, transaction))
                                {
                                    deleteKHCommand.Parameters.AddWithValue("@MaKH", txt_MaKH_LapHD.Text);
                                    deleteKHCommand.ExecuteNonQuery();
                                }

                                // Commit the transaction
                                transaction.Commit();

                                MessageBox.Show("Khách hàng đã được xoá thành công.");
                                LoadData(); // Refresh the data
                            }
                            catch (Exception ex)
                            {
                                // Rollback the transaction in case of an error
                                transaction.Rollback();
                                MessageBox.Show("Lỗi: vui lòng xoá hoá đơn có tên KH bạn muốn xoá ");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

            // Clear the textboxes after deletion
            txtMaHD.Text = "";
            txt_MaNV.Text = "";
            txt_MaKH_LapHD.Text = "";
            txtMaSach.Text = "";
            txtDonGia.Text = "";
            txtSoLuongTon.Text = "";
            txtTenSach.Text = "";
            txt_SoLuong.Text = "";
        }

        

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_MaNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private int clickCount = 0;

        

        private void gbDSKH_Enter(object sender, EventArgs e)
        {

        }

        private void txt_MaKH_LapHD_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_SDTKH_HD_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btn_chonKH_Click(object sender, EventArgs e)
        {
             using (FrmKhachHang frmKhachHang = new FrmKhachHang())
             {
            DialogResult result = frmKhachHang.ShowDialog();

            // Kiểm tra xem người dùng đã chọn khách hàng hay chưa
            if (result == DialogResult.OK)
            {
                // Lấy MaKH từ FrmKhachHang và cập nhật vào txt_MaKH_LapHD
                txt_MaKH_LapHD.Text = frmKhachHang.SelectedMaKH;
            }
                }
        }

        private void btn_Chonsach_Click(object sender, EventArgs e)
        {

            using (FrmSach FormSach = new FrmSach())
            {
                DialogResult result = FormSach.ShowDialog();

                // Kiểm tra xem người dùng đã chọn khách hàng hay chưa
                if (result == DialogResult.OK)
                {
                    // Lấy MaKH từ FrmKhachHang và cập nhật vào txt_MaKH_LapHD
                    txtMaSach.Text = FormSach.SelectedMaSach;
                    txtTenSach.Text = FormSach.SelectedTensach;
                    txtDonGia.Text = FormSach.SelectedDonGia.ToString();
                    txtSoLuongTon.Text = FormSach.SelectedSoluongTon.ToString();
                }
            }
            
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void gbThongTinKhachHang_Enter(object sender, EventArgs e)
        {

        }
    }
}
