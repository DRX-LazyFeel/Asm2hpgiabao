using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL_Xuong;
using GUI_QLThuVien.Helper;

namespace GUI_QLThuVien
{
    public partial class frmDoiMatKhau : Form
    {
        private string maNhanVien;

        public frmDoiMatKhau(string _maNhanVien)
        {
            InitializeComponent();
            maNhanVien = _maNhanVien;

            txtMaNV.Text = maNhanVien;
            txtMaNV.Enabled = false;
        }

        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            if (AuthUtil.IsLogin())
            {
                txtMaNV.Text = AuthUtil.user.MaNhanVien;
                txtTenNV.Text = AuthUtil.user.Ten;
            }
        }

        private void btnShow1_Click(object sender, EventArgs e)
        {

        }

        private void btnShow_Click(object sender, EventArgs e)
        {

        }

        private void btnhide_Click(object sender, EventArgs e)
        {

        }

        private void btnhide1_Click(object sender, EventArgs e)
        {

        }

        private void btnShow2_Click(object sender, EventArgs e)
        {

        }

        private void btnhide2_Click(object sender, EventArgs e)
        {

        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            string matKhauMoi = txtMKMoi.Text.Trim();

            if (string.IsNullOrEmpty(matKhauMoi))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!");
                return;
            }

            DALNhanVien.DoiMatKhau(maNhanVien, matKhauMoi);
            MessageBox.Show("Đổi mật khẩu thành công!");
            this.Close();

        }

        private void chkShowOld_CheckedChanged(object sender, EventArgs e)
        {
            // Nếu CheckBox được tick thì hiện mật khẩu
            if (chkShowOld.Checked)
                txtMKCu.PasswordChar = '\0';  // Hiện
            else
                txtMKCu.PasswordChar = '*';   // Ẩn
        }

        private void chkShowNew_CheckedChanged(object sender, EventArgs e)
        {
            // Nếu CheckBox được tick thì hiện mật khẩu
            if (chkShowNew.Checked)
                txtMKMoi.PasswordChar = '\0';  // Hiện
            else
                txtMKMoi.PasswordChar = '*';   // Ẩn
        }

        private void chkShowRetry_CheckedChanged(object sender, EventArgs e)
        {
            // Nếu CheckBox được tick thì hiện mật khẩu
            if (chkShowRetry.Checked)
                txtEnter.PasswordChar = '\0';  // Hiện
            else
                txtEnter.PasswordChar = '*';   // Ẩn
        }
    }
}
