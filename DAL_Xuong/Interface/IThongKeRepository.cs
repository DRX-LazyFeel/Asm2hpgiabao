using System.Data; // Thống kê thường trả về bảng dữ liệu

namespace DAL_Xuong.Interface
{
    public interface IThongKeRepository
    {
        DataTable GetSachMuonNhieuNhat();
    }
}