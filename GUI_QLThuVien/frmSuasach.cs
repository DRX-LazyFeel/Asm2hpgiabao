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
using GUI_QLThuVien; // Giả sử bạn có một namespace Utils chứa imageutil

namespace GUI_QLThuVien
{
    public partial class frmSuasach : Form
    {
        private BUSSach busSach = new BUSSach();
        private Sach sach;

        public frmSuasach(Sach sach)
        {
            InitializeComponent();
            this.sach = sach;
            if (string.IsNullOrEmpty(sach.HinhAnh))
            {
                sach.HinhAnh = new BUS_Xuong.BUSSach().LayHinhAnhTheoMaSach(sach.MaSach);
            }
        }
        private void LoadNhaXuatBan()
        {
            // Giả sử bạn có BUSNhaXuatBan với hàm GetAllNhaXuatBan trả về List<NhaXuatBan>
            var busNxb = new BUSSach();
            var dsNxb = busNxb.GetAllSach();
            cbnxb.DataSource = dsNxb;

            cbnxb.ValueMember = "NhaXuatBan";
        }

        // Hàm load dữ liệu Thể Loại vào ComboBox
        private void LoadTheLoai()
        {
            var busTheLoai = new BUSTheLoaiSach();
            var dsTheLoai = busTheLoai.GetAllTheLoaiSach();
            cbtheloai.DataSource = dsTheLoai;
            cbtheloai.DisplayMember = "TenTheLoai";
            cbtheloai.ValueMember = "MaTheLoai";
        }

        // Hàm load dữ liệu Tác Giả vào ComboBox
        private void LoadTacGia()
        {
            var busTacGia = new BUSTacGia();
            var dsTacGia = busTacGia.GetAllTacGia();
            cbtacgia.DataSource = dsTacGia;
            cbtacgia.DisplayMember = "TenTacGia";
            cbtacgia.ValueMember = "MaTacGia";
        }

        private void frmSuasach_Load(object sender, EventArgs e)
        {
            LoadNhaXuatBan();
            LoadTheLoai();
            LoadTacGia();

            txtmasach.Text = sach.MaSach;
            txttieude.Text = sach.TieuDe;
            cbnxb.SelectedValue = sach.NhaXuatBan;
            cbtheloai.SelectedValue = sach.MaTheLoai;
            cbtacgia.SelectedValue = sach.MaTacGia;
            txtsl.Text = sach.SoLuongTon.ToString();
            rdoHoatDong.Checked = sach.TrangThai;
            rdoKhongHoatDong.Checked = !sach.TrangThai;

            picHinhAnh.SizeMode = PictureBoxSizeMode.StretchImage;

            // ✅ Load ảnh nếu có
            if (!string.IsNullOrEmpty(sach.HinhAnh))
            {
                imageutil.LoadHinhAnh(picHinhAnh, sach.HinhAnh); // truyền đường dẫn tương đối: main/hinh.jpg
            }
            else
            {
                picHinhAnh.Image = null;
                picHinhAnh.Tag = null;
            }


        
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            string tieude = txttieude.Text.Trim();
            string nxb = cbnxb.SelectedValue?.ToString();
            string theloai = cbtheloai.SelectedValue?.ToString();
            string tacgia = cbtacgia.SelectedValue?.ToString();

            // Kiểm tra tiêu đề
            if (string.IsNullOrEmpty(tieude))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttieude.Focus();
                return;
            }
            if (tieude.Length < 2)
            {
                MessageBox.Show("Tiêu đề sách phải có ít nhất 2 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttieude.Focus();
                return;
            }

            // Kiểm tra NXB
            if (string.IsNullOrEmpty(nxb))
            {
                MessageBox.Show("Vui lòng chọn nhà xuất bản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbnxb.Focus();
                return;
            }

            // Kiểm tra thể loại
            if (string.IsNullOrEmpty(theloai))
            {
                MessageBox.Show("Vui lòng chọn thể loại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbtheloai.Focus();
                return;
            }

            // Kiểm tra tác giả
            if (string.IsNullOrEmpty(tacgia))
            {
                MessageBox.Show("Vui lòng chọn tác giả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbtacgia.Focus();
                return;
            }

            // Kiểm tra số lượng tồn
            if (!int.TryParse(txtsl.Text, out int soLuong) || soLuong < 0)
            {
                MessageBox.Show("Số lượng tồn phải là số nguyên không âm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtsl.Focus();
                return;
            }

            // Gán lại thông tin
            sach.TieuDe = tieude;
            sach.NhaXuatBan = nxb;
            sach.MaTheLoai = theloai;
            sach.MaTacGia = tacgia;
            sach.SoLuongTon = soLuong;
            sach.TrangThai = rdoHoatDong.Checked;

            // Xử lý ảnh
            if (picHinhAnh.Tag != null)
            {
                string relativePath = picHinhAnh.Tag.ToString();
                sach.HinhAnh = relativePath;
            }

            // Cập nhật
            string result = busSach.UpdateSach(sach);

            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Lỗi cập nhật: " + result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChooseImg_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Chọn hình ảnh sách";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = openFileDialog.FileName;
                    string fileName = Path.GetFileName(selectedPath); // chỉ tên ảnh
                    string destFolder = Path.Combine(Application.StartupPath, "images", "main");
                    string destPath = Path.Combine(destFolder, fileName);

                    // Tạo thư mục nếu chưa có
                    if (!Directory.Exists(destFolder))
                        Directory.CreateDirectory(destFolder);

                    // Copy ảnh vào thư mục dự án
                    try
                    {
                        File.Copy(selectedPath, destPath, true); // ghi đè nếu trùng
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể sao chép ảnh: " + ex.Message);
                        return;
                    }

                    // Gán ảnh vào PictureBox
                    picHinhAnh.Image = Image.FromFile(destPath);
                    picHinhAnh.SizeMode = PictureBoxSizeMode.StretchImage;

                    // 👉 Lưu đường dẫn tương đối vào Tag
                    picHinhAnh.Tag = Path.Combine("main", fileName).Replace("\\", "/");
                }
            }
        }
        }
    }

