using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer_DAL_.DAL
{


        public class DatabaseConnection
        {
            // Chuỗi kết nối đến cơ sở dữ liệu
            private readonly string connectionString = "Data Source=LAPTOP-O59DV5JH;Initial Catalog=QLSANBONG;Integrated Security=True;Encrypt=False;";

            public SqlConnection GetConnection()
            {
                return new SqlConnection(connectionString);
            }
    }

}
