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
    public partial class FrmKhachHang : Form
    {
        string connectionString = Properties.Settings.Default.ConStr;
        SqlConnection connection;
        public string SelectedMaKH { get; private set; }

        public FrmKhachHang()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
        }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            string query = "Select * from KHACHHANG";

            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> missingFields = new List<string>();

                // Kiểm tra xem có ô nào bị thiếu không
                if (string.IsNullOrWhiteSpace(txtMaKH.Text))
                {
                    missingFields.Add("Mã KH");
                }
                if (string.IsNullOrWhiteSpace(txtTenKH.Text))
                {
                    missingFields.Add("Tên KH");
                }
                if (string.IsNullOrWhiteSpace(txtDT.Text))
                {
                    missingFields.Add("Số điện thoại");
                }

                // Kiểm tra danh sách các ô bị thiếu
                if (missingFields.Count > 0)
                {
                    string missingFieldsMessage = "Chưa nhập:\n";
                    missingFieldsMessage += string.Join(", ", missingFields);
                    MessageBox.Show(missingFieldsMessage, "Thông báo");
                    //connection.Close();
                    return; // Dừng việc thực hiện thêm dữ liệu
                }

                string query = "SELECT * FROM KHACHHANG";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    bool isDuplicateMaKH = false;
                    bool isDuplicateSDT = false;

                    // Kiểm tra từng dòng trong DataGridView
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            string maKH = row.Cells["MAKH"].Value.ToString();
                            string sdt = row.Cells["SDT"].Value.ToString();

                            // Kiểm tra trùng lặp MaKH
                            if (maKH == txtMaKH.Text)
                            {
                                isDuplicateMaKH = true;
                                break;
                            }

                            // Kiểm tra trùng lặp SDT
                            if (sdt == txtDT.Text)
                            {
                                isDuplicateSDT = true;
                                break;
                            }
                        }
                    }

                    if (isDuplicateMaKH)
                    {
                        MessageBox.Show("Trùng mã KH. Vui lòng nhập lại!", "Thông báo");
                    }
                    else if (isDuplicateSDT)
                    {
                        MessageBox.Show("Số điện thoại đã tồn tại. Vui lòng nhập lại!", "Thông báo");
                    }
                    else
                    {
                        // Thêm dữ liệu vào DataTable từ các TextBox
                        DataRow newRow = dataTable.NewRow();
                        newRow["MAKH"] = txtMaKH.Text;
                        newRow["TenKH"] = txtTenKH.Text;
                        newRow["SDT"] = txtDT.Text;
                        dataTable.Rows.Add(newRow);

                        dataGridView1.DataSource = dataTable;

                        // Thêm dữ liệu vào cơ sở dữ liệu
                        string insertQuery = "INSERT INTO KHACHHANG(MAKH, TenKH, SDT) VALUES (@MAKH, @TenKH, @SDT)";
                        using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@MAKH", txtMaKH.Text);
                            insertCommand.Parameters.AddWithValue("@TenKH", txtTenKH.Text);
                            insertCommand.Parameters.AddWithValue("@SDT", txtDT.Text);
                            insertCommand.ExecuteNonQuery();
                        }

                        MessageBox.Show("Thêm thành công !!!", "Thông báo");
                    }
                }
                connection.Close();
            }
            catch
            {
                MessageBox.Show("Thêm không hợp lệ !!!", "Thông báo");
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
                        string makh = selectedRow.Cells["MAKH"].Value.ToString();
                        string tenkh = selectedRow.Cells["TenKH"].Value.ToString();
                        string dt = selectedRow.Cells["SDT"].Value.ToString();

                        // Xóa dòng được chọn trong DataGridView
                        dataGridView1.Rows.Remove(selectedRow);

                        // Xóa dữ liệu trong cơ sở dữ liệu
                        string deleteQuery = "DELETE FROM KHACHHANG WHERE MAKH = @makh AND TENKH = @tenkh";
                        using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                        {
                            deleteCommand.Parameters.AddWithValue("@makh", makh);
                            deleteCommand.Parameters.AddWithValue("@tenkh", tenkh);

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

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    List<string> missingFields = new List<string>();

                    // Kiểm tra xem có ô nào bị thiếu không
                    if (string.IsNullOrWhiteSpace(txtMaKH.Text))
                    {
                        missingFields.Add("Mã KH");
                    }
                    if (string.IsNullOrWhiteSpace(txtTenKH.Text))
                    {
                        missingFields.Add("Tên KH");
                    }
                    if (string.IsNullOrWhiteSpace(txtDT.Text))
                    {
                        missingFields.Add("Số điện thoại");
                    }

                    // Kiểm tra danh sách các ô bị thiếu
                    if (missingFields.Count > 0)
                    {
                        string missingFieldsMessage = "Chưa nhập:\n";
                        missingFieldsMessage += string.Join(", ", missingFields);
                        MessageBox.Show(missingFieldsMessage, "Thông báo");
                        //connection.Close();
                        return;
                    }
                    // Lấy dòng được chọn
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                    // Lấy giá trị của các cột trong dòng được chọn
                    string makh = selectedRow.Cells["MAKH"].Value.ToString();
                    string tenkh = selectedRow.Cells["TenKH"].Value.ToString();
                    string dt = selectedRow.Cells["SDT"].Value.ToString();

                    // Cập nhật giá trị từ TextBox
                    string newMaKH = txtMaKH.Text;
                    string newTenKH = txtTenKH.Text;
                    string newDT = txtDT.Text;

                        // Câu lệnh cập nhật
                        string updateQuery = "UPDATE KHACHHANG SET TenKH = @newTenKH, SDT = @newDT WHERE MAKH = @makh AND TenKH = @tenkh";

                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            // Sử dụng tham số và gán giá trị cần cập nhật
                            updateCommand.Parameters.AddWithValue("@newMaKH", newMaKH);
                            updateCommand.Parameters.AddWithValue("@newTenKH", newTenKH);
                            updateCommand.Parameters.AddWithValue("@newDT", newDT);
                            updateCommand.Parameters.AddWithValue("@makh", makh);
                            updateCommand.Parameters.AddWithValue("@tenkh", tenkh);
                            connection.Open();
                            int rowsAffected = updateCommand.ExecuteNonQuery();
                            connection.Close();

                            if (rowsAffected > 0)
                            {
                                // Cập nhật giá trị trong DataGridView
                                selectedRow.Cells["MAKH"].Value = newMaKH;
                                selectedRow.Cells["TenKH"].Value = newTenKH;
                                selectedRow.Cells["SDT"].Value = newDT;

                                MessageBox.Show("Sửa thành công !!!", "Thông báo");
                            }
                            else
                            {
                                MessageBox.Show("Sửa không thành công !!!", "Thông báo");
                            }
                        }
                    
                }
            }
            catch
            {
                MessageBox.Show("Không thể sửa !! Vui lòng kiểm tra dữ liệu cần xóa.", "Lỗi");
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

        private void RefreshData()
        {
            string query = "Select * from KHACHHANG";

            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                txtMaKH.Text = selectedRow.Cells["MAKH"].Value.ToString();
                txtTenKH.Text = selectedRow.Cells["TenKH"].Value.ToString();
                txtDT.Text = selectedRow.Cells["SDT"].Value.ToString();
                
            }
            SelectedMaKH = txtMaKH.Text;
            DialogResult = DialogResult.OK;

            // Đóng form KhachHang
            this.Close();
        }

        private void btnTKTC_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ TextBox tìm kiếm
            string searchValue = txtMaKH.Text;

            // Câu lệnh tìm kiếm
            string searchQuery = "SELECT * FROM KHACHHANG WHERE MAKH LIKE @searchValue OR TENKH LIKE @searchValue";

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

        private void btn_Lammoi_Click(object sender, EventArgs e)
        {
            txtMaKH.Text = "";
            txtDT.Text = "";
            txtTenKH.Text = "";
            RefreshData();
        }
    }
}
