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
    public partial class frmThemKhachHang : Form
    {
        private BUSKhachHang busKhachHang = new BUSKhachHang();
        private KhachHang khachHang = new KhachHang();
        private string text = "Thêm mới";
        private string btnText = "Thêm Mới";
        private bool allowClose = false;
        public frmThemKhachHang(KhachHang kh)
        {
            InitializeComponent();
            khachHang = kh;
            loadinfo();
        }

        private void loadinfo()
        {
            if (khachHang != null && !string.IsNullOrEmpty(khachHang.MaKhachHang))
            {
                lbThemSach.Text = "Thông Tin Khách Hàng";
                text = "Cập nhật";
                btnText = "Cập Nhật";
                btnThem.Text = btnText;
                txtmakhachhang.Text = khachHang.MaKhachHang;
                txttenkhachhang.Text = khachHang.TenKhachHang;
                txtemailll.Text = khachHang.Email;
                txtcccd.Text = khachHang.CCCD;
                txtsdt.Text = khachHang.SoDienThoai;
                if (khachHang.TrangThai == false)
                {
                    rdoKhongHoatDong.Checked = true;
                }
                else
                {
                    rdoHoatDong.Checked = true;
                }

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maKH = txtmakhachhang.Text.Trim();
            string tenKH = txttenkhachhang.Text.Trim();
            string email = txtemailll.Text.Trim();
            string cccd = txtcccd.Text.Trim();
            string sdt = txtsdt.Text.Trim();
            bool trangThai = rdoHoatDong.Checked;

            // 1. Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(tenKH) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(cccd) || string.IsNullOrWhiteSpace(sdt))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kiểm tra độ dài tên
            if (tenKH.Length > 100)
            {
                MessageBox.Show("Tên khách hàng không được vượt quá 100 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenkhachhang.Focus();
                return;
            }

            // 3. Kiểm tra email hợp lệ
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtemailll.Focus();
                return;
            }

            // 4. Kiểm tra CCCD (12 số)
            if (!System.Text.RegularExpressions.Regex.IsMatch(cccd, @"^\d{12}$"))
            {
                MessageBox.Show("CCCD phải gồm đúng 12 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtcccd.Focus();
                return;
            }

            // 5. Kiểm tra số điện thoại (10 hoặc 11 số)
            if (!System.Text.RegularExpressions.Regex.IsMatch(sdt, @"^\d{10,11}$"))
            {
                MessageBox.Show("Số điện thoại phải gồm 10 hoặc 11 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtsdt.Focus();
                return;
            }

            // 6. Nếu là cập nhật, giữ nguyên ngày tạo cũ
            DateTime ngayTao = khachHang != null && !string.IsNullOrEmpty(khachHang.MaKhachHang)
                ? khachHang.NgayTao
                : DateTime.Now;

            // 7. Tạo đối tượng KhachHang
            KhachHang kh = new KhachHang
            {
                MaKhachHang = maKH,
                TenKhachHang = tenKH,
                Email = email,
                CCCD = cccd,
                SoDienThoai = sdt,
                TrangThai = trangThai,
                NgayTao = ngayTao
            };

            // 8. Gọi BUS (Thêm hoặc Cập nhật)
            string result;
            if (string.IsNullOrEmpty(khachHang?.MaKhachHang))
            {
                // Thêm mới
                result = busKhachHang.InsertKhachHang(kh);
            }
            else
            {
                // Cập nhật
                result = busKhachHang.UpdateKhachHang(kh);
            }

            // 9. Xử lý kết quả
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show($"{text} khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
