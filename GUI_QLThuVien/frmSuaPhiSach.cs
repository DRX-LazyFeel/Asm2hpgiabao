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
    public partial class frmSuaPhiSach : Form
    {
        private PhiSach phiSach;
        public frmSuaPhiSach(PhiSach ps)
        {
            InitializeComponent();
            phiSach = ps;

            // Load thông tin vào form
            txtMaPhiSach.Text = ps.MaPhiSach;
            txtMa.Text = ps.MaSach;
            txtPhiMuon.Text = ps.PhiMuon.ToString();
            txtPhiPhat.Text = ps.PhiPhat.ToString();
            if (ps.TrangThai)
                rdoApDung.Checked = true;
            else
                rdoNgungApDung.Checked = true;

            txtMaPhiSach.ReadOnly = true;
        }


        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string maSach = txtMa.Text.Trim();
            string phiMuonStr = txtPhiMuon.Text.Trim();
            string phiPhatStr = txtPhiPhat.Text.Trim();

            // Kiểm tra mã sách
            if (string.IsNullOrEmpty(maSach))
            {
                MessageBox.Show("Vui lòng nhập mã sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMa.Focus();
                return;
            }

            // Kiểm tra phí mượn
            if (!decimal.TryParse(phiMuonStr, out decimal phiMuon) || phiMuon < 0)
            {
                MessageBox.Show("Phí mượn phải là số hợp lệ và không âm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhiMuon.Focus();
                return;
            }

            // Kiểm tra phí phạt
            if (!decimal.TryParse(phiPhatStr, out decimal phiPhat) || phiPhat < 0)
            {
                MessageBox.Show("Phí phạt phải là số hợp lệ và không âm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhiPhat.Focus();
                return;
            }

            // Gán lại dữ liệu
            phiSach.MaSach = maSach;
            phiSach.PhiMuon = phiMuon;
            phiSach.PhiPhat = phiPhat;
            phiSach.TrangThai = rdoApDung.Checked;

            // Cập nhật
            var bus = new BUSPhiSach();
            string result = bus.UpdatePhiSach(phiSach);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
