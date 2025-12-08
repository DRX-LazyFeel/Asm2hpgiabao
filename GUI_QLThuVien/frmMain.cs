using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_Xuong;

namespace GUI_QLThuVien
{
    public partial class frmMain : Form
    {

        private NhanVien currentUser;
        public frmMain()
        {
            InitializeComponent();
        }

        private Form currentFormChild;

        private void openChildForm(Form formChild)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = formChild;
            formChild.TopLevel = false;
            formChild.FormBorderStyle = FormBorderStyle.None;
            formChild.Dock = DockStyle.Fill;
            pnMain.Controls.Add(formChild);
            pnMain.Tag = formChild;
            formChild.BringToFront();
            formChild.Show();

        }

        private void btnQLSach_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "QUẢN LÝ SÁCH";
            openChildForm(new frmSach());
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "NHÂN VIÊN";
            openChildForm(new frmNhanVien());
        }

        private void txtTitle_Resize(object sender, EventArgs e)
        {
            txtTitle.Left = (this.ClientSize.Width - txtTitle.Width) / 2;
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "TRANG CHỦ";
            openChildForm(new frmTrangChu());
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            txtTitle.Text = "TRANG CHỦ";
            openChildForm(new frmTrangChu());
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "ĐỌC GIẢ";
            openChildForm(new frmKhachHang());
        }

        private void btnMuonTra_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "MƯỢN TRẢ SÁCH";
            openChildForm(new frmMuonTra());
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "BÁO CÁO - THỐNG KÊ";
            openChildForm(new FormTKBieuDo());
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnQLPhiSach_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "QUẢN LÝ PHÍ SÁCH";
            openChildForm(new frmPhiSach());
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.Show();
            this.Hide(); // Ẩn form chính

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "Setting";
            openChildForm(new frmSet(currentUser));
        }

        private void btnTTTT_Click(object sender, EventArgs e)
        {
            openChildForm(new frmTrangThaiThanhToan());
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
