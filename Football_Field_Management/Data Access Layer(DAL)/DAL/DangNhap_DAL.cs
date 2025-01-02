using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer_DAL_.DataContext;
using Data_Access_Layer_DAL_.Enity;

namespace Data_Access_Layer_DAL_.DAL
{
    public class DangNhap_DAL
    {
        private QLSBContext db = new QLSBContext();

        public bool KiemTraTaiKhoanTonTai(string tenDangNhap)
        {
            return db.DangNhap.Any(u => u.TenDangNhap == tenDangNhap);
        }
        // Kiểm tra thông tin đăng nhập
        public bool KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            var user = db.DangNhap.ToList() // Tải dữ liệu vào bộ nhớ
                  .FirstOrDefault(u =>
                      u.TenDangNhap.Equals(tenDangNhap, StringComparison.Ordinal) &&
                      u.MatKhau.Equals(matKhau, StringComparison.Ordinal));
            return user != null;
        }

        // Kiểm tra sự tồn tại của email
        public bool KiemTraEmail(string email)
        {
            return db.DangNhap.Any(u => u.Email == email);
        }

        // Thêm mới người dùng vào cơ sở dữ liệu
        public string DangKyNguoiDung(string tenDangNhap, string matKhau, string xacNhanMatKhau ,string email)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrWhiteSpace(matKhau) || string.IsNullOrWhiteSpace(xacNhanMatKhau)|| string.IsNullOrWhiteSpace(email))
            {
                return "Vui lòng nhập đầy đủ tên đăng nhập, mật khẩu và email!";
            }

            // Kiểm tra sự tồn tại của tên đăng nhập hoặc email trong cơ sở dữ liệu
            if (KiemTraDangNhap(tenDangNhap, matKhau))  // Kiểm tra tên đăng nhập đã tồn tại
            {
                return "Tên đăng nhập đã tồn tại!";
            }

            if (KiemTraEmail(email))  // Kiểm tra email đã tồn tại
            {
                return "Email đã tồn tại!";
            }

            // Thêm người dùng mới vào cơ sở dữ liệu nếu không có lỗi
            var nguoiDungMoi = new DangNhap
            {
                TenDangNhap = tenDangNhap,
                MatKhau = matKhau,
                Email = email
            };

            db.DangNhap.Add(nguoiDungMoi);
            db.SaveChanges();  // Lưu thay đổi vào cơ sở dữ liệu

            return "Đăng ký thành công!";
        }

        // Lấy lại mật khẩu dựa trên email
        public string LayLaiMatKhau(string email)
        {
            var user = db.DangNhap.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                return user.MatKhau;
            }
            return "Email không tồn tại.";
        }
    }
}
