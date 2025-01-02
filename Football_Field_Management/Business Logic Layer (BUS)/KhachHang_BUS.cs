using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer_DAL_.DAL;

namespace Business_Logic_Layer__BUS_
{
    public class KhachHangBUS
    {
        private readonly KhachHangDAL _khachHangDAL;

        public KhachHangBUS()
        {
            _khachHangDAL = new KhachHangDAL();
        }

        public DataTable GetAllKhachHang()
        {
            return _khachHangDAL.GetAllKhachHang();
        }

        public bool AddKhachHang(string maKH, string hoTen, string gioiTinh, DateTime ngaySinh, string soDienThoai, string diaChi)
        {
            if (string.IsNullOrEmpty(maKH) || string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(soDienThoai))
            {
                throw new ArgumentException("Thông tin khách hàng không được để trống.");
            }

            return _khachHangDAL.AddKhachHang(maKH, hoTen, gioiTinh, ngaySinh, soDienThoai, diaChi);
        }

        public bool UpdateKhachHang(string maKH, string hoTen, string gioiTinh, DateTime ngaySinh, string soDienThoai, string diaChi)
        {
            if (string.IsNullOrEmpty(maKH))
            {
                throw new ArgumentException("Mã khách hàng không được để trống.");
            }

            return _khachHangDAL.UpdateKhachHang(maKH, hoTen, gioiTinh, ngaySinh, soDienThoai, diaChi);
        }

        public bool DeleteKhachHang(string maKH)
        {
            if (string.IsNullOrEmpty(maKH))
            {
                throw new ArgumentException("Mã khách hàng không được để trống.");
            }

            return _khachHangDAL.DeleteKhachHang(maKH);
        }

        public DataTable SearchKhachHang(string keyword)
        {
            return _khachHangDAL.SearchKhachHang(keyword);
        }
    }
}
