using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class DAO_Ban
    {
        SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
        public List<DTO_Ban> getTableList()
        {
            List<DTO_Ban> tableList = new List<DTO_Ban>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_HienThiBan", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                using (DataTable data = new DataTable())
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(data);
                        foreach (DataRow item in data.Rows)
                        {
                            DTO_Ban ban = new DTO_Ban(item);
                            tableList.Add(ban);
                        }
                    }
                }
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
            return tableList;
        }
        public DataTable loadDSCboBan()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Ban", conn);
                da.Fill(dt);
                return dt;
            }
            catch
            { }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        public bool chuyenBan(int idBan1, int idBan2)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ChuyenBan", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@idBan1", SqlDbType.Int);
                par1.Value = idBan1;
                SqlParameter par2 = new SqlParameter("@idBan2", SqlDbType.Int);
                par2.Value = idBan2;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            { return false; }
            finally
            { conn.Close(); }
        }
        public bool themBanMoi(string tenBan)
        {
            try
            {
                conn.Open();
                string sql = "insert into dbo.Ban(tenBan,tinhTrang) values(N'" + tenBan + "',0)";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            { conn.Close(); }
        }
        public bool kiemTraTinhTrangBan(int idBan)
        {
            try
            {
                int kq = 0;
                SQLDatabase.OpenConnection(conn);
                SqlCommand cmd = new SqlCommand("sp_KiemTraTinhTrangBan", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@idBan", System.Data.SqlDbType.Int);
                par1.Value = idBan;   
                SqlParameter par3 = new SqlParameter("@kq", System.Data.SqlDbType.Int);
                par3.Value = kq;
                par3.Direction = System.Data.ParameterDirection.Output;
                par3.Value = kq;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par3);
                cmd.ExecuteNonQuery();
                if ((int)par3.Value == 1)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
