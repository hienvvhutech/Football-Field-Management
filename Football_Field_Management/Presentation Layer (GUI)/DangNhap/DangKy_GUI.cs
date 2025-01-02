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

namespace Presentation_Layer__GUI_.DangNhap
{
    public partial class frmDangKy : Form
    {
        private DangNhap_BUS bus;
        public frmDangKy()
        {
            InitializeComponent();
            bus = new DangNhap_BUS();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenTK.Text;
            string matKhau = txtMatKhau.Text;
            string xacNhanMatKhau = txtXacNhan.Text;
            string email = txtEmail.Text;

            string result = bus.DangKyNguoiDung(tenDangNhap, matKhau, xacNhanMatKhau, email);
            MessageBox.Show(result);

            if (result == "Đăng ký thành công!")
            {
                this.Close();
            }
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
            if(txtMatKhau.PasswordChar == '*')
            {
                ptnHien.BringToFront();
                txtMatKhau.PasswordChar = '\0';
            }
        }

        private void ptnHienXN_Click(object sender, EventArgs e)
        {
            if (txtXacNhan.PasswordChar == '\0')
            {
                ptnAnXN.BringToFront();
                txtXacNhan.PasswordChar = '*';
            }
        }

        private void ptnAnXN_Click(object sender, EventArgs e)
        {
            if (txtXacNhan.PasswordChar == '*')
            {
                ptnHienXN.BringToFront();
                txtXacNhan.PasswordChar = '\0';
            }
        }
    }
}
