using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_DAL_.Enity
{
    public class Ca
    {
        [Key]
        public int MaCa { get; set; } 
        public TimeSpan GioBD { get; set; }
        public TimeSpan GioKT { get; set; }
        public virtual ICollection<GiaCa> GiaCas { get; set; }
        public virtual ICollection<ChiTietDatSan> ChiTietDatSans { get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }

}
