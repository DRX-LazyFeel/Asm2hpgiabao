using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using System.Windows.Media.Media3D;
using BUS_Xuong;
using DAL_Xuong;
using DTO_Xuong;

namespace GUI_QLThuVien
{
    public partial class frmMuonTraSach : Form
    {
        BUSSach busSach = new BUSSach();
        BUSKhachHang busKH = new BUSKhachHang();
        BUSMuonTraSach busMT = new BUSMuonTraSach();
        BUSChiTietMuonTra busChiTiet = new BUSChiTietMuonTra();
        BUSPhiSach busPhiSach = new BUSPhiSach();

        List<Sach> lstSach = new List<Sach>();
        List<ChiTietMuonTra> lstChiTietMuon = new List<ChiTietMuonTra>();
        List<PhiSach> lstPhiSach = new List<PhiSach>();
        List<KhachHang> lstKhachHang = new List<KhachHang>();

        MuonTra muonTra = new MuonTra();

        private bool allowClose = false;
        private bool isMoi = true; // Biến để xác định xem đây có phải là phiếu mượn mới hay không

        public frmMuonTraSach(MuonTra muonTra)
        {
            InitializeComponent();
            this.muonTra = muonTra;
        }
        private void LoadComboKhachHang()
        {
            BUSKhachHang busKH = new BUSKhachHang();
            lstKhachHang = busKH.LoadComboKhachHang();
            cboKhachHang.DataSource = lstKhachHang; // Nguồn dữ liệu cho ComboBox
            cboKhachHang.DisplayMember = "MaVaTen";     // Hiển thị tên
            cboKhachHang.ValueMember = "MaKhachHang";
            cboKhachHang.SelectedIndex = 0;// Giá trị là mã
        }
        private void LoadComboNhanVien()
        {
            BUSNhanVien busNV = new BUSNhanVien();
            var danhSachNV = busNV.GetNhanVienDangHoatDong();

            cboNhanVien.DataSource = danhSachNV;
            cboNhanVien.DisplayMember = "Ten";        // Tên hiển thị
            cboNhanVien.ValueMember = "MaNhanVien";   // Mã dùng để xử lý
            cboNhanVien.SelectedIndex = 0;
        }
        private void LoadComboTrangThai()
        {
            BUSMuonTraSach busMT = new BUSMuonTraSach();
            cboTrangThai.DataSource = busMT.LoadBangThanhToan();
            cboTrangThai.DisplayMember = "TenTrangThai"; // Hiển thị tên trạng thái
            cboTrangThai.ValueMember = "MaTrangThai";    // Giá trị là mã trạng thái
            cboTrangThai.SelectedIndex = 0; // Chọn trạng thái đầu tiên
        }
        private void LoadDSMuonTra()
        {
            dgvSachMuon.DataSource = busMT.GetAllMuonTra();
        }

        private void LoadChiTietSach()
        {
            if (muonTra != null && !string.IsNullOrEmpty(muonTra.MaMuonTra))
            {
                lstChiTietMuon = busChiTiet.GetChiTietByMaMuonTra(muonTra.MaMuonTra);
                dgvSachMuon.DataSource = null;
                dgvSachMuon.DataSource = lstChiTietMuon;
                isMoi = false; // Đặt biến isMoi là false vì đây là phiếu mượn đã có mã
            }
            else
            {
                dgvSachMuon.DataSource = null;
                dgvSachMuon.DataSource = new List<ChiTietMuonTra>();
            }
            LoadHeaderChiTietMuon();
        }

        private void LoadHeaderChiTietMuon()
        {
            ;
            dgvSachMuon.Columns["MaSach"].HeaderText = "Mã Sách";
            dgvSachMuon.Columns["TenSach"].HeaderText = "Tên Sách";
            dgvSachMuon.Columns["SoLuong"].HeaderText = "Số Lượng";
            dgvSachMuon.Columns["MaMuonTra"].Visible = false;
            dgvSachMuon.Columns["NgayTao"].Visible = false;
            dgvSachMuon.Columns["TrangThaiText"].Visible = false;

            dgvSachMuon.Columns["MaChiTiet"].Visible = false;
            if (dgvSachMuon.Columns.Contains("TrangThai"))
            {
                dgvSachMuon.Columns["TrangThai"].Visible = false;
            }
        }

        private void loadSach()
        {
            lstSach = busSach.GetSachChoMuon();
            dgvListSach.DataSource = null;
            dgvListSach.DataSource = lstSach;
            LoadHeader();
        }
        private void LoadHeader()
        {
            dgvListSach.Columns["MaSach"].HeaderText = "Mã Sách";
            dgvListSach.Columns["TieuDe"].HeaderText = "Tiêu Đề";
            dgvListSach.Columns["TenTheLoai"].Visible = false;
            dgvListSach.Columns["TenTacGia"].Visible = false;
            dgvListSach.Columns["NhaXuatBan"].HeaderText = "Nhà Xuất Bản";
            dgvListSach.Columns["SoLuongTon"].HeaderText = "Số Lượng Tồn";


            // Ẩn các cột không cần hiển thị trực tiếp

            dgvListSach.Columns["MaVaTenSach"].Visible = false;
            dgvListSach.Columns["TrangThai"].Visible = false;
            dgvListSach.Columns["TrangThaiText"].Visible = false;
            dgvListSach.Columns["HinhAnh"].Visible = false;
            dgvListSach.Columns["NgayTao"].Visible = false;
            dgvListSach.Columns["MaTheLoai"].Visible = false;
            dgvListSach.Columns["MaTacGia"].Visible = false;

            dgvListSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadInfo()
        {
            if (muonTra != null && !string.IsNullOrEmpty(muonTra.MaMuonTra))
            {
                txtMaMuonTa.Text = muonTra.MaMuonTra;
                cboKhachHang.SelectedValue = muonTra.MaKhachHang;
                cboNhanVien.SelectedValue = muonTra.MaNhanVien;
                dtpNgayMuon.Value = muonTra.NgayMuon;
                dtpNgayTra.Value = muonTra.NgayTra;
                cboTrangThai.SelectedValue = muonTra.MaTrangThai;

                KhachHang kh = lstKhachHang.FirstOrDefault(k => k.MaKhachHang == muonTra.MaKhachHang);
                if (kh != null)
                {
                    txtTenKhachHang.Text = kh.TenKhachHang;
                    txtCCCD.Text = kh.CCCD;
                    txtPhone.Text = kh.SoDienThoai;
                    txtMail.Text = kh.Email;
                }

            }
            else
            {
                dtpNgayMuon.Value = DateTime.Now;
                dtpNgayTra.Value = DateTime.Now.AddDays(7);
            }

        }
        private void ThemSachVaoChiTietMuon(Sach sachChon)
        {
            if (sachChon == null)
            {
                MessageBox.Show("Vui lòng chọn sách để mượn.", "Thông Báo");
                return;
            }

            // Giảm số lượng tồn kho của sách đã chọn
            sachChon.SoLuongTon--;

            // Kiểm tra xem sách đã có trong danh sách mượn chưa
            var chiTiet = lstChiTietMuon.FirstOrDefault(ct => ct.MaSach == sachChon.MaSach);
            if (chiTiet != null)
            {
                chiTiet.SoLuong++;
            }
            else
            {
                PhiSach? phiSach = lstPhiSach.FirstOrDefault(p => p.MaSach == sachChon.MaSach);

                lstChiTietMuon.Add(new ChiTietMuonTra
                {
                    MaChiTiet = "",
                    MaSach = sachChon.MaSach,
                    SoLuong = 1,
                    TrangThai = false,
                    NgayTao = DateTime.Now
                });
            }

            // danh sách sách
            dgvListSach.DataSource = null;
            dgvListSach.DataSource = lstSach;
            LoadHeader(); // Cập nhật lại header nếu cần

            //DS mượn
            dgvSachMuon.DataSource = null;
            dgvSachMuon.DataSource = lstChiTietMuon;
            LoadHeaderChiTietMuon(); // Cập nhật lại header nếu cần
        }

        private string ThemThongTinPhieu(bool isTnsert = false)
        {
            List<ChiTietMuonTra> listCT = new List<ChiTietMuonTra>();

            string maPhieu = muonTra.MaMuonTra;
            string maKH = cboKhachHang.SelectedValue?.ToString() ?? string.Empty;
            string maNV = cboNhanVien.SelectedValue?.ToString() ?? string.Empty;
            DateTime ngayMuon = dtpNgayMuon.Value;
            DateTime ngayTra = dtpNgayTra.Value;
            string maTT = cboTrangThai.SelectedValue?.ToString() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(maKH))
            {
                MessageBox.Show("Vui lòng chọn khách hàng.", "Thông Báo");
                return string.Empty;
            }
            if (ngayMuon > ngayTra)
            {
                MessageBox.Show("Vui lòng chọn khách hàng.", "Thông Báo");
                return string.Empty;
            }
            if (string.IsNullOrWhiteSpace(maNV))
            {
                MessageBox.Show("Vui lòng chọn nhân viên.", "Thông Báo");
                return string.Empty;
            }
            if (lstChiTietMuon.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sách để mượn.", "Thông Báo");
                return string.Empty;
            }
            muonTra.MaMuonTra = maPhieu;
            muonTra.MaKhachHang = maKH;
            muonTra.MaNhanVien = maNV;
            muonTra.NgayMuon = ngayMuon;
            muonTra.NgayTra = ngayTra;
            muonTra.NgayTao = DateTime.Now;
            muonTra.MaTrangThai = maTT;

            if (isTnsert)
            {
                string kq = busMT.InsertMuonTraReturn(muonTra);
                if (string.IsNullOrEmpty(kq))
                {
                    return string.Empty;
                }
                if (kq.Length != 5)
                {
                    return string.Empty;
                }
                return kq;
            }
            else
            {
                string kq = busMT.UpdateMuonTra(muonTra);
                if (!string.IsNullOrEmpty(kq))
                {
                    MessageBox.Show(kq, "Thông Báo");
                    return string.Empty;
                }
                else
                {
                    return muonTra.MaMuonTra;
                }
            }
        }

        private void CapNhatThongTin()
        {
            string kq = ThemThongTinPhieu(isMoi);
            if (kq.Length != 5)
            {
                MessageBox.Show("Lỗi khi cập nhật thông tin phiếu mượn.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (lstChiTietMuon.Count > 0)
            {
                string ressul = busChiTiet.InsertRange(lstChiTietMuon, kq);
                if (string.IsNullOrEmpty(ressul))
                {
                    MessageBox.Show("Cập nhật thông tin phiếu mượn thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lỗi khi cập nhật thông tin chi tiết phiếu mượn: " + ressul, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmMuonTraSach_Load_1(object sender, EventArgs e)
        {
            LoadComboKhachHang();
            LoadComboNhanVien();
            LoadComboTrangThai();
            loadSach();
            LoadChiTietSach();
            LoadInfo();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvListSach.CurrentRow != null)
            {
                // Lấy sách được chọn từ danh sách sách
                var sachChon = dgvListSach.CurrentRow.DataBoundItem as Sach;
                ThemSachVaoChiTietMuon(sachChon);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sách để thêm vào danh sách mượn.", "Thông Báo");
            }
        }
        private void XoaSachKhoiChiTietMuon(ChiTietMuonTra chiTiet)
        {
            // Cộng lại số lượng tồn vào danh sách sách
            var sach = lstSach.FirstOrDefault(s => s.MaSach == chiTiet.MaSach);
            if (sach != null)
            {
                sach.SoLuongTon += chiTiet.SoLuong;
            }

            // Xoá chi tiết khỏi danh sách mượn
            lstChiTietMuon.Remove(chiTiet);

            // Cập nhật lại DataGridView
            dgvSachMuon.DataSource = null;
            dgvSachMuon.DataSource = lstChiTietMuon;
            LoadHeaderChiTietMuon(); // Cập nhật lại header nếu cần
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvSachMuon.CurrentRow != null)
            {
                // Lấy sách đang chọn từ danh sách sách đã mượn
                var chiTiet = dgvSachMuon.CurrentRow.DataBoundItem as ChiTietMuonTra;
                if (chiTiet != null)
                {
                    XoaSachKhoiChiTietMuon(chiTiet);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sách để xoá khỏi danh sách mượn.", "Thông Báo");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Cập nhật thông tin phiếu mượn đang làm
                muonTra.MaKhachHang = cboKhachHang.SelectedValue?.ToString();
                muonTra.MaNhanVien = cboNhanVien.SelectedValue?.ToString();
                muonTra.NgayMuon = dtpNgayMuon.Value;
                muonTra.NgayTra = dtpNgayTra.Value;
                muonTra.MaTrangThai = cboTrangThai.SelectedValue?.ToString();
                muonTra.NgayTao = DateTime.Now;

                // 2. Cập nhật thông tin phiếu mượn trong DB (nếu chưa cập nhật)
                busMT.UpdateMuonTra(muonTra);

                // 3. Cập nhật danh sách chi tiết từ giao diện (nếu bạn có xử lý ở đây)
                CapNhatThongTin(); // Đưa dữ liệu từ form vào lstChiTietMuon

                // 4. Gọi BUS để lưu danh sách chi tiết mượn trả
                string result = busMT.InsertRange(lstChiTietMuon, muonTra.MaMuonTra);
                if (!string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Lỗi khi lưu chi tiết mượn: " + result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 5. Đóng form và load lại dữ liệu
                this.Close();
                LoadDSMuonTra();
                loadSach();
                LoadChiTietSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu phiếu mượn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            allowClose = true;
            this.Close();
        }

        private string maPhieuMoi;
        private MuonTra muonTraMoi;



        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maKhachHang = cboKhachHang.SelectedValue?.ToString();
            KhachHang khachHang = lstKhachHang.FirstOrDefault(kh => kh.MaKhachHang == maKhachHang);
            if (khachHang != null)
            {
                txtTenKhachHang.Text = khachHang.TenKhachHang;
                txtCCCD.Text = khachHang.CCCD;
                txtPhone.Text = khachHang.SoDienThoai;
                txtMail.Text = khachHang.Email;
            }
            else
            {
                txtTenKhachHang.Clear();
                txtCCCD.Clear();
                txtPhone.Clear();
                txtMail.Clear();
            }
        }

        private void btnTraPhieu_Click(object sender, EventArgs e)
        {
            if (dgvSachMuon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phiếu mượn để trả.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã phiếu mượn từ dòng đang chọn
            string maMuonTra = dgvSachMuon.SelectedRows[0].Cells["MaMuonTra"].Value.ToString();

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
            LoadDSMuonTra();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
