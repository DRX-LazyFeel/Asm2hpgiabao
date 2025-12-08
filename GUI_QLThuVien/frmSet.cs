using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_Xuong;
using Microsoft.VisualBasic.ApplicationServices;

namespace GUI_QLThuVien
{
    public partial class frmSet : Form
    {
        private NhanVien currentUser;
        public frmSet(NhanVien user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void btnDoiMK_Click_1(object sender, EventArgs e)
        {
            frmDoiMatKhau doiMatKhauForm = new frmDoiMatKhau();
            doiMatKhauForm.ShowDialog();
        }

        private void frmSet_Load(object sender, EventArgs e)
        {
            if (SessionLogin.CurrentUser != null)
            {
                txtTen.Text = SessionLogin.CurrentUser.Ten;
                txtSDT.Text = SessionLogin.CurrentUser.SoDienThoai;
                txtEmail.Text = SessionLogin.CurrentUser.Email;
            }
        }
    }
}
