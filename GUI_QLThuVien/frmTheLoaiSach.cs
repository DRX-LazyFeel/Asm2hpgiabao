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
    public partial class frmTheLoaiSach : Form
    {
        BUSTheLoaiSach BUSTheLoaiSach = new BUSTheLoaiSach();
        List<TheLoaiSach> listTheLoaiSach = new List<TheLoaiSach>();
        public frmTheLoaiSach()
        {
            InitializeComponent();
            dgvTheLoaiSach.CellFormatting += dgvTheLoaiSach_CellFormatting;
            dgvTheLoaiSach.DataError += dgvTheLoaiSach_DataError;
        }

        private void LoadDanhSachLoaiSach()
        {

            dgvTheLoaiSach.DataSource = null;
            dgvTheLoaiSach.DataSource = BUSTheLoaiSach.GetAllTheLoaiSach();

           
            if (dgvTheLoaiSach.Columns.Contains("TrangThai") && dgvTheLoaiSach.Columns["TrangThai"] is DataGridViewCheckBoxColumn)
            {
              
                DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
                textColumn.Name = "TrangThai"; 
                textColumn.DataPropertyName = "TrangThai"; 

               
                int colIndex = dgvTheLoaiSach.Columns["TrangThai"].Index;
                dgvTheLoaiSach.Columns.Insert(colIndex, textColumn);
                dgvTheLoaiSach.Columns.RemoveAt(colIndex + 1); 
            }
           

            dgvTheLoaiSach.Columns["MaTheLoai"].HeaderText = "Mã Thể Loại";
            dgvTheLoaiSach.Columns["TenTheLoai"].HeaderText = "Tên Thể Loại";
            dgvTheLoaiSach.Columns["TrangThai"].HeaderText = "Trạng Thái"; // Dòng này vẫn giữ nguyên

            dgvTheLoaiSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }


        private void frmTheLoaiSach_Load(object sender, EventArgs e)
        {
            LoadDanhSachLoaiSach();
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

        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            TheLoaiSach theloaisach = new TheLoaiSach();
            using (frmthemloaisach nv = new frmthemloaisach())
            {
                DialogResult result = nv.ShowDialog();

                if (result == DialogResult.OK)
                {
                    LoadDanhSachLoaiSach();
                }
                else if (result == DialogResult.Cancel)
                {
                    LoadDanhSachLoaiSach();
                }
            }
        }

        private void dgvTheLoaiSach_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dữ liệu từ dòng đang chọn
                DataGridViewRow row = dgvTheLoaiSach.Rows[e.RowIndex];

                string ma = row.Cells["MaTheLoai"].Value.ToString();
                string ten = row.Cells["TenTheLoai"].Value.ToString();
                bool trangThai = Convert.ToBoolean(row.Cells["TrangThai"].Value);

                using (frmsualoaisach frm = new frmsualoaisach())
                {
                    frm.SetData(ma, ten, trangThai); // ✅ GỌI TRUYỀN DỮ LIỆU TRƯỚC

                    DialogResult result = frm.ShowDialog();

                    if (result == DialogResult.OK || result == DialogResult.Cancel)
                    {
                        LoadDanhSachLoaiSach();
                    }
                }
            }
        }
        private void loaddatatogrid()
        {
            dgvTheLoaiSach.DataSource = BUSTheLoaiSach.GetAllTheLoaiSach();
            dgvTheLoaiSach.Columns["MaTheLoai"].HeaderText = "Mã Thể Loại";
            dgvTheLoaiSach.Columns["TenTheLoai"].HeaderText = "Tên Thể Loại";
            dgvTheLoaiSach.Columns["TrangThai"].HeaderText = "Trạng Thái";
            dgvTheLoaiSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (dgvTheLoaiSach.CurrentRow != null)
            {
                string matl = dgvTheLoaiSach.CurrentRow.Cells["MaTheLoai"].Value.ToString();
                string tentl = dgvTheLoaiSach.CurrentRow.Cells["TenTheLoai"].Value.ToString();
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sách có mã {matl}?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    BUSTheLoaiSach bus = new BUSTheLoaiSach();
                    string kq = bus.DeleteTheLoaiSach(matl);

                    if (string.IsNullOrEmpty(kq))
                    {
                        MessageBox.Show($"Xóa thông tin sách {matl} - {tentl} thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loaddatatogrid();
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
            LoadDanhSachLoaiSach();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            if (!string.IsNullOrEmpty(keyword))
            {
                var filteredList = BUSTheLoaiSach.GetAllTheLoaiSach().Where(s =>
                    s.MaTheLoai.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    s.TenTheLoai.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();


                dgvTheLoaiSach.DataSource = null;
                dgvTheLoaiSach.DataSource = filteredList;
            }
            else
            {
                LoadDanhSachLoaiSach();
            }
        }

        private void dgvTheLoaiSach_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTheLoaiSach.Columns[e.ColumnIndex].Name == "TrangThai" && e.Value != null)
            {
                
                if (e.Value is bool)
                {
                    bool trangThai = (bool)e.Value; 
                    if (trangThai)
                    {
                        e.Value = "Đang áp dụng"; 
                    }
                    else
                    {
                        e.Value = "Ngừng áp dụng"; 
                    }
                    e.FormattingApplied = true; 
                }
            }
        }

        private void dgvTheLoaiSach_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (dgvTheLoaiSach.Columns[e.ColumnIndex].Name == "TrangThai")
            {
                
                e.ThrowException = false;
            }
            else
            {
                
                e.ThrowException = false;
                
            }
        }
    }
}

