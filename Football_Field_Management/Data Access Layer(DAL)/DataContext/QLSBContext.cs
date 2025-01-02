using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer_DAL_.Enity;

namespace Data_Access_Layer_DAL_.DataContext
{
    public class QLSBContext : DbContext
    {
        public DbSet<DangNhap> DangNhap { get; set; }
        public DbSet<LoaiSan> LoaiSans { get; set; }
        public DbSet<San> Sans { get; set; }
        public DbSet<Ca> Cas { get; set; }
        public DbSet<GiaCa> GiaCas { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<PhieuDatSan> PhieuDatSans { get; set; }
        public DbSet<ChiTietDatSan> ChiTietDatSans { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public QLSBContext() : base("name=QLSANBONG")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
