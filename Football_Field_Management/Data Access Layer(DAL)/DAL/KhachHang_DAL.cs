using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_DAL_.DAL
{
    public class KhachHangDAL : DatabaseConnection
    {
        public DataTable GetAllKhachHang()
        {
            using (var connection = GetConnection())
            {
                string query = "SELECT * FROM KhachHangs";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public bool AddKhachHang(string maKH, string hoTen, string gioiTinh, DateTime ngaySinh, string soDienThoai, string diaChi)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO KhachHangs (MaKH, HoTen, GioiTinh, NgaySinh, SoDienThoai, DiaChi) VALUES (@MaKH, @HoTen, @GioiTinh, @NgaySinh, @SoDienThoai, @DiaChi)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaKH", maKH);
                command.Parameters.AddWithValue("@HoTen", hoTen);
                command.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                command.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                command.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                command.Parameters.AddWithValue("@DiaChi", diaChi);
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateKhachHang(string maKH, string hoTen, string gioiTinh, DateTime ngaySinh, string soDienThoai, string diaChi)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "UPDATE KhachHangs SET HoTen = @HoTen, GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, SoDienThoai = @SoDienThoai, DiaChi = @DiaChi WHERE MaKH = @MaKH";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaKH", maKH);
                command.Parameters.AddWithValue("@HoTen", hoTen);
                command.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                command.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                command.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                command.Parameters.AddWithValue("@DiaChi", diaChi);
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteKhachHang(string maKH)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM KhachHangs WHERE MaKH = @MaKH";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaKH", maKH);
                return command.ExecuteNonQuery() > 0;
            }
        }

        public DataTable SearchKhachHang(string keyword)
        {
            using (var connection = GetConnection())
            {
                string query = "SELECT * FROM KhachHang WHERE MaKH LIKE @Keyword OR HoTen LIKE @Keyword";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }
    }
}
