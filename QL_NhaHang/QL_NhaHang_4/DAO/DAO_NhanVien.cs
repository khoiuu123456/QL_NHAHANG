using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_NhanVien
    {
        //DataSet ds = new DataSet();
        static SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);

        public DataTable loadThongTinNhanVien()
        {
            DataTable dt = new DataTable();
            SQLDatabase.OpenConnection(conn);
            SqlCommand cmd = new SqlCommand("sp_HienThiThongTinNV", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            //Sua
            SQLDatabase.CloseConnection(conn);
            return dt;
        }
        public DataTable loadThongTinNhanVienAll()
        {
            DataTable dt = new DataTable();
            SQLDatabase.OpenConnection(conn);
            SqlCommand cmd = new SqlCommand("sp_HienThiThongTinNVAll", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            //Sua
            SQLDatabase.CloseConnection(conn);
            return dt;
        }

        public DataTable loadThongTinNhanVien(string tenNhanVien)
        {
            DataTable dt = new DataTable();
            SQLDatabase.OpenConnection(conn);
            SqlCommand cmd = new SqlCommand("sp_TimKiemNhanVien", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par1 = new SqlParameter("@tenNhanvien", SqlDbType.NVarChar);
            par1.Value = tenNhanVien;
            cmd.Parameters.Add(par1);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            SQLDatabase.CloseConnection(conn);
            return dt;
        }
        public DataTable locNhanVienTheoChucVu(int idChucvu)
        {
            DataTable dt = new DataTable();
            SQLDatabase.OpenConnection(conn);
            SqlCommand cmd = new SqlCommand("sp_HienThiThongTinNV_ChucVu", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par1 = new SqlParameter("@idChucvu", SqlDbType.Int);
            par1.Value = idChucvu;
            cmd.Parameters.Add(par1);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            SQLDatabase.CloseConnection(conn);
            return dt;

        }
        public DataTable loadCaLam()
        {
            DataTable dt = new DataTable();
            SQLDatabase.OpenConnection(conn);
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.CaLamViec", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            //Sua
            SQLDatabase.CloseConnection(conn);
            return dt;
        }
        public bool themNhanVien(string tenNV, string diaChi, string gioiTinh, string ngaySinh, string sdt, int idChucvu, int idHSL, int idPhuCap, int idChamcong,int idCalam,string ghiChu)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                SqlCommand cmd = new SqlCommand("sp_ThemNhanVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@tenNhanvien", SqlDbType.NVarChar);
                par1.Value = tenNV;
                SqlParameter par2 = new SqlParameter("@diaChi", SqlDbType.NVarChar);
                par2.Value = diaChi;
                SqlParameter par3 = new SqlParameter("@gioiTinh", SqlDbType.NVarChar);
                par3.Value = gioiTinh;
                SqlParameter par4 = new SqlParameter("@ngaySinh", SqlDbType.NVarChar);
                par4.Value = ngaySinh;
                SqlParameter par5 = new SqlParameter("@soDienthoai", SqlDbType.NVarChar);
                par5.Value = sdt;
                SqlParameter par6 = new SqlParameter("@idChucvu", SqlDbType.Int);
                par6.Value = idChucvu;
                SqlParameter par7 = new SqlParameter("@idHesoluong", SqlDbType.Int);
                par7.Value = idHSL;
                SqlParameter par8 = new SqlParameter("@idPhucap", SqlDbType.Int);
                par8.Value = idPhuCap;
                SqlParameter par9 = new SqlParameter("@idChamcong", SqlDbType.Int);
                par9.Value = idChamcong;
                SqlParameter par10 = new SqlParameter("@idCalam", SqlDbType.Int);
                par10.Value = idCalam;
                SqlParameter par11 = new SqlParameter("@ghiChu", SqlDbType.NVarChar);
                par11.Value = ghiChu;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.Parameters.Add(par3);
                cmd.Parameters.Add(par4);
                cmd.Parameters.Add(par5);
                cmd.Parameters.Add(par6);
                cmd.Parameters.Add(par7);
                cmd.Parameters.Add(par8);
                cmd.Parameters.Add(par9);
                cmd.Parameters.Add(par10);
                cmd.Parameters.Add(par11);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            //Sua
            finally { SQLDatabase.CloseConnection(conn); }
        }
        public void xoaNhanVien(int idNhanvien)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                string sql = "UPDATE dbo.NhanVien SET tinhTrang = 'FALSE' WHERE idNhanvien = '"+idNhanvien+"'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch { }
            //Sua
            finally { SQLDatabase.CloseConnection(conn); }
        }
        public bool chinhSuaNhanVien(int idNhanvien, string tenNV, string diaChi, string gioiTinh, string ngaySinh, string sdt, int idChucvu, int idHSL, int idPhuCap, int idChamcong,int idCalam,string ghiChu)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                SqlCommand cmd = new SqlCommand("sp_CapNhatNhanVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@idNhanvien", SqlDbType.Int);
                par1.Value = idNhanvien;
                SqlParameter par2 = new SqlParameter("@tenNhanvien", SqlDbType.NVarChar);
                par2.Value = tenNV;
                SqlParameter par3 = new SqlParameter("@diaChi", SqlDbType.NVarChar);
                par3.Value = diaChi;
                SqlParameter par4 = new SqlParameter("@gioiTinh", SqlDbType.NVarChar);
                par4.Value = gioiTinh;
                SqlParameter par5 = new SqlParameter("@ngaySinh", SqlDbType.NVarChar);
                par5.Value = ngaySinh;
                SqlParameter par6 = new SqlParameter("@soDienthoai", SqlDbType.NVarChar);
                par6.Value = sdt;
                SqlParameter par7 = new SqlParameter("@idChucvu", SqlDbType.Int);
                par7.Value = idChucvu;
                SqlParameter par8 = new SqlParameter("@idHesoluong", SqlDbType.Int);
                par8.Value = idHSL;
                SqlParameter par9 = new SqlParameter("@idPhucap", SqlDbType.Int);
                par9.Value = idPhuCap;
                SqlParameter par10 = new SqlParameter("@idChamcong", SqlDbType.Int);
                par10.Value = idChamcong;
                SqlParameter par11 = new SqlParameter("@idCalam", SqlDbType.Int);
                par11.Value = idCalam;
                SqlParameter par12 = new SqlParameter("@ghiChu", SqlDbType.NVarChar);
                par12.Value = ghiChu;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.Parameters.Add(par3);
                cmd.Parameters.Add(par4);
                cmd.Parameters.Add(par5);
                cmd.Parameters.Add(par6);
                cmd.Parameters.Add(par7);
                cmd.Parameters.Add(par8);
                cmd.Parameters.Add(par9);
                cmd.Parameters.Add(par10);
                cmd.Parameters.Add(par11);
                cmd.Parameters.Add(par12);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            //Sua
            finally { SQLDatabase.CloseConnection(conn); }
        }
        public bool ktChamCongCapNhat(int idNhanvien,int idChamcong)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("sp_KiemTraChamCongCapNhat", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@idNhanvien", SqlDbType.Int);
                par1.Value = idNhanvien;
                SqlParameter par2 = new SqlParameter("@idChamcong", SqlDbType.Int);
                par2.Value = idChamcong;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if(dt.Rows.Count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { return false; }
            //Sua
            finally { SQLDatabase.CloseConnection(conn); }
        }

        public int tinhTongLuongThangNV(int thang, int nam)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                int kq = 0;
                SqlCommand cmd = new SqlCommand("sp_TongluongNVThang", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par2 = new SqlParameter("@thang", SqlDbType.Int);
                par2.Value = thang;
                SqlParameter par3 = new SqlParameter("@nam", SqlDbType.Int);
                par3.Value = nam;
                SqlParameter par4 = new SqlParameter("@Luong", SqlDbType.Int);
                par4.Direction = ParameterDirection.Output;
                par4.Value = kq;
                cmd.Parameters.Add(par2);
                cmd.Parameters.Add(par3);
                cmd.Parameters.Add(par4);
                cmd.ExecuteNonQuery();
                return (int)par4.Value;
            }
            catch { return 0; }
            //Sua
            finally { SQLDatabase.CloseConnection(conn); }
        }

        public int tinhTongLuongNamNV(int nam)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                int kq = 0;
                SqlCommand cmd = new SqlCommand("sp_TongluongNVNam", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par3 = new SqlParameter("@nam", SqlDbType.Int);
                par3.Value = nam;
                SqlParameter par4 = new SqlParameter("@Luong", SqlDbType.Int);
                par4.Direction = ParameterDirection.Output;
                par4.Value = kq;
                cmd.Parameters.Add(par3);
                cmd.Parameters.Add(par4);
                cmd.ExecuteNonQuery();
                return (int)par4.Value;
            }
            catch { return 0; }
            //Sua
            finally { SQLDatabase.CloseConnection(conn); }
        }

        public int ktMaChamCong(int idChamCong)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                string sql = "select count(*) from dbo.NhanVien where idChamcong = '" + idChamCong + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                int kq = (int)cmd.ExecuteScalar();
                return kq;
            }
            catch
            { return -1; }
            finally
            //Sua
            { SQLDatabase.CloseConnection(conn); }
        }
        public int ktLuong(int maNV, int thang, int nam)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                string sql = "select count(*) from dbo.Luong where idNhanvien='" + maNV + "' and thang=" + thang + " and " + "nam = " + nam;
                SqlCommand cmd = new SqlCommand(sql, conn);
                return (int)cmd.ExecuteScalar();
            }
            catch { return -1; }
            //Sua
            finally { SQLDatabase.CloseConnection(conn); }
        }
        public DataTable loadThongTinChamCongNV()
        {
            SQLDatabase.OpenConnection(conn);
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_HienThiChamCongNhanVien", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            SQLDatabase.CloseConnection(conn);
            return dt;
        }
        public decimal tinhLuongNhanVien(int idNhanvien,float tienThuong,int thang,int nam)
        {
            try
            {
                decimal kq = 0;
                SQLDatabase.OpenConnection(conn);
                SqlCommand cmd = new SqlCommand("sp_TinhLuongNhanVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@idNhanvien", SqlDbType.Int);
                par1.Value = idNhanvien;
                SqlParameter par2 = new SqlParameter("@Thuong", SqlDbType.Float);
                par2.Value = tienThuong;
                SqlParameter par3 = new SqlParameter("@Thang", SqlDbType.Int);
                par3.Value = thang;
                SqlParameter par4 = new SqlParameter("@Nam", SqlDbType.Int);
                par4.Value = nam;
                SqlParameter par5 = new SqlParameter("@KQ", SqlDbType.Money);
                par5.Direction = ParameterDirection.Output;
                par5.Value = kq;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.Parameters.Add(par3);
                cmd.Parameters.Add(par4);
                cmd.Parameters.Add(par5);
                cmd.ExecuteNonQuery();
                return (decimal)par5.Value;
            }
            catch { return -1; }
            //Sua
            finally { SQLDatabase.CloseConnection(conn); }
        }
        public bool luuLuongNhanVien(int idNhanvien,decimal luong,int thang,int nam,string ghiChu)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                SqlCommand cmd = new SqlCommand("sp_LuuLuongNhanVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@idNhanvien", SqlDbType.Int);
                par1.Value = idNhanvien;
                SqlParameter par2 = new SqlParameter("@thang", SqlDbType.Int);
                par2.Value = thang;
                SqlParameter par3 = new SqlParameter("@nam", SqlDbType.Int);
                par3.Value = nam;
                SqlParameter par4 = new SqlParameter("@luong", SqlDbType.Money);
                par4.Value = luong;
                SqlParameter par5 = new SqlParameter("@ghiChu", SqlDbType.NVarChar);
                par5.Value = ghiChu;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.Parameters.Add(par3);
                cmd.Parameters.Add(par4);
                cmd.Parameters.Add(par5);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { SQLDatabase.CloseConnection(conn); }
        }
        public DataTable loadDSLuongThangNam(int thang,int nam)
        {
            SQLDatabase.OpenConnection(conn);
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_HienThiLuongNhanVien", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par2 = new SqlParameter("@thang", SqlDbType.Int);
            par2.Value = thang;
            SqlParameter par3 = new SqlParameter("@nam", SqlDbType.Int);
            par3.Value = nam;
            cmd.Parameters.Add(par2);
            cmd.Parameters.Add(par3);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            SQLDatabase.CloseConnection(conn);
            return dt;
        }
        public int sp_KiemTraLuong(int idNhanVien,int thang,int nam)
        {
            try
            {
                int kq = 0;
                SQLDatabase.OpenConnection(conn);
                SqlCommand cmd = new SqlCommand("sp_KiemTraLuongNhanVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@idNhanvien", SqlDbType.Int);
                par1.Value = idNhanVien;
                SqlParameter par2 = new SqlParameter("@thang",SqlDbType.NVarChar);
                par2.Value = thang;
                SqlParameter par3 = new SqlParameter("@nam", SqlDbType.Int);
                par3.Value = nam;
                SqlParameter par4 = new SqlParameter("@kq", SqlDbType.Int);
                par4.Value = kq;
                par4.Direction = ParameterDirection.Output;
                par4.Value = kq;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.Parameters.Add(par3);
                cmd.Parameters.Add(par4);
                cmd.ExecuteNonQuery();
                return (int)par4.Value;
            }
            catch
            {
                return -1;
            }
            finally
            {
                SQLDatabase.CloseConnection(conn);
            }
        }
        public bool CapNhatLuongNhanVien(int idNhanvien, decimal luong, int thang, int nam, string ghiChu)
        {
            try
            {
                SQLDatabase.OpenConnection(conn);
                SqlCommand cmd = new SqlCommand("sp_CapNhatLuongNhanVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@idNhanvien", SqlDbType.Int);
                par1.Value = idNhanvien;
                SqlParameter par2 = new SqlParameter("@thang", SqlDbType.Int);
                par2.Value = thang;
                SqlParameter par3 = new SqlParameter("@nam", SqlDbType.Int);
                par3.Value = nam;
                SqlParameter par4 = new SqlParameter("@luong", SqlDbType.Money);
                par4.Value = luong;
                SqlParameter par5 = new SqlParameter("@ghiChu", SqlDbType.NVarChar);
                par5.Value = ghiChu;
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.Parameters.Add(par3);
                cmd.Parameters.Add(par4);
                cmd.Parameters.Add(par5);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { SQLDatabase.CloseConnection(conn); }
        }
    }
}
