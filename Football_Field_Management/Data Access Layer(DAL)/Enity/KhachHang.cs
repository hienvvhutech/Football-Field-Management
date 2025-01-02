using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_DAL_.Enity
{
    public class KhachHang
    {
        [Key]
        public int MaKH { get; set; }
        public string HoTen { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public virtual ICollection<PhieuDatSan> PhieuDatSans { get; set; }
    }

}
