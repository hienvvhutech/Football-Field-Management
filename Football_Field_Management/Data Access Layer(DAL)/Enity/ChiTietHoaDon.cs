using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_DAL_.Enity
{
    public class ChiTietHoaDon
    {
        [Key]
        public int MaChiTietHD { get; set; } 
        public int MaHD { get; set; } 
        public int MaSan { get; set; } 
        public int MaCa { get; set; } 
        public int SoGio { get; set; }
        public float DonGia { get; set; }
        public float ThanhTien { get; set; }
        public virtual HoaDon HoaDon { get; set; }
        public virtual San San { get; set; }
        public virtual Ca Ca { get; set; }
    }

}
