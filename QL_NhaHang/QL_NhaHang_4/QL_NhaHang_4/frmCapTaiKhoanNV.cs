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
    public partial class frmCapTaiKhoanNV : Form
    {
        DAO_NhanVien nhanVien;
        DAO_NguoiDung nguoiDung;
        public frmCapTaiKhoanNV()
        {
            InitializeComponent();
            nhanVien = new DAO_NhanVien();
            nguoiDung = new DAO_NguoiDung();
        }

        private void frmCapTaiKhoanNV_Load(object sender, EventArgs e)
        {
            LoadGridNhanVien();
            loadCboNguoiDung();
        }
        public void LoadGridNhanVien()
        {
            DataTable dt = new DataTable();
            dt = nhanVien.loadThongTinNhanVien();
            gridNhanVien.DataSource = dt; gridNhanVien.Columns[0].HeaderText = "ID Nhân viên";
            gridNhanVien.Columns[1].HeaderText = "Tên nhân viên";
            gridNhanVien.Columns[2].HeaderText = "Địa chỉ";
            gridNhanVien.Columns[3].HeaderText = "Giới tính";
            gridNhanVien.Columns[4].HeaderText = "Ngày sinh";
            gridNhanVien.Columns[5].HeaderText = "Số điện thoại";
            gridNhanVien.Columns[6].HeaderText = "Tên chức vụ";
            gridNhanVien.Columns[7].HeaderText = "Hệ số lương";
            gridNhanVien.Columns[8].HeaderText = "Tiền phụ cấp";
            gridNhanVien.Columns[9].HeaderText = "Ca làm";
            gridNhanVien.Columns[10].HeaderText = "Mã chấm công";
            gridNhanVien.Columns[11].HeaderText = "Ghi chú";
            gridNhanVien.Columns[12].HeaderText = "Tình trạng";
            DataBinding(dt);
        }
        public void loadCboNguoiDung()
        {
            cboKieuNguoiDung.DataSource = nguoiDung.loadKieuNguoiDung();
            cboKieuNguoiDung.ValueMember = "idKieunguoidung";
            cboKieuNguoiDung.DisplayMember = "tenKieunguoidung";
        }
        public void DataBinding(DataTable dt)
        {
            txtTenHienThi.DataBindings.Clear();
            Binding b2 = new Binding("Text", dt, "tenNhanvien", true, DataSourceUpdateMode.Never);
            txtTenHienThi.DataBindings.Add(b2);
            txtMaNV.DataBindings.Clear();
            Binding b3 = new Binding("Text", dt, "idNhanvien", true, DataSourceUpdateMode.Never);
            txtMaNV.DataBindings.Add(b3);
        }

        private void btnCapTK_Click(object sender, EventArgs e)
        {
            if(txtMaNV.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa chọn nhân viên", "Thông báo");
                return;
            }
            if(txtTenDangNhap.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên đăng nhập", "Thông báo");
                return;
            }
            if (txtTenHienThi.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hiển thị", "Thông báo");
                return;
            }
            if (txtMatKhau.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu", "Thông báo");
                return;
            }
            if (txtXacNhanMK.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải xác nhận mật khẩu", "Thông báo");
                return;
            }
            string tenDN = txtTenDangNhap.Text.ToString();
            string tenHienThi = txtTenHienThi.Text.ToString();
            string matKhau = txtMatKhau.Text.ToString();
            string xacNhanMatKhau = txtXacNhanMK.Text.ToString();
            int idKieuND = int.Parse(cboKieuNguoiDung.SelectedValue.ToString());
            int idNhanvien = int.Parse(txtMaNV.Text.ToString());
            if(matKhau.Equals(xacNhanMatKhau))
            {
                if(nguoiDung.themTaiKhoan(idKieuND, idNhanvien, tenHienThi, tenDN, matKhau));
                {
                    MessageBox.Show("Cấp tài khoản thành công", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu không trùng khớp", "Thông báo");
                return;
            }
        }

        private void btnResetMK_Click(object sender, EventArgs e)
        {

        }
    }
}
