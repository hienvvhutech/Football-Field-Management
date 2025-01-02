using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer_DAL_.DAL;

namespace Business_Logic_Layer__BUS_
{
    public class HoaDonBUS
    {
        private readonly HoaDonDAL _hoaDonDAL;

        public HoaDonBUS()
        {
            _hoaDonDAL = new HoaDonDAL();
        }

        public DataTable GetAllHoaDon()
        {
            return _hoaDonDAL.GetAllHoaDon();
        }

        public bool AddHoaDon(string maHD, DateTime ngayLap, string maKH, decimal tongTien, decimal tienCoc, decimal thanhTien)
        {
            if (string.IsNullOrEmpty(maHD) || string.IsNullOrEmpty(maKH))
            {
                throw new ArgumentException("Mã hóa đơn hoặc mã khách hàng không được để trống.");
            }

            return _hoaDonDAL.AddHoaDon(maHD, ngayLap, maKH, tongTien, tienCoc, thanhTien);
        }

        public bool UpdateHoaDon(string maHD, DateTime ngayLap, string maKH, decimal tongTien, decimal tienCoc, decimal thanhTien)
        {
            if (string.IsNullOrEmpty(maHD))
            {
                throw new ArgumentException("Mã hóa đơn không được để trống.");
            }

            return _hoaDonDAL.UpdateHoaDon(maHD, ngayLap, maKH, tongTien, tienCoc, thanhTien);
        }

        public bool DeleteHoaDon(string maHD)
        {
            if (string.IsNullOrEmpty(maHD))
            {
                throw new ArgumentException("Mã hóa đơn không được để trống.");
            }

            return _hoaDonDAL.DeleteHoaDon(maHD);
        }

        public DataTable SearchHoaDon(string keyword)
        {
            return _hoaDonDAL.SearchHoaDon(keyword);
        }
    }

}
