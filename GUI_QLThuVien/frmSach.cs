using BUS_Xuong;
using DAL_Xuong;
using DTO_Xuong;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLThuVien
{
    public partial class frmSach : Form
    {

        BUSSach busSach = new BUSSach();
        List<Sach> listSach = new List<Sach>();
        public frmSach()
        {
            InitializeComponent();
        }

        private void LoadDataToGrid()
        {
            var ds = busSach.GetAllSach();
            dgvSach.DataSource = null;
            dgvSach.AutoGenerateColumns = false; // Tắt tự động tạo cột

            dgvSach.Columns.Clear();

            dgvSach.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaSach", DataPropertyName = "MaSach", HeaderText = "Mã sách" });
            dgvSach.Columns.Add(new DataGridViewTextBoxColumn { Name = "TieuDe", DataPropertyName = "TieuDe", HeaderText = "Tên sách" });
            dgvSach.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaTheLoai", DataPropertyName = "MaTheLoai", HeaderText = "Mã thể loại" });
            dgvSach.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaTacGia", DataPropertyName = "MaTacGia", HeaderText = "Tác giả" });
            dgvSach.Columns.Add(new DataGridViewTextBoxColumn { Name = "NhaXuatBan", DataPropertyName = "NhaXuatBan", HeaderText = "Nhà xuất bản" });
            dgvSach.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoLuongTon", DataPropertyName = "SoLuongTon", HeaderText = "Số lượng tồn" });
            dgvSach.Columns.Add(new DataGridViewTextBoxColumn { Name = "TrangThaiText", DataPropertyName = "TrangThaiText", HeaderText = "Trạng thái" });

            // Cột hình ảnh
            dgvSach.Columns.Add(new DataGridViewImageColumn { Name = "HinhAnh", DataPropertyName = "HinhAnh", HeaderText = "Hình ảnh" });
            dgvSach.Columns.Add(new DataGridViewTextBoxColumn { Name = "NgayTao", DataPropertyName = "NgayTao", HeaderText = "Ngày tạo" });

            dgvSach.DataSource = ds;

            // Ẩn cột hình ảnh
            dgvSach.Columns["HinhAnh"].Visible = false;
        }

        private void frmSach_Load(object sender, EventArgs e)
        {
            LoadDataToGrid();
        }

        private void btnThem_Click_2(object sender, EventArgs e)
        {
            Sach sach = new Sach();
            using (frmThemSach s = new frmThemSach())
            {
                DialogResult result = s.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LoadDataToGrid();
                }
                else if (result == DialogResult.Cancel)
                {
                    LoadDataToGrid();
                }
            }
        }

        private void txtTimKiem_TextChanged_1(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            if (!string.IsNullOrEmpty(keyword))
            {
                var filteredList = busSach.GetAllSach().Where(s =>
                    s.MaSach.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    s.TieuDe.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    s.MaTheLoai.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    s.MaTacGia.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    s.NhaXuatBan.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();

                dgvSach.DataSource = null;
                dgvSach.DataSource = filteredList;
            }
            else
            {
                LoadDataToGrid();
            }
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            if (dgvSach.CurrentRow != null)
            {
                string maSach = dgvSach.CurrentRow.Cells["MaSach"].Value.ToString();
                string tieuDe = dgvSach.CurrentRow.Cells["TieuDe"].Value.ToString();
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sách có mã {maSach}?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    BUSSach bus = new BUSSach();
                    string kq = bus.DeleteSach(maSach);

                    if (string.IsNullOrEmpty(kq))
                    {
                        MessageBox.Show($"Xóa thông tin sách {maSach} - {tieuDe} thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataToGrid();
                    }
                    else
                    {
                        MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void tabSach_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (tabSach.SelectedTab != null)
            {
                if (tabSach.SelectedTab.Name == "qlPhiSach")
                {
                    TabPage tab = tabSach.SelectedTab;
                    frmPhiSach frm = new frmPhiSach();
                    if (tabSach.SelectedTab.Name == "qlPhiSach")
                    {
                        frm.TopLevel = false;
                        frm.FormBorderStyle = FormBorderStyle.None;
                        frm.Dock = DockStyle.Fill;

                        tab.Controls.Add(frm);
                        frm.Show();
                        return;
                    }
                }
                else if (tabSach.SelectedTab.Name == "qlLoaiSach")
                {
                    TabPage tab = tabSach.SelectedTab;
                    frmTheLoaiSach frm = new frmTheLoaiSach();
                    if (tabSach.SelectedTab.Name == "qlLoaiSach")
                    {
                        frm.TopLevel = false;
                        frm.FormBorderStyle = FormBorderStyle.None;
                        frm.Dock = DockStyle.Fill;

                        tab.Controls.Add(frm);
                        frm.Show();
                        return;
                    }
                }

                else if (tabSach.SelectedTab.Name == "qlTacGia")
                {
                    TabPage tab = tabSach.SelectedTab;
                    frmTacGia frm = new frmTacGia();
                    if (tabSach.SelectedTab.Name == "qlTacGia")
                    {
                        frm.TopLevel = false;
                        frm.FormBorderStyle = FormBorderStyle.None;
                        frm.Dock = DockStyle.Fill;

                        tab.Controls.Add(frm);
                        frm.Show();
                        return;
                    }
                }
                else if (tabSach.SelectedTab.Name == "qlTacGia")
                {
                    TabPage tab = tabSach.SelectedTab;
                    frmTheLoaiSach frm = new frmTheLoaiSach();
                    if (tabSach.SelectedTab.Name == "qlTacGia")
                    {
                        frm.TopLevel = false;
                        frm.FormBorderStyle = FormBorderStyle.None;
                        frm.Dock = DockStyle.Fill;

                        tab.Controls.Add(frm);
                        frm.Show();
                        return;
                    }
                }
            }
        }

        private void dgvSach_CellDoubleClick_2(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is clicked  
            {
                string maSach = dgvSach.Rows[e.RowIndex].Cells["MaSach"].Value.ToString();
                Sach sach = busSach.GetAllSach().FirstOrDefault(s => s.MaSach == maSach);

                if (sach != null)
                {
                    using (frmSuasach frmSua = new frmSuasach(sach))
                    {
                        DialogResult result = frmSua.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            LoadDataToGrid();
                        }
                    }
                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
        }
    }
}

