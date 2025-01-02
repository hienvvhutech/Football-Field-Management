using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_DAL_.Enity
{
    public class San
    {
        [Key]
        public int MaSan { get; set; }
        public string TenSan { get; set; }
        public int MaLoaiSan { get; set; } 
        public string TrangThai { get; set; }

        // Navigation properties
        public virtual LoaiSan LoaiSan { get; set; }
        public virtual ICollection<ChiTietDatSan> ChiTietDatSans { get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }

}
