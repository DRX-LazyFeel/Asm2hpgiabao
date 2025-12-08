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
using static DTO_Xuong.ThongKe;

namespace GUI_QLThuVien
{
    public partial class frmtkdata : Form
    {
        private BUSNhanVien busNhanVien = new BUSNhanVien();
        private BusThongKe busThongKe = new BusThongKe();

        public frmtkdata()
        {
            InitializeComponent();
        }

        private void LoadNhanVien()
        {
            // Gọi BUS lấy danh sách nhân viên
            var danhSachNV = busNhanVien.GetNhanVienList(); // Thay tên hàm theo BUS của bạn

            // Xóa dữ liệu cũ
            cbNV.DataSource = null;

            // Thêm mục "Tất cả"
            var dsHienThi = new List<dynamic>();
            dsHienThi.Add(new { MaNhanVien = "", Ten = "Tất cả" });

            foreach (var nv in danhSachNV)
            {
                dsHienThi.Add(new { nv.MaNhanVien, nv.Ten });
            }

            // Gán vào ComboBox
            cbNV.DataSource = dsHienThi;
            cbNV.DisplayMember = "Ten";
            cbNV.ValueMember = "MaNhanVien";

            // Mặc định chọn "Tất cả"
            cbNV.SelectedIndex = 0;
        }

        private void LoadThongKe()
        {
            

            string maNV = cbNV.SelectedValue?.ToString();
            List<ThongKeDTO> data;

            if (string.IsNullOrEmpty(maNV)) // Chọn "Tất cả"
            {
                // Lấy tất cả không lọc ngày
                data = busThongKe.LayThongKeTatCaNhanVien();
            }
            else // Xem theo nhân viên
            {
                var tk = busThongKe.ThongKeTheoMaNhanVien(maNV);
                data = tk != null ? new List<ThongKeDTO> { tk } : new List<ThongKeDTO>();
            }

            dgvdt.DataSource = data;

            ChinhSuaDataGridView();
        }

        private void frmtkdata_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
            LoadThongKe();
           
            dgvdt.Visible = true;
            dgvdt.BringToFront();
            
            ChinhSuaDataGridView();
        }

        private void btTK_Click(object sender, EventArgs e)
        {
            LoadThongKe();
        }
        private void ChinhSuaDataGridView()
        {
            // Không tự động tạo cột từ DataSource
            dgvdt.AutoGenerateColumns = false;

            // Tự động giãn cột
            dgvdt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Chiều cao tiêu đề cột
            dgvdt.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvdt.ColumnHeadersHeight = 40; // bạn có thể tăng/giảm số này

            // Không cho header xuống dòng
            dgvdt.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

            // Màu header
            dgvdt.EnableHeadersVisualStyles = false;
            dgvdt.ColumnHeadersDefaultCellStyle.BackColor = Color.DeepSkyBlue;
            dgvdt.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvdt.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvdt.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // Nội dung căn giữa
            dgvdt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvdt.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            // Màu xen kẽ dòng
            dgvdt.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

            // Màu khi chọn
            dgvdt.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvdt.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Tiêu đề cột
            if (dgvdt.Columns.Contains("MaNhanVien"))
                dgvdt.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
            if (dgvdt.Columns.Contains("TenNhanVien"))
                dgvdt.Columns["TenNhanVien"].HeaderText = "Tên Nhân Viên";
            if (dgvdt.Columns.Contains("SoLuongPhieuMuon"))
                dgvdt.Columns["SoLuongPhieuMuon"].HeaderText = "Số Phiếu Mượn";
            if (dgvdt.Columns.Contains("TongSachMuon"))
                dgvdt.Columns["TongSachMuon"].HeaderText = "Tổng Sách Mượn";
        }

        private void dgvdt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

