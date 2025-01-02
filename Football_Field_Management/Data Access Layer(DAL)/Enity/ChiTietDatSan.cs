using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_DAL_.Enity
{
    public class ChiTietDatSan
    {
        [Key]
        public int MaChiTiet { get; set; } 
        public int MaPhieu { get; set; } 
        public int MaSan { get; set; } 
        public int MaCa { get; set; } 
        public virtual PhieuDatSan PhieuDatSan { get; set; }
        public virtual San San { get; set; }
        public virtual Ca Ca { get; set; }
    }

}
