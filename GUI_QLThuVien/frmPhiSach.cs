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
    public partial class frmPhiSach : Form
    {
        BUSPhiSach busPhiSach = new BUSPhiSach();
        List<PhiSach> listPhiSach = new List<PhiSach>();
        public frmPhiSach()
        {
            InitializeComponent();
            dgvPhiSach.CellFormatting += dgvPhiSach_CellFormatting;
            dgvPhiSach.DataError += dgvPhiSach_DataError;
        }

        private void frmPhiSach_Load(object sender, EventArgs e)
        {
            LoadDanhSachPhiSach();
        }

        private void LoadDanhSachPhiSach()
        {

            dgvPhiSach.DataSource = null;
            dgvPhiSach.DataSource = busPhiSach.GetAllPhiSach();

            
            if (dgvPhiSach.Columns.Contains("TrangThai") && dgvPhiSach.Columns["TrangThai"] is DataGridViewCheckBoxColumn)
            {
                
                DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
                textColumn.Name = "TrangThai"; 
                textColumn.DataPropertyName = "TrangThai"; 

                int colIndex = dgvPhiSach.Columns["TrangThai"].Index;

              
                dgvPhiSach.Columns.Insert(colIndex, textColumn);
                dgvPhiSach.Columns.RemoveAt(colIndex + 1); 
            }
          

            dgvPhiSach.Columns["MaPhiSach"].HeaderText = "Mã Phí Sách";
            dgvPhiSach.Columns["MaSach"].HeaderText = "Mã Sách";
            dgvPhiSach.Columns["PhiMuon"].HeaderText = "Phí Mượn";
            dgvPhiSach.Columns["PhiPhat"].HeaderText = "Phí Phạt";
            dgvPhiSach.Columns["TrangThai"].HeaderText = "Trạng Thái"; 

            dgvPhiSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            frmThemPhiSach frm = new frmThemPhiSach();
            frm.ShowDialog();

            LoadDanhSachPhiSach();
        }

        private void dgvPhiSach_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvPhiSach.Rows[e.RowIndex];

                PhiSach ps = new PhiSach
                {
                    MaPhiSach = row.Cells["MaPhiSach"].Value.ToString(),
                    MaSach = row.Cells["MaSach"].Value.ToString(),
                    PhiMuon = Convert.ToDecimal(row.Cells["PhiMuon"].Value),
                    PhiPhat = Convert.ToDecimal(row.Cells["PhiPhat"].Value),
                    TrangThai = Convert.ToBoolean(row.Cells["TrangThai"].Value),
                    NgayTao = Convert.ToDateTime(row.Cells["NgayTao"].Value)
                };

                frmSuaPhiSach frm = new frmSuaPhiSach(ps);
                frm.ShowDialog();

                LoadDanhSachPhiSach();
            }

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (dgvPhiSach.CurrentRow != null)
            {
                string MaPhiSach = dgvPhiSach.CurrentRow.Cells["MaPhiSach"].Value.ToString();
                string MaSach = dgvPhiSach.CurrentRow.Cells["MaSach"].Value.ToString();
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa phí sách có mã {MaPhiSach}?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    BUSPhiSach bus = new BUSPhiSach();
                    string kq = bus.DeletePhiSach(MaPhiSach);

                    if (string.IsNullOrEmpty(kq))
                    {
                        MessageBox.Show($"Xóa ohis sách {MaPhiSach} - {MaSach} thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachPhiSach();
                    }
                    else
                    {
                        MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoadDanhSachPhiSach();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string keyword = guna2TextBox1.Text.Trim();
            if (!string.IsNullOrEmpty(keyword))
            {
                var filteredList = busPhiSach.GetAllPhiSach().Where(s =>
                    s.MaPhiSach.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    s.MaSach.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();

                dgvPhiSach.DataSource = null;
                dgvPhiSach.DataSource = filteredList;
            }
            else
            {
                LoadDanhSachPhiSach();
            }
        }

        private void dgvPhiSach_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPhiSach.Columns[e.ColumnIndex].Name == "TrangThai" && e.Value != null)
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

        private void dgvPhiSach_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (dgvPhiSach.Columns[e.ColumnIndex].Name == "TrangThai")
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
