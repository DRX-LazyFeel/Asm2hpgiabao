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
    public partial class frmthemloaisach : Form
    {
        private BUSTheLoaiSach busTheLoaiSach = new BUSTheLoaiSach();
        private TheLoaiSach theLoaiSach = new TheLoaiSach();
        private string text = "Thêm mới";
        private string btnText = "Thêm Mới";
        public frmthemloaisach()
        {
            InitializeComponent();
        }
        private void loadcbTheLoai()
        {
            //var dsTheLoai = busTheLoaiSach.GetAllTheLoaiSach();
            //comboBox1.DataSource = dsTheLoai;
            //comboBox1.DisplayMember = "TenTheLoai";

        }

        private void frmthemloaisach_Load(object sender, EventArgs e)
        {
            loadcbTheLoai();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maTheLoai = txtmatheloai.Text.Trim();
            string tenTheLoai = txttentheloai.Text.Trim();
            bool trangThai = rdhoatdong.Checked;
            DateTime ngayTao = DateTime.Now;

            // 1. Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(tenTheLoai))
            {
                MessageBox.Show("Vui lòng nhập tên thể loại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttentheloai.Focus();
                return;
            }

            // 2. Kiểm tra độ dài tên thể loại
            if (tenTheLoai.Length > 100)
            {
                MessageBox.Show("Tên thể loại không được vượt quá 100 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttentheloai.Focus();
                return;
            }

            // 3. Kiểm tra ký tự hợp lệ (chỉ cho phép chữ cái, số, khoảng trắng)
            if (!System.Text.RegularExpressions.Regex.IsMatch(tenTheLoai, @"^[\p{L}\p{N}\s]+$"))
            {
                MessageBox.Show("Tên thể loại chỉ được chứa chữ, số và khoảng trắng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttentheloai.Focus();
                return;
            }

            // 4. Sinh mã tự động nếu chưa nhập
            if (string.IsNullOrEmpty(maTheLoai))
            {
                maTheLoai = busTheLoaiSach.GenerateMaTheLoaiSach();
            }

            // 5. Tạo đối tượng TheLoaiSach
            TheLoaiSach theloai = new TheLoaiSach
            {
                MaTheLoai = maTheLoai,
                TenTheLoai = tenTheLoai,
                TrangThai = trangThai,
                NgayTao = ngayTao
            };

            // 6. Gọi BUS thêm dữ liệu
            string result = busTheLoaiSach.InsertTheLoaiSach(theloai);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Thêm thể loại sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Lỗi khi thêm thể loại sách: " + result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
