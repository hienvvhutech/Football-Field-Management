using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_DAL_.Enity
{
    public class PhieuDatSan
    {
        [Key] 
        public int MaPhieu { get; set; } 
        public int MaKH { get; set; }
        public DateTime NgayDat { get; set; }
        public float TienCoc { get; set; }
        public string GhiChu { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public virtual ICollection<ChiTietDatSan> ChiTietDatSans { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }

}
