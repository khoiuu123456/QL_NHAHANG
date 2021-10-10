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
    public class DAO_NguoiDung
    {
        static SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
        public int sp_KiemTraDangNhap(string tenDangnhap, string matKhau)
        {
            try
            {
                int kq = 0;
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_KiemTraDangNhap", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@tenDangnhap", System.Data.SqlDbType.NVarChar);
                par1.Value = tenDangnhap;
                SqlParameter par2 = new SqlParameter("@Matkhau", System.Data.SqlDbType.NVarChar);
                par2.Value = matKhau;
                SqlParameter par3 = new SqlParameter("@Kq", System.Data.SqlDbType.Int);
                par3.Value = kq;
                par3.Direction = System.Data.ParameterDirection.Output;
                par3.Value = kq;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.Parameters.Add(par3);
                cmd.ExecuteNonQuery();
                return (int)par3.Value;
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
            return -1;
        }
        public int kiemTraLoaiTaiKhoan(string tenDN)
        {
            int kq = 0;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spKiemTraTaiKhoanId", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@tenDangnhap", SqlDbType.NVarChar);
                par1.Value = tenDN;
                SqlParameter par2 = new SqlParameter("@kq", conn);
                par2.Value = kq;
                par2.Direction = ParameterDirection.Output;
                par2.Value = kq;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.ExecuteNonQuery();
                return (int)par2.Value;
            }
            catch { }
            finally { conn.Close(); }
            return 0;
        }
        public DataTable loadKieuNguoiDung()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                string sql = "SELECT * FROM dbo.KieuNguoiDung";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch { }
            finally { conn.Close(); }
            return dt;
        }
        public int kiemTraTenDN(string tenDN)
        {
            try
            {
                conn.Open();
                string sql = "select count(*) from dbo.NguoiDung where tenDangnhap='" + tenDN + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                int kq = (int)cmd.ExecuteScalar();
                return kq;
            }
            catch { return -1; }
            finally { conn.Close(); }
        }
        public bool themTaiKhoan(int kieuND,int idNhanvien, string tenHienThi, string tenDN, string matKhau)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ThemNguoiDung", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@idKieunguoidung", SqlDbType.Int);
                par1.Value = kieuND;
                SqlParameter par5 = new SqlParameter("@idNhanvien", SqlDbType.Int);
                par5.Value = idNhanvien;
                SqlParameter par2 = new SqlParameter("@tenHienthi", SqlDbType.NVarChar);
                par2.Value = tenHienThi;
                SqlParameter par3 = new SqlParameter("@tenDangnhap", SqlDbType.NVarChar);
                par3.Value = tenDN;
                SqlParameter par4 = new SqlParameter("@matKhau", SqlDbType.NVarChar);
                par4.Value = matKhau;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.Parameters.Add(par3);
                cmd.Parameters.Add(par4);
                cmd.Parameters.Add(par5);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally { conn.Close(); }
        }
        public DTO_NguoiDung layNguoiDung(string username)
        {
            DTO_NguoiDung nguoiDung = null;
            try
            {
                DataTable dt = new DataTable();
                conn.Open();
                string sql = "SELECT * FROM dbo.NguoiDung WHERE tenDangnhap = '" + username + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    nguoiDung = new DTO_NguoiDung(row);
                }
                return nguoiDung;
            }
            catch { }
            finally { conn.Close(); }
            return nguoiDung;
        }
        public bool capNhatTaiKhoan(string tenHienThi, string userName, string Pass)
        {
            conn.Open();
            string sql = "UPDATE dbo.NguoiDung SET tenHienthi = N'" + tenHienThi + "', matKhau = N'" + Pass + "' WHERE tenDangnhap = N'" + userName + "'";
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { conn.Close(); }
        }
    }
}
