using static DTO_Xuong.ThongKe;
namespace DTO_Xuong

{
    public class ThongKe
    {
        public class ThongKeDTO
        {
            public string MaNhanVien { get; set; } = string.Empty;
            public string TenNhanVien { get; set; } = string.Empty;
            public int SoLuongPhieuMuon { get; set; }
            public int TongSachMuon { get; set; }
        }
    }
}