using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QL_NhaHang_4.Menu_Forms
{
    public partial class frmOrderMon : Form
    {
        private DAO_Mon mon;
        private DAO_HoaDon hoaDon;
        private DTO_NguoiDung nguoiDung;
        private DAO_Ban Ban;
        public frmOrderMon(DTO_NguoiDung nguoiDung)
        {
            InitializeComponent();
            this.nguoiDung = nguoiDung;
            mon = new DAO_Mon();
            hoaDon = new DAO_HoaDon();
            Ban = new DAO_Ban();
        }

        private void frmOrderMon_Load(object sender, EventArgs e)
        {
            loadBan();
            loadDSBan();
        }

        private void frmOrderMon_Resize(object sender, EventArgs e)
        {

        }
        private void loadBan()
        {
            flowBan.Controls.Clear();
            int width = 133;
            DAO_Ban dAO_Ban = new DAO_Ban();
            List<DTO_Ban> bans = dAO_Ban.getTableList();
            foreach (DTO_Ban ban in bans)
            {
                Button btn = new Button() { Width = width, Height = 119, };
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
                btn.ForeColor = Color.DarkBlue;
                //Button btn = new Button() { Width = (int)140F, Height = (int)130F, };
                btn.Text = ban.TenBan;
                btn.Font = new Font("Times New Roman", 14);
                btn.Click += btn_Click;
                btn.Tag = ban;
                switch (ban.TinhTrang)
                {
                    case 1:
                        btn.BackColor = Color.Crimson;
                        break;
                    case 0:
                        btn.BackColor = Color.White;
                        break;
                }
                flowBan.Controls.Add(btn);
            }
            txtTongTien.Text = string.Format("{0:0,0 đ}", 0);
        }
        private void btn_Click(object sender, EventArgs e)
        {
            int idBan = ((sender as Button).Tag as DTO_Ban).IdBan;
            string tenBan = ((sender as Button).Tag as DTO_Ban).TenBan;
            lstChiTietHoaDon.Tag = (sender as Button).Tag;
            lblTenBan.Text = tenBan;
            hienThiHoaDonTheoBan(idBan);
        }

        private void hienThiHoaDonTheoBan(int idBan)
        {
            int kq = hoaDon.kiemTraTinhTrangBan(idBan);
            if (kq == 1)
            {
                string date = hoaDon.layNgayVaoBan(idBan);
                DateTime dateTime = new DateTime();
                dateTime = Convert.ToDateTime(date);
                lblGioVao.Text = dateTime.ToShortTimeString();
            }
            if (kq == 0)
            {
                lblGioVao.Text = "";
            }
            int tongTien = 0;
            DataTable dt = hoaDon.layChiTietHoaDon(idBan);
            lstChiTietHoaDon.Clear();
            lstChiTietHoaDon.View = View.Details;
            lstChiTietHoaDon.Columns.Add("Tên món").Width = 170;
            lstChiTietHoaDon.Columns.Add("Đơn giá").Width = 110;
            lstChiTietHoaDon.Columns.Add("Số lượng").Width = 90;
            lstChiTietHoaDon.Columns.Add("Thành tiền").Width = 120;
            lstChiTietHoaDon.GridLines = true;
            lstChiTietHoaDon.FullRowSelect = true;
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                lstChiTietHoaDon.Items.Add(row["tenMon"].ToString());
                lstChiTietHoaDon.Items[i].SubItems.Add(row["donGia"].ToString());
                lstChiTietHoaDon.Items[i].SubItems.Add(row["soLuong"].ToString());
                lstChiTietHoaDon.Items[i].SubItems.Add(row["thanhTien"].ToString());
                tongTien += int.Parse(row["thanhTien"].ToString());
                i++;
            }
            txtTongTien.Text = string.Format("{0:0,0 đ}", tongTien);
        }
        private void flowBan_Resize(object sender, EventArgs e)
        {

        }

        private void flowBan_SizeChanged(object sender, EventArgs e)
        {
            //loadBan();
        }

        private void btnMonNuong_Click(object sender, EventArgs e)
        {
            cboTenMon.DataSource = mon.loadDsMonTheoDm(2);
            cboTenMon.DisplayMember = "tenMon";
            cboTenMon.ValueMember = "idMon";
        }

        private void btnMonHap_Click(object sender, EventArgs e)
        {
            cboTenMon.DataSource = mon.loadDsMonTheoDm(4);
            cboTenMon.DisplayMember = "tenMon";
            cboTenMon.ValueMember = "idMon";
        }

        private void btnMonLau_Click(object sender, EventArgs e)
        {
            cboTenMon.DataSource = mon.loadDsMonTheoDm(1);
            cboTenMon.DisplayMember = "tenMon";
            cboTenMon.ValueMember = "idMon";
        }

        private void btnComMi_Click(object sender, EventArgs e)
        {
            cboTenMon.DataSource = mon.loadDsMonTheoDm(3);
            cboTenMon.DisplayMember = "tenMon";
            cboTenMon.ValueMember = "idMon";
        }

        private void btnNuoc_Click(object sender, EventArgs e)
        {
            cboTenMon.DataSource = mon.loadDsMonTheoDm(5);
            cboTenMon.DisplayMember = "tenMon";
            cboTenMon.ValueMember = "idMon";
        }

        private void btnKhac_Click(object sender, EventArgs e)
        {
            cboTenMon.DataSource = mon.loadDsMonTheoDm(6);
            cboTenMon.DisplayMember = "tenMon";
            cboTenMon.ValueMember = "idMon";
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            DTO_Ban ban = lstChiTietHoaDon.Tag as DTO_Ban;
            if (ban == null)
            {
                MessageBox.Show("Bạn chưa chọn bàn", "Thông báo");
                return;
            }
            else if (cboTenMon.SelectedValue == null)
            {
                MessageBox.Show("Bạn chưa chọn món", "Thông báo");
                return;
            }
            int idBan = ban.IdBan;
            int idHoaDon = 0;
            int idMon = int.Parse(cboTenMon.SelectedValue.ToString());
            int soLuong = int.Parse(numSoLuongMon.Value.ToString());
            idHoaDon = hoaDon.layIdHoaDon(idBan);
            if (hoaDon.kiemTraTinhTrangBan(idBan) == 0)
            {
                if (idHoaDon == -1)
                {
                    hoaDon.themHoaDon(idBan, nguoiDung.IdNguoidung);
                    hoaDon.capNhatTinhTrangBan1(idBan);
                    hoaDon.themChiTietHoaDon(hoaDon.layIdHoaDon(idBan), idMon, soLuong);
                    flowBan.Controls.Clear();
                    loadBan();
                    hienThiHoaDonTheoBan(idBan);
                }
            }
            else
            {
                hoaDon.themChiTietHoaDon(idHoaDon, idMon, soLuong);
                hienThiHoaDonTheoBan(idBan);
            }
        }

        private void btnHuyMon_Click(object sender, EventArgs e)
        {
            DTO_Ban ban = lstChiTietHoaDon.Tag as DTO_Ban;
            if (ban == null)
            {
                MessageBox.Show("Bạn chưa chọn bàn", "Thông báo");
                return;
            }
            if (txtMon.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa chọn món", "Thông báo");
                return;
            }
            int idBan = ban.IdBan;
            int idHoaDon = 0;
            idHoaDon = hoaDon.layIdHoaDon(idBan);
            hoaDon.xoaMonKhoiHoaDon(idHoaDon, txtMon.Text);
            hienThiHoaDonTheoBan(idBan);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            DTO_Ban ban = lstChiTietHoaDon.Tag as DTO_Ban;
            if (ban == null)
            {
                MessageBox.Show("Bạn chưa chọn bàn", "Thông báo");
                return;
            }
            if (!Ban.kiemTraTinhTrangBan(ban.IdBan))
            {
                MessageBox.Show("Bàn đang trống", "Thông báo");
                return;
            }
            int idBan = ban.IdBan;
            int idHoaDon = 0;
            idHoaDon = hoaDon.layIdHoaDon(idBan);
            int tongTien = hoaDon.layTongTienTheoHoaDon(idHoaDon);
            int giamGia = 0;
            if(txtGiamGia.Text.Length > 0)
            {
                giamGia = int.Parse(txtGiamGia.Text.ToString());
            }
            if (giamGia > tongTien)
            {
                MessageBox.Show("Giảm giá phải nhỏ hơn tổng tiền", "Thông báo");
                txtGiamGia.Focus();
            }
            int thanhToan = tongTien - giamGia;
            txtThanhToan.Text = string.Format("{0:0,0 đ}", thanhToan);
            if (MessageBox.Show("Bạn có chắc chắn muốn thanh toán?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                hoaDon.capNhatHoaDon(idHoaDon, (hoaDon.layTongTienTheoHoaDon(idHoaDon) - giamGia), nguoiDung.IdNguoidung);
                hoaDon.capNhatTinhTrangBan0(idBan);
                flowBan.Controls.Clear();
                loadBan();
            }
            txtGiamGia.Text = "0";
            txtThanhToan.Clear();
        }
        private void loadDSBan()
        {
            DAO_Ban ban = new DAO_Ban();
            cboChuyenban.DataSource = ban.loadDSCboBan();
            cboChuyenban.DisplayMember = "tenBan";
            cboChuyenban.ValueMember = "idBan";
        }
        private void lstChiTietHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lsv = sender as ListView;
            if (lstChiTietHoaDon.SelectedItems.Count > 0)
            {
                ListViewItem item = lsv.SelectedItems[0];
                txtMon.Text = item.Text;
            }
        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            DTO_Ban ban = lstChiTietHoaDon.Tag as DTO_Ban;
            int idBan1 = ban.IdBan;
            int idBan2 = int.Parse(cboChuyenban.SelectedValue.ToString());
            if (ban == null)
            {
                MessageBox.Show("Bạn chưa chọn bàn", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show(string.Format("Bạn có chắc chắn chuyến từ {0} sang bàn {1} hay không", ban.TenBan, idBan2 - 1), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                if (idBan1 == idBan2)
                {
                    MessageBox.Show("Không thể chuyển", "Thông báo");
                    return;
                }
                if (!Ban.kiemTraTinhTrangBan(idBan1) && !Ban.kiemTraTinhTrangBan(idBan2))
                {
                    MessageBox.Show("Không thể chuyển", "Thông báo");
                    return;
                }
                if (!Ban.kiemTraTinhTrangBan(idBan1) && Ban.kiemTraTinhTrangBan(idBan2))
                {
                    MessageBox.Show("Không thể chuyển", "Thông báo");
                    return;
                }
                if (Ban.chuyenBan(idBan1, idBan2))
                {
                    Ban.chuyenBan(idBan1, idBan2);
                    flowBan.Controls.Clear();
                    loadBan();
                }
                else
                {
                    MessageBox.Show("Không thể chuyển được");
                }
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            DTO_Ban ban = lstChiTietHoaDon.Tag as DTO_Ban;
            if (ban == null)
            {
                MessageBox.Show("Bàn đang trống", "Thông báo");
                return;
            }
            frmInHoaDon frm = new frmInHoaDon(ban.IdBan, nguoiDung.TenHienThi, int.Parse(txtGiamGia.Text.ToString()));
            frm.ShowDialog();
        }
    }
}
