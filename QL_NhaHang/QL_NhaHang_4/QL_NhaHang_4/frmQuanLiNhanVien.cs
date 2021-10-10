using DAO;
using System;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace QL_NhaHang_4
{
    public partial class frmQuanLiNhanVien : Form
    {
        private DAO_NhanVien nhanVien;
        private DAO_ChucVu chucVu;
        private DAO_HSL hSL;
        private DAO_PhuCap phuCap;
        private DAO_ChamCong chamCong;
        public frmQuanLiNhanVien()
        {
            InitializeComponent();
            nhanVien = new DAO_NhanVien();
            chucVu = new DAO_ChucVu();
            hSL = new DAO_HSL();
            phuCap = new DAO_PhuCap();
            chamCong = new DAO_ChamCong();
        }

        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            if (txtTenNhanVien.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtDiaChi.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtSoDienThoai.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtNgaySinh.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtMaChamCong.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã chấm công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (nhanVien.ktMaChamCong(int.Parse(txtMaChamCong.Text.Trim())) == 1)
            {
                MessageBox.Show("Mã chấm công đã thuộc về ai khác rồi!");
                return;
            }
            if (cboChucVu.SelectedValue.ToString().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboHeSoLuong.SelectedValue.ToString().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập hệ số lương", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboCaLam.SelectedValue.ToString().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ca làm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboPhuCap.SelectedValue.ToString().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập vào phụ cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboGioiTinh.SelectedItem.ToString().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string tenNV = txtTenNhanVien.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string gioiTinh = cboGioiTinh.Text.Trim();
            string ngaySinh = txtNgaySinh.Text.Trim();
            string sdt = txtSoDienThoai.Text.Trim();
            string ghiChu = txtGhiChu.Text.Trim();
            int idCalam = (int)cboCaLam.SelectedValue;
            int idChucvu = (int)cboChucVu.SelectedValue;
            int idHesoluong = (int)cboHeSoLuong.SelectedValue;
            int idPhucap = (int)cboPhuCap.SelectedValue;
            int idChamcong = int.Parse(txtMaChamCong.Text.Trim());
            if (nhanVien.themNhanVien(tenNV, diaChi, gioiTinh, ngaySinh, sdt, idChucvu, idHesoluong, idPhucap, idChamcong, idCalam, ghiChu))
            {
                loadNhanVien();
            }
            else
            {
                MessageBox.Show("Thêm không thành công");
            }
        }
        public void loadNhanVien()
        {
            DataTable dt = nhanVien.loadThongTinNhanVien();
            gridNhanVien.DataSource = dt;
            DataBinding(dt);
            gridNhanVien.Columns[0].HeaderText = "ID Nhân viên";
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
        }
        public void loadNhanVienAll()
        {
            DataTable dt = nhanVien.loadThongTinNhanVienAll();
            gridNhanVien.DataSource = dt;
            DataBinding(dt);
            gridNhanVien.Columns[0].HeaderText = "ID Nhân viên";
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
        }
        public void loadNhanVien(string tenNV)
        {
            DataTable dt = nhanVien.loadThongTinNhanVien(tenNV);
            gridNhanVien.DataSource = dt;
            DataBinding(dt);
            gridNhanVien.Columns[0].HeaderText = "ID Nhân viên";
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
        }
        public void loadNhanVien(int idChucvu)
        {
            DataTable dt = nhanVien.locNhanVienTheoChucVu(idChucvu);
            gridNhanVien.DataSource = dt;
            DataBinding(dt);
            gridNhanVien.Columns[0].HeaderText = "ID Nhân viên";
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
        }
        private void frmQuanLiNhanVien_Load(object sender, EventArgs e)
        {
            load_CboChucVu();
            load_CboPhuCap();
            load_CboHeSL();
            load_CboCalam();
            cboGioiTinh.SelectedIndex = 0;
            cboTinhTrangNV.SelectedIndex = 0;
        }
        public void DataBinding(DataTable dt)
        {
            txtMaNhanVien.DataBindings.Clear();
            Binding b1 = new Binding("Text", dt, "idNhanvien", true, DataSourceUpdateMode.Never);
            txtMaNhanVien.DataBindings.Add(b1);

            txtTenNhanVien.DataBindings.Clear();
            Binding b2 = new Binding("Text", dt, "tenNhanvien", true, DataSourceUpdateMode.Never);
            txtTenNhanVien.DataBindings.Add(b2);

            txtDiaChi.DataBindings.Clear();
            Binding b3 = new Binding("Text", dt, "diaChi", true, DataSourceUpdateMode.Never);
            txtDiaChi.DataBindings.Add(b3);

            txtSoDienThoai.DataBindings.Clear();
            Binding b4 = new Binding("Text", dt, "soDienthoai", true, DataSourceUpdateMode.Never);
            txtSoDienThoai.DataBindings.Add(b4);

            txtMaChamCong.DataBindings.Clear();
            Binding b5 = new Binding("Text", dt, "idChamcong", true, DataSourceUpdateMode.Never);
            txtMaChamCong.DataBindings.Add(b5);

            txtGhiChu.DataBindings.Clear();
            Binding b6 = new Binding("Text", dt, "ghiChu", true, DataSourceUpdateMode.Never);
            txtGhiChu.DataBindings.Add(b6);

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

            txtNgaySinh.DataBindings.Clear();
            Binding b11 = new Binding("Text", dt, "ngaySinh", true, DataSourceUpdateMode.Never);
            txtNgaySinh.DataBindings.Add(b11);
        }

        private void txtCapMaCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public void load_CboChucVu()
        {
            cboChucVu.DataSource = chucVu.loadChucVu();
            cboLocChucVu.DataSource = chucVu.loadChucVu();
            cboChucVu.DisplayMember = "tenChucvu";
            cboChucVu.ValueMember = "idChucvu";
            cboLocChucVu.DisplayMember = "tenChucvu";
            cboLocChucVu.ValueMember = "idChucvu";
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
        private void cboChucVu_SelectedValueChanged(object sender, EventArgs e)
        {

        }
        public void DataBindingChamCong(DataTable dt)
        {
            txtMaChamCong.DataBindings.Clear();
            Binding binding = new Binding("Text", dt, "idChamcong", true, DataSourceUpdateMode.Never);
            txtMaChamCong.DataBindings.Add(binding);
        }

        private void rdoChuaCap_CheckedChanged(object sender, EventArgs e)
        {
            /*DataTable dt = chamCong.loadDSChamCongChuaCap();
            gridMaChamCong.DataSource = dt;
            DataBindingChamCong(dt);*/
            gridMaChamCong.DataSource = chamCong.loadDSChamCongChuaCap();
        }

        private void rdoDaCap_CheckedChanged(object sender, EventArgs e)
        {
            gridMaChamCong.DataSource = chamCong.loadDSChamCong();
        }

        private void txtNgaySinh_Validating(object sender, CancelEventArgs e)
        {
            DateTime rs;

            CultureInfo ci = new CultureInfo("en-IE");

            if (!DateTime.TryParseExact(this.txtNgaySinh.Text, "dd/MM/yyyy", ci, DateTimeStyles.None, out rs))
            {
                e.Cancel = true;
            }
        }

        private void btnSuaNhanVien_Click(object sender, EventArgs e)
        {
            if (txtMaNhanVien.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải chọn nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtTenNhanVien.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtDiaChi.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtSoDienThoai.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtNgaySinh.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtMaChamCong.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã chấm công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!nhanVien.ktChamCongCapNhat(int.Parse(txtMaNhanVien.Text.Trim()), int.Parse(txtMaChamCong.Text.Trim())))
            {
                MessageBox.Show("Mã chấm công đã thuộc về ai khác rồi!");
                return;
            }
            if (cboChucVu.SelectedValue.ToString().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboHeSoLuong.SelectedValue.ToString().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập hệ số lương", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboCaLam.SelectedValue.ToString().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ca làm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboPhuCap.SelectedValue.ToString().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập và phụ cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboGioiTinh.SelectedItem.ToString().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int idNhanvien = int.Parse(txtMaNhanVien.Text.ToString());
            string tenNV = txtTenNhanVien.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string gioiTinh = cboGioiTinh.Text.Trim();
            string ngaySinh = txtNgaySinh.Text.Trim();
            string sdt = txtSoDienThoai.Text.Trim();
            string ghiChu = txtGhiChu.Text.Trim();
            int idCalam = (int)cboCaLam.SelectedValue;
            int idChucvu = (int)cboChucVu.SelectedValue;
            int idHesoluong = (int)cboHeSoLuong.SelectedValue;
            int idPhucap = (int)cboPhuCap.SelectedValue;
            int idChamcong = int.Parse(txtMaChamCong.Text.Trim());
            if (MessageBox.Show("Cập nhật thông tin nhân viên " + tenNV, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (nhanVien.chinhSuaNhanVien(idNhanvien, tenNV, diaChi, gioiTinh, ngaySinh, sdt, idChucvu, idHesoluong, idPhucap, idChamcong, idCalam, ghiChu))
                {
                    MessageBox.Show("Cập nhật thành công");
                    loadNhanVien();
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công");
                }
            }
        }

        private void btnXoaNhanVien_Click(object sender, EventArgs e)
        {
            if (txtMaNhanVien.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải chọn nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int idNhanvien = int.Parse(txtMaNhanVien.Text.ToString());
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên " + txtTenNhanVien.Text, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                nhanVien.xoaNhanVien(idNhanvien);
                MessageBox.Show("Xóa thành công");
                loadNhanVien();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaNhanVien.Clear();
            txtTenNhanVien.Clear();
            txtDiaChi.Clear();
            txtNgaySinh.Clear();
            txtSoDienThoai.Clear();
            txtGhiChu.Clear();
        }

        private void btnThemMaCC_Click(object sender, EventArgs e)
        {
            if (txtCapMaCC.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã chấm công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int idChamcong = int.Parse(txtCapMaCC.Text.ToString());
            int kq = chamCong.themChamCong(idChamcong);
            if(kq == 1)
            {
                gridMaChamCong.DataSource = chamCong.loadDSChamCongChuaCap();
            }
            if(kq == 0)
            {
                MessageBox.Show("Mã chấm công đã tồn tại");
                return;
            }
            if(kq == -1)
            {
                MessageBox.Show("Thêm thất bại");
                return;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            loadNhanVien(txtTimKiemNhanVien.Text.ToString());
        }

        private void btnLocChuVu_Click(object sender, EventArgs e)
        {
            if(cboLocChucVu.SelectedValue == null)
            {
                MessageBox.Show("Bạn phải chọn chức vụ cần lọc");
                return;
            }
            int chucVu = int.Parse(cboLocChucVu.SelectedValue.ToString());
            loadNhanVien(chucVu);
        }

        private void txtTimKiemNhanVien_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtTimKiemNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnTimKiem.PerformClick();
            }
        }

        private void cboTinhTrangNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboTinhTrangNV.SelectedIndex == 0)
            {
                loadNhanVien();
            }
            if(cboTinhTrangNV.SelectedIndex == 1)
            {
                loadNhanVienAll();
            }
        }
    }
}
