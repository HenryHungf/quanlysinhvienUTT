using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace quanlysinhvien
{
     class ConnectDB
    {
        private readonly string connectionString = "Data Source=hungf;Initial Catalog=CS_QuanLySinhVien12;Integrated Security=True";

        private SqlConnection conn;

        public SqlConnection Connect()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open(); // Đảm bảo mở kết nối trước khi trả về
                return conn;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi kết nối CSDL: {ex.Message}");
            }
        }
    }
}
