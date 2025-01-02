using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_DAL_.Enity
{
    public class LoaiSan
    {
        [Key]
        public int MaLoaiSan { get; set; } 
        public string TenLoaiSan { get; set; }
        public int SoNguoiToiDa { get; set; }

        // Navigation property
        public virtual ICollection<San> Sans { get; set; }
    }

}
