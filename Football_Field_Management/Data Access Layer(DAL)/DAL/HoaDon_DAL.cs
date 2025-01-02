using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_DAL_.DAL
{
    public class HoaDonDAL : DatabaseConnection
    {
        public DataTable GetAllHoaDon()
        {
            using (var connection = GetConnection())
            {
                string query = "SELECT * FROM HoaDon";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public bool AddHoaDon(string maHD, DateTime ngayLap, string maKH, decimal tongTien, decimal tienCoc, decimal thanhTien)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO HoaDon (MaHD, NgayLap, MaKH, TongTien, TienCoc, ThanhTien) VALUES (@MaHD, @NgayLap, @MaKH, @TongTien, @TienCoc, @ThanhTien)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaHD", maHD);
                command.Parameters.AddWithValue("@NgayLap", ngayLap);
                command.Parameters.AddWithValue("@MaKH", maKH);
                command.Parameters.AddWithValue("@TongTien", tongTien);
                command.Parameters.AddWithValue("@TienCoc", tienCoc);
                command.Parameters.AddWithValue("@ThanhTien", thanhTien);
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateHoaDon(string maHD, DateTime ngayLap, string maKH, decimal tongTien, decimal tienCoc, decimal thanhTien)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "UPDATE HoaDon SET NgayLap = @NgayLap, MaKH = @MaKH, TongTien = @TongTien, TienCoc = @TienCoc, ThanhTien = @ThanhTien WHERE MaHD = @MaHD";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaHD", maHD);
                command.Parameters.AddWithValue("@NgayLap", ngayLap);
                command.Parameters.AddWithValue("@MaKH", maKH);
                command.Parameters.AddWithValue("@TongTien", tongTien);
                command.Parameters.AddWithValue("@TienCoc", tienCoc);
                command.Parameters.AddWithValue("@ThanhTien", thanhTien);
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteHoaDon(string maHD)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM HoaDon WHERE MaHD = @MaHD";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaHD", maHD);
                return command.ExecuteNonQuery() > 0;
            }
        }

        public DataTable SearchHoaDon(string keyword)
        {
            using (var connection = GetConnection())
            {
                string query = "SELECT * FROM HoaDon WHERE MaHD LIKE @Keyword OR MaKH LIKE @Keyword";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }
    }
}
