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
    public partial class frmQuenMK : Form
    {
        private DangNhap_BUS bus;
        public frmQuenMK()
        {
            InitializeComponent();
            bus = new DangNhap_BUS();
        }

        private void btnLayMK_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            // Kiểm tra nhập liệu qua BUS
            string validationMessage = bus.KiemTraNhapLieuQuenMatKhau(email);
            if (validationMessage != null)
            {
                MessageBox.Show(validationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi phương thức lấy lại mật khẩu từ BUS
            string result = bus.QuenMatKhau(email);
            txtKetQua.Text = result;

            if (result != "Email không tồn tại.")
            {
                MessageBox.Show("Mật khẩu đã được hiển thị.");
            }
            else
            {
                MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
