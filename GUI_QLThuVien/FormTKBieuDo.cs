using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BUS_Xuong;
using DAL_Xuong;
using DTO_Xuong;
using static DTO_Xuong.ThongKe;

namespace GUI_QLThuVien
{
    public partial class FormTKBieuDo : Form
    {
        private BUSNhanVien busNhanVien = new BUSNhanVien();
        private BusThongKe busThongKe = new BusThongKe();
        private DALThongKe dalThongKe = new DALThongKe();
        public FormTKBieuDo()
        {
            InitializeComponent();
        }

        private void FormTKBieuDo_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
        }
        private void LoadNhanVien()
        {
            var dsNhanVien = busNhanVien.GetNhanVienList();

            // Thêm tùy chọn "Tất cả"
            var dsHienThi = new List<dynamic>();
            dsHienThi.Add(new { MaNhanVien = "", Ten = "Tất cả" });
            foreach (var nv in dsNhanVien)
            {
                dsHienThi.Add(new { nv.MaNhanVien, nv.Ten });
            }

            cbNV.DataSource = dsHienThi;
            cbNV.DisplayMember = "Ten";
            cbNV.ValueMember = "MaNhanVien";
            cbNV.SelectedIndex = 0;
        }

        private void VeBieuDo(List<ThongKeDTO> data)
        {
            chartTK.Series.Clear();
            chartTK.Legends.Clear();

            Legend legend = new Legend { Docking = Docking.Top };
            chartTK.Legends.Add(legend);

            Series seriesMuon = new Series("Tổng Sách Mượn")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.SteelBlue,
                IsValueShownAsLabel = true
            };

            Series seriesPhieu = new Series("Số Phiếu Mượn")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.Orange,
                IsValueShownAsLabel = true
            };

            foreach (var item in data)
            {
                seriesMuon.Points.AddXY(item.TenNhanVien, item.TongSachMuon);
                seriesPhieu.Points.AddXY(item.TenNhanVien, item.SoLuongPhieuMuon);
            }

            chartTK.Series.Add(seriesMuon);
            chartTK.Series.Add(seriesPhieu);

            chartTK.ChartAreas[0].AxisX.Title = "Nhân Viên";
            chartTK.ChartAreas[0].AxisY.Title = "Số Lượng";
            chartTK.ChartAreas[0].AxisX.LabelStyle.Angle = -30;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string maNV = cbNV.SelectedValue?.ToString();
            List<ThongKeDTO> dsThongKe;

            if (string.IsNullOrEmpty(maNV)) // Tất cả
            {
                dsThongKe = busThongKe.LayThongKeTatCaNhanVien();
            }
            else // Theo nhân viên
            {
                var tk = busThongKe.ThongKeTheoMaNhanVien(maNV);
                dsThongKe = tk != null ? new List<ThongKeDTO> { tk } : new List<ThongKeDTO>();
            }

            if (dsThongKe == null || dsThongKe.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu thống kê.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chartTK.Series.Clear();
                return;
            }

            VeBieuDo(dsThongKe);


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

            chartTK.DataSource = data;

          
        }
        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            frmtkdata form = new frmtkdata();
            form.Show();
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
