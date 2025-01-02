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
    public class LoaiSanBUS
    {
        private readonly LoaiSanDAL _loaiSanDAL;

        public LoaiSanBUS()
        {
            _loaiSanDAL = new LoaiSanDAL();
        }

        public DataTable GetAllLoaiSan()
        {
            return _loaiSanDAL.GetAllLoaiSan();
        }

        public bool AddLoaiSan(string maLoai, string tenLoai, int soNguoiToiDa)
        {
            if (string.IsNullOrEmpty(maLoai) || string.IsNullOrEmpty(tenLoai))
            {
                throw new ArgumentException("Thông tin loại sân không được để trống.");
            }

            return _loaiSanDAL.AddLoaiSan(maLoai, tenLoai, soNguoiToiDa);
        }

        public bool UpdateLoaiSan(string maLoai, string tenLoai, int soNguoiToiDa)
        {
            if (string.IsNullOrEmpty(maLoai))
            {
                throw new ArgumentException("Mã loại sân không được để trống.");
            }

            return _loaiSanDAL.UpdateLoaiSan(maLoai, tenLoai, soNguoiToiDa);
        }

        public bool DeleteLoaiSan(string maLoai)
        {
            if (string.IsNullOrEmpty(maLoai))
            {
                throw new ArgumentException("Mã loại sân không được để trống.");
            }

            return _loaiSanDAL.DeleteLoaiSan(maLoai);
        }
    }
}
