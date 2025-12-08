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
    public partial class FrmThemTacGia : Form
    {
        private BUSTacGia BUSTacGia = new BUSTacGia();
        private TacGia tacGia = new TacGia();
        public event EventHandler<TacGia>? TacGiaAdded;

        private string text = "Thêm mới";
        private string btnText = "Thêm Mới";
        private bool allowClose = false;
        public FrmThemTacGia()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maTacGia = txtmatacgia.Text.Trim();
            string tenTacGia = txttentacgia.Text.Trim();
            string quocTich = cbqt.Text.Trim();
            bool trangThai = rdoHoatDong.Checked; // Hoạt động nếu chọn radio này

            DateTime ngayTao = DateTime.Now;

            // Kiểm tra dữ liệu  
            if (string.IsNullOrEmpty(tenTacGia) || string.IsNullOrEmpty(quocTich))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin tác giả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng TacGia  
            TacGia tacGia = new TacGia
            {
                MaTacGia = string.IsNullOrEmpty(maTacGia) ? BUSTacGia.GenerateMaTacGia() : maTacGia,
                TenTacGia = tenTacGia,
                QuocTich = quocTich,
                TrangThai = trangThai, // true nếu chọn Hoạt động, false nếu chọn Không hoạt động
                NgayTao = ngayTao,
            };

            // Thêm vào database  
            string result = BUSTacGia.InsertTacGia(tacGia);

            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Thêm tác giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TacGiaAdded?.Invoke(this, tacGia); // Gửi sự kiện thêm tác giả  
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdoKhongHoatDong_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
