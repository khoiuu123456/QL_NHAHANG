using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using DAO;

namespace QL_NhaHang_4
{
    public partial class frmTaiKhoan : Form
    {
        DTO_NguoiDung nguoiDung;
        public frmTaiKhoan(DTO_NguoiDung nguoiDung)
        {
            InitializeComponent();
            this.nguoiDung = nguoiDung;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtMatKhauCu.Enabled = true;
            txtMatKhau.Enabled = true;
            txtNhapLaiMatKhau.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DAO_NguoiDung dAO_NguoiDung = new DAO_NguoiDung();
            if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật tài khoản","Thông báo",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                int kq = dAO_NguoiDung.sp_KiemTraDangNhap(txtTenDN.Text, txtMatKhauCu.Text);
                if (kq == 0)
                {
                    MessageBox.Show("Mật khẩu cũ không đúng", "Thông báo");
                    return;
                }
                if(txtMatKhau.Text.Equals(txtNhapLaiMatKhau.Text) == false)
                {
                    MessageBox.Show("Mật khẩu không trùng nhau", "Thông báo");
                    return;
                }
                else
                {
                    
                    dAO_NguoiDung.capNhatTaiKhoan(txtTenHienThi.Text,txtTenDN.Text,txtNhapLaiMatKhau.Text);
                }
            }
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            txtTenDN.Text = nguoiDung.TenDangNhap;
            txtTenHienThi.Text = nguoiDung.TenHienThi;
            txtMatKhauCu.Enabled = false;
            txtMatKhau.Enabled = false;
            txtNhapLaiMatKhau.Enabled = false; 
        }
    }
}
