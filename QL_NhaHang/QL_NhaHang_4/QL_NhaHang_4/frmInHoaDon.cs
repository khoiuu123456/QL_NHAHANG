using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;

namespace QL_NhaHang_4
{
    public partial class frmInHoaDon : Form
    {
        SqlConnection conn;
        int idBan;
        string tenNguoiDung;
        int giamGia;
        public frmInHoaDon(int idBan,string tenNguoiDung,int giamGia)
        {
            InitializeComponent();
            this.idBan = idBan;
            this.tenNguoiDung = tenNguoiDung;
            this.giamGia = giamGia;
            conn = new SqlConnection(SQLDatabase.ConnectionString);
        }

        private void frmInHoaDon_Load(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("sp_HienThiHoaDonTheoBan", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@idBan", SqlDbType.Int);
                par1.Value = idBan;
                cmd.Parameters.Add(par1);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                QL_NhaHang_4.ChiTietHoaDon hoaDon = new ChiTietHoaDon();
                hoaDon.Database.Tables["ThongTinHoaDon"].SetDataSource(dt);
                hoaDon.SetParameterValue("TenNguoiDung", tenNguoiDung);
                hoaDon.SetParameterValue("GiamGia", giamGia);
                crystalInHoaDon.ReportSource = null;
                crystalInHoaDon.ReportSource = hoaDon;
            }
            catch { }
            finally { conn.Close(); }
        }
    }
}
