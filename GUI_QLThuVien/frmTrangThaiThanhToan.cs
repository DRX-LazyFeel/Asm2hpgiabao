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
    public partial class frmTrangThaiThanhToan : Form
    {
        BUSTrangThaiThanhToan bus = new BUSTrangThaiThanhToan();
        List<TrangThaiThanhToan> listtt = new List<TrangThaiThanhToan>();
        public frmTrangThaiThanhToan()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            listtt = bus.GetAll();

            // Tạo danh sách hiển thị có cột trạng thái dạng chuỗi
            var displayList = listtt.Select(t => new
            {
                t.MaTrangThai,
                t.TenTrangThai,
                t.NgayTao,
                TrangThai = t.TrangThai ? "Đang áp dụng" : "Ngưng áp dụng"
            }).ToList();

            dgvTrangThai.DataSource = null;
            dgvTrangThai.DataSource = displayList;
            dgvTrangThai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvNhanVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu dòng hiện tại không null và không phải header
            if (dgvTrangThai.CurrentRow != null && e.RowIndex >= 0)
            {
                // Lấy dữ liệu từ dòng được chọn
                string ma = dgvTrangThai.CurrentRow.Cells["MaTrangThai"].Value.ToString();
                string ten = dgvTrangThai.CurrentRow.Cells["TenTrangThai"].Value.ToString();

                // Tạo đối tượng DTO
                var data = new TrangThaiThanhToan
                {
                    MaTrangThai = ma,
                    TenTrangThai = ten
                };

                // Gọi form sửa, truyền dữ liệu vào
                frmSuaTrangThai frm = new frmSuaTrangThai(data);

                // Khi form sửa đóng thì tự động load lại danh sách
                frm.FormClosed += (s, args) => LoadData();

                frm.ShowDialog();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {


            // Gán sự kiện khi form đóng sẽ gọi lại LoadData()
            frmThemTrangThai themForm = new frmThemTrangThai();
            themForm.FormClosed += (s, args) => LoadData();
            themForm.ShowDialog();
        }

        private void frmTrangThaiThanhToan_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadData();
            }
            else
            {
                List<TrangThaiThanhToan> searchResults = listtt
                    .Where(nv => nv.MaTrangThai.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                                 nv.TenTrangThai.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                dgvTrangThai.DataSource = searchResults;
                LoadData();
                dgvTrangThai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvTrangThai.CurrentRow != null)
            {
                string maTrangThai = dgvTrangThai.CurrentRow.Cells["MaTrangThai"].Value.ToString();
                string tenTrangThai = dgvTrangThai.CurrentRow.Cells["TenTrangThai"].Value.ToString();

                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn ngừng áp dụng trạng thái thanh toán \"{tenTrangThai}\" (Mã: {maTrangThai}) không?",
                    "Xác nhận ngừng áp dụng",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (bus.Delete(maTrangThai)) // Vẫn gọi là Delete nhưng trong DAL chỉ đổi trạng thái
                    {
                        MessageBox.Show($"Trạng thái \"{tenTrangThai}\" đã được chuyển sang ngừng áp dụng.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật trạng thái thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        }
    }
