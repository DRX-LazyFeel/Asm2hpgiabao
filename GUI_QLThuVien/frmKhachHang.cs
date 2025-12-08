using BUS_Xuong;
using DAL_Xuong;
using DTO_Xuong;
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
    public partial class frmKhachHang : Form
    {
        BUSKhachHang busKhachHang = new BUSKhachHang();
        List<KhachHang> listKhachHang = new List<KhachHang>();
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadKhachHang();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadKhachHang();
        }

        private void LoadKhachHang()
        {

            dgvKhachHang.Visible = false;


            Task.Run(() =>
            {
                var listKhachHang = busKhachHang.GetKhachHangList();

                this.Invoke(() =>
                {
                    dgvKhachHang.DataSource = null;
                    dgvKhachHang.DataSource = listKhachHang;
                    LoadHeader();
                    dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    dgvKhachHang.Visible = true;
                });
            });
        }
        private void LoadHeader()
        {
            dgvKhachHang.Columns["MaKhachHang"].HeaderText = "Mã Khách Hàng";
            dgvKhachHang.Columns["TenKhachHang"].HeaderText = "Họ Tên";
            dgvKhachHang.Columns["Email"].HeaderText = "Email";
            dgvKhachHang.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
            dgvKhachHang.Columns["CCCD"].HeaderText = "cccd";

            dgvKhachHang.Columns["TrangThaiText"].HeaderText = "Trạng Thái";
            dgvKhachHang.Columns["NgayTao"].HeaderText = "Ngày Tạo";

            dgvKhachHang.Columns["TrangThai"].Visible = false;

        }

        private void txtTitle_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtTitle_Click_1(object sender, EventArgs e)
        {

        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            KhachHang khachHang = new KhachHang();
            using (frmThemKhachHang kh = new frmThemKhachHang(khachHang))
            {
                DialogResult result = kh.ShowDialog();

                if (result == DialogResult.OK)
                {
                    LoadKhachHang();
                }
                else if (result == DialogResult.Cancel)
                {
                    LoadKhachHang();
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow != null)
            {
                string maKhachHang = dgvKhachHang.CurrentRow.Cells["MaKhachHang"].Value.ToString();
                string name = dgvKhachHang.CurrentRow.Cells["TenKhachHang"].Value.ToString();
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa khách hàng có mã {maKhachHang}?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    BUSKhachHang bus = new BUSKhachHang();
                    string kq = bus.DeleteKhachHang(maKhachHang);

                    if (string.IsNullOrEmpty(kq))
                    {
                        MessageBox.Show($"Xóa thông tin khách hàng {maKhachHang} - {name} thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadKhachHang();
                    }
                    else
                    {
                        MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            LoadKhachHang();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                LoadKhachHang();
                return;
            }

            dgvKhachHang.Visible = false;

            Task.Run(() =>
            {
                var searchResult = busKhachHang.SearchKhachHang(keyword);

                this.Invoke(() =>
                {
                    dgvKhachHang.DataSource = null;
                    dgvKhachHang.DataSource = searchResult;
                    LoadHeader();
                    dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvKhachHang.Visible = true;
                });
            });
        }

        private void dgvKhachHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is clicked  
            {
                string maKhachHang = dgvKhachHang.Rows[e.RowIndex].Cells["MaKhachHang"].Value.ToString();
                KhachHang khachHang = busKhachHang.GetKhachHangList().FirstOrDefault(kh => kh.MaKhachHang == maKhachHang);

                if (khachHang != null)
                {
                    using (FrmSuaKhachHang frmSua = new FrmSuaKhachHang(khachHang))
                    {
                        DialogResult result = frmSua.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            LoadKhachHang();
                        }
                    }
                }
            }
        }
    }
}

