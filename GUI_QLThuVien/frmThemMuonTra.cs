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
using DTO_Xuong;

namespace GUI_QLThuVien
{
    public partial class frmThemMuonTra : Form
    { List<ChiTietMuonTra> listCT = new List<ChiTietMuonTra>();
        public string MaMuonTraMoi { get; private set; }

        List<KhachHang> lstKhachHang = new List<KhachHang>();
        BUSMuonTraSach busMuonTra = new BUSMuonTraSach();
        public frmThemMuonTra()
        {
            InitializeComponent();
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

        private void frmThemMuonTra_Load(object sender, EventArgs e)
        {
            LoadComboKhachHang();
            LoadComboNhanVien();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra khách hàng
            if (cboKhachHang.SelectedValue == null || string.IsNullOrWhiteSpace(cboKhachHang.SelectedValue.ToString()))
            {
                MessageBox.Show("Vui lòng chọn khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKhachHang.Focus();
                return;
            }

            // 2. Kiểm tra nhân viên
            if (cboNhanVien.SelectedValue == null || string.IsNullOrWhiteSpace(cboNhanVien.SelectedValue.ToString()))
            {
                MessageBox.Show("Vui lòng chọn nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNhanVien.Focus();
                return;
            }

            // 3. Kiểm tra ngày mượn / trả
            if (dtpNgayTra.Value.Date < dtpNgayMuon.Value.Date)
            {
                MessageBox.Show("Ngày trả không được trước ngày mượn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayTra.Focus();
                return;
            }

            // 4. Kiểm tra danh sách sách mượn
            if (listCT == null || listCT.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm ít nhất một sách vào danh sách mượn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 5. Sinh mã mượn và tạo object
            string maMuon = busMuonTra.GenerateMuonTra();

            MuonTra muon = new MuonTra()
            {
                MaMuonTra = maMuon,
                MaKhachHang = cboKhachHang.SelectedValue.ToString(),
                MaNhanVien = cboNhanVien.SelectedValue.ToString(),
                NgayMuon = dtpNgayMuon.Value,
                NgayTra = dtpNgayTra.Value,
                NgayTao = dtpNgayTao.Value,
                MaTrangThai = rdoHoatDong.Checked ? "1" : "0"
            };

            // 6. Gọi BUS để lưu
            string result = busMuonTra.InsertMuonTra(muon, listCT);
            if (string.IsNullOrEmpty(result))
            {
                this.Tag = maMuon;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
