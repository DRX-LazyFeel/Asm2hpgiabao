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
    public partial class FrmSuaTacGia : Form
    {
        private TacGia tacGia;
        private BUSTacGia bustacgia = new BUSTacGia();
        public FrmSuaTacGia(TacGia tacGia)
        {
            InitializeComponent();
            this.tacGia = tacGia;
            lloadquosctich(); // Gọi hàm để nạp danh sách quốc tịch vào ComboBox
        }
        private void lloadquosctich()
        {
            // Giả sử bạn có một danh sách quốc tịch
            List<string> quocTichList = new List<string>
     {
         "Việt Nam",
         "Mỹ",
         "Anh",
         "Pháp",
         "Nhật Bản",
         "Hàn Quốc"
     };
            cbqt.DataSource = quocTichList;
            cbqt.SelectedIndex = -1;
        }

        private void FrmSuaTacGia_Load(object sender, EventArgs e)
        {
            if (tacGia == null) return;

            txtmatacgia.Text = tacGia.MaTacGia;
            txtmatacgia.Enabled = false;
            txttentacgia.Text = tacGia.TenTacGia;
            cbqt.Text = tacGia.QuocTich;

            if (tacGia.TrangThai)
                rdoHoatDong.Checked = true;
            else
                rdoKhongHoatDong.Checked = true;
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            // Lấy và chuẩn hóa dữ liệu nhập
            string tenTacGia = txttentacgia.Text.Trim();
            string quocTich = cbqt.Text.Trim();

            // 1. Kiểm tra dữ liệu rỗng
            if (string.IsNullOrWhiteSpace(tenTacGia))
            {
                MessageBox.Show("Vui lòng nhập tên tác giả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttentacgia.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(quocTich))
            {
                MessageBox.Show("Vui lòng chọn quốc tịch!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbqt.Focus();
                return;
            }

            // 2. Kiểm tra độ dài chuỗi
            if (tenTacGia.Length > 100)
            {
                MessageBox.Show("Tên tác giả không được vượt quá 100 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttentacgia.Focus();
                return;
            }

            // 3. Kiểm tra ký tự hợp lệ (chỉ chữ cái và khoảng trắng)
            if (!System.Text.RegularExpressions.Regex.IsMatch(tenTacGia, @"^[\p{L}\s]+$"))
            {
                MessageBox.Show("Tên tác giả chỉ được chứa chữ cái và khoảng trắng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttentacgia.Focus();
                return;
            }

            // 4. Kiểm tra quốc tịch có nằm trong danh sách ComboBox
            if (cbqt.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn quốc tịch từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbqt.Focus();
                return;
            }

            // 5. Gán giá trị mới cho đối tượng
            tacGia.TenTacGia = tenTacGia;
            tacGia.QuocTich = quocTich;
            tacGia.TrangThai = rdoHoatDong.Checked;

            // 6. Gọi BUS để cập nhật
            string result = bustacgia.UpdateTacGia(tacGia);

            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void cbqt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
