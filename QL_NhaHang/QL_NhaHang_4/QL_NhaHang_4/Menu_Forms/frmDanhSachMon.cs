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

namespace QL_NhaHang_4.Menu_Forms
{
    public partial class frmDanhSachMon : Form
    {
        DAO_Mon mon;
        DAO_DanhMucMon dmMon;
        public frmDanhSachMon()
        {
            InitializeComponent();
            mon = new DAO_Mon();
            dmMon = new DAO_DanhMucMon();
        }

        private void frmDanhSachMon_Load(object sender, EventArgs e)
        {
            loadDSMon();
            loadDanhMucMon();
        }

        public void loadDSMon()
        {
            DataTable dt = mon.loadDanhSachMon();
            gridDSMon.DataSource = dt;
            gridDSMon.Columns[0].HeaderText = "ID Món";
            gridDSMon.Columns[1].HeaderText = "Tên món";
            gridDSMon.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gridDSMon.Columns[2].HeaderText = "Đơn giá";
            gridDSMon.Columns[3].HeaderText = "Danh mục";
            gridDSMon.Columns[4].HeaderText = "Tình trạng";
            DataBinding(dt);
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            if (txtTenMon.Text.Length == 0 || txtDonGia.Text.Length == 0 || cboDanhMuc.SelectedValue.ToString().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string tenMon = txtTenMon.Text;
            int donGia = int.Parse(txtDonGia.Text);
            int tinhTrangMon = 1;
            int idDanhmuc = int.Parse(cboDanhMuc.SelectedValue.ToString());
            try
            {
                if (mon.KiemTraMon(tenMon) == 0)
                {
                    if (mon.themMon(tenMon, donGia, idDanhmuc, tinhTrangMon) == 1)
                    {
                        loadDSMon();
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công", "Thông báo");
                    }
                }
                else
                {
                    MessageBox.Show("Món đã tồn tại", "Thông báo");
                }

            }
            catch
            {
                MessageBox.Show("Thêm không thành công", "Thông báo");
            }
        }

        public void DataBinding(DataTable dt)
        {
            txtIdMon.DataBindings.Clear();
            Binding b1 = new Binding("Text", dt, "idMon", true, DataSourceUpdateMode.Never);
            txtIdMon.DataBindings.Add(b1);

            txtTenMon.DataBindings.Clear();
            Binding b2 = new Binding("Text", dt, "tenMon", true, DataSourceUpdateMode.Never);
            txtTenMon.DataBindings.Add(b2);

            txtDonGia.DataBindings.Clear();
            Binding b3 = new Binding("Text", dt, "donGia", true, DataSourceUpdateMode.Never);
            txtDonGia.DataBindings.Add(b3);

        }
        public void loadDanhMucMon()
        {
            cboDanhMuc.DataSource = dmMon.loadDanhMucMon();
            cboDanhMuc.DisplayMember = "tenDanhmuc";
            cboDanhMuc.ValueMember = "idDanhmuc";
        }

        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            if (txtIdMon.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa chọn món", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int idMon = int.Parse(txtIdMon.Text);
            mon.xoaMon(idMon);
            loadDSMon();
        }
        public void loadDSTheoTen(string tenMon)
        {
            DataTable dt = mon.timKiemMonAnTheoTen(tenMon);
            gridDSMon.Controls.Clear();
            gridDSMon.DataSource = dt;
            DataBinding(dt);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tenMon = txtTimKiem.Text.ToString();
            loadDSTheoTen(tenMon);
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnTimKiem.PerformClick();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtIdMon.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa chọn món", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int idMon = int.Parse(txtIdMon.Text);
            string tenMon = txtTenMon.Text;
            int donGia = int.Parse(txtDonGia.Text);
            int idDanhmuc = int.Parse(cboDanhMuc.SelectedValue.ToString());
            if (rdoCon.Checked)
            {
                mon.capNhatMon(idMon, tenMon, donGia, idDanhmuc, 1);
            }
            else if (rdoHet.Checked)
            {
                mon.capNhatMon(idMon, tenMon, donGia, idDanhmuc, 0);
            }
            loadDSMon();
        }

    }
}
