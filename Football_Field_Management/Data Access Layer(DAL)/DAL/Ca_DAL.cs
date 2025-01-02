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
    public class CaDAL : DatabaseConnection
    {
        public DataTable GetAllCa()
        {
            using (var connection = GetConnection())
            {
                string query = "SELECT * FROM Ca";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public bool AddCa(string maCa, TimeSpan gioBatDau, TimeSpan gioKetThuc)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Ca (MaCa, GioBatDau, GioKetThuc) VALUES (@MaCa, @GioBatDau, @GioKetThuc)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaCa", maCa);
                command.Parameters.AddWithValue("@GioBatDau", gioBatDau);
                command.Parameters.AddWithValue("@GioKetThuc", gioKetThuc);
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateCa(string maCa, TimeSpan gioBatDau, TimeSpan gioKetThuc)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "UPDATE Ca SET GioBatDau = @GioBatDau, GioKetThuc = @GioKetThuc WHERE MaCa = @MaCa";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaCa", maCa);
                command.Parameters.AddWithValue("@GioBatDau", gioBatDau);
                command.Parameters.AddWithValue("@GioKetThuc", gioKetThuc);
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteCa(string maCa)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM Ca WHERE MaCa = @MaCa";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaCa", maCa);
                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
