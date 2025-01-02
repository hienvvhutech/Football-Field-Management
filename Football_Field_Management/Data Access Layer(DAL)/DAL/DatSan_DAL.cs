using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_DAL_.DAL
{
    public class DatSanDAL : DatabaseConnection
    {
        public DataTable GetAllDatSan()
        {
            using (var connection = GetConnection())
            {
                string query = "SELECT * FROM DatSan";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public bool AddDatSan(string maPhieu, string maKH, DateTime ngayDat, string maSan, TimeSpan gioBD, TimeSpan gioKT, decimal tienCoc, string ghiChu)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO DatSan (MaPhieu, MaKH, NgayDat, MaSan, GioBD, GioKT, TienCoc, GhiChu) VALUES (@MaPhieu, @MaKH, @NgayDat, @MaSan, @GioBD, @GioKT, @TienCoc, @GhiChu)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaPhieu", maPhieu);
                command.Parameters.AddWithValue("@MaKH", maKH);
                command.Parameters.AddWithValue("@NgayDat", ngayDat);
                command.Parameters.AddWithValue("@MaSan", maSan);
                command.Parameters.AddWithValue("@GioBD", gioBD);
                command.Parameters.AddWithValue("@GioKT", gioKT);
                command.Parameters.AddWithValue("@TienCoc", tienCoc);
                command.Parameters.AddWithValue("@GhiChu", ghiChu);
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateDatSan(string maPhieu, string maKH, DateTime ngayDat, string maSan, TimeSpan gioBD, TimeSpan gioKT, decimal tienCoc, string ghiChu)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "UPDATE DatSan SET MaKH = @MaKH, NgayDat = @NgayDat, MaSan = @MaSan, GioBD = @GioBD, GioKT = @GioKT, TienCoc = @TienCoc, GhiChu = @GhiChu WHERE MaPhieu = @MaPhieu";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaPhieu", maPhieu);
                command.Parameters.AddWithValue("@MaKH", maKH);
                command.Parameters.AddWithValue("@NgayDat", ngayDat);
                command.Parameters.AddWithValue("@MaSan", maSan);
                command.Parameters.AddWithValue("@GioBD", gioBD);
                command.Parameters.AddWithValue("@GioKT", gioKT);
                command.Parameters.AddWithValue("@TienCoc", tienCoc);
                command.Parameters.AddWithValue("@GhiChu", ghiChu);
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteDatSan(string maPhieu)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM DatSan WHERE MaPhieu = @MaPhieu";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaPhieu", maPhieu);
                return command.ExecuteNonQuery() > 0;
            }
        }
    }

}
