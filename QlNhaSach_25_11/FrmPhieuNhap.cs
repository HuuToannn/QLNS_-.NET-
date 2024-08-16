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
    public partial class FrmPhieuNhap : Form
    {
        private string connectionString = Properties.Settings.Default.ConStr;
        SqlCommand command;
        SqlConnection connection;
        private int soluongnhapcu;
        private string masach;


        public FrmPhieuNhap()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            txt_manv.Text = Properties.Settings.Default.MaNV;
            txt_maSachNhap.Enabled = false;
            txt_dongiaNhap.Enabled = false;
            try
            {
                // Initialize the connection object
                connection = new SqlConnection(connectionString);

                // Open the connection here
                connection.Open();

                
                // Use using to automatically release resources of adapter and connection
                string Query = "SELECT PN.MA_PN, PN.NGAY_NHAP, PN.MANV, NCC.TEN_NCC, CT.MASACH, CT.SL_NHAP, CT.GIA_NHAP, CT.GIA_NHAP * CT.SL_NHAP AS THANH_TIEN " +
                                   "FROM PHIEUNHAP PN " +
                                   "JOIN NHACC NCC ON PN.MA_NCC = NCC.MA_NCC " +
                                   "JOIN CT_PHIEUNHAP CT ON PN.MA_PN = CT.MA_PN;" +
                                   "SELECT * FROM SACH;";
                using (SqlDataAdapter adapter = new SqlDataAdapter(Query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
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


        private void FrmPhieuNhap_Load_1(object sender, EventArgs e)
        {
            txt_manv.Text = Properties.Settings.Default.MaNV;
            txt_manv.Enabled = false;
            txt_dongiaNhap.Enabled = false;
            txtSoLuongTon.Enabled = false;
            txtTenSach.Enabled = false;

            try
            {
                // Open the connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    LoadData();

                    // Use the existing 'command' variable declared at the class level
                    command = connection.CreateCommand();
                    command.CommandText = "SELECT DISTINCT TEN_NCC FROM NHACC";

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        cb_Nhacc.Items.Add(reader["TEN_NCC"].ToString());
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Assuming your columns are in order: MA_PN, NGAY_NHAP, MANV, TEN_NCC, SL_NHAP, GIA_NHAP, THANH_TIEN
                txt_MaPN.Text = row.Cells["MA_PN"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(row.Cells["NGAY_NHAP"].Value);
                txt_maSachNhap.Text = row.Cells["MASACH"].Value.ToString();
                txt_manv.Text = row.Cells["MANV"].Value.ToString();
                cb_Nhacc.Text = row.Cells["TEN_NCC"].Value.ToString();
                txt_soluong.Text = row.Cells["SL_NHAP"].Value.ToString();
                txt_dongiaNhap.Text = row.Cells["GIA_NHAP"].Value.ToString();

                
                soluongnhapcu = Convert.ToInt32(txt_soluong.Text);
                masach = txt_maSachNhap.Text;
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.ConStr))
                {
                    con.Open();
                    string sql = "SELECT * FROM SACH WHERE MaSach = '" + masach + "'";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Lấy thông tin từ cơ sở dữ liệu
                        string masach = reader["MaSach"].ToString();
                        string tensach = reader["TenSach"].ToString();
                        decimal GiaBan = Convert.ToInt32(reader["GiaBan"]);
                        int soluongton = Convert.ToInt32(reader["SoLuongTon"]);

                        txt_maSachNhap.Text = masach;
                        txtTenSach.Text = tensach;
                        txt_dongiaNhap.Text = GiaBan.ToString();
                        txtSoLuongTon.Text = soluongton.ToString();
                        // Xuất thông tin vào các Label

                    }
                }
                //txt_thanhtien.Text = row.Cells["THANH_TIEN"].Value.ToString();
            }
        }
       
        private void txt_MaPN_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_manv_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cb_Nhacc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_maSachNhap_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_dongiaNhap_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_soluong_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void btnThemPN_Click(object sender, EventArgs e)
        {
            try
            {
                int soluongnhap = Convert.ToInt32(txt_soluong.Text);
                int quantity = 0;

                // Kiểm tra xem số lượng nhập vào có phải là số nguyên hợp lệ hay không
                if (!int.TryParse(txt_soluong.Text, out quantity) || quantity <= 0)
                {
                    MessageBox.Show("Vui lòng nhập số lượng hợp lệ.");
                    return;
                }

                // Kiểm tra xem số lượng nhập vào có lớn hơn số lượng tồn không

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            decimal donGia;
                            string maNCC;

                            // Lấy MA_NCC tương ứng với TEN_NCC từ bảng NHACC
                            string selectNCCQuery = "SELECT MA_NCC FROM NHACC WHERE TEN_NCC = @TEN_NCC;";
                            using (SqlCommand selectNCCCommand = new SqlCommand(selectNCCQuery, connection, transaction))
                            {
                                selectNCCCommand.Parameters.AddWithValue("@TEN_NCC", cb_Nhacc.Text);
                                maNCC = selectNCCCommand.ExecuteScalar() as string;

                                if (string.IsNullOrEmpty(maNCC))
                                {
                                    MessageBox.Show("Nhà cung cấp không hợp lệ.");
                                    return;
                                }
                            }

                            // Thêm phiếu nhập
                            string insertPhieuNhapQuery = "INSERT INTO PHIEUNHAP (MA_PN, NGAY_NHAP, MaNV, MA_NCC) " +
                                                          "VALUES (@MA_PN, @NGAY_NHAP, @MaNV, @MA_NCC);";

                            using (SqlCommand insertPhieuNhapCommand = new SqlCommand(insertPhieuNhapQuery, connection, transaction))
                            {
                                // Gán giá trị cho các tham số
                                insertPhieuNhapCommand.Parameters.AddWithValue("@MA_PN", txt_MaPN.Text);
                                insertPhieuNhapCommand.Parameters.AddWithValue("@NGAY_NHAP", DateTime.Now);
                                insertPhieuNhapCommand.Parameters.AddWithValue("@MaNV", txt_manv.Text);
                                insertPhieuNhapCommand.Parameters.AddWithValue("@MA_NCC", maNCC);

                                insertPhieuNhapCommand.ExecuteNonQuery();
                            }

                            // Thêm chi tiết phiếu nhập
                            donGia = Convert.ToDecimal(txt_dongiaNhap.Text);
                            string insertCT_PNQuery = "INSERT INTO CT_PHIEUNHAP(MA_PN, MASACH, SL_NHAP, GIA_NHAP) " +
                                                      "VALUES (@MA_PN, @MASACH, @SL_NHAP, @GIA_NHAP);";

                            using (SqlCommand insertCT_PNCommand = new SqlCommand(insertCT_PNQuery, connection, transaction))
                            {
                                // Gán giá trị cho các tham số
                                insertCT_PNCommand.Parameters.AddWithValue("@MA_PN", txt_MaPN.Text);
                                insertCT_PNCommand.Parameters.AddWithValue("@MASACH", txt_maSachNhap.Text);
                                insertCT_PNCommand.Parameters.AddWithValue("@SL_NHAP", quantity);
                                insertCT_PNCommand.Parameters.AddWithValue("@GIA_NHAP", donGia);

                                // Thực thi truy vấn thêm
                                insertCT_PNCommand.ExecuteNonQuery();
                            }

                            // Cập nhật SoLuongTon trong bảng SACH
                            string updateSoLuongTonQuery = "UPDATE SACH SET SoLuongTon = SoLuongTon + @SL_NHAP WHERE MaSach = @MaSach;";
                            using (SqlCommand updateSoLuongTonCommand = new SqlCommand(updateSoLuongTonQuery, connection, transaction))
                            {
                                // Gán giá trị cho các tham số
                                updateSoLuongTonCommand.Parameters.AddWithValue("@SL_NHAP", quantity);
                                updateSoLuongTonCommand.Parameters.AddWithValue("@MaSach", txt_maSachNhap.Text);

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
            txt_MaPN.Text = "";
            dateTimePicker1.Text = "";
            txt_manv.Text = "";
            txt_maSachNhap.Text = "";
            txt_soluong.Text = "";
            txt_dongiaNhap.Text = "";
        }

        private void btn_SuaPN_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        decimal donGia;
                        string maNCC;

                        // Lấy MA_NCC tương ứng với TEN_NCC từ bảng NHACC
                        string selectNCCQuery = "SELECT MA_NCC FROM NHACC WHERE TEN_NCC = @TEN_NCC;";
                        using (SqlCommand selectNCCCommand = new SqlCommand(selectNCCQuery, connection, transaction))
                        {
                            selectNCCCommand.Parameters.AddWithValue("@TEN_NCC", cb_Nhacc.Text);
                            maNCC = selectNCCCommand.ExecuteScalar() as string;

                            if (string.IsNullOrEmpty(maNCC))
                            {
                                MessageBox.Show("Nhà cung cấp không hợp lệ.");
                                return;
                            }
                        }

                        // Cập nhật phiếu nhập
                        string updatePhieuNhapQuery = "UPDATE PHIEUNHAP SET NGAY_NHAP = @NGAY_NHAP, MANV = @MANV, MA_NCC = @MA_NCC WHERE MA_PN = @MA_PN;";
                        using (SqlCommand updatePhieuNhapCommand = new SqlCommand(updatePhieuNhapQuery, connection, transaction))
                        {
                            // Gán giá trị cho các tham số
                            updatePhieuNhapCommand.Parameters.AddWithValue("@MA_PN", txt_MaPN.Text);
                            updatePhieuNhapCommand.Parameters.AddWithValue("@NGAY_NHAP", DateTime.Now);
                            updatePhieuNhapCommand.Parameters.AddWithValue("@MANV", txt_manv.Text);
                            updatePhieuNhapCommand.Parameters.AddWithValue("@MA_NCC", maNCC);

                            updatePhieuNhapCommand.ExecuteNonQuery();
                        }

                        // Cập nhật chi tiết phiếu nhập
                        donGia = Convert.ToDecimal(txt_dongiaNhap.Text);
                        string updateCTPhieuNhapQuery = "UPDATE CT_PHIEUNHAP SET SL_NHAP = @SL_NHAP, GIA_NHAP = @GIA_NHAP WHERE MA_PN = @MA_PN AND MASACH = @MASACH;";
                        using (SqlCommand updateCTPhieuNhapCommand = new SqlCommand(updateCTPhieuNhapQuery, connection, transaction))
                        {
                            // Gán giá trị cho các tham số
                            updateCTPhieuNhapCommand.Parameters.AddWithValue("@MA_PN", txt_MaPN.Text);
                            updateCTPhieuNhapCommand.Parameters.AddWithValue("@MASACH", txt_maSachNhap.Text);
                            updateCTPhieuNhapCommand.Parameters.AddWithValue("@SL_NHAP", int.Parse(txt_soluong.Text));
                            updateCTPhieuNhapCommand.Parameters.AddWithValue("@GIA_NHAP", donGia);

                            updateCTPhieuNhapCommand.ExecuteNonQuery();
                        }

                        // Cập nhật lại số lượng tồn trong bảng SACH
                        string updateSoLuongTonQuery = "UPDATE SACH SET SoLuongTon = SoLuongTon - @SoLuong WHERE MaSach = @MaSach;";
                        using (SqlCommand updateSoLuongTonCommand = new SqlCommand(updateSoLuongTonQuery, connection, transaction))
                        {
                            // Set parameters
                            updateSoLuongTonCommand.Parameters.AddWithValue("@SoLuong", soluongnhapcu);
                            updateSoLuongTonCommand.Parameters.AddWithValue("@MaSach", masach);

                            // Execute the update query
                            updateSoLuongTonCommand.ExecuteNonQuery();
                        }
                        string updateSoLuongTonQuery1 = "UPDATE SACH SET SoLuongTon = SoLuongTon + @SoLuong WHERE MaSach = @MaSach;";
                        using (SqlCommand updateSoLuongTonCommand = new SqlCommand(updateSoLuongTonQuery1, connection, transaction))
                        {
                            // Set parameters
                            updateSoLuongTonCommand.Parameters.AddWithValue("@SoLuong", txt_soluong.Text);
                            updateSoLuongTonCommand.Parameters.AddWithValue("@MaSach", txt_maSachNhap.Text);

                            // Execute the update query
                            updateSoLuongTonCommand.ExecuteNonQuery();
                        }

                        // Commit giao dịch
                        transaction.Commit();

                        MessageBox.Show("Phiếu nhập đã được cập nhật thành công.");
                        LoadData(); // Refresh dữ liệu
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


        private void btn_xoaPN_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xoá phiếu nhập này?", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    try
                    {
                        // Assuming txt_MaPN is a TextBox control on your form.
                        string maPN = txt_MaPN.Text.Trim();

                        // Delete from CT_PHIEUNHAP table
                        string deleteCTPhieuNhapQuery = "DELETE FROM CT_PHIEUNHAP WHERE MA_PN = '{maPN}';";

                        using (SqlCommand deleteCTPhieuNhapCommand = new SqlCommand(deleteCTPhieuNhapQuery, connection))
                        {
                            deleteCTPhieuNhapCommand.ExecuteNonQuery();
                        }

                        // Delete from PHIEUNHAP table
                        string deletePhieuNhapQuery = "DELETE FROM PHIEUNHAP WHERE MA_PN = '{maPN}';";

                        using (SqlCommand deletePhieuNhapCommand = new SqlCommand(deletePhieuNhapQuery, connection))
                        {
                            deletePhieuNhapCommand.ExecuteNonQuery();
                        }

                        MessageBox.Show("Phiếu nhập đã được xoá thành công.");
                        LoadData(); // Refresh the data
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }
        }

        

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        
        
        
        private void btn_Thoat_Click(object sender, EventArgs e)
        {

            // Lấy IDQuyen của người dùng từ cơ sở dữ liệu hoặc từ nơi nào đó
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

        private void label5_Click(object sender, EventArgs e)
        {

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
                    txt_maSachNhap.Text = FormSach.SelectedMaSach;
                    txtTenSach.Text = FormSach.SelectedTensach;
                    txt_dongiaNhap.Text = FormSach.SelectedDonGia.ToString();
                    txtSoLuongTon.Text = FormSach.SelectedSoluongTon.ToString();
                }
            }
        }
    }
}
