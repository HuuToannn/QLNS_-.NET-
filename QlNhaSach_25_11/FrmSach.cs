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
    public partial class FrmSach : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string connectionString = Properties.Settings.Default.ConStr;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public string SelectedMaSach { get; private set; }
        public string SelectedTensach { get; private set; }
        public decimal SelectedDonGia { get; private set; }
        public int SelectedSoluongTon { get; private set; }
        public FrmSach()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
        }

        private List<string> GetTenTacGia()
        {
            List<string> tenTacGiaList = new List<string>();

            string query = "SELECT TenTG FROM TACGIA";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string tenTacGia = reader.GetString(0);
                    tenTacGiaList.Add(tenTacGia);
                }
            }
            connection.Close();

            return tenTacGiaList;
        }
        private List<string> GetTenTheLoai()
        {
            List<string> tenTheLoaiList = new List<string>();

            string query = "SELECT TenTheLoai FROM THELOAI";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string tenTheLoai = reader.GetString(0);
                    tenTheLoaiList.Add(tenTheLoai);
                }
            }
            connection.Close();

            return tenTheLoaiList;
        }
        private List<string> GetNXB()
        {
            List<string> tenNXBList = new List<string>();

            string query = "SELECT TenNXB FROM NHAXUATBAN";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string tenNXB = reader.GetString(0);
                    tenNXBList.Add(tenNXB);
                }
            }
            connection.Close();

            return tenNXBList;
        }
        private void FrmSach_Load(object sender, EventArgs e)
        {
            string query = "select MaSach, TenTG, TenSach, TenTheLoai, GiaBan, SoLuongTon,TenNXB from SACH, THELOAI,TACGIA ,NHAXUATBAN where SACH.MaTL = THELOAI.MaTheLoai AND SACH.MaTG = TACGIA.MaTG AND SACH.MaNXB = NHAXUATBAN.MaNXB";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
            connection.Close();

            List<string> tenTacGiaList = GetTenTacGia();
            cbb_TacGia.DataSource = tenTacGiaList;

            List<string> tenTheLoaiList = GetTenTheLoai();
            cbb_TheLoai.DataSource = tenTheLoaiList;

            List<string> tenNXBList = GetNXB();
            cbb_NXB.DataSource = tenNXBList;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> missingFields = new List<string>();

                // Kiểm tra xem có ô nào bị thiếu không
                if (string.IsNullOrWhiteSpace(txtMaSach.Text))
                {
                    missingFields.Add("Mã Sách");
                }
                if (string.IsNullOrWhiteSpace(cbb_TheLoai.Text))
                {
                    missingFields.Add("Thể loại");
                }
                if (string.IsNullOrWhiteSpace(txtTenSach.Text))
                {
                    missingFields.Add("Tên Sách");
                }
                if (string.IsNullOrWhiteSpace(cbb_TacGia.Text))
                {
                    missingFields.Add("Tên Tác Giả");
                }
                if (string.IsNullOrWhiteSpace(txtDonGia.Text))
                {
                    missingFields.Add("Đơn giá");
                }
                if (string.IsNullOrWhiteSpace(txtSoLuong.Text))
                {
                    missingFields.Add("Số lượng");
                }
                if (string.IsNullOrWhiteSpace(cbb_NXB.Text))
                {
                    missingFields.Add("NXB");
                }
               

                // Kiểm tra danh sách các ô bị thiếu
                if (missingFields.Count > 0)
                {
                    string missingFieldsMessage = "Chưa nhập:\n";
                    missingFieldsMessage += string.Join(", ", missingFields);
                    MessageBox.Show(missingFieldsMessage, "Thông báo");
                    connection.Close();
                    return; // Dừng việc thực hiện thêm dữ liệu
                }
                string query = "select MaSach, TenTG, TenSach, TenTheLoai, GiaBan, SoLuongTon,TenNXB from SACH, " +
                    "THELOAI,TACGIA ,NHAXUATBAN where SACH.MaTL = THELOAI.MaTheLoai AND SACH.MaTG = TACGIA.MaTG AND SACH.MaNXB = NHAXUATBAN.MaNXB";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    bool isDuplicateMaSach = false;
                    bool isDuplicateTenSach = false;
                    // Kiểm tra từng dòng trong DataGridView
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            string masach = row.Cells["MASACH"].Value.ToString();
                            string tensach = row.Cells["TenSach"].Value.ToString();
                            // Kiểm tra trùng lặp MaKH
                            if (masach == txtMaSach.Text)
                            {
                                isDuplicateMaSach = true;
                                break;
                            }
                            if (tensach == txtTenSach.Text)
                            {
                                isDuplicateTenSach = true;
                                break;
                            }
                        }
                    }
                    if (isDuplicateMaSach)
                    {
                        MessageBox.Show("Trùng mã sách. Vui lòng nhập lại!", "Thông báo");
                    }
                    else if (isDuplicateTenSach)
                    {
                        MessageBox.Show("Trùng tên sách. Vui lòng nhập lại!", "Thông báo");
                    }
                    else
                    {
                        // Thêm dữ liệu vào DataTable từ các TextBox
                        DataRow newRow = dataTable.NewRow();
                        newRow["MASACH"] = txtMaSach.Text;
                        newRow["TenTheLoai"] = cbb_TheLoai.Text;
                        newRow["TENSACH"] = txtTenSach.Text;
                        newRow["TenTG"] = cbb_TacGia.Text;
                        newRow["GIABAN"] = txtDonGia.Text;
                        newRow["SOLUONGTON"] = txtSoLuong.Text;
                        newRow["TENNXB"] = cbb_NXB.Text;
                        dataTable.Rows.Add(newRow);

                        dataGridView1.DataSource = dataTable;

                        // Thêm dữ liệu trong cơ sở dữ liệu
                        string insertQuery = "INSERT INTO SACH (MaSach, MaTG, TenSach, MaTL, GiaBan, SoLuongTon, MaNXB) VALUES (@MaSach, @MaTG, @TenSach, @MaTL, @GiaBan, @SoLuongTon, @MaNXB)";
                        using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@MaSach", txtMaSach.Text);

                            // Lấy mã tác giả dựa trên tên tác giả được chọn trong ComboBox
                            string selectedTacGia = cbb_TacGia.Text;
                            string maTacGia = string.Empty;
                            string selectTacGiaQuery = "SELECT MaTG FROM TACGIA WHERE TenTG = @TenTG";
                            using (SqlCommand selectTacGiaCommand = new SqlCommand(selectTacGiaQuery, connection))
                            {
                                selectTacGiaCommand.Parameters.AddWithValue("@TenTG", selectedTacGia);
                                maTacGia = selectTacGiaCommand.ExecuteScalar().ToString();
                            }
                            insertCommand.Parameters.AddWithValue("@MaTG", maTacGia);

                            // Lấy mã thể loại dựa trên tên thể loại được chọn trong ComboBox
                            string selectedTheLoai = cbb_TheLoai.Text;
                            string maTheLoai = string.Empty;
                            string selectTheLoaiQuery = "SELECT MaTheLoai FROM THELOAI WHERE TenTheLoai = @TenTheLoai";
                            using (SqlCommand selectTheLoaiCommand = new SqlCommand(selectTheLoaiQuery, connection))
                            {
                                selectTheLoaiCommand.Parameters.AddWithValue("@TenTheLoai", selectedTheLoai);
                                maTheLoai = selectTheLoaiCommand.ExecuteScalar().ToString();
                            }

                            // Lấy mã NXB dựa trên tên thể loại được chọn trong ComboBox
                            string selectedNXB = cbb_NXB.Text;
                            string maNXB = string.Empty;
                            string selectNXBQuery = "SELECT MaNXB FROM NHAXUATBAN WHERE TenNXB = @TenNXB";
                            using (SqlCommand selectNXBCommand = new SqlCommand(selectNXBQuery, connection))
                            {
                                selectNXBCommand.Parameters.AddWithValue("@TenNXB", selectedNXB);
                                maNXB = selectNXBCommand.ExecuteScalar().ToString();
                            }

                            insertCommand.Parameters.AddWithValue("@TenSach", txtTenSach.Text);
                            insertCommand.Parameters.AddWithValue("@MaTL", maTheLoai);
                            insertCommand.Parameters.AddWithValue("@GiaBan", txtDonGia.Text);
                            insertCommand.Parameters.AddWithValue("@SoLuongTon", txtSoLuong.Text);
                            insertCommand.Parameters.AddWithValue("@MaNXB", maNXB);

                            insertCommand.ExecuteNonQuery();
                        }
                        MessageBox.Show("Thêm thành công !!!", "Thông báo!");
                    }
                }
                connection.Close();
            }
            catch
            {
                MessageBox.Show("Thêm không hợp lệ!", "Thông báo");
            }
        }
        
        private void bntThoat_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                this.Close();
                FrmMain main = new FrmMain();
                main.Show();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    List<string> missingFields = new List<string>();

                    // Kiểm tra xem có ô nào bị thiếu không
                    if (string.IsNullOrWhiteSpace(txtMaSach.Text))
                    {
                        missingFields.Add("Mã Sách");
                    }
                    if (string.IsNullOrWhiteSpace(cbb_TheLoai.Text))
                    {
                        missingFields.Add("Thể loại");
                    }
                    if (string.IsNullOrWhiteSpace(txtTenSach.Text))
                    {
                        missingFields.Add("Tên Sách");
                    }
                    if (string.IsNullOrWhiteSpace(cbb_TacGia.Text))
                    {
                        missingFields.Add("Tên Tác Giả");
                    }
                    if (string.IsNullOrWhiteSpace(txtDonGia.Text))
                    {
                        missingFields.Add("Đơn giá");
                    }
                    if (string.IsNullOrWhiteSpace(txtSoLuong.Text))
                    {
                        missingFields.Add("Số lượng");
                    }
                    if (string.IsNullOrWhiteSpace(cbb_NXB.Text))
                    {
                        missingFields.Add("NXB");
                    }


                    // Kiểm tra danh sách các ô bị thiếu
                    if (missingFields.Count > 0)
                    {
                        string missingFieldsMessage = "Chưa nhập:\n";
                        missingFieldsMessage += string.Join(", ", missingFields);
                        MessageBox.Show(missingFieldsMessage, "Thông báo");
                        connection.Close();
                        return; // Dừng việc thực hiện thêm dữ liệu
                    }
                   
                        int soluongton = Convert.ToInt32(txtSoLuong.Text);
                        int quantity = 0;

                        // Validate the quantity
                        if (!int.TryParse(txtSoLuong.Text, out quantity) || quantity <= 0)
                        {
                            MessageBox.Show("Vui lòng nhập số lượng hợp lệ.");
                            return;
                        }
                        // Lấy dòng được chọn
                        DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                        // Lấy giá trị của các cột trong dòng được chọn
                        string masach = selectedRow.Cells["MaSach"].Value.ToString();

                        // Cập nhật giá trị từ TextBox
                        string newmasach = txtMaSach.Text;
                        string newtentl = cbb_TheLoai.SelectedItem.ToString();
                        string newtensach = txtTenSach.Text;
                        string newtentg = cbb_TacGia.SelectedItem.ToString();
                        decimal newgiaban = Convert.ToDecimal(txtDonGia.Text);
                        int newsoluongton = Convert.ToInt32(txtSoLuong.Text);
                        string newtennxb = cbb_NXB.SelectedItem.ToString();

                        // Lấy mã thể loại mới dựa trên tên thể loại được chọn trong ComboBox
                        string selectedTheLoai = cbb_TheLoai.Text;
                        string maTheLoai = string.Empty;
                        string selectTheLoaiQuery = "SELECT MaTheLoai FROM THELOAI WHERE TenTheLoai = @TenTheLoai";
                        using (SqlCommand selectTheLoaiCommand = new SqlCommand(selectTheLoaiQuery, connection))
                        {
                            selectTheLoaiCommand.Parameters.AddWithValue("@TenTheLoai", selectedTheLoai);
                            connection.Open();
                            maTheLoai = selectTheLoaiCommand.ExecuteScalar().ToString();
                            connection.Close();
                        }

                        // Lấy mã tác giả mới dựa trên tên tác giả được chọn trong ComboBox
                        string selectedTacGia = cbb_TacGia.Text;
                        string maTacGia = string.Empty;
                        string selectTacGiaQuery = "SELECT MaTG FROM TACGIA WHERE TenTG = @TenTG";
                        using (SqlCommand selectTacGiaCommand = new SqlCommand(selectTacGiaQuery, connection))
                        {
                            selectTacGiaCommand.Parameters.AddWithValue("@TenTG", selectedTacGia);
                            connection.Open();
                            maTacGia = selectTacGiaCommand.ExecuteScalar().ToString();
                            connection.Close();
                        }

                        // Lấy mã NXB mới dựa trên tên NXB được chọn trong ComboBox
                        string selectedNXB = cbb_NXB.Text;
                        string maNXB = string.Empty;
                        string selectNXBQuery = "SELECT MaNXB FROM NHAXUATBAN WHERE TenNXB = @TenNXB";
                        using (SqlCommand selectNXBCommand = new SqlCommand(selectNXBQuery, connection))
                        {
                            selectNXBCommand.Parameters.AddWithValue("@TenNXB", selectedNXB);
                            connection.Open();
                            maNXB = selectNXBCommand.ExecuteScalar().ToString();
                            connection.Close();
                        }

                        // Cập nhật dữ liệu trong cơ sở dữ liệu
                        string updateQuery = "UPDATE SACH SET MaSach = @NewMaSach, MaTG = @MaTG, TenSach = @TenSach, MaTL = @MaTL, GiaBan = @GiaBan, SoLuongTon = @SoLuongTon, MaNXB = @MaNXB WHERE MaSach = @MaSach";
                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@NewMaSach", newmasach);
                            updateCommand.Parameters.AddWithValue("@MaTG", maTacGia);
                            updateCommand.Parameters.AddWithValue("@TenSach", newtensach);
                            updateCommand.Parameters.AddWithValue("@MaTL", maTheLoai);
                            updateCommand.Parameters.AddWithValue("@GiaBan", newgiaban);
                            updateCommand.Parameters.AddWithValue("@SoLuongTon", newsoluongton);
                            updateCommand.Parameters.AddWithValue("@MaNXB", maNXB);
                            updateCommand.Parameters.AddWithValue("@MaSach", masach);

                            connection.Open();
                            updateCommand.ExecuteNonQuery();
                            connection.Close();
                        }


                        // Refresh DataGridView
                        FrmSach_Load(sender, e);

                        MessageBox.Show("Cập nhật thành công !!!", "Thông báo!");
                    

                }
                else
                {
                    MessageBox.Show("Chưa chọn hàng cần cập nhật!!!");
                }
            }
            catch
            {
                MessageBox.Show("Không thể sửa!! Vui lòng kiểm tra dữ liệu cần xóa.", "Lỗi");
            }

            
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult r = MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        // Lấy dòng được chọn
                        DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                        // Lấy giá trị của các cột trong dòng được chọn
                        string masach = selectedRow.Cells["MASACH"].Value.ToString();
                        string tentl = selectedRow.Cells["TenTheLoai"].Value.ToString();
                        string tensach = selectedRow.Cells["TENSACH"].Value.ToString();
                        string tentg = selectedRow.Cells["TenTG"].Value.ToString();
                        string giaban = selectedRow.Cells["GIABAN"].Value.ToString();
                        string soluongton = selectedRow.Cells["SOLUONGTON"].Value.ToString();
                        string tennxb = selectedRow.Cells["TENNXB"].Value.ToString();
                        // Xóa dòng được chọn trong DataGridView
                        dataGridView1.Rows.Remove(selectedRow);

                        // Xóa dữ liệu trong cơ sở dữ liệu
                        string deleteQuery = "DELETE FROM SACH WHERE MaSach = @masach AND TenSach = @tensach";
                        using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                        {
                            deleteCommand.Parameters.AddWithValue("@masach", masach);
                            deleteCommand.Parameters.AddWithValue("@tensach", tensach);

                            connection.Open();
                            deleteCommand.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chưa chọn hàng cần xóa!!!");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Không thể xóa !! Vui lòng kiểm tra dữ liệu cần xóa.", "Lỗi");
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            //DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            txtMaSach.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            cbb_TheLoai.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            cbb_TacGia.Text= dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtTenSach.Text= dataGridView1.Rows[i].Cells[2].Value.ToString();
            txtDonGia.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txtSoLuong.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            cbb_NXB.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();

            SelectedMaSach = txtMaSach.Text;
            SelectedTensach = txtTenSach.Text;
            SelectedDonGia = Convert.ToDecimal(txtDonGia.Text);
            SelectedSoluongTon = Convert.ToInt32(txtSoLuong.Text);
            DialogResult = DialogResult.OK;

            // Đóng form KhachHang
            this.Close();
            //dateTimePicker1.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
        }

        private void btnTKTC_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ TextBox tìm kiếm
            string searchValue = txtMaSach.Text;

            // Câu lệnh tìm kiếm
            string searchQuery = "SELECT * FROM SACH WHERE MaSach LIKE @searchValue OR TenSach LIKE @searchValue";

            using (SqlCommand searchCommand = new SqlCommand(searchQuery, connection))
            {
                // Sử dụng tham số và gán giá trị tìm kiếm
                searchCommand.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%");

                // Tạo DataTable để lưu kết quả tìm kiếm
                DataTable searchResult = new DataTable();

                using (SqlDataAdapter adapter = new SqlDataAdapter(searchCommand))
                {
                    // Đổ dữ liệu vào DataTable
                    adapter.Fill(searchResult);
                }

                // Hiển thị kết quả tìm kiếm trong DataGridView
                dataGridView1.DataSource = searchResult;
            }
        }
        private void RefreshData()
        {
            string query = "select MaSach, TenTG, TenSach, TenTheLoai, GiaBan, SoLuongTon,TenNXB from SACH, THELOAI,TACGIA ,NHAXUATBAN where SACH.MaTL = THELOAI.MaTheLoai AND SACH.MaTG = TACGIA.MaTG AND SACH.MaNXB = NHAXUATBAN.MaNXB";

            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;
        }
        private void btn_Lammoi_Click(object sender, EventArgs e)
        {
            txtMaSach.Text = "";
            txtDonGia.Text = "";
            txtSoLuong.Text = "";
            txtTenSach.Text = "";
            cbb_NXB.Text = "";
            cbb_TacGia.Text = "";
            cbb_TheLoai.Text = "";
            RefreshData();
        }
    }
}
