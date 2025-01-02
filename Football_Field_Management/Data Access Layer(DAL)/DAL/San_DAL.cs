using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer_DAL_.DataContext;
using Data_Access_Layer_DAL_.Enity;

namespace Data_Access_Layer_DAL_.DAL
{
    public class SanDAL : DatabaseConnection
    {
        public DataTable GetAllSan()
        {
            using (var connection = GetConnection())
            {
                string query = "SELECT * FROM San";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public bool AddSan(string maSan, string tenSan, string loaiSan, int soNguoiToiDa, string trangThai)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO San (MaSan, TenSan, LoaiSan, SoNguoiToiDa, TrangThai) VALUES (@MaSan, @TenSan, @LoaiSan, @SoNguoiToiDa, @TrangThai)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaSan", maSan);
                command.Parameters.AddWithValue("@TenSan", tenSan);
                command.Parameters.AddWithValue("@LoaiSan", loaiSan);
                command.Parameters.AddWithValue("@SoNguoiToiDa", soNguoiToiDa);
                command.Parameters.AddWithValue("@TrangThai", trangThai);
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateSan(string maSan, string tenSan, string loaiSan, int soNguoiToiDa, string trangThai)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "UPDATE San SET TenSan = @TenSan, LoaiSan = @LoaiSan, SoNguoiToiDa = @SoNguoiToiDa, TrangThai = @TrangThai WHERE MaSan = @MaSan";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaSan", maSan);
                command.Parameters.AddWithValue("@TenSan", tenSan);
                command.Parameters.AddWithValue("@LoaiSan", loaiSan);
                command.Parameters.AddWithValue("@SoNguoiToiDa", soNguoiToiDa);
                command.Parameters.AddWithValue("@TrangThai", trangThai);
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteSan(string maSan)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM San WHERE MaSan = @MaSan";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaSan", maSan);
                return command.ExecuteNonQuery() > 0;
            }
        }

        public DataTable SearchSan(string keyword)
        {
            using (var connection = GetConnection())
            {
                string query = "SELECT * FROM San WHERE MaSan LIKE @Keyword OR TenSan LIKE @Keyword";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }
    }

}
