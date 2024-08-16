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
    public partial class FrmBaoCaoThongKe : Form
    {
        private DataTable originalDataTable;
        SqlCommand command;
        string connectionString = Properties.Settings.Default.ConStr;
        SqlConnection connection;
        int totalSoLuong = 0;
        int tongthanhtien = 0;

        public FrmBaoCaoThongKe()
        {
            InitializeComponent();
        }
        private void LoadHoaDonData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT MaHD, MaNV, MaKH, MaSach, NgayLap, SoLuong, DonGia, ThanhTien FROM HOADON;" +
                               "SELECT * FROM BAOCAOTHONGKE;";
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable dataTable = new DataTable();
                using (command = new SqlCommand(query, connection))
                {
                    using (adapter = new SqlDataAdapter(command))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);

                        // Store the original data
                        originalDataTable = dataSet.Tables[0];

                        dataGridView1.DataSource = originalDataTable;
                        dataGridView2.DataSource = dataSet.Tables[1];
                    }
                }
            }
        }
        private void FrmBaoCaoThongKe_Load(object sender, EventArgs e)
        {

            txt_mabc.Enabled = false;
            txt_SLBR.Enabled = false;
            txt_TongDoanhThu.Enabled = false;
            dateTimePicker1.Enabled = false;
            LoadHoaDonData();
            //btn_Loc.Click += btn_Loc_Click;
        }
        private void FilterHoaDonData(DateTime startDate, DateTime endDate)
        {
            // Check if the originalDataTable is available
            if (originalDataTable == null)
                return;

            DataView dataView = new DataView(originalDataTable);
            dataView.RowFilter = $"NgayLap >= #{startDate:yyyy-MM-dd}# AND NgayLap <= #{endDate:yyyy-MM-dd}#";

            dataGridView1.DataSource = dataView.ToTable();
        }

        private void btn_Loc_Click(object sender, EventArgs e)
        {
            DateTime startDate = NGAYBATDAU.Value;
            DateTime endDate = NGAYKETHUC.Value;

            FilterHoaDonData(startDate, endDate);
            CalculateAndDisplayTotals();
        }

        private void CalculateAndDisplayTotals()
        {
            DataTable filteredTable = (DataTable)dataGridView1.DataSource;

            if (filteredTable != null && filteredTable.Rows.Count > 0)
            {
                totalSoLuong = 0;
                tongthanhtien = 0;

                foreach (DataRow row in filteredTable.Rows)
                {
                    totalSoLuong += Convert.ToInt32(row["SoLuong"]);
                    tongthanhtien += Convert.ToInt32(row["ThanhTien"]);
                }

                txt_TongDoanhThu.Text = tongthanhtien.ToString();
                txt_SLBR.Text = totalSoLuong.ToString();
            }
            else
            {
                // If there is no filtered data, set txt_SLBR to empty or any default value
                txt_SLBR.Text = "";
                txt_TongDoanhThu.Text = "";
            }
        }
        private void txt_MaPL_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_NgayLap_TextChanged(object sender, EventArgs e)
        {

        }


        private void txt_SLBR_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_TongDoanhThu_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_THEM_Click(object sender, EventArgs e)
        {
            DateTime startDate = NGAYBATDAU.Value;
            DateTime endDate = NGAYKETHUC.Value;
            totalSoLuong = 0;
            tongthanhtien = 0;
            FilterHoaDonData(startDate, endDate);

            // Calculate total SoLuong after filtering
            DataTable filteredTable = (DataTable)dataGridView1.DataSource;

            if (filteredTable != null && filteredTable.Rows.Count > 0)
            {
                

                foreach (DataRow row in filteredTable.Rows)
                {
                    totalSoLuong += Convert.ToInt32(row["SoLuong"]);
                    tongthanhtien += Convert.ToInt32(row["ThanhTien"]);
                }

                txt_TongDoanhThu.Text = tongthanhtien.ToString();
                txt_SLBR.Text = totalSoLuong.ToString();

                if (totalSoLuong > 0 && tongthanhtien > 0)
                {
                    // Save data to BAOCAOTHONGKE table
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string insertQuery = "INSERT INTO BAOCAOTHONGKE (NgayLap, NgayThangBatDau, NgayThangKetThuc, SoLuongSachBanDuoc, TongTien, MaNV) " +
                                             "VALUES (GETDATE(), @StartDate, @EndDate, @SoLuongSach, @TongTien, @MaNV)";

                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@StartDate", startDate);
                            command.Parameters.AddWithValue("@EndDate", endDate);
                            command.Parameters.AddWithValue("@SoLuongSach", totalSoLuong);
                            command.Parameters.AddWithValue("@TongTien", tongthanhtien);
                            command.Parameters.AddWithValue("@MaNV", Properties.Settings.Default.MaNV);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    // If there is no filtered data or the totals are 0, handle it accordingly
                    MessageBox.Show("No data to save or totals are 0.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // If there is no filtered data, set txt_SLBR to empty or any default value
                txt_SLBR.Text = "";
                txt_TongDoanhThu.Text = "";
            }
            LoadHoaDonData();
        }
        private void btn_XoaBC_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                // Lấy dòng đã chọn
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];

                // Lấy giá trị của cột MaBC từ dòng đã chọn
                int maBC = Convert.ToInt32(selectedRow.Cells["MaBaoCao"].Value);

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xoá bản ghi này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Người dùng xác nhận muốn xoá, tiến hành xoá
                    XoaBaoCao(maBC);

                    // Tải lại dữ liệu sau khi xoá
                    LoadHoaDonData();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bản ghi để xoá.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void XoaBaoCao(int maBC)
        {
            // Triển khai logic để xoá bản ghi có MaBC tương ứng
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM BAOCAOTHONGKE WHERE MaBaoCao = @MaBaoCao";

                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@MaBaoCao", maBC);

                    command.ExecuteNonQuery();
                }
            }
        }


        private void btn_SuaBaoCao_Click(object sender, EventArgs e)
        {
            // Get the selected row from dataGridView2
            if (dataGridView2.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView2.SelectedRows[0];

                // Extract data from the selected row
                int maBC = Convert.ToInt32(row.Cells[0].Value);
                DateTime ngayLap = Convert.ToDateTime(row.Cells[1].Value);
                DateTime ngayBatDau = Convert.ToDateTime(row.Cells[2].Value);
                DateTime ngayKetThuc = Convert.ToDateTime(row.Cells[3].Value);
                int soLuong = Convert.ToInt32(row.Cells[4].Value);
                int tongTien = Convert.ToInt32(row.Cells[5].Value);

                // Display data in controls
                txt_mabc.Text = maBC.ToString();
                dateTimePicker1.Value = ngayLap;
                NGAYBATDAU.Value = ngayBatDau;
                NGAYKETHUC.Value = ngayKetThuc;
                txt_SLBR.Text = soLuong.ToString();
                txt_TongDoanhThu.Text = tongTien.ToString();

                // Allow the user to modify the start date and end date
                NGAYBATDAU.Enabled = true;
                NGAYKETHUC.Enabled = true;

                // Recalculate SoLuongBanRa based on the new start date and end date
                RecalculateSoLuongBanRa();

            }
            else
            {
                MessageBox.Show("Vui lòng chon 1 phiếu báo cáo cần sửa");
            }
        }
        private void RecalculateSoLuongBanRa()
        {
            DateTime startDate = NGAYBATDAU.Value;
            DateTime endDate = NGAYKETHUC.Value;

            // Thực hiện logic của bạn để tính toán SoLuongBanRa dựa trên ngày bắt đầu và ngày kết thúc mới
            // Ví dụ, bạn có thể truy vấn cơ sở dữ liệu để lấy giá trị đã cập nhật
            int updatedSoLuongBanRa = GetUpdatedSoLuongBanRa(startDate, endDate);

            // Update the displayed value
            txt_SLBR.Text = updatedSoLuongBanRa.ToString();
        }

        private int GetUpdatedSoLuongBanRa(DateTime startDate, DateTime endDate)
        {
            // Thực hiện logic của bạn để truy vấn cơ sở dữ liệu và lấy giá trị SoLuongBanRa đã cập nhật
            // Ví dụ:
            // SELECT SUM(SoLuong) FROM HOADON WHERE NgayLap BETWEEN @StartDate AND @EndDate
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT SUM(SoLuong) FROM HOADON WHERE NgayLap BETWEEN @StartDate AND @EndDate";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    object result = command.ExecuteScalar();

                    return result != DBNull.Value ? Convert.ToInt32(result) : 0;
                    //Kiểm tra nếu giá trị trả về là khác DBNull.Value (nghĩa là truy vấn có kết quả), thì chuyển đổi giá trị
                    //đó sang kiểu int và trả về. Nếu không có kết quả, phương thức trả về 0.
                }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            int maBC = Convert.ToInt32(txt_mabc.Text);
            DateTime ngayLap = dateTimePicker1.Value;
            DateTime ngayBatDau = NGAYBATDAU.Value;
            DateTime ngayKetThuc = NGAYKETHUC.Value;
            int soLuongBanRa = Convert.ToInt32(txt_SLBR.Text);
            int tongTien = Convert.ToInt32(txt_TongDoanhThu.Text);

            // Update the data in the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string updateQuery = "UPDATE BAOCAOTHONGKE " +
                                     "SET NgayLap = @NgayLap, NgayThangBatDau = @NgayBatDau, NgayThangKetThuc = @NgayKetThuc, " +
                                     "SoLuongSachBanDuoc = @SoLuongBanRa, TongTien = @TongTien " +
                                     "WHERE MaBaoCao = @MaBC";

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@NgayLap", ngayLap);
                    command.Parameters.AddWithValue("@NgayBatDau", ngayBatDau);
                    command.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc);
                    command.Parameters.AddWithValue("@SoLuongBanRa", soLuongBanRa);
                    command.Parameters.AddWithValue("@TongTien", tongTien);
                    command.Parameters.AddWithValue("@MaBC", maBC);

                    command.ExecuteNonQuery();
                }
                txt_mabc.Text = "";
                txt_SLBR.Text = "";
                txt_TongDoanhThu.Text = "";
                ngayBatDau.ToString("");
                ngayKetThuc.ToString("");
            }

            // Reload the data to reflect the changes
            LoadHoaDonData();
        }
        private void btn_in_Click(object sender, EventArgs e)
        {

        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                this.Close();
                FrmMain main = new FrmMain();
                main.Show();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void NGAYBATDAU_ValueChanged(object sender, EventArgs e)
        {

        }

        private void NGAYKETHUC_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_mabc_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
