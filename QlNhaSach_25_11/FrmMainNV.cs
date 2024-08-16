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
    public partial class FrmMainNV : Form
    {
        public FrmMainNV()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            THONGTINNHANVIEN nv = new THONGTINNHANVIEN();
            nv.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
           
        }

        private void button11_Click(object sender, EventArgs e)
        {
           
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            THONGTINNHANVIEN nv = new THONGTINNHANVIEN();
            nv.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                this.Close();
                Form1 dn = new Form1();
                dn.Show();
            }
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            FrmLapHoaDon formHD = new FrmLapHoaDon();
            formHD.Show();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            FrmPhieuNhap formNS = new FrmPhieuNhap();
            formNS.Show();
        }
    }
}
