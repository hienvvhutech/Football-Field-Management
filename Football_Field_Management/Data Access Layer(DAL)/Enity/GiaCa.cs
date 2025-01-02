using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_DAL_.Enity
{
    public class GiaCa
    {
        [Key]
        public int MaGia { get; set; } 
        public int MaLoaiSan { get; set; } 
        public int MaCa { get; set; } 
        public float Gia { get; set; }
        public virtual LoaiSan LoaiSan { get; set; }
        public virtual Ca Ca { get; set; }
    }

}
