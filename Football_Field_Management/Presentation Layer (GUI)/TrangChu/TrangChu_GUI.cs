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
using Presentation_Layer__GUI_.DangNhap;

namespace Presentation_Layer__GUI_.TrangChu
{
    public partial class frmTrangChu : Form
    {
        private Form activeForm = null;
        public frmTrangChu()
        {
            InitializeComponent();
            
        }
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close(); // Đóng Form con hiện tại

            activeForm = childForm; // Gán Form con mới
            childForm.TopLevel = false; // Không phải Form độc lập
            childForm.FormBorderStyle = FormBorderStyle.None; // Xóa viền Form
            childForm.Dock = DockStyle.Fill; // Phủ đầy Panel
            panelBody.Controls.Add(childForm); // Thêm vào Panel
            panelBody.Tag = childForm; // Gắn dữ liệu Tag
            childForm.BringToFront(); // Hiển thị phía trước
            childForm.Show(); // Mở Form
        }
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            frmDangNhap frmDangNhap = new frmDangNhap();
            frmDangNhap.Show();
            this.Close();
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
        }

        private void btnDatSan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDatSan());
            lblTrangChu.Text = btnDatSan.Text;
        }

        private void btnQLDatSan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQLDatSan());
            lblTrangChu.Text = btnQLDatSan.Text;
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {

            OpenChildForm(new frmKhachHang());
            lblTrangChu.Text = btnKhachHang.Text;
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {

            OpenChildForm(new frmThanhToan());
            lblTrangChu.Text = btnHoaDon.Text;
        }

        private void btnNhanSan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhanSan());
            lblTrangChu.Text = btnNhanSan.Text;
        }
    }
}
