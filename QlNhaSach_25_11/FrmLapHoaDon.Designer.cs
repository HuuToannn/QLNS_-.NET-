
namespace QlNhaSach_25_11
{
    partial class FrmLapHoaDon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLapHoaDon));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Chonsach = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSoLuongTon = new System.Windows.Forms.TextBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.txt_SoLuong = new System.Windows.Forms.TextBox();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.txtMaSach = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.gbThongTinKhachHang = new System.Windows.Forms.GroupBox();
            this.btn_chonKH = new System.Windows.Forms.Button();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_TimHD = new System.Windows.Forms.Button();
            this.txt_MaKH_LapHD = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txt_MaNV = new System.Windows.Forms.TextBox();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_Thoat_HD = new System.Windows.Forms.Button();
            this.btn_XoaHD = new System.Windows.Forms.Button();
            this.btx_SuaHoaDon = new System.Windows.Forms.Button();
            this.btn_ThemHD = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbThongTinKhachHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Location = new System.Drawing.Point(136, 61);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1140, 517);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hoá Đơn";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.Controls.Add(this.dataGridView3);
            this.panel2.Controls.Add(this.btn_Chonsach);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.gbThongTinKhachHang);
            this.panel2.Location = new System.Drawing.Point(16, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1120, 481);
            this.panel2.TabIndex = 31;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btn_Chonsach
            // 
            this.btn_Chonsach.BackColor = System.Drawing.Color.Turquoise;
            this.btn_Chonsach.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Chonsach.Location = new System.Drawing.Point(852, 173);
            this.btn_Chonsach.Name = "btn_Chonsach";
            this.btn_Chonsach.Size = new System.Drawing.Size(205, 64);
            this.btn_Chonsach.TabIndex = 33;
            this.btn_Chonsach.Text = "CHỌN SÁCH";
            this.btn_Chonsach.UseVisualStyleBackColor = false;
            this.btn_Chonsach.Click += new System.EventHandler(this.btn_Chonsach_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtSoLuongTon);
            this.groupBox3.Controls.Add(this.txtDonGia);
            this.groupBox3.Controls.Add(this.txt_SoLuong);
            this.groupBox3.Controls.Add(this.txtTenSach);
            this.groupBox3.Controls.Add(this.txtMaSach);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(32, 140);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(745, 119);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin sách";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(665, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 19);
            this.label3.TabIndex = 32;
            this.label3.Text = "Số lượng";
            // 
            // txtSoLuongTon
            // 
            this.txtSoLuongTon.Location = new System.Drawing.Point(134, 65);
            this.txtSoLuongTon.Margin = new System.Windows.Forms.Padding(4);
            this.txtSoLuongTon.Name = "txtSoLuongTon";
            this.txtSoLuongTon.Size = new System.Drawing.Size(99, 27);
            this.txtSoLuongTon.TabIndex = 31;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(446, 78);
            this.txtDonGia.Margin = new System.Windows.Forms.Padding(4);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(99, 27);
            this.txtDonGia.TabIndex = 30;
            // 
            // txt_SoLuong
            // 
            this.txt_SoLuong.Location = new System.Drawing.Point(668, 37);
            this.txt_SoLuong.Margin = new System.Windows.Forms.Padding(4);
            this.txt_SoLuong.Name = "txt_SoLuong";
            this.txt_SoLuong.Size = new System.Drawing.Size(54, 27);
            this.txt_SoLuong.TabIndex = 26;
            // 
            // txtTenSach
            // 
            this.txtTenSach.Location = new System.Drawing.Point(443, 33);
            this.txtTenSach.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.Size = new System.Drawing.Size(170, 27);
            this.txtTenSach.TabIndex = 28;
            // 
            // txtMaSach
            // 
            this.txtMaSach.Location = new System.Drawing.Point(134, 29);
            this.txtMaSach.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaSach.Name = "txtMaSach";
            this.txtMaSach.Size = new System.Drawing.Size(135, 27);
            this.txtMaSach.TabIndex = 26;
            this.txtMaSach.TextChanged += new System.EventHandler(this.txtMaSach_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(25, 68);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 19);
            this.label10.TabIndex = 15;
            this.label10.Text = "Số lượng còn";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(366, 76);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 19);
            this.label11.TabIndex = 13;
            this.label11.Text = "Đơn giá";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(366, 37);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 19);
            this.label12.TabIndex = 5;
            this.label12.Text = "Tên Sách";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(25, 30);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 19);
            this.label14.TabIndex = 2;
            this.label14.Text = "Mã sách";
            // 
            // gbThongTinKhachHang
            // 
            this.gbThongTinKhachHang.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbThongTinKhachHang.BackColor = System.Drawing.Color.Transparent;
            this.gbThongTinKhachHang.Controls.Add(this.btn_chonKH);
            this.gbThongTinKhachHang.Controls.Add(this.btn_Reset);
            this.gbThongTinKhachHang.Controls.Add(this.btn_TimHD);
            this.gbThongTinKhachHang.Controls.Add(this.txt_MaKH_LapHD);
            this.gbThongTinKhachHang.Controls.Add(this.dateTimePicker1);
            this.gbThongTinKhachHang.Controls.Add(this.txt_MaNV);
            this.gbThongTinKhachHang.Controls.Add(this.txtMaHD);
            this.gbThongTinKhachHang.Controls.Add(this.label5);
            this.gbThongTinKhachHang.Controls.Add(this.label4);
            this.gbThongTinKhachHang.Controls.Add(this.label2);
            this.gbThongTinKhachHang.Controls.Add(this.label7);
            this.gbThongTinKhachHang.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbThongTinKhachHang.Location = new System.Drawing.Point(32, 7);
            this.gbThongTinKhachHang.Margin = new System.Windows.Forms.Padding(4);
            this.gbThongTinKhachHang.Name = "gbThongTinKhachHang";
            this.gbThongTinKhachHang.Padding = new System.Windows.Forms.Padding(4);
            this.gbThongTinKhachHang.Size = new System.Drawing.Size(1084, 125);
            this.gbThongTinKhachHang.TabIndex = 30;
            this.gbThongTinKhachHang.TabStop = false;
            this.gbThongTinKhachHang.Text = "Thêm Hoá Đơn";
            this.gbThongTinKhachHang.Enter += new System.EventHandler(this.gbThongTinKhachHang_Enter);
            // 
            // btn_chonKH
            // 
            this.btn_chonKH.BackColor = System.Drawing.Color.Turquoise;
            this.btn_chonKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_chonKH.Location = new System.Drawing.Point(828, 21);
            this.btn_chonKH.Name = "btn_chonKH";
            this.btn_chonKH.Size = new System.Drawing.Size(197, 69);
            this.btn_chonKH.TabIndex = 32;
            this.btn_chonKH.Text = "CHỌN KHÁCH HÀNG";
            this.btn_chonKH.UseVisualStyleBackColor = false;
            this.btn_chonKH.Click += new System.EventHandler(this.btn_chonKH_Click);
            // 
            // btn_Reset
            // 
            this.btn_Reset.Location = new System.Drawing.Point(648, 41);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(109, 44);
            this.btn_Reset.TabIndex = 33;
            this.btn_Reset.Text = "Reset";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // btn_TimHD
            // 
            this.btn_TimHD.Location = new System.Drawing.Point(241, 25);
            this.btn_TimHD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_TimHD.Name = "btn_TimHD";
            this.btn_TimHD.Size = new System.Drawing.Size(75, 31);
            this.btn_TimHD.TabIndex = 32;
            this.btn_TimHD.Text = "Tìm";
            this.btn_TimHD.UseVisualStyleBackColor = true;
            this.btn_TimHD.Click += new System.EventHandler(this.btn_TimHD_Click_1);
            // 
            // txt_MaKH_LapHD
            // 
            this.txt_MaKH_LapHD.Location = new System.Drawing.Point(426, 34);
            this.txt_MaKH_LapHD.Margin = new System.Windows.Forms.Padding(4);
            this.txt_MaKH_LapHD.Name = "txt_MaKH_LapHD";
            this.txt_MaKH_LapHD.Size = new System.Drawing.Size(161, 27);
            this.txt_MaKH_LapHD.TabIndex = 26;
            this.txt_MaKH_LapHD.TextChanged += new System.EventHandler(this.txt_MaKH_LapHD_TextChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(107, 68);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(209, 27);
            this.dateTimePicker1.TabIndex = 29;
            // 
            // txt_MaNV
            // 
            this.txt_MaNV.Location = new System.Drawing.Point(426, 70);
            this.txt_MaNV.Margin = new System.Windows.Forms.Padding(4);
            this.txt_MaNV.Name = "txt_MaNV";
            this.txt_MaNV.Size = new System.Drawing.Size(161, 27);
            this.txt_MaNV.TabIndex = 22;
            this.txt_MaNV.TextChanged += new System.EventHandler(this.txt_MaNV_TextChanged);
            // 
            // txtMaHD
            // 
            this.txtMaHD.Location = new System.Drawing.Point(107, 34);
            this.txtMaHD.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.Size = new System.Drawing.Size(125, 27);
            this.txtMaHD.TabIndex = 22;
            this.txtMaHD.TextChanged += new System.EventHandler(this.txtMaHD_TextChanged_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(345, 37);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "MÃ KH";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 68);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ngày Lập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(346, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã NV";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 34);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 19);
            this.label7.TabIndex = 2;
            this.label7.Text = "Mã HĐ";
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView3.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView3.ColumnHeadersHeight = 29;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn12,
            this.MaNV,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
            this.dataGridView3.Location = new System.Drawing.Point(45, 267);
            this.dataGridView3.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView3.Size = new System.Drawing.Size(1012, 210);
            this.dataGridView3.TabIndex = 1;
            this.dataGridView3.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellContentClick_1);
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "MaHD";
            this.dataGridViewTextBoxColumn12.HeaderText = "Mã HĐ";
            this.dataGridViewTextBoxColumn12.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // MaNV
            // 
            this.MaNV.DataPropertyName = "MaNV";
            this.MaNV.HeaderText = "Mã NV";
            this.MaNV.MinimumWidth = 6;
            this.MaNV.Name = "MaNV";
            this.MaNV.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "MaKH";
            this.dataGridViewTextBoxColumn9.HeaderText = "Mã KH";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "NgayLap";
            this.dataGridViewTextBoxColumn10.HeaderText = "Ngày Lập";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1113, 584);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(163, 60);
            this.button1.TabIndex = 31;
            this.button1.Text = "IN HOÁ ĐƠN";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btn_Thoat_HD
            // 
            this.btn_Thoat_HD.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_Thoat_HD.Image = ((System.Drawing.Image)(resources.GetObject("btn_Thoat_HD.Image")));
            this.btn_Thoat_HD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Thoat_HD.Location = new System.Drawing.Point(943, 584);
            this.btn_Thoat_HD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Thoat_HD.Name = "btn_Thoat_HD";
            this.btn_Thoat_HD.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btn_Thoat_HD.Size = new System.Drawing.Size(163, 60);
            this.btn_Thoat_HD.TabIndex = 31;
            this.btn_Thoat_HD.Text = "THOÁT";
            this.btn_Thoat_HD.UseVisualStyleBackColor = true;
            this.btn_Thoat_HD.Click += new System.EventHandler(this.btn_Thoat_HD_Click);
            // 
            // btn_XoaHD
            // 
            this.btn_XoaHD.Image = ((System.Drawing.Image)(resources.GetObject("btn_XoaHD.Image")));
            this.btn_XoaHD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_XoaHD.Location = new System.Drawing.Point(533, 584);
            this.btn_XoaHD.Margin = new System.Windows.Forms.Padding(4);
            this.btn_XoaHD.Name = "btn_XoaHD";
            this.btn_XoaHD.Size = new System.Drawing.Size(107, 61);
            this.btn_XoaHD.TabIndex = 31;
            this.btn_XoaHD.Text = "Xóa";
            this.btn_XoaHD.UseVisualStyleBackColor = true;
            this.btn_XoaHD.Click += new System.EventHandler(this.btn_XoaHD_Click);
            // 
            // btx_SuaHoaDon
            // 
            this.btx_SuaHoaDon.Image = ((System.Drawing.Image)(resources.GetObject("btx_SuaHoaDon.Image")));
            this.btx_SuaHoaDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btx_SuaHoaDon.Location = new System.Drawing.Point(706, 584);
            this.btx_SuaHoaDon.Margin = new System.Windows.Forms.Padding(4);
            this.btx_SuaHoaDon.Name = "btx_SuaHoaDon";
            this.btx_SuaHoaDon.Size = new System.Drawing.Size(129, 60);
            this.btx_SuaHoaDon.TabIndex = 30;
            this.btx_SuaHoaDon.Text = "    Sửa";
            this.btx_SuaHoaDon.UseVisualStyleBackColor = true;
            this.btx_SuaHoaDon.Click += new System.EventHandler(this.btx_SuaHoaDon_Click_1);
            // 
            // btn_ThemHD
            // 
            this.btn_ThemHD.ForeColor = System.Drawing.Color.Blue;
            this.btn_ThemHD.Image = ((System.Drawing.Image)(resources.GetObject("btn_ThemHD.Image")));
            this.btn_ThemHD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ThemHD.Location = new System.Drawing.Point(355, 584);
            this.btn_ThemHD.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ThemHD.Name = "btn_ThemHD";
            this.btn_ThemHD.Size = new System.Drawing.Size(111, 61);
            this.btn_ThemHD.TabIndex = 28;
            this.btn_ThemHD.Text = "   Thêm";
            this.btn_ThemHD.UseVisualStyleBackColor = true;
            this.btn_ThemHD.Click += new System.EventHandler(this.btn_ThemHD_Click_1);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.Location = new System.Drawing.Point(554, 10);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(352, 47);
            this.label8.TabIndex = 42;
            this.label8.Text = "LẬP HOÁ ĐƠN";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label8.Click += new System.EventHandler(this.label8_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btn_Thoat_HD);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.btn_XoaHD);
            this.panel1.Controls.Add(this.btx_SuaHoaDon);
            this.panel1.Controls.Add(this.btn_ThemHD);
            this.panel1.Location = new System.Drawing.Point(0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1905, 1007);
            this.panel1.TabIndex = 43;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // FrmLapHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1547, 700);
            this.Controls.Add(this.panel1);
            this.Name = "FrmLapHoaDon";
            this.Text = "FrmLapHoaDon";
            this.Load += new System.EventHandler(this.FrmLapHoaDon_Load_1);
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbThongTinKhachHang.ResumeLayout(false);
            this.gbThongTinKhachHang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Thoat_HD;
        private System.Windows.Forms.GroupBox gbThongTinKhachHang;
        private System.Windows.Forms.Button btn_XoaHD;
        private System.Windows.Forms.Button btx_SuaHoaDon;
        private System.Windows.Forms.Button btn_TimHD;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btn_ThemHD;
        private System.Windows.Forms.TextBox txt_MaNV;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtSoLuongTon;
        private System.Windows.Forms.TextBox txt_SoLuong;
        private System.Windows.Forms.TextBox txtMaSach;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.TextBox txt_MaKH_LapHD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_chonKH;
        private System.Windows.Forms.Button btn_Chonsach;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.TextBox txtTenSach;
        public System.Windows.Forms.Panel panel2;
    }
}