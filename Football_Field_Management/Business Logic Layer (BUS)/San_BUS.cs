using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer_DAL_.DAL;
using Data_Access_Layer_DAL_.Enity;

namespace Business_Logic_Layer__BUS_
{
    public class SanBUS
    {
        private readonly SanDAL _sanDAL;

        public SanBUS()
        {
            _sanDAL = new SanDAL();
        }

        public DataTable GetAllSan()
        {
            return _sanDAL.GetAllSan();
        }

        public bool AddSan(string maSan, string tenSan, string loaiSan, int soNguoiToiDa, string trangThai)
        {
            if (string.IsNullOrEmpty(maSan) || string.IsNullOrEmpty(tenSan) || string.IsNullOrEmpty(loaiSan))
            {
                throw new ArgumentException("Thông tin sân không được để trống.");
            }

            return _sanDAL.AddSan(maSan, tenSan, loaiSan, soNguoiToiDa, trangThai);
        }

        public bool UpdateSan(string maSan, string tenSan, string loaiSan, int soNguoiToiDa, string trangThai)
        {
            if (string.IsNullOrEmpty(maSan))
            {
                throw new ArgumentException("Mã sân không được để trống.");
            }

            return _sanDAL.UpdateSan(maSan, tenSan, loaiSan, soNguoiToiDa, trangThai);
        }

        public bool DeleteSan(string maSan)
        {
            if (string.IsNullOrEmpty(maSan))
            {
                throw new ArgumentException("Mã sân không được để trống.");
            }

            return _sanDAL.DeleteSan(maSan);
        }

        public DataTable SearchSan(string keyword)
        {
            return _sanDAL.SearchSan(keyword);
        }
    }
}
