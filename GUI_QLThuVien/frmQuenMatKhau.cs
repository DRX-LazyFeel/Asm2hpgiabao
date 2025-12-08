using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_Xuong;
using DTO_Xuong;

namespace GUI_QLThuVien
{
    public partial class frmQuenMatKhau : Form
    {
        public frmQuenMatKhau()
        {
            InitializeComponent();
            MessageBox.Show("Gửi Yêu Cầu Cấp Lại Mật Khẩu Tài Khoản", "Thông báo",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            if (BUSQuenMatKhau.GuiMa(email, out string ma))
            {
                MessageBox.Show($"Mã xác nhận của bạn là: {ma}", "Mã xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmXacNhan frm = new frmXacNhan(email);
                this.Enabled = false;

                frm.FormClosed += (s, args) =>
                {
                    this.Enabled = true;
                    this.Activate();
                };

                frm.Show();
            }
            else
            {
                MessageBox.Show("Email không tồn tại trong hệ thống.");
            }

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
