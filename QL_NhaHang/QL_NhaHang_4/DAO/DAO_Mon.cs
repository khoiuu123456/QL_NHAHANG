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
    public class DAO_Mon
    {
        public int themMon(string tenMon, int donGia, int idDanhmuc, int tinhTrangMon)
        {
            SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ThemMon", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@tenMon", SqlDbType.NVarChar);
                par1.Value = tenMon;
                SqlParameter par2 = new SqlParameter("@donGia", SqlDbType.Int);
                par2.Value = donGia;
                SqlParameter par3 = new SqlParameter("@idDanhmuc", SqlDbType.Int);
                par3.Value = idDanhmuc;
                SqlParameter par4 = new SqlParameter("@tinhTrangMon", SqlDbType.Int);
                par4.Value = tinhTrangMon;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.Parameters.Add(par3);
                cmd.Parameters.Add(par4);
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch { return -1; }
            finally { conn.Close(); }
        }
        public DataTable loadDanhSachMon()
        {
            SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM dbo.Mon", conn);
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
        public int KiemTraMon(string tenMon)
        {
            SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
            try
            {
                int kq = 0;
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_KiemTraMon", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@tenMon", SqlDbType.NVarChar);
                par1.Value = tenMon;
                SqlParameter par2 = new SqlParameter("@kq", SqlDbType.Int);
                par2.Value = kq;
                par2.Direction = ParameterDirection.Output;
                par2.Value = kq;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.ExecuteNonQuery();
                return (int)par2.Value;
            }
            catch
            { }
            finally
            {
                conn.Close();
            }
            return -1;
        }
        public List<DTO_Mon> loadThongTinMon(int idMon)
        {
            List<DTO_Mon> listMon = new List<DTO_Mon>();
            SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_HienThiMonAnTheoId", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@idMon", SqlDbType.Int);
                par1.Value = idMon;
                cmd.Parameters.Add(par1);
                using (DataTable dt = new DataTable())
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                        foreach (DataRow item in dt.Rows)
                        {
                            DTO_Mon mon = new DTO_Mon(item);
                            listMon.Add(mon);
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
            return listMon;
        }
        public DataTable loadDsMonTheoDm(int idDanhmuc)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Mon WHERE idDanhmuc = " + idDanhmuc + "and tinhTrangMon = 1", conn);
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
        public void capNhatMon(int idMon, string tenMon, int donGia, int idDanhmuc, int tinhTrangmon)
        {
            SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_CapNhatMon", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@idMon", SqlDbType.Int);
                par1.Value = idMon;
                SqlParameter par2 = new SqlParameter("@tenMon", SqlDbType.NVarChar);
                par2.Value = tenMon;
                SqlParameter par3 = new SqlParameter("@donGia", SqlDbType.Int);
                par3.Value = donGia;
                SqlParameter par4 = new SqlParameter("@idDanhmuc", SqlDbType.Int);
                par4.Value = idDanhmuc;
                SqlParameter par5 = new SqlParameter("@tinhTrangmon", SqlDbType.Int);
                par5.Value = tinhTrangmon;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.Parameters.Add(par3);
                cmd.Parameters.Add(par4);
                cmd.Parameters.Add(par5);
                cmd.ExecuteNonQuery();
            }
            catch
            { }
            finally
            { conn.Close(); }
        }
        public DataTable timKiemMonAnTheoTen(string tenMon)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM dbo.Mon WHERE tenMon LIKE N'" + tenMon + "%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch
            { }
            finally
            { conn.Close(); }
            return dt;
        }
        public void xoaMon(int idMon)
        {
            SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM dbo.Mon WHERE idMon = " + idMon;
                cmd.ExecuteNonQuery();
            }
            catch
            { }
            finally
            { conn.Close(); }
        }
    }
}
