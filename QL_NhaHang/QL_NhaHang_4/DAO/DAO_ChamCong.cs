using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DAO_ChamCong
    {
        private static SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
        public DataTable loadDSChamCong()
        {
            DataTable dt = new DataTable();
            string sql = "select * from dbo.ChamCong";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public DataTable loadDSChamCongChuaCap()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_HienThiChamCongChuaCap", conn);
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public int themChamCong(int idChamcong)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ThemChamCong", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@idChamcong", SqlDbType.Int);
                par1.Value = idChamcong;
                cmd.Parameters.Add(par1);
                if (ktIdChamCong(idChamcong))
                {
                    return 0;
                }
                else
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return 1;
                }

            }
            catch { return -1; }
            finally { conn.Close(); }
        }
        public bool ktIdChamCong(int idChamcong)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                SqlCommand cmd = new SqlCommand("select count(*) from ChamCong where idChamcong = '" + idChamcong + "'", conn);
                int kq = (int)cmd.ExecuteScalar();
                if (kq == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { return false; }
            finally { conn.Close(); }
        }
        public bool xoaChamCong(string maCC)
        {
            try
            {
                conn.Open();
                string sql = "delete from dbo.ChamCong where idChamcong='" + maCC + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally { conn.Close(); }
        }
        public bool capNhatChamCong(string maCC, string ngay, string thang)
        {
            try
            {
                conn.Open();
                string sql = "update dbo.ChamCong set soNgaylamviec=" + ngay + " where idChamcong='" + maCC + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
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
        public bool capnhatThang(string thang)
        {
            try
            {
                conn.Open();
                string sql = "update dbo.Chamcong set thang =" + thang;
                SqlCommand cmd = new SqlCommand(sql, conn);
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
        public DataTable loadChamCongTheoThangNam(int thang, int nam)
        {
            SQLDatabase.OpenConnection(conn);
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_HienThiNgayCongTheoThangNam", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par1 = new SqlParameter("@thang", SqlDbType.Int);
            par1.Value = thang;
            SqlParameter par2 = new SqlParameter("@nam", SqlDbType.Int);
            par2.Value = nam;
            cmd.Parameters.Add(par1);
            cmd.Parameters.Add(par2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            SQLDatabase.CloseConnection(conn);
            return dt;
        }
        public bool capNhatNgayCong(int idChamcong, int thang, int nam, int soNgaylam)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                SqlCommand cmd = new SqlCommand("sp_CapNhatNgayCong", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@idChamcong", SqlDbType.Int);
                par1.Value = idChamcong;
                SqlParameter par2 = new SqlParameter("@thang", SqlDbType.Int);
                par2.Value = thang;
                SqlParameter par3 = new SqlParameter("@nam", SqlDbType.Int);
                par3.Value = nam;
                SqlParameter par4 = new SqlParameter("@soNgaylam", SqlDbType.Int);
                par4.Value = soNgaylam;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.Parameters.Add(par3);
                cmd.Parameters.Add(par4);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { SQLDatabase.CloseConnection(conn); }
        }
        public bool ktCapNhatNgayCong(int idChamcong, int thang, int nam)
        {
            try
            {
                int kq = 0;
                SQLDatabase.OpenConnection(conn);
                SqlCommand cmd = new SqlCommand("sp_KiemTraCapNhatNgayCong", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@idChamcong", SqlDbType.Int);
                par1.Value = idChamcong;
                SqlParameter par2 = new SqlParameter("@thang", SqlDbType.Int);
                par2.Value = thang;
                SqlParameter par3 = new SqlParameter("@nam", SqlDbType.Int);
                par3.Value = nam;
                SqlParameter par4 = new SqlParameter("@kq", SqlDbType.Int);
                par4.Value = kq;
                par4.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.Parameters.Add(par3);
                cmd.Parameters.Add(par4);
                cmd.ExecuteNonQuery();
                if ((int)par4.Value == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { return false; }
            finally { SQLDatabase.CloseConnection(conn); }
        }
        public bool capNhatLaiNgayCong(int idChamcong, int thang, int nam, int soNgaylam)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                SqlCommand cmd = new SqlCommand("sp_CapNhatLaiNgayCong", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@idChamcong", SqlDbType.Int);
                par1.Value = idChamcong;
                SqlParameter par2 = new SqlParameter("@thang", SqlDbType.Int);
                par2.Value = thang;
                SqlParameter par3 = new SqlParameter("@nam", SqlDbType.Int);
                par3.Value = nam;
                SqlParameter par4 = new SqlParameter("@soNgaylam", SqlDbType.Int);
                par4.Value = soNgaylam;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.Parameters.Add(par3);
                cmd.Parameters.Add(par4);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { SQLDatabase.CloseConnection(conn); }
        }
    }
}
