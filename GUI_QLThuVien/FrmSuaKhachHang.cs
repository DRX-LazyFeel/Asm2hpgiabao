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
    public partial class FrmSuaKhachHang : Form
    {
        private KhachHang khachhang;
        private BUSKhachHang BUSKhachHang = new BUSKhachHang();

        public FrmSuaKhachHang(KhachHang khachHang)
        {
            InitializeComponent();
            this.khachhang = khachHang;
        }

        private void FrmSuaKhachHang_Load(object sender, EventArgs e)
        {
            txtmakhachhang.Text = khachhang.MaKhachHang;
            txttenkhachhang.Text = khachhang.TenKhachHang;
            txtemailll.Text = khachhang.Email;
            txtsdt.Text = khachhang.SoDienThoai;
            txtcccd.Text = khachhang.CCCD;

            if (khachhang.TrangThai)
                rdoHoatDong.Checked = true;
            else
                rdoKhongHoatDong.Checked = true;
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            string ten = txttenkhachhang.Text.Trim();
            string email = txtemailll.Text.Trim();
            string sdt = txtsdt.Text.Trim();
            string cccd = txtcccd.Text.Trim();

            // Kiểm tra rỗng
            if (string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(cccd))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra tên
            if (ten.Length < 2)
            {
                MessageBox.Show("Tên khách hàng phải có ít nhất 2 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra email
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra số điện thoại
            if (!System.Text.RegularExpressions.Regex.IsMatch(sdt, @"^\d{10,11}$"))
            {
                MessageBox.Show("Số điện thoại phải gồm 10 hoặc 11 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra CCCD
            if (!System.Text.RegularExpressions.Regex.IsMatch(cccd, @"^\d{12}$"))
            {
                MessageBox.Show("CCCD phải gồm 12 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gán lại giá trị vào đối tượng
            khachhang.TenKhachHang = ten;
            khachhang.Email = email;
            khachhang.SoDienThoai = sdt;
            khachhang.CCCD = cccd;
            khachhang.TrangThai = rdoHoatDong.Checked;

            // Gọi BUS cập nhật
            string result = BUSKhachHang.UpdateKhachHang(khachhang);

            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
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

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
