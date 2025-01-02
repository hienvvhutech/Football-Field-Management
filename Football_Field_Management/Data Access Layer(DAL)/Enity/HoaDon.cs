using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_DAL_.Enity
{
    public class HoaDon
    {
        [Key]
        public int MaHD { get; set; } 
        public int MaPhieu { get; set; } 
        public DateTime NgayThanhToan { get; set; }
        public float TongTien { get; set; }
        public virtual PhieuDatSan PhieuDatSan { get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }

}
