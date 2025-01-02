using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer_DAL_.DAL;
using Data_Access_Layer_DAL_.Enity;


namespace Business_Logic_Layer__BUS_
{
    public class DangNhap_BUS
    {
        private DangNhap_DAL dal;

        public DangNhap_BUS()
        {
            dal = new DangNhap_DAL();
        }
        public string XuLyDangNhap(string tenDangNhap, string matKhau)
        {
            // Kiểm tra nhập liệu
            var kiemTraNhapLieu = KiemTraNhapLieu(tenDangNhap, matKhau);
            if (kiemTraNhapLieu != null)
            {
                return kiemTraNhapLieu;
            }

            // Kiểm tra nếu tài khoản không tồn tại
            if (!dal.KiemTraTaiKhoanTonTai(tenDangNhap))
            {
                return "Tài khoản không tồn tại. Vui lòng đăng ký!";
            }

            // Kiểm tra thông tin đăng nhập
            if (dal.KiemTraDangNhap(tenDangNhap, matKhau))
            {
                return "Đăng nhập thành công!";
            }

            return "Tên đăng nhập hoặc mật khẩu không đúng!";
        }
        public string KiemTraNhapLieu(string tenDangNhap, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap) && string.IsNullOrWhiteSpace(matKhau))
            {
                return "Vui lòng nhập tên đăng nhập và mật khẩu!";
            }

            if (string.IsNullOrWhiteSpace(tenDangNhap))
            {
                return "Vui lòng nhập tên đăng nhập!";
            }

            if (string.IsNullOrWhiteSpace(matKhau))
            {
                return "Vui lòng nhập mật khẩu!";
            }

            return null; // Không có lỗi
        }
        public string KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
        if (dal.KiemTraDangNhap(tenDangNhap, matKhau))
            {
                return "Đăng nhập thành công!";
            }
            return "Tên đăng nhập hoặc mật khẩu không đúng!";
        }

        // Đăng ký người dùng mới
        public string DangKyNguoiDung(string tenDangNhap, string matKhau, string xacNhanMatKhau, string email)
        {
            // Kiểm tra mật khẩu và xác nhận mật khẩu trong lớp BUS
            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrWhiteSpace(matKhau) || string.IsNullOrWhiteSpace(email))
            {
                return "Vui lòng nhập đầy đủ tên đăng nhập, mật khẩu và email!";
            }

            if (matKhau != xacNhanMatKhau)
            {
                return "Mật khẩu và xác nhận mật khẩu không khớp!";
            }

            // Kiểm tra sự tồn tại của tên đăng nhập hoặc email trong cơ sở dữ liệu thông qua DAL
            var result = dal.DangKyNguoiDung(tenDangNhap, matKhau, xacNhanMatKhau, email);
            return result;  // Trả kết quả từ DAL
        }


        // Lấy lại mật khẩu qua email
        public string KiemTraNhapLieuQuenMatKhau(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return "Vui lòng nhập email!";
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                return "Email không hợp lệ!";
            }

            return null; // Không có lỗi
        }
        public string QuenMatKhau(string email)
        {
            return dal.LayLaiMatKhau(email);
        }

    }
}
