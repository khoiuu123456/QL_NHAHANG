using DAO;
using System;
using System.Data;
using System.Windows.Forms;

namespace QL_NhaHang_4
{
    public partial class frmLuongNhanVien : Form
    {
        private DAO_NhanVien nhanVien;
        private DAO_ChamCong chamCong;
        private DAO_ChucVu chucVu;
        private DAO_HSL hSL;
        private DAO_PhuCap phuCap;
        public frmLuongNhanVien()
        {
            InitializeComponent();
            nhanVien = new DAO_NhanVien();
            chamCong = new DAO_ChamCong();
            chucVu = new DAO_ChucVu();
            hSL = new DAO_HSL();
            phuCap = new DAO_PhuCap();
        }

        private void frmLuongNhanVien_Load(object sender, EventArgs e)
        {
            loadThongTinChamCongNV();
            load_CboChucVu();
            load_CboPhuCap();
            load_CboHeSL();
            load_CboCalam();
            cboThang.SelectedIndex = 0;
            cboNam.SelectedIndex = 0;
        }
        public void loadThongTinChamCongNV()
        {
            DataTable dt = nhanVien.loadThongTinChamCongNV();
            gridTTChamCongNV.DataSource = dt;
            gridTTChamCongNV.Columns[0].HeaderText = "ID";
            gridTTChamCongNV.Columns[1].HeaderText = "Tên nhân viên";
            gridTTChamCongNV.Columns[2].HeaderText = "Tên chức vụ";
            gridTTChamCongNV.Columns[3].HeaderText = "Hệ số lương";
            gridTTChamCongNV.Columns[4].HeaderText = "Tiền phụ cấp";
            gridTTChamCongNV.Columns[5].HeaderText = "Ca làm";
            gridTTChamCongNV.Columns[6].HeaderText = "ID Chấm công";
            DataBinding(dt);

        }
        public void DataBinding(DataTable dt)
        {
            txtIdNhanVien.DataBindings.Clear();
            Binding b1 = new Binding("Text", dt, "idNhanvien", true, DataSourceUpdateMode.Never);
            txtIdNhanVien.DataBindings.Add(b1);

            txtTenNhanVien.DataBindings.Clear();
            Binding b2 = new Binding("Text", dt, "tenNhanvien", true, DataSourceUpdateMode.Never);
            txtTenNhanVien.DataBindings.Add(b2);

            txtMaChamCong.DataBindings.Clear();
            Binding b5 = new Binding("Text", dt, "idChamcong", true, DataSourceUpdateMode.Never);
            txtMaChamCong.DataBindings.Add(b5);

            cboChucVu.DataBindings.Clear();
            Binding b7 = new Binding("Text", dt, "tenChucvu", true, DataSourceUpdateMode.Never);
            cboChucVu.DataBindings.Add(b7);

            cboHeSoLuong.DataBindings.Clear();
            Binding b8 = new Binding("Text", dt, "heSoluong", true, DataSourceUpdateMode.Never);
            cboHeSoLuong.DataBindings.Add(b8);

            cboPhuCap.DataBindings.Clear();
            Binding b9 = new Binding("Text", dt, "tienPhucap", true, DataSourceUpdateMode.Never);
            cboPhuCap.DataBindings.Add(b9);

            cboCaLam.DataBindings.Clear();
            Binding b10 = new Binding("Text", dt, "tenCalam", true, DataSourceUpdateMode.Never);
            cboCaLam.DataBindings.Add(b10);

        }
        public void loadChamCongTheoThangNam(int thang, int nam)
        {
            DataTable dt = chamCong.loadChamCongTheoThangNam(thang, nam);
            gridChamCongThangNam.DataSource = dt;
            gridChamCongThangNam.Columns[0].HeaderText = "Id Chấm công";
            gridChamCongThangNam.Columns[1].HeaderText = "Tên nhân viên";
            gridChamCongThangNam.Columns[2].HeaderText = "Tháng";
            gridChamCongThangNam.Columns[3].HeaderText = "Năm";
            gridChamCongThangNam.Columns[4].HeaderText = "Ngày công";
        }
        public void loadluongTheoThangNam(int thang, int nam)
        {
            DataTable dt = nhanVien.loadDSLuongThangNam(thang, nam);
            gridLuongNhanVien.DataSource = dt;
            gridLuongNhanVien.Columns[0].HeaderText = "Tên nhân viên";
            gridLuongNhanVien.Columns[1].HeaderText = "Tháng";
            gridLuongNhanVien.Columns[2].HeaderText = "Năm";
            gridLuongNhanVien.Columns[3].HeaderText = "Lương";
            gridLuongNhanVien.Columns[4].HeaderText = "Ghi chú";
        }

        private void btnLocChamCong_Click(object sender, EventArgs e)
        {
            int thang = int.Parse(cboThang.SelectedItem.ToString());
            int nam = int.Parse(cboNam.SelectedItem.ToString());
            loadChamCongTheoThangNam(thang, nam);
            loadluongTheoThangNam(thang, nam);
        }

        private void txtSoNgayLam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public void load_CboChucVu()
        {
            cboChucVu.DataSource = chucVu.loadChucVu();
            cboChucVu.DisplayMember = "tenChucvu";
            cboChucVu.ValueMember = "idChucvu";
        }
        public void load_CboHeSL()
        {
            cboHeSoLuong.DataSource = hSL.loadHeSoLuong();
            cboHeSoLuong.DisplayMember = "heSoluong";
            cboHeSoLuong.ValueMember = "idHesoluong";
        }
        public void load_CboPhuCap()
        {
            cboPhuCap.DataSource = phuCap.loadPhuCap();
            cboPhuCap.DisplayMember = "tienPhucap";
            cboPhuCap.ValueMember = "idPhucap";
        }
        public void load_CboCalam()
        {
            cboCaLam.DataSource = nhanVien.loadCaLam();
            cboCaLam.ValueMember = "idCalam";
            cboCaLam.DisplayMember = "tenCalam";
        }

        private void btnCapNhatNgayCong_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSoNgayLam.Text.ToString()))
            {
                MessageBox.Show("Bạn chưa nhập ngày công");
                return;
            }
            int idChamcong = int.Parse(txtMaChamCong.Text.ToString());
            int ngayCong = int.Parse(txtSoNgayLam.Text.ToString());
            int thang = int.Parse(cboThang.SelectedItem.ToString());
            int nam = int.Parse(cboNam.SelectedItem.ToString());
            if (chamCong.ktCapNhatNgayCong(idChamcong, thang, nam))
            {
                if (MessageBox.Show("Ngày công đã được cập nhật! Bạn có muốn sửa lại", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (chamCong.capNhatLaiNgayCong(idChamcong, thang, nam, ngayCong))
                    {
                        loadChamCongTheoThangNam(thang, nam);
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            if (chamCong.capNhatNgayCong(idChamcong, thang, nam, ngayCong))
            {
                loadChamCongTheoThangNam(thang, nam);
            }
        }

        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            float tienThuong = 0;
            float tienPhat = 0;
            if (String.IsNullOrEmpty(txtIdNhanVien.Text.ToString()))
            {
                MessageBox.Show("Bạn phải chọn nhân viên muốn tính lương", "Thông báo");
                return;
            }
            if (String.IsNullOrEmpty(cboThang.SelectedItem.ToString()))
            {
                MessageBox.Show("Bạn phải chọn tháng", "Thông báo");
                return;
            }
            if (String.IsNullOrEmpty(cboNam.SelectedItem.ToString()))
            {
                MessageBox.Show("Bạn phải chọn năm", "Thông báo");
                return;
            }
            if (String.IsNullOrEmpty(txtTienThuong.Text.ToString()))
            {
                MessageBox.Show("Tiền thưởng không được để trống", "Thông báo");
                return;
            }
            if (String.IsNullOrEmpty(txtTienPhat.Text.ToString()))
            {
                MessageBox.Show("Tiền phạt không được để trống", "Thông báo");
                return;
            }
            int idNhanvien = int.Parse(txtIdNhanVien.Text.ToString());
            int thang = int.Parse(cboThang.SelectedItem.ToString());
            int nam = int.Parse(cboNam.SelectedItem.ToString());
            tienThuong = float.Parse(txtTienThuong.Text.ToString());
            tienPhat = float.Parse(txtTienPhat.Text.ToString());
            decimal luong = nhanVien.tinhLuongNhanVien(idNhanvien, tienThuong, thang, nam) - (decimal)tienPhat;
            txtTongLuong.Text = luong.ToString("F");
        }

        private void btnLuuLuong_Click(object sender, EventArgs e)
        {
            if (txtTongLuong.Text.ToString().Length == 0)
            {
                MessageBox.Show("Bạn chưa tính lương cho nhân viên", "Thông báo");
                return;
            }
            if (String.IsNullOrEmpty(txtIdNhanVien.Text.ToString()))
            {
                MessageBox.Show("Bạn phải chọn nhân viên muốn tính lương", "Thông báo");
                return;
            }
            int idNhanvien = int.Parse(txtIdNhanVien.Text.ToString());
            int thang = int.Parse(cboThang.SelectedItem.ToString());
            int nam = int.Parse(cboNam.SelectedItem.ToString());
            string ghiChu = txtGhiChuThuongPhat.Text.ToString();
            decimal tongLuong = Decimal.Parse(txtTongLuong.Text.ToString());
            if (nhanVien.sp_KiemTraLuong(idNhanvien,thang,nam) == 1)
            {
                if(MessageBox.Show("Lương đã được lưu. Bạn có muốn cập nhật lại lương", "Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    nhanVien.CapNhatLuongNhanVien(idNhanvien, tongLuong, thang, nam,ghiChu);
                    loadluongTheoThangNam(thang, nam);
                    MessageBox.Show("Cập nhật thành công");
                    return;
                }
                else
                {
                    return;
                }
            }
            
            if (nhanVien.luuLuongNhanVien(idNhanvien, tongLuong, thang, nam, ghiChu))
            {
                loadluongTheoThangNam(thang, nam);
                MessageBox.Show("Lưu thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Lưu không thành công", "Thông báo");
            }
        }

        private void gridTTChamCongNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTongLuong.Clear();
        }
    }
}
