// File: QLTV.Tests/TestDoubles/FakeDALKhachHang.cs
using DAL_Xuong;
using DTO_Xuong;
using System.Collections.Generic;
using System.Linq;

namespace QLTV.Tests.TestDoubles
{
    /// <summary>
    /// Fake DALKhachHang để test BUS mà không đụng DB thật
    /// Dùng "new" để ẩn (hide) các method của class cha
    /// </summary>
    public class FakeDALKhachHang : DALKhachHang
    {
        // Dữ liệu giả trong RAM
        private readonly List<KhachHang> _list = new List<KhachHang>();

        // Ẩn (hide) các method gốc bằng từ khóa "new"
        public new List<KhachHang> selectAll()
            => _list.ToList();   // trả về bản sao để an toàn

        public new List<KhachHang> SearchKhachHang(string keyword)
            => _list.Where(kh =>
                   kh.MaKhachHang.Contains(keyword) ||
                   kh.TenKhachHang.Contains(keyword) ||
                   kh.Email.Contains(keyword) ||
                   kh.SoDienThoai.Contains(keyword))
                   .ToList();

        public new string generateMaKhachHang()
            => "KH" + (_list.Count + 1).ToString("000");

        public new bool checkEmailExists(string email)
            => _list.Any(kh => kh.Email == email);

        public new void insertKhachHang(KhachHang kh)
            => _list.Add(kh);

        public new void updateKhachHang(KhachHang kh)
        {
            var existing = _list.FirstOrDefault(x => x.MaKhachHang == kh.MaKhachHang);
            if (existing != null)
            {
                existing.TenKhachHang = kh.TenKhachHang;
                existing.Email = kh.Email;
                existing.SoDienThoai = kh.SoDienThoai;
                existing.CCCD = kh.CCCD;
                existing.TrangThai = kh.TrangThai;
                // các field khác nếu cần
            }
        }

        public new void deleteKhachHang(string maKH)
            => _list.RemoveAll(x => x.MaKhachHang == maKH);
    }
}