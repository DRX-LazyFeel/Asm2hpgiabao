// IKhachHangRepository.cs
using DTO_Xuong;
using System.Collections.Generic;

namespace DAL_Xuong
{
    public interface IKhachHangRepository
    {
        List<KhachHang> selectAll();
        List<KhachHang> SearchKhachHang(string keyword);
        string generateMaKhachHang();
        bool checkEmailExists(string email);
        void insertKhachHang(KhachHang kh);
        void updateKhachHang(KhachHang kh);
        void deleteKhachHang(string maKH);
        // Thêm các phương thức khác nếu cần trong tương lai
    }
}