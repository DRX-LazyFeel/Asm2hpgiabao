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
    public partial class frmsualoaisach : Form
    {

        private BUSTheLoaiSach busTheLoaiSach = new BUSTheLoaiSach();
        private TheLoaiSach theLoaiSach = new TheLoaiSach();
        private string text = "Thêm mới";
        private string btnText = "Thêm Mới";
        public frmsualoaisach()
        {
            InitializeComponent();
        }
        private string maTheLoaiCapNhat = "";

        public void SetData(string ma, string ten, bool trangThai)
        {
            maTheLoaiCapNhat = ma;
            txtmatheloai.Text = ma;
            txttentheloai.Text = ten;
            rdoHoatDong.Checked = trangThai;
        }


        private void btsua_Click(object sender, EventArgs e)
        {
            string tenTheLoai = txttentheloai.Text.Trim();
            bool trangThai = rdoHoatDong.Checked;

            // Kiểm tra mã thể loại
            if (string.IsNullOrEmpty(maTheLoaiCapNhat))
            {
                MessageBox.Show("Mã thể loại không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra tên thể loại
            if (string.IsNullOrEmpty(tenTheLoai))
            {
                MessageBox.Show("Vui lòng nhập tên thể loại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttentheloai.Focus();
                return;
            }

            if (tenTheLoai.Length < 2)
            {
                MessageBox.Show("Tên thể loại phải có ít nhất 2 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttentheloai.Focus();
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(tenTheLoai, @"^[\p{L}0-9\s]+$"))
            {
                MessageBox.Show("Tên thể loại chỉ được chứa chữ, số và khoảng trắng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttentheloai.Focus();
                return;
            }

            // Gán lại đối tượng
            theLoaiSach.MaTheLoai = maTheLoaiCapNhat;
            theLoaiSach.TenTheLoai = tenTheLoai;
            theLoaiSach.TrangThai = trangThai;

            string result = busTheLoaiSach.UpdateTheLoaiSach(theLoaiSach);

            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Cập nhật thể loại sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Lỗi khi cập nhật thể loại sách: " + result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
