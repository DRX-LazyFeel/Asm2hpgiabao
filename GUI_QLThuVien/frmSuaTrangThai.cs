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
    public partial class frmSuaTrangThai : Form
    {
        private TrangThaiThanhToan _data;
        private BUSTrangThaiThanhToan bus = new BUSTrangThaiThanhToan();


        public frmSuaTrangThai(TrangThaiThanhToan data)
        {
            InitializeComponent();
            _data = data;

        }

        private void frmThemTTTT_Load(object sender, EventArgs e)
        {
            if (_data != null)
            {
                txtMa.Text = _data.MaTrangThai;
                txtTen.Text = _data.TenTrangThai;
                txtMa.ReadOnly = true; // không cho sửa mã
                txtTen.Focus();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            if (_data == null)
            {
                MessageBox.Show("Dữ liệu trạng thái không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy dữ liệu từ form
            string tenMoi = txtTen.Text.Trim();
            bool trangThaiMoi = rdhoatdong.Checked;

            // 1. Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(tenMoi))
            {
                MessageBox.Show("Vui lòng nhập tên trạng thái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTen.Focus();
                return;
            }

            // 2. Kiểm tra độ dài tên (ví dụ tối đa 50 ký tự)
            if (tenMoi.Length > 50)
            {
                MessageBox.Show("Tên trạng thái không được vượt quá 50 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTen.Focus();
                return;
            }

            // 3. Kiểm tra ký tự hợp lệ (chữ + số + khoảng trắng, không ký tự đặc biệt)
            if (!System.Text.RegularExpressions.Regex.IsMatch(tenMoi, @"^[\p{L}\p{N}\s]+$"))
            {
                MessageBox.Show("Tên trạng thái chỉ được chứa chữ, số và khoảng trắng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTen.Focus();
                return;
            }

            // 4. Nếu dữ liệu không thay đổi -> thông báo
            if (tenMoi.Equals(_data.TenTrangThai, StringComparison.OrdinalIgnoreCase) && trangThaiMoi == _data.TrangThai)
            {
                MessageBox.Show("Không có thay đổi nào để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 5. Tạo đối tượng mới để cập nhật
            TrangThaiThanhToan capNhat = new TrangThaiThanhToan
            {
                MaTrangThai = _data.MaTrangThai,
                TenTrangThai = tenMoi,
                TrangThai = trangThaiMoi,
                NgayTao = _data.NgayTao // Giữ nguyên ngày tạo
            };

            // 6. Gọi BUS
            bool isSuccess = bus.Update(capNhat);

            if (isSuccess)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
