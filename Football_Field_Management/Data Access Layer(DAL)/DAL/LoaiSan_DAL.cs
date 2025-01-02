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
    public class LoaiSanDAL : DatabaseConnection
    {
        public DataTable GetAllLoaiSan()
        {
            using (var connection = GetConnection())
            {
                string query = "SELECT * FROM LoaiSan";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public bool AddLoaiSan(string maLoai, string tenLoai, int soNguoiToiDa)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO LoaiSan (MaLoai, TenLoai, SoNguoiToiDa) VALUES (@MaLoai, @TenLoai, @SoNguoiToiDa)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaLoai", maLoai);
                command.Parameters.AddWithValue("@TenLoai", tenLoai);
                command.Parameters.AddWithValue("@SoNguoiToiDa", soNguoiToiDa);
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateLoaiSan(string maLoai, string tenLoai, int soNguoiToiDa)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "UPDATE LoaiSan SET TenLoai = @TenLoai, SoNguoiToiDa = @SoNguoiToiDa WHERE MaLoai = @MaLoai";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaLoai", maLoai);
                command.Parameters.AddWithValue("@TenLoai", tenLoai);
                command.Parameters.AddWithValue("@SoNguoiToiDa", soNguoiToiDa);
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteLoaiSan(string maLoai)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM LoaiSan WHERE MaLoai = @MaLoai";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaLoai", maLoai);
                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
