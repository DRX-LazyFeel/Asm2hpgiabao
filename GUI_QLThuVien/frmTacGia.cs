using BUS_Xuong;
using DAL_Xuong;
using DTO_Xuong;
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
    public partial class frmTacGia : Form
    {
        BUSTacGia busTacGia = new BUSTacGia();
        List<TacGia> listTacGia = new List<TacGia>();
        public frmTacGia()
        {
            InitializeComponent();
        }
        private void LoadDanhSachTacGia()
        {
            dgvTacGia.DataSource = null;
            var ds = busTacGia.GetAllTacGia()
                .Select(tg => new
                {
                    tg.MaTacGia,
                    tg.TenTacGia,
                    tg.QuocTich,
                    tg.NgayTao, // Thêm trường NgayTao
                    TrangThai = tg.TrangThai ? "Hoạt động" : "Tạm khóa"
                })
                .ToList();
            dgvTacGia.DataSource = ds;

            dgvTacGia.Columns["MaTacGia"].HeaderText = "Mã Tác Giả";
            dgvTacGia.Columns["TenTacGia"].HeaderText = "Tên Tác Giả";
            dgvTacGia.Columns["QuocTich"].HeaderText = "Quốc Tịch";
            dgvTacGia.Columns["NgayTao"].HeaderText = "Ngày Tạo"; // Đổi sang HeaderText
            dgvTacGia.Columns["TrangThai"].HeaderText = "Trạng Thái";

            dgvTacGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void frmTacGia_Load(object sender, EventArgs e)
        {
            LoadDanhSachTacGia();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadDanhSachTacGia();
        }

        private void btthemm_Click(object sender, EventArgs e)
        {
            TacGia tacgia = new TacGia();
            using (FrmThemTacGia nv = new FrmThemTacGia())
            {
                DialogResult result = nv.ShowDialog();

                if (result == DialogResult.OK)
                {
                    LoadDanhSachTacGia();
                }
                else if (result == DialogResult.Cancel)
                {
                    LoadDanhSachTacGia();
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            if(string.IsNullOrEmpty(keyword))
            {
                LoadDanhSachTacGia();
            }
            else
            {
                var filteredList = busTacGia.GetAllTacGia()
                    .Where(tg => tg.TenTacGia.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                                 tg.MaTacGia.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                    .Select(tg => new
                    {
                        tg.MaTacGia,
                        tg.TenTacGia,
                        tg.QuocTich,
                        tg.NgayTao,
                        TrangThai = tg.TrangThai ? "Hoạt động" : "Tạm khóa"
                    })
                    .ToList();
                dgvTacGia.DataSource = filteredList;
            }
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            if (dgvTacGia.CurrentRow != null)
            {
                string maTacGia = dgvTacGia.CurrentRow.Cells["MaTacGia"].Value.ToString();
                string tenTacGia = dgvTacGia.CurrentRow.Cells["TenTacGia"].Value.ToString();
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa tác giả có mã {maTacGia}?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    BUSTacGia bus = new BUSTacGia();
                    string kq = bus.DeleteTacGia(maTacGia);

                    if (string.IsNullOrEmpty(kq))
                    {
                        MessageBox.Show($"Xóa thông tin tác giả {maTacGia} - {tenTacGia} thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachTacGia();
                    }
                    else
                    {
                        MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvTacGia_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is clicked  
            {
                string maTacGia = dgvTacGia.Rows[e.RowIndex].Cells["MaTacGia"].Value.ToString();
                TacGia tacGia = busTacGia.GetAllTacGia().FirstOrDefault(tg => tg.MaTacGia == maTacGia);

                if (tacGia != null)
                {
                    using (FrmSuaTacGia frmSua = new FrmSuaTacGia(tacGia))
                    {
                        DialogResult result = frmSua.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            LoadDanhSachTacGia();
                        }
                    }
                }
            }
        }

        private void dgvTacGia_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is clicked  
            {
                string maTacGia = dgvTacGia.Rows[e.RowIndex].Cells["MaTacGia"].Value.ToString();
                TacGia tacGia = busTacGia.GetAllTacGia().FirstOrDefault(tg => tg.MaTacGia == maTacGia);

                if (tacGia != null)
                {
                    using (FrmSuaTacGia frmSua = new FrmSuaTacGia(tacGia))
                    {
                        DialogResult result = frmSua.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            LoadDanhSachTacGia();
                        }
                    }
                }
            }
        }
    }
}
