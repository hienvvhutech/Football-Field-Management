using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Logic_Layer__BUS_;
using Presentation_Layer__GUI_.TrangChu;

namespace Presentation_Layer__GUI_.DangNhap
{
    public partial class frmDangNhap : Form
    {
        private DangNhap_BUS bus;
        public frmDangNhap()
        {
            InitializeComponent();
            bus = new DangNhap_BUS();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDN.Text;
            string matKhau = txtMatKhau.Text;

            string ketQua = bus.XuLyDangNhap(tenDangNhap, matKhau);

            if (ketQua == "Đăng nhập thành công!")
            {
                frmTrangChu mainForm = new frmTrangChu();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(ketQua, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void llblQuenMK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmQuenMK frm = new frmQuenMK();
            frm.Show();

        }
        private void llblDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDangKy frm = new frmDangKy();
            frm.Show();
        }
        private void ptnHien_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.PasswordChar == '\0')
            {
                ptnAn.BringToFront();
                txtMatKhau.PasswordChar = '*';
            }
        }

        private void ptnAn_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.PasswordChar == '*')
            {
                ptnHien.BringToFront();
                txtMatKhau.PasswordChar = '\0';
            }
        }
    }
}
