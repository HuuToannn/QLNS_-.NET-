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
    public partial class FrmTheLoai : Form
    {
        string connectionString = Properties.Settings.Default.ConStr;
        SqlConnection connection;
        public FrmTheLoai()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
        }

        private void FrmTheLoai_Load(object sender, EventArgs e)
        {
            string query = "Select * from THELOAI";

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
                if (string.IsNullOrWhiteSpace(txtMaLS.Text))
                {
                    missingFields.Add("Mã thể loại");
                }
                if (string.IsNullOrWhiteSpace(txtTenLS.Text))
                {
                    missingFields.Add("Tên thể loại");
                }
                if (string.IsNullOrWhiteSpace(cbb_NgonNgu.Text))
                {
                    missingFields.Add("Ngôn ngữ");
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


                string query = "Select * from THELOAI";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    bool isDuplicateMaTL = false;
                    // Kiểm tra từng dòng trong DataGridView
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            string maTL = row.Cells["MaTheLoai"].Value.ToString();
                            string tenTL = row.Cells["TenTheLoai"].Value.ToString();

                            // Kiểm tra trùng lặp MaKH
                            if (maTL == txtMaLS.Text)
                            {
                                isDuplicateMaTL = true;
                                break;
                            }
                        }
                    }
                    if (isDuplicateMaTL)
                    {
                        MessageBox.Show("Mã thể loại đã tồn tại. Vui lòng nhập lại!", "Thông báo");
                    }
                    else
                    {
                        // Thêm dữ liệu vào DataTable từ các TextBox
                        DataRow newRow = dataTable.NewRow();
                        newRow["MaTheLoai"] = txtMaLS.Text;
                        newRow["TenTheLoai"] = txtTenLS.Text;
                        newRow["NgonNgu"] = cbb_NgonNgu.Text;
                        dataTable.Rows.Add(newRow);

                        dataGridView1.DataSource = dataTable;


                        //Thêm dữ liệu trong cơ sở dữ liệu
                        string insertQuery = "INSERT INTO THELOAI(MaTheLoai, TenTheLoai, NgonNgu) VALUES (@MaLoai, @TenLoai, @NgonNgu)";
                        using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@MaLoai", txtMaLS.Text);
                            insertCommand.Parameters.AddWithValue("@TenLoai", txtTenLS.Text);
                            insertCommand.Parameters.AddWithValue("@NgonNgu", cbb_NgonNgu.Text);
                            insertCommand.ExecuteNonQuery();
                        }


                        MessageBox.Show("Thêm thành công !!!", "Thông báo!");
                    }

                    connection.Close();
                }
            }
            catch
            {
                MessageBox.Show("Thêm không hợp lệ.", "Lỗi");
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
                        string matl = selectedRow.Cells["MaTheLoai"].Value.ToString();
                        string tentl = selectedRow.Cells["TenTheLoai"].Value.ToString();
                        string ngonngu = selectedRow.Cells["NgonNgu"].Value.ToString();

                        // Xóa dòng được chọn trong DataGridView
                        dataGridView1.Rows.Remove(selectedRow);
                        // Xóa dữ liệu trong cơ sở dữ liệu
                        string deleteQuery = "DELETE FROM THELOAI WHERE MaTheLoai = @matl AND TenTheLoai = @tentl";
                        using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                        {
                            deleteCommand.Parameters.AddWithValue("@matl", matl);
                            deleteCommand.Parameters.AddWithValue("@tentl", tentl);

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
                    if (string.IsNullOrWhiteSpace(txtMaLS.Text))
                    {
                        missingFields.Add("Mã thể loại");
                    }
                    if (string.IsNullOrWhiteSpace(txtTenLS.Text))
                    {
                        missingFields.Add("Tên thể loại");
                    }
                    if (string.IsNullOrWhiteSpace(cbb_NgonNgu.Text))
                    {
                        missingFields.Add("Ngôn ngữ");
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
                    string matl = selectedRow.Cells["MaTheLoai"].Value.ToString();
                    string tentl = selectedRow.Cells["TenTheLoai"].Value.ToString();
                    string ngonngu = selectedRow.Cells["NgonNgu"].Value.ToString();

                    // Cập nhật giá trị từ TextBox
                    string newTenTL = txtTenLS.Text;
                    string newNgonNgu = cbb_NgonNgu.Text;

                    // Câu lệnh cập nhật
                    string updateQuery = "UPDATE THELOAI SET TenTheLoai = @newTenTL, NgonNgu = @newNgonNgu WHERE MaTheLoai = @matl AND TenTheLoai = @tentl";

                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                    {
                        // Sử dụng tham số và gán giá trị cần cập nhật
                        updateCommand.Parameters.AddWithValue("@newTenTL", newTenTL);
                        updateCommand.Parameters.AddWithValue("@newNgonNgu", newNgonNgu);
                        updateCommand.Parameters.AddWithValue("@MaTL", matl);
                        updateCommand.Parameters.AddWithValue("@TenTL", tentl);
                        connection.Open();
                        updateCommand.ExecuteNonQuery();
                        connection.Close();
                    }

                    // Cập nhật giá trị trong DataGridView
                    selectedRow.Cells["TenTheLoai"].Value = newTenTL;
                    selectedRow.Cells["NgonNgu"].Value = newNgonNgu;

                    MessageBox.Show("Cập nhật thành công !!!", "Thông báo!");
                }
                else
                {
                    MessageBox.Show("Chưa chọn hàng cần sửa!!");
                }
            }
            catch
            {
                MessageBox.Show("Không thể sửa !! Vui lòng kiểm tra dữ liệu cần xóa.", "Lỗi");
            }

            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                this.Close();
                FrmMain main = new FrmMain();
                main.Show();
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //if (dataGridView1.SelectedRows.Count > 0)
            //{
            //    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            //    txtMaLS.Text = selectedRow.Cells["MaTheLoai"].Value.ToString();
            //    txtTenLS.Text = selectedRow.Cells["TenTheLoai"].Value.ToString();
            //    cbb_NgonNgu.Text = selectedRow.Cells["NgonNgu"].Value.ToString();
            //}
            int i = dataGridView1.CurrentRow.Index;
            txtMaLS.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtTenLS.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            cbb_NgonNgu.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();

        }
    }
}
