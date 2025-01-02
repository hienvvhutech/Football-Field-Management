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

namespace Presentation_Layer__GUI_.TrangChu
{
    public partial class frmKhachHang : Form
    {
        private readonly KhachHangBUS _khachHangBUS;
        public frmKhachHang()
        {
            InitializeComponent();
            _khachHangBUS = new KhachHangBUS();
            InitializeGioiTinhComboBox();
            LoadData();
        }
        private void InitializeGioiTinhComboBox()
        {
            cmbGioiTinh.Items.Clear();
            cmbGioiTinh.Items.Add("Nam");
            cmbGioiTinh.Items.Add("Nữ");
            cmbGioiTinh.SelectedIndex = 0; // Mặc định chọn giá trị đầu tiên (Nam)
        }
        private void LoadData()
        {
            dgvDSKhachHang.DataSource = _khachHangBUS.GetAllKhachHang();
        }

        private void btnThemKhach_Click(object sender, EventArgs e)
        {
            try
            {
                _khachHangBUS.AddKhachHang(
                    txtMaKH.Text,
                    txtHoTen.Text,
                    cmbGioiTinh.Text,
                    date_NgaySinh.Value,
                    txtSoDT.Text,
                    txtDiaChi.Text
                );
                MessageBox.Show("Thêm khách hàng thành công!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                _khachHangBUS.UpdateKhachHang(
                    txtMaKH.Text,
                    txtHoTen.Text,
                    cmbGioiTinh.Text,
                   date_NgaySinh.Value,
                    txtSoDT.Text,
                    txtDiaChi.Text
                );
                MessageBox.Show("Cập nhật khách hàng thành công!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            try
            {
                _khachHangBUS.DeleteKhachHang(txtMaKH.Text);
                MessageBox.Show("Xóa khách hàng thành công!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvDSKhachHang.DataSource = _khachHangBUS.SearchKhachHang(txtTenKH.Text);
        }
    }
}
