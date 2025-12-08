using DTO_Xuong; // Đã sửa: Dùng namespace chứa class MuonTra
using System.Collections.Generic;

namespace DAL_Xuong.Interface
{
    // Đã sửa: Tên Interface thống nhất là IMuonTraRepository
    public interface IMuonTraRepository
    {
        // Đã sửa: Nhận vào đối tượng 'MuonTra' chứ không phải 'DTO_MuonTra'
        bool ThemMuonTra(MuonTra mt);

        List<MuonTra> GetDanhSachMuon();
    }
}