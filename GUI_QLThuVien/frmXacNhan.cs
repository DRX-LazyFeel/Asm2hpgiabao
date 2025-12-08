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
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GUI_QLThuVien
{
    public partial class frmXacNhan : Form
    {
        private string email;

        public frmXacNhan(string _email)
        {
            InitializeComponent();
            email = _email;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text.Trim();
            string mkMoi = txtRSPass.Text.Trim();

            if (BUSQuenMatKhau.XacNhan(email, ma, mkMoi))
            {
                MessageBox.Show("Thay đổi mật khẩu thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Mã không đúng hoặc đã hết hạn!");
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text.Trim();
            string mk = txtRSPass.Text.Trim();

            if (BUSQuenMatKhau.XacNhan(email, ma, mk))
            {
                MessageBox.Show("Mật khẩu đã được cập nhật!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Mã xác nhận không hợp lệ hoặc đã hết hạn.");
            }

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
