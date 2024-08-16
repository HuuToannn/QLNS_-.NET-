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
    public partial class FrmNhanVien : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string connectionString = Properties.Settings.Default.ConStr;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public FrmNhanVien()
        {
            
            InitializeComponent();
            connection = new SqlConnection(connectionString);
        }
        private List<string> GetTenQuyen()
        {
            List<string> tenquyenist = new List<string>();

            string query = "SELECT Name FROM PHANQUYEN";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string tenquyen = reader.GetString(0);
                    tenquyenist.Add(tenquyen);
                }
            }
            connection.Close();

            return tenquyenist;
        }
        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            
            string query = "Select MaNV, HoTen, GioiTinh, SDT, DiaChi, PassWord, Name from [USER], [PHANQUYEN] where [USER].IDQuyen = [PHANQUYEN].IDQuyen";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
               
            }
            connection.Close();
            //SqlDataReader reader = command.ExecuteReader();
            //while (reader.Read())
            //{
            //    CB_ChucVu.Items.Add(reader["CatName"].ToString());
            //}
            List<string> tenTacGiaList = GetTenQuyen();
            CB_ChucVu.DataSource = tenTacGiaList;

            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txt_MK.Enabled = false;
            try
            {
                List<string> missingFields = new List<string>();

                // Kiểm tra xem có ô nào bị thiếu không
                if (string.IsNullOrWhiteSpace(txtManv.Text))
                {
                    missingFields.Add("Mã Nhân Viên");
                }
                if (string.IsNullOrWhiteSpace(txtHoTenNV.Text))
                {
                    missingFields.Add("Tên NV");
                }
                if (radioButton1.Checked == false && radioButton2.Checked == false)
                    missingFields.Add("Giới tính");
                if (string.IsNullOrWhiteSpace(CB_ChucVu.Text))
                {
                    missingFields.Add("Chức vụ");
                }
                if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
                {
                    missingFields.Add("Địa chỉ");
                }
                if (string.IsNullOrWhiteSpace(txtDT.Text))
                {
                    missingFields.Add("Số điện thoại");
                }
                if (string.IsNullOrWhiteSpace(txt_MK.Text))
                {
                    missingFields.Add("Mật Khẩu");
                }

                // Kiểm tra danh sách các ô bị thiếu
                if (missingFields.Count > 0)
                {
                    string missingFieldsMessage = "Chưa nhập:\n";
                    missingFieldsMessage += string.Join(", ", missingFields);
                    MessageBox.Show(missingFieldsMessage, "Thông báo");
                    return; // Dừng việc thực hiện thêm dữ liệu
                }

                // Check the connection state and open it if needed
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = "Select MaNV, HoTen, GioiTinh, SDT, DiaChi, PassWord, Name from [USER], [PHANQUYEN] where [USER].IDQuyen = [PHANQUYEN].IDQuyen";
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    bool isDuplicateMaNV = false;
                    bool isDuplicateSDT = false;

                    // Kiểm tra từng dòng trong DataGridView
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            string manv = row.Cells["MaNV"].Value.ToString();
                            string sdt = row.Cells["SDT"].Value.ToString();

                            // Kiểm tra trùng lặp MaKH
                            if (manv == txtManv.Text)
                            {
                                isDuplicateMaNV = true;
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

                    if (isDuplicateMaNV)
                    {
                        MessageBox.Show("Trùng mã Nhân viên. Vui lòng nhập lại!", "Thông báo");
                    }
                    else if (isDuplicateSDT)
                    {
                        MessageBox.Show("Số điện thoại đã tồn tại. Vui lòng nhập lại!", "Thông báo");
                    }
                    else
                    {
                        string gt = "";
                        if (radioButton1.Checked)
                            gt = "Nam";
                        if (radioButton2.Checked)
                            gt = "Nữ";
                        // Thêm dữ liệu vào DataTable từ các TextBox
                        DataRow newRow = dataTable.NewRow();
                        newRow["MANV"] = txtManv.Text;
                        newRow["HOTEN"] = txtHoTenNV.Text;
                        newRow["GIOITINH"] = gt;
                        newRow["Name"] = CB_ChucVu.Text;  // Fix the column name here
                        newRow["DIACHI"] = txtDiaChi.Text;
                        newRow["SDT"] = txtDT.Text;
                        newRow["PassWord"] = txt_MK.Text;
                        dataTable.Rows.Add(newRow);


                        dataGridView1.DataSource = dataTable;

                        //Thêm dữ liệu trong cơ sở dữ liệu
                        string insertQuery = "INSERT INTO [USER] (MaNV, HoTen, GioiTinh, SDT, DiaChi, PassWord, IDQuyen) VALUES (@MaNV, @HoTen, @GioiTinh, @SDT, @DiaChi, @PassWord,  @IDQuyen)";
                        using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                        {
                            string catName = CB_ChucVu.SelectedItem.ToString();
                            command.CommandText = "SELECT IDQuyen FROM [PHANQUYEN] WHERE [Name] = @CatName";
                            command.Parameters.AddWithValue("@CatName", catName);
                            int QuyenID = Convert.ToInt32(command.ExecuteScalar());
                            insertCommand.Parameters.AddWithValue("@MaNV", txtManv.Text);
                            insertCommand.Parameters.AddWithValue("@HoTen", txtHoTenNV.Text);
                            insertCommand.Parameters.AddWithValue("@GioiTinh", gt);
                            insertCommand.Parameters.AddWithValue("@SDT", txtDT.Text);
                            insertCommand.Parameters.AddWithValue("@IDQuyen", QuyenID);  
                            insertCommand.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                            insertCommand.Parameters.AddWithValue("@PassWord", txt_MK.Text);
                            insertCommand.ExecuteNonQuery();
                        }

                        MessageBox.Show("Thêm thành công !!!", "Thông báo!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Thêm không hợp lệ! Lỗi: {ex.Message}", "Thông báo");
            }
            finally
            {
                // Always close the connection in a finally block to ensure it's closed even if an exception occurs
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }


        private void btnTKTC_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ TextBox tìm kiếm
            string searchValue = txtManv.Text;

            // Câu lệnh tìm kiếm
            string searchQuery = "SELECT * FROM [USER] WHERE MaNV LIKE @searchValue OR HoTen LIKE @searchValue";

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
                        string manv = selectedRow.Cells["MaNV"].Value.ToString();
                        string hoten = selectedRow.Cells["HoTen"].Value.ToString();
                        string gioitinh = selectedRow.Cells["GIOITINH"].Value.ToString();
                        string sdt = selectedRow.Cells["SDT"].Value.ToString();
                        string chucvu = selectedRow.Cells["Name"].Value.ToString();
                        string diachi = selectedRow.Cells["DIACHI"].Value.ToString();
                        string MK = selectedRow.Cells["PassWord"].Value.ToString();
                        // Xóa dòng được chọn trong DataGridView
                        dataGridView1.Rows.Remove(selectedRow);

                        // Xóa dữ liệu trong cơ sở dữ liệu
                        string deleteQuery = "DELETE FROM [USER] WHERE MaNV = @manv AND HoTen = @hoten";
                        using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                        {
                            deleteCommand.Parameters.AddWithValue("@manv", manv);
                            deleteCommand.Parameters.AddWithValue("@hoten", hoten);

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
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                    // Check the connection state and open it if needed
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    string query = "Select MaNV, HoTen, GioiTinh, SDT, DiaChi, PassWord, Name from [USER], [PHANQUYEN] where [USER].IDQuyen = [PHANQUYEN].IDQuyen";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        string gt = "";
                        if (radioButton1.Checked)
                            gt = "Nam";
                        if (radioButton2.Checked)
                            gt = "Nữ";

                        // Update the selected row in DataTable
                        DataRow selectedDataRow = dataTable.Rows[selectedRow.Index];
                        selectedDataRow["MANV"] = txtManv.Text;
                        selectedDataRow["HOTEN"] = txtHoTenNV.Text;
                        selectedDataRow["GIOITINH"] = gt;
                        selectedDataRow["Name"] = CB_ChucVu.Text;
                        selectedDataRow["DIACHI"] = txtDiaChi.Text;
                        selectedDataRow["SDT"] = txtDT.Text;
                        selectedDataRow["PassWord"] = txt_MK.Text;

                        // Update the database
                        string updateQuery = "UPDATE [USER] SET HoTen = @HoTen, GioiTinh = @GioiTinh, SDT = @SDT, DiaChi = @DiaChi, PassWord = @PassWord, IDQuyen = @IDQuyen WHERE MaNV = @MaNV";
                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            string catName = CB_ChucVu.SelectedItem.ToString();
                            command.CommandText = "SELECT IDQuyen FROM [PHANQUYEN] WHERE [Name] = @CatName";
                            command.Parameters.AddWithValue("@CatName", catName);
                            int QuyenID = Convert.ToInt32(command.ExecuteScalar());
                            updateCommand.Parameters.AddWithValue("@MaNV", txtManv.Text);
                            updateCommand.Parameters.AddWithValue("@HoTen", txtHoTenNV.Text);
                            updateCommand.Parameters.AddWithValue("@GioiTinh", gt);
                            updateCommand.Parameters.AddWithValue("@SDT", txtDT.Text);
                            updateCommand.Parameters.AddWithValue("@IDQuyen", QuyenID);
                            updateCommand.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                            updateCommand.Parameters.AddWithValue("@PassWord", txt_MK.Text);
                            updateCommand.ExecuteNonQuery();
                        }

                        dataGridView1.DataSource = dataTable;

                        MessageBox.Show("Cập nhật thành công !!!", "Thông báo!");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một dòng để cập nhật.", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cập nhật không hợp lệ! Lỗi: {ex.Message}", "Thông báo");
            }
            finally
            {
                // Always close the connection in a finally block to ensure it's closed even if an exception occurs
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                txtManv.Text = selectedRow.Cells["MaNV"].Value.ToString();
                txtHoTenNV.Text = selectedRow.Cells["HOTEN"].Value.ToString();
                CB_ChucVu.Text = selectedRow.Cells["Name"].Value.ToString(); // Assuming "Name" is the correct column name
                txtDiaChi.Text = selectedRow.Cells["DIACHI"].Value.ToString();
                txtDT.Text = selectedRow.Cells["SDT"].Value.ToString();
                txt_MK.Text = selectedRow.Cells["PassWord"].Value.ToString();
                string gt = selectedRow.Cells["GIOITINH"].Value.ToString();
                if (gt == "Nam")
                    radioButton1.Checked = true;
                else
                    radioButton2.Checked = true;
            }
        }
        private void RefreshData()
        {
            string query = "Select MaNV, HoTen, GioiTinh, SDT, DiaChi, PassWord, Name from [USER], [PHANQUYEN] where [USER].IDQuyen = [PHANQUYEN].IDQuyen";

            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;
        }
        private void btn_Lammoi_Click(object sender, EventArgs e)
        {
            txtManv.Text = "";
            txtHoTenNV.Text = "";
            txtDT.Text = "";
            txtDiaChi.Text = "";
            txt_MK.Text = "";
            CB_ChucVu.Text = "";
            RefreshData();
        }

        private void CB_ChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_MK_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
