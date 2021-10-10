using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_DanhMucMon
    {
        public DataTable loadDanhMucMon()
        {
            SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM dbo.DanhMucMon", conn);
                da.Fill(dt);
                return dt;
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
    }
}
