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
using Microsoft.Data.SqlClient;

namespace GUI_QLThuVien
{
    public partial class frmThemPhiSach : Form
    {
        private BUSPhiSach bus = new BUSPhiSach();
        private BUSSach buss = new BUSSach();
        private PhiSach phiSach = new PhiSach();
        public event EventHandler<PhiSach> PhiSachAdded;
        private string text = "Thêm mới";
        private string btnText = "Thêm Mới";

        public frmThemPhiSach()
        {
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string MaPhiSach = txtmaphiSach.Text.Trim();
            string MaSach = cbmasach.SelectedValue?.ToString();
            string phiMuonText = txtPhiMuon.Text.Trim();
            string phiPhatText = txtPhiPhat.Text.Trim();
            bool trangThai = rdoApDung.Checked;
            DateTime ngayTao = DateTime.Now;

            // 1. Kiểm tra mã sách
            if (string.IsNullOrEmpty(MaSach))
            {
                MessageBox.Show("Vui lòng chọn mã sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kiểm tra số tiền mượn
            if (!decimal.TryParse(phiMuonText, out decimal phiMuon) || phiMuon < 0)
            {
                MessageBox.Show("Phí mượn phải là số và >= 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Kiểm tra số tiền phạt
            if (!decimal.TryParse(phiPhatText, out decimal phiPhat) || phiPhat < 0)
            {
                MessageBox.Show("Phí phạt phải là số và >= 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Kiểm tra trùng mã sách (nếu đang thêm mới)
            if (string.IsNullOrEmpty(MaPhiSach))
            {
                var danhSach = bus.GetAllPhiSach();
                if (danhSach.Any(p => p.MaSach == MaSach))
                {
                    MessageBox.Show("Mã sách này đã tồn tại phí sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                MaPhiSach = bus.GenerateMaPhiSach();
            }

            // 5. Tạo đối tượng
            PhiSach phisa = new PhiSach
            {
                MaPhiSach = MaPhiSach,
                MaSach = MaSach,
                PhiMuon = phiMuon,
                PhiPhat = phiPhat,
                TrangThai = trangThai,
                NgayTao = ngayTao
            };

            // 6. Gọi lưu
            string result = bus.InsertPhiSach(phisa);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Thêm phí sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PhiSachAdded?.Invoke(this, phisa);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadComboBoxSach()
        {
            List<Sach> danhSachSach = buss.LaySachDangHoatDong(); // gọi BUS

            cbmasach.DataSource = danhSachSach;
            cbmasach.DisplayMember = "TenSach";
            cbmasach.ValueMember = "MaSach";
        }

        private void frmThemPhiSach_Load(object sender, EventArgs e)
        {
            LoadComboBoxSach();
            // B1: Lấy danh sách mã sách đã tồn tại từ bảng PhiSach
            List<PhiSach> danhSach = bus.GetAllPhiSach(); // bạn cần có hàm này trong BUSPhiSach

            // B2: Tạo danh sách mã sách dạng S001, S002,...
            List<string> maSachList = new List<string>();

            foreach (var p in danhSach)
            {
                maSachList.Add(p.MaSach); // lấy các mã đã tồn tại
            }

            // B3: Tính mã mới tự tăng
            int max = 0;
            foreach (var ma in maSachList)
            {
                if (ma.StartsWith("S") && int.TryParse(ma.Substring(1), out int so))
                {
                    if (so > max) max = so;
                }
            }

            string maMoi = "S" + (max + 1).ToString("D3");

            // B4: Gán danh sách vào ComboBox
            maSachList.Add(maMoi); // thêm mã mới vào danh sách

            cbmasach.DataSource = null;
            cbmasach.DataSource = maSachList;
            cbmasach.DropDownStyle = ComboBoxStyle.DropDownList;

            // B5: Chọn dòng mã mới nhất
            cbmasach.SelectedItem = maMoi;

        }
    }
}
