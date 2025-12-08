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
    public partial class frmThemNhanVien : Form
    {
        private BUSNhanVien busNhanVien = new BUSNhanVien();
        private NhanVien nhanVien = new NhanVien();
        private string text = "Thêm mới";
        private string btnText = "Thêm Mới";
        private bool allowClose = false;
        public frmThemNhanVien(NhanVien nv)
        {
            InitializeComponent();
            nhanVien = nv;
        }
        private void LoadInfo()
        {




            if (nhanVien != null && !string.IsNullOrEmpty(nhanVien.MaNhanVien))
            {
                lbThemSach.Text = "Thông Tin Nhân Viên";
                text = "Cập nhật";
                btnText = "Cập Nhật";
                btnThem.Text = btnText;

                txtMaNhanVien.Text = nhanVien.MaNhanVien;
                txtTenNhanVien.Text = nhanVien.Ten;
                txtEmail.Text = nhanVien.Email;
                txtMatKhau.Text = nhanVien.MatKhau;
                txtSoDienThoai.Text = nhanVien.SoDienThoai;

                rdoNhanVien.Checked = !nhanVien.VaiTro;
                rdoQuanLy.Checked = nhanVien.VaiTro;

                rdoHoatDong.Checked = nhanVien.TrangThai;
                rdoKhongHoatDong.Checked = !nhanVien.TrangThai;
                picHinhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
                // 🔹 Load ảnh nhân viên
                if (!string.IsNullOrEmpty(nhanVien.HinhAnh))
                {
                    // Đã sửa: Sử dụng Path.Combine để tạo đường dẫn tuyệt đối
                    string imagePath = Path.Combine(Application.StartupPath, nhanVien.HinhAnh);
                    if (File.Exists(imagePath))
                    {
                        // Tạo một bản sao của hình ảnh để tránh lỗi khóa file
                        using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                        {
                            picHinhAnh.Image = Image.FromStream(stream);
                        }
                        // Gán Tag để lưu đường dẫn tương đối
                        picHinhAnh.Tag = nhanVien.HinhAnh;
                    }
                    else
                    {
                        picHinhAnh.Image = null;
                        picHinhAnh.Tag = null;
                    }
                }
                else
                {
                    picHinhAnh.Image = null;
                    picHinhAnh.Tag = null;

                }
            }
            }
        private void ThemNhanVien()
        {

            string maNV = txtMaNhanVien.Text.Trim();
            string hoTen = txtTenNhanVien.Text.Trim();
            string email = txtEmail.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
            string phone = txtSoDienThoai.Text.Trim();
            bool trangThai = rdoHoatDong.Checked;

            // Đã sửa lỗi: Lấy giá trị VaiTro trực tiếp từ RadioButton
            bool vaiTro = rdoQuanLy.Checked;

            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(matKhau) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin nhân viên.");
                return;
            }

            string savedPath = picHinhAnh.Tag?.ToString();

            NhanVien nv = new NhanVien
            {
                MaNhanVien = maNV,
                Ten = hoTen,
                Email = email,
                MatKhau = matKhau,
                SoDienThoai = phone,
                VaiTro = vaiTro,
                HinhAnh = savedPath,
                TrangThai = trangThai
            };

            string result = busNhanVien.InsertNhanVien(nv);

            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                allowClose = true;
                this.Close();
            }
            else
            {
                MessageBox.Show(result);
            }
        }
        private void SuaNhanVien()
        {

            string maNV = txtMaNhanVien.Text.Trim();
            string hoTen = txtTenNhanVien.Text.Trim();
            string email = txtEmail.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
            string phone = txtSoDienThoai.Text.Trim();
            bool trangThai = rdoHoatDong.Checked;

            bool vaiTro = false;
            if (rdoQuanLy.Checked)
                vaiTro = true;
            else if (rdoNhanVien.Checked)
                vaiTro = false;
            else
            {
                // Nếu không có chọn thì default là nhân viên
                vaiTro = false;
            }

            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin nhân viên.");
                return;
            }

            if (string.IsNullOrEmpty(matKhau))
                matKhau = nhanVien.MatKhau;

            string savedPath = picHinhAnh.Tag?.ToString() ?? nhanVien.HinhAnh;

            NhanVien nv = new NhanVien
            {
                MaNhanVien = maNV,
                Ten = hoTen,
                Email = email,
                MatKhau = matKhau,
                SoDienThoai = phone,
                VaiTro = vaiTro,
                HinhAnh = savedPath,
                TrangThai = trangThai
            };

            string result = busNhanVien.UpdateNhanVien(nv);

            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show($"{text} nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                allowClose = true;
                this.Close();
            }
            else
            {
                MessageBox.Show(result);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nhanVien.MaNhanVien))
            {
                ThemNhanVien();
            }
            else
            {
                SuaNhanVien();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            allowClose = true;
            this.Close();
        }

        private void frmThemNhanVien_Load(object sender, EventArgs e)
        {
            LoadInfo();
        }

        private void btnChooseImg_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                ofd.Title = "Chọn hình ảnh nhân viên";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = ofd.FileName;
                    string fileName = Path.GetFileName(selectedPath);
                    string destFolder = Path.Combine(Application.StartupPath, "main");
                    string destPath = Path.Combine(destFolder, fileName);

                    if (!Directory.Exists(destFolder))
                        Directory.CreateDirectory(destFolder);

                    try
                    {
                        File.Copy(selectedPath, destPath, true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể sao chép ảnh: " + ex.Message);
                        return;
                    }

                    // Sửa lỗi: Tạo bản sao hình ảnh trước khi hiển thị
                    using (var stream = new FileStream(destPath, FileMode.Open, FileAccess.Read))
                    {
                        picHinhAnh.Image = Image.FromStream(stream);
                    }
                    picHinhAnh.SizeMode = PictureBoxSizeMode.StretchImage;

                    // Lưu đường dẫn tương đối giống frmSach
                    picHinhAnh.Tag = Path.Combine("main", fileName).Replace("\\", "/");
                }
            }
        }

        private void frmThemNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!allowClose && e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
