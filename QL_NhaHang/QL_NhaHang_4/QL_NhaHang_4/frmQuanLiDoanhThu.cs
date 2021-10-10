using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;

namespace QL_NhaHang_4
{
    public partial class frmQuanLiDoanhThu : Form
    {
        DAO_DoanhThu DoanhThu;
        public frmQuanLiDoanhThu()
        {
            InitializeComponent();
            DoanhThu = new DAO_DoanhThu();
        }

        private void btnLocDoanhThu_Click(object sender, EventArgs e)
        {
            int nam = int.Parse(cboNam.SelectedItem.ToString());
            loadDoanhThuThang(nam);
            loadTongLuongThang(nam);
        }
        public void loadDoanhThuThang(int nam)
        {
            DataTable dt = new DataTable();
            chartDoanThuThang.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chartDoanThuThang.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            dt = DoanhThu.loadDoanhThuNam(nam);
            string[] x = new string[dt.Rows.Count];
            decimal[] y = new decimal[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToDecimal(dt.Rows[i][1]);
            }
            chartDoanThuThang.Series[0].Points.DataBindXY(x, y);
        }
        public void loadTongLuongThang(int nam)
        {
            DataTable dt = new DataTable();
            chartLuongNV.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chartLuongNV.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            dt = DoanhThu.layDSTongLuongThang(nam);
            string[] x = new string[dt.Rows.Count];
            decimal[] y = new decimal[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToDecimal(dt.Rows[i][1]);
            }
            chartLuongNV.Series[0].Points.DataBindXY(x, y);
        }

        private void frmQuanLiDoanhThu_Load(object sender, EventArgs e)
        {
            cboNam.SelectedIndex = 0;
            cboThangDoanhThu.SelectedIndex = 0;
            cboNamDoanhThu.SelectedIndex = 0;
            int nam = int.Parse(cboNam.SelectedItem.ToString());
            loadDoanhThuThang(nam);
            loadTongLuongThang(nam);
            DateTime dt = txtNgay.Value;
            int ngay = dt.Day;
            int thang = dt.Month;
            int nam1 = dt.Year;
            loadGridTienBan(ngay, thang, nam1);
        }
        public void loadGridTienBan(int ngay,int thang,int nam)
        {
            DataTable dt = DoanhThu.loadHoaDonTheoNgay(ngay, thang, nam);
            gridHoaDon.DataSource = dt;
            gridHoaDon.Columns[0].HeaderText = "Mã HD";
            gridHoaDon.Columns[1].HeaderText = "Mã bàn";
            gridHoaDon.Columns[2].HeaderText = "Ngày nhập";
            gridHoaDon.Columns[3].HeaderText = "Ngày xuất";
            gridHoaDon.Columns[4].HeaderText = "Tình trạng";
            gridHoaDon.Columns[5].HeaderText = "Tổng tiền";
        }

        private void btnLocNgay_Click(object sender, EventArgs e)
        {
            DateTime dt = txtNgay.Value;
            int ngay = dt.Day;
            int thang = dt.Month;
            int nam1 = dt.Year;
            int thang1 = int.Parse(cboThangDoanhThu.SelectedItem.ToString());
            int nam2 = int.Parse(cboNamDoanhThu.SelectedItem.ToString());
            loadGridTienBan(ngay, thang, nam1);
            int tienBan = DoanhThu.layDoanhThuNgay(ngay, thang, nam1);
            int tienBanThang = DoanhThu.layDoanhThuThang(thang1, nam2);
            int tienBanNam = DoanhThu.layDoanhThuNam(nam2);
            txtHDNgay.Text = string.Format("{0:0,0 VNĐ}", tienBan);
            txtHDThang.Text = string.Format("{0:0,0 VNĐ}", tienBanThang);
            txtHDNam.Text = string.Format("{0:0,0 VNĐ}", tienBanNam);
        }
    }
}
