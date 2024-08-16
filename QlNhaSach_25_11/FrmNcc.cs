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
    public partial class FrmNcc : Form
    {
        string connectionString = Properties.Settings.Default.ConStr;
        SqlConnection connection;
        public FrmNcc()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
        }

        private void FrmNcc_Load(object sender, EventArgs e)
        {
            string query = "Select MA_NCC, TEN_NCC, DC_NCC,DT_NCC from NHACC";

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
                if (string.IsNullOrWhiteSpace(txtMaNCC.Text))
                {
                    missingFields.Add("Mã NCC");
                }
                if (string.IsNullOrWhiteSpace(txtTenNCC.Text))
                {
                    missingFields.Add("Tên NCC");
                }
                if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
                {
                    missingFields.Add("Địa chỉ");
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
                string query = "Select MA_NCC, TEN_NCC, DC_NCC,DT_NCC from NHACC";
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
                            string maKH = row.Cells["MA_NCC"].Value.ToString();
                            string sdt = row.Cells["DT_NCC"].Value.ToString();

                            // Kiểm tra trùng lặp MaKH
                            if (maKH == txtMaNCC.Text)
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
                        MessageBox.Show("Trùng mã NCC. Vui lòng nhập lại!", "Thông báo");
                    }
                    else if (isDuplicateSDT)
                    {
                        MessageBox.Show("Số điện thoại đã tồn tại. Vui lòng nhập lại!", "Thông báo");
                    }
                    else
                    {
                        // Thêm dữ liệu vào DataTable từ các TextBox
                        DataRow newRow = dataTable.NewRow();
                        newRow["MA_NCC"] = txtMaNCC.Text;
                        newRow["TEN_NCC"] = txtTenNCC.Text;
                        newRow["DC_NCC"] = txtDiaChi.Text;
                        newRow["DT_NCC"] = txtDT.Text;
                        dataTable.Rows.Add(newRow);

                        dataGridView1.DataSource = dataTable;


                        //Thêm dữ liệu trong cơ sở dữ liệu
                        string insertQuery = "INSERT INTO NHACC(MA_NCC, TEN_NCC, DC_NCC,DT_NCC) VALUES (@MaNCC, @TenNCC, @DC,@DT)";
                        using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@MaNCC", txtMaNCC.Text);
                            insertCommand.Parameters.AddWithValue("@TenNCC", txtTenNCC.Text);
                            insertCommand.Parameters.AddWithValue("@DC", txtDiaChi.Text);
                            insertCommand.Parameters.AddWithValue("@DT", txtDT.Text);
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
                        string mancc = selectedRow.Cells["MA_NCC"].Value.ToString();
                        string tenncc = selectedRow.Cells["TEN_NCC"].Value.ToString();
                        string dc = selectedRow.Cells["DC_NCC"].Value.ToString();
                        string dt = selectedRow.Cells["DT_NCC"].Value.ToString();

                        // Xóa dòng được chọn trong DataGridView
                        dataGridView1.Rows.Remove(selectedRow);

                        // Xóa dữ liệu trong cơ sở dữ liệu
                        string deleteQuery = "DELETE FROM NHACC WHERE MA_NCC = @mancc AND TEN_NCC = @tenncc";
                        using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                        {
                            deleteCommand.Parameters.AddWithValue("@mancc", mancc);
                            deleteCommand.Parameters.AddWithValue("@tenncc", tenncc);

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
                    if (string.IsNullOrWhiteSpace(txtMaNCC.Text))
                    {
                        missingFields.Add("Mã NCC");
                    }
                    if (string.IsNullOrWhiteSpace(txtTenNCC.Text))
                    {
                        missingFields.Add("Tên NCC");
                    }
                    if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
                    {
                        missingFields.Add("Địa chỉ");
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
                    // Lấy dòng được chọn
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                    // Lấy giá trị của các cột trong dòng được chọn
                    string mancc = selectedRow.Cells["MA_NCC"].Value.ToString();
                    string tenncc = selectedRow.Cells["TEN_NCC"].Value.ToString();
                    string dc = selectedRow.Cells["DC_NCC"].Value.ToString();
                    string dt = selectedRow.Cells["DT_NCC"].Value.ToString();

                    // Cập nhật giá trị từ TextBox
                    string newMaNCC = txtMaNCC.Text;
                    string newTenNCC = txtTenNCC.Text;
                    string newDC = txtDiaChi.Text;
                    string newDT = txtDT.Text;


                        // Câu lệnh cập nhật
                        string updateQuery = "UPDATE NHACC SET TEN_NCC = @newTenNCC, DC_NCC = @newDC, DT_NCC = @newDT WHERE MA_NCC = @MaNCC AND TEN_NCC = @TenNCC";

                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            // Sử dụng tham số và gán giá trị cần cập nhật
                            updateCommand.Parameters.AddWithValue("@newTenNCC", newTenNCC);
                            updateCommand.Parameters.AddWithValue("@newDC", newDC);
                            updateCommand.Parameters.AddWithValue("@newDT", newDT);
                            updateCommand.Parameters.AddWithValue("@MaNCC", mancc);
                            updateCommand.Parameters.AddWithValue("@TenNCC", tenncc);
                            connection.Open();
                            updateCommand.ExecuteNonQuery();
                            int rowsAffected = updateCommand.ExecuteNonQuery();
                            connection.Close();

                            if (rowsAffected > 0)
                            {
                                // Cập nhật giá trị trong DataGridView
                                selectedRow.Cells["MA_NCC"].Value = newMaNCC;
                                selectedRow.Cells["TEN_NCC"].Value = newTenNCC;
                                selectedRow.Cells["DC_NCC"].Value = newDC;
                                selectedRow.Cells["DT_NCC"].Value = newDT;

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
                MessageBox.Show("Không thể sửa!! Vui lòng kiểm tra dữ liệu cần xóa.", "Lỗi");
            }

           
        }

        private void btnTKTC_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ TextBox tìm kiếm
            string searchValue = txtMaNCC.Text;

            // Câu lệnh tìm kiếm
            string searchQuery = "SELECT * FROM NHACC WHERE MA_NCC LIKE @searchValue OR TEN_NCC LIKE @searchValue";

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
            string query = "Select * from NHACC";

            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;
        }
        private void btn_Lammoi_Click(object sender, EventArgs e)
        {
            txtMaNCC.Text = "";
            txtDT.Text = "";
            txtDiaChi.Text = "";
            txtTenNCC.Text = "";
            RefreshData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                txtMaNCC.Text = selectedRow.Cells["MA_NCC"].Value.ToString();
                txtTenNCC.Text = selectedRow.Cells["TEN_NCC"].Value.ToString();
                txtDiaChi.Text = selectedRow.Cells["DC_NCC"].Value.ToString();
                txtDT.Text = selectedRow.Cells["DT_NCC"].Value.ToString();
            }
        }

    }
}
