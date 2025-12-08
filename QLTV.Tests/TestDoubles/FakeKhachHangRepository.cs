// QLTV.Tests/TestDoubles/FakeKhachHangRepository.cs
namespace QLTV.Tests.TestDoubles
{
    // Giả lập repository để test BUS không cần kết nối DB thật
    public class FakeKhachHangRepository
    {
        // Hiện tại để trống cũng được, vì mình mới chỉ cần nó tồn tại để khởi tạo BUS
        // Sau này bạn muốn test thật thì thêm method vào đây
        public bool ThemKhachHang(object kh) => true;
        public bool SuaKhachHang(object kh) => true;
        public bool XoaKhachHang(string maKH) => true;
        public bool KiemTraMaTrung(string maKH) => false;
        public List<object> TimKiem(string keyword) => new();
        public List<object> LayDanhSach() => new();
    }
}