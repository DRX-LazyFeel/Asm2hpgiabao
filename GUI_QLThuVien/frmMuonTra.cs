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
    public partial class frmMuonTra : Form
    {
        BUSMuonTraSach busMT = new BUSMuonTraSach();
        BUSPhiSach busPhiSach = new BUSPhiSach();
        BUSMuonTraSach busMuonTraSach = new BUSMuonTraSach();
        BUSChiTietMuonTra busChiTiet = new BUSChiTietMuonTra();

        public frmMuonTra()
        {
            InitializeComponent();
        }

        private void frmMuonTra_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadLaiDanhSach()
        {
            try
            {
                List<MuonTra> dsPhieu = busMuonTraSach.GetAllMuonTra(); // Hoặc SelectAll()

                // Nếu bạn chỉ muốn hiển thị một số cột
                var bindingList = dsPhieu.Select(p => new
                {
                    MaMuonTra = p.MaMuonTra,
                    TenKhachHang = p.TenKhachHang ?? "",  // Nếu null thì hiển thị rỗng
                    TenNhanVien = p.TenNhanVien ?? "",
                    NgayMuon = p.NgayMuon.ToString("dd/MM/yyyy") ?? "",
                    NgayTra = p.NgayTra.ToString("dd/MM/yyyy") ?? "",
                    TrangThai = p.MaTrangThai == "1" ? "Hoạt động" : "Đã trả"
                }).ToList();

                dgvMuonTra.DataSource = bindingList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách phiếu mượn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            dgvMuonTra.DataSource = null;
            dgvMuonTra.DataSource = busMuonTraSach.GetAllMuonTra();

            dgvMuonTra.Columns["MaMuonTra"].HeaderText = "Mã Mượn Trả";
            dgvMuonTra.Columns["MaKhachHang"].HeaderText = "Khách Hàng";
            dgvMuonTra.Columns["MaNhanVien"].HeaderText = "Nhân viên";
            dgvMuonTra.Columns["NgayMuon"].HeaderText = "Ngày Mượn";
            dgvMuonTra.Columns["NgayTra"].HeaderText = "Ngyaf Trả";
            dgvMuonTra.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TenTrangThai",
                DataPropertyName = "TenTrangThai",
                HeaderText = "Trạng thái"
            });


            dgvMuonTra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvMuonTra_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvMuonTra.Rows[e.RowIndex];

                MuonTra mt = new MuonTra
                {
                    MaMuonTra = row.Cells["MaMuonTra"].Value.ToString(),
                    MaKhachHang = row.Cells["MaKhachHang"].Value.ToString(),
                    MaNhanVien = row.Cells["MaNhanVien"].Value.ToString(),
                    NgayMuon = Convert.ToDateTime(row.Cells["NgayMuon"].Value),
                    NgayTra = Convert.ToDateTime(row.Cells["NgayTra"].Value),
                    MaTrangThai = row.Cells["MaTrangThai"].Value.ToString(),
                    NgayTao = Convert.ToDateTime(row.Cells["NgayTao"].Value)
                };

                frmMuonTraSach frm = new frmMuonTraSach(mt);
                frm.ShowDialog();

                LoadData(); // Gọi lại hàm load danh sách sau khi sửa
            }
        }

        private void btnCapNhat_Click_1(object sender, EventArgs e)
        {
            if (dgvMuonTra.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phiếu mượn để trả.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã phiếu mượn từ dòng đang chọn
            string maMuonTra = dgvMuonTra.SelectedRows[0].Cells["MaMuonTra"].Value.ToString();

            // Lấy thông tin phiếu mượn từ BUS
            MuonTra muonTra = busMT.GetMuonTraById(maMuonTra).FirstOrDefault();

            if (muonTra == null)
            {
                MessageBox.Show("Không tìm thấy phiếu mượn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy danh sách chi tiết mượn
            List<ChiTietMuonTra> chiTietList = busChiTiet.GetChiTietByMaMuonTra(maMuonTra);
            if (chiTietList == null || chiTietList.Count == 0)
            {
                MessageBox.Show("Không tìm thấy chi tiết mượn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy danh sách phí sách
            List<PhiSach> phiSachList = busPhiSach.GetAllPhiSach();

            decimal tongPhiMuon = 0;
            decimal tongPhiPhat = 0;

            foreach (var ct in chiTietList)
            {
                var phiSach = phiSachList.FirstOrDefault(p => p.MaSach == ct.MaSach);
                if (phiSach != null)
                {
                    tongPhiMuon += phiSach.PhiMuon;

                    if (DateTime.Now.Date > muonTra.NgayTra.Date)
                    {
                        tongPhiPhat += phiSach.PhiPhat;
                    }
                }
            }

            decimal tongBill = tongPhiMuon + tongPhiPhat;

            // Cập nhật trạng thái phiếu mượn
            muonTra.MaTrangThai = "TT002"; // Đã trả
            muonTra.NgayTra = DateTime.Now;

            string result = busMT.UpdateMuonTra(muonTra);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show(
                    $"Trả sách thành công.\nTổng phí mượn: {tongPhiMuon:C}\nTổng phí phạt: {tongPhiPhat:C}\n\nTổng bill: {tongBill:C}",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else
            {
                MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Làm mới danh sách
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvMuonTra.CurrentRow != null)
            {
                // Lấy mã mượn trả từ dòng đang chọn (giả sử cột 0 là MaMuonTra)
                string maMuonTra = dgvMuonTra.CurrentRow.Cells[0].Value.ToString();

                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa mượn trả có mã '{maMuonTra}' không?",
                                                       "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string thongBao = busMuonTraSach.DeleteMuonTra(maMuonTra);

                    if (string.IsNullOrEmpty(thongBao))
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(); // hoặc gọi lại phương thức fill lại dgvMuonTra
                    }
                    else
                    {
                        MessageBox.Show("Lỗi: " + thongBao, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //frmThemMuonTra frm = new frmThemMuonTra();
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    string maMoi = frm.Tag.ToString();
            //    LoadLaiDanhSach(); // Gọi lại dgvMuonTra

            //    // Chọn dòng mới tạo trong dgvMuonTra (nếu muốn)
            //    foreach (DataGridViewRow row in dgvMuonTra.Rows)
            //    {
            //        if (row.Cells["MaMuonTra"].Value.ToString() == maMoi)
            //        {
            //            row.Selected = true;
            //            dgvMuonTra.FirstDisplayedScrollingRowIndex = row.Index;
            //            break;
            //        }
            //    }
            //}
            MuonTra mt = new MuonTra();
            using (frmMuonTraSach frm = new frmMuonTraSach(mt))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    string maMoi = frm.Tag.ToString();
                    LoadLaiDanhSach(); // Gọi lại dgvMuonTra

                }
            }
        } 
    }
}
