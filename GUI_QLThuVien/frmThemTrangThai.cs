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
using TheArtOfDevHtmlRenderer.Adapters;

namespace GUI_QLThuVien
{
    public partial class frmThemTrangThai : Form
    {
        private BUSTrangThaiThanhToan bus = new BUSTrangThaiThanhToan();

        private bool isEdit = false;
        private TrangThaiThanhToan trangThaiCanSua;
        public event EventHandler<TrangThaiThanhToan> TrangThaiAdded;

        public frmThemTrangThai()
        {
            InitializeComponent(); ;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text.Trim();
            string ten = txtTen.Text.Trim();
            bool trangThai = rdhoatdong.Checked;
            DateTime ngayTao = DateTime.Now;

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show("Vui lòng nhập tên trạng thái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTen.Focus();
                return;
            }

            // Tạo đối tượng TrạngTháiThanhToan mới
            TrangThaiThanhToan newTT = new TrangThaiThanhToan
            {
                MaTrangThai = ma,
                TenTrangThai = ten,
                TrangThai = trangThai,
                NgayTao = ngayTao
            };

            // Gọi BUS để thêm mới
            if (bus.Insert(newTT))
            {
                MessageBox.Show("Thêm trạng thái thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Gửi sự kiện cho form cha nếu cần
                TrangThaiAdded?.Invoke(this, newTT);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm trạng thái thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmSuaTTTT_Load(object sender, EventArgs e)
        {
            txtMa.Enabled = false;
            txtMa.Text = bus.GetNextMaSach();
            txtTen.Focus();
        }

        private void lbThemSach_Click(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
