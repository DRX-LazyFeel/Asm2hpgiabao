using BUS_Xuong;
using DTO_Xuong;
using GUI_QLThuVien.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLThuVien
{
    public partial class frmNhanVien : Form
    {
        BUSNhanVien busNhanVien = new BUSNhanVien();
        List<NhanVien> listNhanVien = new List<NhanVien>();
        string imageFolder = @"D:\Dụ án mẫu\Giao Dien Demo\Ảnh";
        public frmNhanVien()
        {
            InitializeComponent();
        }
        private void LoadDanhSachNhanVien()
        {
            loading.Visible = true;
            dgvNhanVien.Visible = false;
            loading.BringToFront();

            Task.Run(() =>
            {
                listNhanVien = busNhanVien.GetNhanVienList();

                this.Invoke(() =>
                {
                    dgvNhanVien.DataSource = null;
                    dgvNhanVien.DataSource = listNhanVien;
                    LoadHeader();
                    dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    loading.Visible = false;
                    dgvNhanVien.Visible = true;
                });
            });
        }
        private void LoadHeader()
        {
            dgvNhanVien.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
            dgvNhanVien.Columns["Ten"].HeaderText = "Họ Tên";
            dgvNhanVien.Columns["Email"].HeaderText = "Email";
            dgvNhanVien.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
            dgvNhanVien.Columns["VaiTroText"].HeaderText = "Vai Trò";
            dgvNhanVien.Columns["TrangThaiText"].HeaderText = "Trạng Thái";
            dgvNhanVien.Columns["HinhAnh"].Visible = false;
            dgvNhanVien.Columns["NgayTao"].Visible = false;
            dgvNhanVien.Columns["VaiTro"].Visible = false;
            dgvNhanVien.Columns["TrangThai"].Visible = false;
            dgvNhanVien.Columns["MatKhau"].Visible = false;
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadDanhSachNhanVien();
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            NhanVien nhanVien = new NhanVien();
            using (frmThemNhanVien nv = new frmThemNhanVien(nhanVien))
            {
                DialogResult result = nv.ShowDialog();

                if (result == DialogResult.OK)
                {
                    LoadDanhSachNhanVien();
                }
                else if (result == DialogResult.Cancel)
                {
                    LoadDanhSachNhanVien();
                }
            }
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow != null)
            {
                string maNhanVien = dgvNhanVien.CurrentRow.Cells["MaNhanVien"].Value.ToString();
                string name = dgvNhanVien.CurrentRow.Cells["Ten"].Value.ToString();

                //Không cho xóa tài khoản đang đăng nhập
                if (SessionLogin.CurrentUser != null && maNhanVien == SessionLogin.CurrentUser.MaNhanVien)
                {
                    MessageBox.Show("Bạn không thể xóa tài khoản đang đăng nhập!",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhân viên có mã {maNhanVien}?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {

                    BUSNhanVien bus = new BUSNhanVien();
                    string kq = bus.DeleteNhanVien(maNhanVien);

                    if (string.IsNullOrEmpty(kq))
                    {
                        MessageBox.Show($"Xóa thông tin nhân viên {maNhanVien} - {name} thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachNhanVien();
                    }
                    else
                    {
                        MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnLamMoi_Click_1(object sender, EventArgs e)
        {
            LoadDanhSachNhanVien();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadDanhSachNhanVien();
            }
            else
            {
                List<NhanVien> searchResults = listNhanVien
                    .Where(nv => nv.MaNhanVien.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                                 nv.Ten.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                dgvNhanVien.DataSource = searchResults;
                LoadHeader();
                dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
        private void CenterControl(Control control)
        {
            control.Left = (this.ClientSize.Width - control.Width) / 2;
        }

        private void frmNhanVien_Shown(object sender, EventArgs e)
        {
            CenterControl(loading);
        }

        private void dgvNhanVien_CellDoubleClick_2(object sender, DataGridViewCellEventArgs e)
        {
            string maNhanVien = dgvNhanVien.CurrentRow.Cells["MaNhanVien"].Value.ToString();
            NhanVien nhanVien = listNhanVien.FirstOrDefault(nv => nv.MaNhanVien == maNhanVien);

            using (frmThemNhanVien nv = new frmThemNhanVien(nhanVien))
            {
                DialogResult result = nv.ShowDialog();

                if (result == DialogResult.OK)
                {
                    MessageBox.Show($"Người dùng nhấn OK! Tên: {nhanVien.Ten}");
                    LoadDanhSachNhanVien();
                }
                else if (result == DialogResult.Cancel)
                {
                    LoadDanhSachNhanVien();
                }
            }
        }
    }
}
