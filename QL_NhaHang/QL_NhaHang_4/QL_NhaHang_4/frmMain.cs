using DTO;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QL_NhaHang_4
{
    public partial class frmMain : Form
    {
        private Form activeForm;
        private int loaiTK;
        private Random random;
        private DTO_NguoiDung nguoiDung;
        private Button currentButton;
        private int tempIndex;
        public frmMain(int loaiTK, DTO_NguoiDung nguoiDung)
        {
            this.loaiTK = loaiTK;
            this.nguoiDung = nguoiDung;
            InitializeComponent();
            if (loaiTK == 1)
            {
                btnFrmOrder.Enabled = true;
                btnFrmThemban.Enabled = true;
            }
            if (loaiTK == 3)
            {
                btnFrmOrder.Enabled = true;
                btnFrmThemban.Enabled = false;
                btnFrmDanhSachNhanVien.Enabled = false;
                btnFrmXemLuong.Enabled = false;
                btnFrmCapTaiKhoan.Enabled = false;
            }
            random = new Random();
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        //Update align title of form
        private void UpdateTextPosition()
        {
            Graphics g = this.CreateGraphics();
            Double startingPoint = (this.Width / 2) - (g.MeasureString(this.Text.Trim(), this.Font).Width / 2);
            Double widthOfASpace = g.MeasureString(" ", this.Font).Width;
            String tmp = " ";
            Double tmpWidth = 0;

            while ((tmpWidth + widthOfASpace) < startingPoint)
            {
                tmp += " ";
                tmpWidth += widthOfASpace;
            }

            this.Text = tmp + this.Text.Trim();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            CustomMenuDesize();
            lblTenHienThi.Text = nguoiDung.TenHienThi;
            lblTenTK.Text = nguoiDung.TenDangNhap;
        }
        private void OpenChildForm(Form childForm, Object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            activeForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelForm.Controls.Add(childForm);
            this.panelForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lbMenu.Text = childForm.Text;
        }

        private void btnFrmOrder_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Menu_Forms.frmOrderMon(nguoiDung), sender);
        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            Reset();
        }

        private void Reset()
        {
            lbMenu.Text = "Nhà hàng Yaki";
        }

        private void btnFrmMon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Menu_Forms.frmDanhSachMon(), sender);
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    //currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    //pannelTieuDe.BackColor = color;
                    //panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseChildForm.Visible = true;
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaxsize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (panelMenu.Width == 224)
            {
                panelMenu.Width = 2;
            }
            else
            {
                panelMenu.Width = 224;
            }
        }
        private void CustomMenuDesize()
        {
            panelQuanLiBan.Visible = false;
            panelQuanLiDoanhThu.Visible = false;
            panelQuanLiMon.Visible = false;
            panelQuanLiNhanVien.Visible = false;
        }
        private void AnSubMenu()
        {
            if (panelQuanLiBan.Visible == true)
            {
                panelQuanLiBan.Visible = false;
            }
            if (panelQuanLiNhanVien.Visible == true)
            {
                panelQuanLiNhanVien.Visible = false;
            }
            if (panelQuanLiDoanhThu.Visible == true)
            {
                panelQuanLiDoanhThu.Visible = false;
            }
            if (panelQuanLiMon.Visible == true)
            {
                panelQuanLiMon.Visible = false;
            }
        }
        private void HienSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                AnSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void btnQuanLiBan_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            HienSubMenu(panelQuanLiBan);
        }

        private void btnQuanLiMon_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            HienSubMenu(panelQuanLiMon);
        }

        private void btnQuanLiDoanhThu_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            HienSubMenu(panelQuanLiDoanhThu);
        }

        private void btnQuanLiNhanVien_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            HienSubMenu(panelQuanLiNhanVien);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTaiKhoan(nguoiDung), sender);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
            frmLogin frm = new frmLogin();
            frm.Show();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btnFrmThemban_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThemBan(),sender);
        }

        private void btnFrmDanhSachNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQuanLiNhanVien(), sender);
        }

        private void btnFrmXemLuong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmLuongNhanVien(), sender);
        }

        private void btnFrmTienBan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQuanLiDoanhThu(), sender);
        }

        private void btnFrmCapTaiKhoan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmCapTaiKhoanNV(), sender);
        }
    }
}
