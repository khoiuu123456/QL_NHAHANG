using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_NhaHang_4
{
    public partial class frmCauHinh : Form
    {
        public frmCauHinh()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnKetnoi_Click(object sender, EventArgs e)
        {
            if (txtSever.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên server", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDatabase.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên database", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtPass.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtUser.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên username", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string conn = "Data Source=" + txtSever.Text.Trim() + ";Initial Catalog=" + txtDatabase.Text.Trim() + ";User id=" + txtUser.Text.Trim() + ";Password=" + txtPass.Text.Trim() + ";";
            Properties.Settings.Default.ConectionString = conn;
            Properties.Settings.Default.Save();
            this.Close();
        }
    }
}
