
namespace QlNhaSach_25_11
{
    partial class FrmPhieuNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPhieuNhap));
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.txt_soluong = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Ma_PN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MASACH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NGAY_NHAP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TEN_NCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SL_NHAP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GIA_NHAP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Inphieunhap = new System.Windows.Forms.Button();
            this.txt_dongiaNhap = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_maSachNhap = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_xoaPN = new System.Windows.Forms.Button();
            this.btn_SuaPN = new System.Windows.Forms.Button();
            this.btnThemPN = new System.Windows.Forms.Button();
            this.cb_Nhacc = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txt_manv = new System.Windows.Forms.TextBox();
            this.txt_MaPN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSoLuongTon = new System.Windows.Forms.TextBox();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_Chonsach = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_Thoat);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.btn_Inphieunhap);
            this.panel2.Location = new System.Drawing.Point(56, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1157, 935);
            this.panel2.TabIndex = 41;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Chonsach);
            this.groupBox2.Controls.Add(this.btn_xoaPN);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.btn_SuaPN);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.btnThemPN);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(38, 242);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1072, 480);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi Tiết Phiếu Nhập";
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Thoat.Location = new System.Drawing.Point(927, 729);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(155, 62);
            this.btn_Thoat.TabIndex = 15;
            this.btn_Thoat.Text = "THOÁT";
            this.btn_Thoat.UseVisualStyleBackColor = true;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // txt_soluong
            // 
            this.txt_soluong.Location = new System.Drawing.Point(669, 38);
            this.txt_soluong.Margin = new System.Windows.Forms.Padding(4);
            this.txt_soluong.Name = "txt_soluong";
            this.txt_soluong.Size = new System.Drawing.Size(45, 27);
            this.txt_soluong.TabIndex = 1;
            this.txt_soluong.TextChanged += new System.EventHandler(this.txt_soluong_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ma_PN,
            this.MASACH,
            this.MaNV,
            this.NGAY_NHAP,
            this.TEN_NCC,
            this.SL_NHAP,
            this.GIA_NHAP,
            this.Column7});
            this.dataGridView1.Location = new System.Drawing.Point(28, 232);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1016, 234);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Ma_PN
            // 
            this.Ma_PN.DataPropertyName = "Ma_PN";
            this.Ma_PN.HeaderText = "Mã Phiếu Nhập";
            this.Ma_PN.MinimumWidth = 6;
            this.Ma_PN.Name = "Ma_PN";
            // 
            // MASACH
            // 
            this.MASACH.DataPropertyName = "MASACH";
            this.MASACH.HeaderText = "Mã Sách";
            this.MASACH.MinimumWidth = 6;
            this.MASACH.Name = "MASACH";
            // 
            // MaNV
            // 
            this.MaNV.DataPropertyName = "MaNV";
            this.MaNV.HeaderText = "Mã NV";
            this.MaNV.MinimumWidth = 6;
            this.MaNV.Name = "MaNV";
            // 
            // NGAY_NHAP
            // 
            this.NGAY_NHAP.DataPropertyName = "NGAY_NHAP";
            this.NGAY_NHAP.HeaderText = "Ngày Nhập";
            this.NGAY_NHAP.MinimumWidth = 6;
            this.NGAY_NHAP.Name = "NGAY_NHAP";
            // 
            // TEN_NCC
            // 
            this.TEN_NCC.DataPropertyName = "TEN_NCC";
            this.TEN_NCC.HeaderText = "Nhà Cung Cấp";
            this.TEN_NCC.MinimumWidth = 6;
            this.TEN_NCC.Name = "TEN_NCC";
            // 
            // SL_NHAP
            // 
            this.SL_NHAP.DataPropertyName = "SL_NHAP";
            this.SL_NHAP.HeaderText = "Số Lượng";
            this.SL_NHAP.MinimumWidth = 6;
            this.SL_NHAP.Name = "SL_NHAP";
            // 
            // GIA_NHAP
            // 
            this.GIA_NHAP.DataPropertyName = "GIA_NHAP";
            this.GIA_NHAP.HeaderText = "Đơn Giá";
            this.GIA_NHAP.MinimumWidth = 6;
            this.GIA_NHAP.Name = "GIA_NHAP";
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "THANH_TIEN";
            this.Column7.HeaderText = "Thành Tiền";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            // 
            // btn_Inphieunhap
            // 
            this.btn_Inphieunhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Inphieunhap.Image = ((System.Drawing.Image)(resources.GetObject("btn_Inphieunhap.Image")));
            this.btn_Inphieunhap.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Inphieunhap.Location = new System.Drawing.Point(756, 730);
            this.btn_Inphieunhap.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Inphieunhap.Name = "btn_Inphieunhap";
            this.btn_Inphieunhap.Size = new System.Drawing.Size(152, 62);
            this.btn_Inphieunhap.TabIndex = 13;
            this.btn_Inphieunhap.Text = "In Phiếu Nhập";
            this.btn_Inphieunhap.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Inphieunhap.UseVisualStyleBackColor = true;
            // 
            // txt_dongiaNhap
            // 
            this.txt_dongiaNhap.Location = new System.Drawing.Point(443, 73);
            this.txt_dongiaNhap.Margin = new System.Windows.Forms.Padding(4);
            this.txt_dongiaNhap.Name = "txt_dongiaNhap";
            this.txt_dongiaNhap.Size = new System.Drawing.Size(170, 27);
            this.txt_dongiaNhap.TabIndex = 1;
            this.txt_dongiaNhap.TextChanged += new System.EventHandler(this.txt_dongiaNhap_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 29);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 19);
            this.label7.TabIndex = 0;
            this.label7.Text = "Mã Sản Phẩm";
            // 
            // txt_maSachNhap
            // 
            this.txt_maSachNhap.Location = new System.Drawing.Point(145, 21);
            this.txt_maSachNhap.Margin = new System.Windows.Forms.Padding(4);
            this.txt_maSachNhap.Name = "txt_maSachNhap";
            this.txt_maSachNhap.Size = new System.Drawing.Size(163, 27);
            this.txt_maSachNhap.TabIndex = 1;
            this.txt_maSachNhap.TextChanged += new System.EventHandler(this.txt_maSachNhap_TextChanged);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(427, 5);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(352, 47);
            this.label5.TabIndex = 39;
            this.label5.Text = "LẬP PHIẾU NHẬP";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(38, 56);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1072, 165);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_Nhacc);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.txt_manv);
            this.groupBox1.Controls.Add(this.txt_MaPN);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(28, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1016, 128);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Phiếu Nhập";
            // 
            // btn_xoaPN
            // 
            this.btn_xoaPN.Image = ((System.Drawing.Image)(resources.GetObject("btn_xoaPN.Image")));
            this.btn_xoaPN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_xoaPN.Location = new System.Drawing.Point(514, 158);
            this.btn_xoaPN.Margin = new System.Windows.Forms.Padding(4);
            this.btn_xoaPN.Name = "btn_xoaPN";
            this.btn_xoaPN.Size = new System.Drawing.Size(159, 50);
            this.btn_xoaPN.TabIndex = 13;
            this.btn_xoaPN.Text = "Xoá Phiếu Nhập";
            this.btn_xoaPN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_xoaPN.UseVisualStyleBackColor = true;
            this.btn_xoaPN.Click += new System.EventHandler(this.btn_xoaPN_Click);
            // 
            // btn_SuaPN
            // 
            this.btn_SuaPN.Image = ((System.Drawing.Image)(resources.GetObject("btn_SuaPN.Image")));
            this.btn_SuaPN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SuaPN.Location = new System.Drawing.Point(315, 158);
            this.btn_SuaPN.Margin = new System.Windows.Forms.Padding(4);
            this.btn_SuaPN.Name = "btn_SuaPN";
            this.btn_SuaPN.Size = new System.Drawing.Size(159, 50);
            this.btn_SuaPN.TabIndex = 13;
            this.btn_SuaPN.Text = "Sửa Phiếu Nhập";
            this.btn_SuaPN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_SuaPN.UseVisualStyleBackColor = true;
            this.btn_SuaPN.Click += new System.EventHandler(this.btn_SuaPN_Click);
            // 
            // btnThemPN
            // 
            this.btnThemPN.Image = ((System.Drawing.Image)(resources.GetObject("btnThemPN.Image")));
            this.btnThemPN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemPN.Location = new System.Drawing.Point(112, 158);
            this.btnThemPN.Margin = new System.Windows.Forms.Padding(4);
            this.btnThemPN.Name = "btnThemPN";
            this.btnThemPN.Size = new System.Drawing.Size(160, 50);
            this.btnThemPN.TabIndex = 13;
            this.btnThemPN.Text = "Tạo Phiếu Nhập";
            this.btnThemPN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemPN.UseVisualStyleBackColor = true;
            this.btnThemPN.Click += new System.EventHandler(this.btnThemPN_Click);
            // 
            // cb_Nhacc
            // 
            this.cb_Nhacc.FormattingEnabled = true;
            this.cb_Nhacc.Location = new System.Drawing.Point(553, 63);
            this.cb_Nhacc.Margin = new System.Windows.Forms.Padding(4);
            this.cb_Nhacc.Name = "cb_Nhacc";
            this.cb_Nhacc.Size = new System.Drawing.Size(215, 27);
            this.cb_Nhacc.TabIndex = 3;
            this.cb_Nhacc.SelectedIndexChanged += new System.EventHandler(this.cb_Nhacc_SelectedIndexChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Cursor = System.Windows.Forms.Cursors.Default;
            this.dateTimePicker1.Location = new System.Drawing.Point(168, 65);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(215, 27);
            this.dateTimePicker1.TabIndex = 2;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // txt_manv
            // 
            this.txt_manv.Location = new System.Drawing.Point(553, 22);
            this.txt_manv.Margin = new System.Windows.Forms.Padding(4);
            this.txt_manv.Name = "txt_manv";
            this.txt_manv.Size = new System.Drawing.Size(215, 27);
            this.txt_manv.TabIndex = 1;
            this.txt_manv.TextChanged += new System.EventHandler(this.txt_manv_TextChanged);
            // 
            // txt_MaPN
            // 
            this.txt_MaPN.Location = new System.Drawing.Point(168, 31);
            this.txt_MaPN.Margin = new System.Windows.Forms.Padding(4);
            this.txt_MaPN.Name = "txt_MaPN";
            this.txt_MaPN.Size = new System.Drawing.Size(215, 27);
            this.txt_MaPN.TabIndex = 1;
            this.txt_MaPN.TextChanged += new System.EventHandler(this.txt_MaPN_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(417, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nhà Cung Cấp";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(417, 31);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mã NV";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ngày Nhập";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Phiếu Nhập";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txt_soluong);
            this.groupBox3.Controls.Add(this.txtSoLuongTon);
            this.groupBox3.Controls.Add(this.txt_dongiaNhap);
            this.groupBox3.Controls.Add(this.txtTenSach);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txt_maSachNhap);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(28, 31);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(745, 119);
            this.groupBox3.TabIndex = 33;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin sách";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(665, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 19);
            this.label6.TabIndex = 32;
            this.label6.Text = "Số lượng";
            // 
            // txtSoLuongTon
            // 
            this.txtSoLuongTon.Location = new System.Drawing.Point(145, 68);
            this.txtSoLuongTon.Margin = new System.Windows.Forms.Padding(4);
            this.txtSoLuongTon.Name = "txtSoLuongTon";
            this.txtSoLuongTon.Size = new System.Drawing.Size(99, 27);
            this.txtSoLuongTon.TabIndex = 31;
            // 
            // txtTenSach
            // 
            this.txtTenSach.Location = new System.Drawing.Point(443, 33);
            this.txtTenSach.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.Size = new System.Drawing.Size(170, 27);
            this.txtTenSach.TabIndex = 28;
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
            // btn_Chonsach
            // 
            this.btn_Chonsach.BackColor = System.Drawing.Color.Turquoise;
            this.btn_Chonsach.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Chonsach.Location = new System.Drawing.Point(825, 54);
            this.btn_Chonsach.Name = "btn_Chonsach";
            this.btn_Chonsach.Size = new System.Drawing.Size(205, 64);
            this.btn_Chonsach.TabIndex = 34;
            this.btn_Chonsach.Text = "CHỌN SÁCH";
            this.btn_Chonsach.UseVisualStyleBackColor = false;
            this.btn_Chonsach.Click += new System.EventHandler(this.btn_Chonsach_Click);
            // 
            // FrmPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 1010);
            this.Controls.Add(this.panel2);
            this.Name = "FrmPhieuNhap";
            this.Text = "FrmPhieuNhap";
            this.Load += new System.EventHandler(this.FrmPhieuNhap_Load_1);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_SuaPN;
        private System.Windows.Forms.Button btnThemPN;
        private System.Windows.Forms.ComboBox cb_Nhacc;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txt_manv;
        private System.Windows.Forms.TextBox txt_MaPN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_xoaPN;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_soluong;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_Inphieunhap;
        private System.Windows.Forms.TextBox txt_dongiaNhap;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_maSachNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_PN;
        private System.Windows.Forms.DataGridViewTextBoxColumn MASACH;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn NGAY_NHAP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TEN_NCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn SL_NHAP;
        private System.Windows.Forms.DataGridViewTextBoxColumn GIA_NHAP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.Button btn_Thoat;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSoLuongTon;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btn_Chonsach;
    }
}