using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlNhaSach_25_11
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //if (Properties.Settings.Default.Role == "User")
            //{
            //    button1.Hide();
            //    button9.Hide();
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            THONGTINNHANVIEN nv = new THONGTINNHANVIEN();
            nv.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmNhanVien nv = new FrmNhanVien();
            nv.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                this.Close();
                Form1 dn = new Form1();
                dn.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmSach sach = new FrmSach();
            sach.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmTheLoai theloai = new FrmTheLoai();
            theloai.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmNcc ncc = new FrmNcc();
            ncc.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmKhachHang kh = new FrmKhachHang();
            kh.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLapHoaDon formHD = new FrmLapHoaDon();
            formHD.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmPhieuNhap formNS = new FrmPhieuNhap();
            formNS.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FrmBaoCaoThongKe BC = new FrmBaoCaoThongKe();
            BC.Show();
        }
    }
}
