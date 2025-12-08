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
using DAL_Xuong;
using DTO_Xuong;

namespace GUI_QLThuVien
{
    public partial class frmThemSach : Form
    {

        private BUSSach busSach = new BUSSach();
        private Sach sAch = new Sach();
        private string text = "Thêm mới";
        private string btnText = "Thêm Mới";
        private bool allowClose = false;
        public frmThemSach()
        {
            InitializeComponent();
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
            DALTheLoaiSach dal = new DALTheLoaiSach();
            List<TheLoaiSach> ds = dal.LayTheLoaiDangHoatDong();

            cbtheloai.DataSource = ds;
            cbtheloai.DisplayMember = "TenTheLoai";
            cbtheloai.ValueMember = "MaTheLoai";
        }

        // Hàm load dữ liệu Tác Giả vào ComboBox
        private void LoadTacGia()
        {
            DALTacGia dal = new DALTacGia();
            List<TacGia> ds = dal.LayTacGiaDangHoatDong();

            cboTacSach.DataSource = ds;
            cboTacSach.DisplayMember = "TenTacGia";
            cboTacSach.ValueMember = "MaTacGia";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maSach = txtmasach.Text.Trim();
            string tieuDe = txttieude.Text.Trim();
            string maTheLoai = cbtheloai.SelectedValue?.ToString();
            string maTacGia = cboTacSach.SelectedValue?.ToString();
            string nhaXuatBan = cbnxb.SelectedValue?.ToString();
            string soLuongText = txtsl.Text.Trim();
            string HinhAnh = picHinhAnh.Tag != null ? picHinhAnh.Tag.ToString() : string.Empty;
            bool trangThai = rdoHoatDong.Checked;
            DateTime ngayTao = DateTime.Now;

            // --- Kiểm tra dữ liệu ---
            if (string.IsNullOrEmpty(maTheLoai))
            {
                MessageBox.Show("Vui lòng chọn thể loại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbtheloai.Focus();
                return;
            }
            if (string.IsNullOrEmpty(maTacGia))
            {
                MessageBox.Show("Vui lòng chọn tác giả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTacSach.Focus();
                return;
            }
            if (string.IsNullOrEmpty(nhaXuatBan))
            {
                MessageBox.Show("Vui lòng chọn nhà xuất bản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbnxb.Focus();
                return;
            }
            if (!int.TryParse(soLuongText, out int soLuongTon) || soLuongTon < 0)
            {
                MessageBox.Show("Số lượng tồn phải ít nhất 1!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtsl.Focus();
                return;
            }
            if (string.IsNullOrEmpty(HinhAnh))
            {
                MessageBox.Show("Vui lòng chọn hình ảnh cho sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- Tạo đối tượng Sach ---
            Sach sach = new Sach
            {
                MaSach = maSach,
                TieuDe = tieuDe,
                MaTheLoai = maTheLoai,
                MaTacGia = maTacGia,
                NhaXuatBan = nhaXuatBan,
                SoLuongTon = soLuongTon,
                TrangThai = trangThai,
                HinhAnh = HinhAnh,
                NgayTao = ngayTao
            };

            // --- Gọi BUS để lưu ---
            string result = busSach.InsertSach(sach);

            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Thêm sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void frmThemSach_Load(object sender, EventArgs e)
        {
            LoadNhaXuatBan();
            LoadTheLoai();
            LoadTacGia();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
           this.Close(); 
        }
    }
}
