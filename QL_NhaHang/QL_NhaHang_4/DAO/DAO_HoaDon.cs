using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_HoaDon
    {

        //Nếu kết quả trả về 0 thì bàn chưa có người ngồi
        public int kiemTraTinhTrangBan(int idBan)
        {
            SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
            try
            {
                int kq = 0;
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_KiemTraTinhTrangBan", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@idBan", SqlDbType.Int);
                par1.Value = idBan;
                SqlParameter par2 = new SqlParameter("@kq", SqlDbType.Int);
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
        //sau khi kiểm tra tình trạng bàn thì thêm hóa đơn mới vào bàn đó
        public void themHoaDon(int idBan,int idNguoidung)
        {
            SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ThemHoaDon", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@idBan", SqlDbType.Int);
                par1.Value = idBan;
                SqlParameter par2 = new SqlParameter("@idNguoidung", SqlDbType.Int);
                par2.Value = idNguoidung;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.ExecuteNonQuery();
            }
            catch
            { }
            finally
            { conn.Close(); }
        }
        public void capNhatTinhTrangBan1(int idBan)
        {
            SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_CapNhatTinhTrangBan1", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par2 = new SqlParameter("@idBan", SqlDbType.Int);
                par2.Value = idBan;
                cmd.Parameters.Add(par2);
                cmd.ExecuteNonQuery();
            }
            catch
            { }
            finally
            { conn.Close(); }
        }
        public void capNhatTinhTrangBan0(int idBan)
        {
            SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_CapNhatTinhTrangBan0", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par2 = new SqlParameter("@idBan", SqlDbType.Int);
                par2.Value = idBan;
                cmd.Parameters.Add(par2);
                cmd.ExecuteNonQuery();
            }
            catch
            { }
            finally
            { conn.Close(); }
        }
        //Lẫy mã hóa đơn theo idBan
        public int layIdHoaDon(int idBan)
        {
            SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
            try
            {
                int kq = 0;
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_LayIdHoaDon", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@idBan", SqlDbType.Int);
                par1.Value = idBan;
                SqlParameter par2 = new SqlParameter("@kq", SqlDbType.Int);
                par2.Value = kq;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                par2.Direction = ParameterDirection.Output;
                par2.Value = kq;
                cmd.ExecuteNonQuery();
                return (int)par2.Value;
            }
            catch
            { }
            finally
            { conn.Close(); }
            return -1;
        }
        //sau khi thêm hóa đơn thì vào chi tiết hóa đơn
        public void themChiTietHoaDon(int idHoadon, int idMon, int soLuong)
        {
            SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ThemChiTietHoaDon", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@idHoadon", SqlDbType.Int);
                par1.Value = idHoadon;
                SqlParameter par2 = new SqlParameter("@idMon", SqlDbType.Int);
                par2.Value = idMon;
                SqlParameter par3 = new SqlParameter("@soLuong", SqlDbType.Int);
                par3.Value = soLuong;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.Parameters.Add(par3);
                cmd.ExecuteNonQuery();
            }
            catch
            { }
            finally
            { conn.Close(); }
        }
        public DataTable layChiTietHoaDon(int idBan)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_HienThiHoaDonTheoBan", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par = new SqlParameter("@idBan", SqlDbType.Int);
                par.Value = idBan;
                cmd.Parameters.Add(par);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch
            { }
            finally { conn.Close(); }
            return dt;
        }
        public int layMaxIdHoaDon()
        {
            SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
            try
            {
                int kq = 0;
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_LayMaxIdHoaDon", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@idBan", SqlDbType.Int);
                par1.Value = kq;
                par1.Direction = ParameterDirection.Output;
                par1.Value = kq;
                cmd.Parameters.Add(par1);
                cmd.ExecuteNonQuery();
                return (int)par1.Value;
            }
            catch
            { }
            finally
            { conn.Close(); }
            return -1;
        }
        public void capNhatHoaDon(int idHoaDon, int tongTien,int idNguoidung)
        {
            SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_CapNhatHoaDon", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@idHoaDon", SqlDbType.Int);
                par1.Value = idHoaDon;
                SqlParameter par2 = new SqlParameter("@tongTien", SqlDbType.Int);
                par2.Value = tongTien;
                SqlParameter par3 = new SqlParameter("@idNguoidung", SqlDbType.Int);
                par3.Value = idNguoidung;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.Parameters.Add(par3);
                cmd.ExecuteNonQuery();
            }
            catch
            { }
            finally
            { conn.Close(); }
        }
        public int layTongTienTheoHoaDon(int idHoaDon)
        {
            SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
            try
            {
                int kq = 0;
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_LayTongTien", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@idHoaDon", SqlDbType.Int);
                par1.Value = idHoaDon;
                SqlParameter par2 = new SqlParameter("@kq", SqlDbType.Int);
                par2.Value = kq;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                par2.Direction = ParameterDirection.Output;
                par2.Value = kq;
                cmd.ExecuteNonQuery();
                return (int)par2.Value;
            }
            catch
            { }
            finally
            { conn.Close(); }
            return -1;
        }
        public void xoaMonKhoiHoaDon(int idHoaDon, string tenMon)
        {
            SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_XoaMonHoaDon", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@idHoaDon", SqlDbType.Int);
                par1.Value = idHoaDon;
                SqlParameter par2 = new SqlParameter("@tenMon", SqlDbType.NVarChar);
                par2.Value = tenMon;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.ExecuteNonQuery();
            }
            catch
            { }
            finally
            { conn.Close(); }
        }
        public string layNgayVaoBan(int idBan)
        {
            DataTable dt = new DataTable();
            string date = "";
            SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_HienThiNgayVao", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@idBan", SqlDbType.Int);
                par1.Value = idBan;
                cmd.Parameters.Add(par1);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                
                foreach(DataRow row in dt.Rows)
                {
                    date = row["ngayNhap"].ToString();
                }
                return date;
            }
            catch
            { return date; }
            finally
            { conn.Close(); }
        }
    }
}
