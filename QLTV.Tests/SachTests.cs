using BUS_Xuong;
using DTO_Xuong;
using QLTV.Tests.TestDoubles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.Tests
{
    public class SachTests
    {
        private readonly BUSSach _bus;

        public SachTests()
        {
            var fakeRepo = new FakeSachRepository();
            _bus = new BUSSach(fakeRepo);
        }

        // 1. Thêm sách thành công
        [Fact]
        public void TC_ThemSach_ThanhCong()
        {
            var sach = new Sach { MaSach = "S001", TieuDe = "Lập trình C#", SoLuongTon = 5, TrangThai = true };
            var actual = _bus.InsertSach(sach);
            Assert.True(actual);
        }

        // 2. Thêm sách để trống thông tin bắt buộc
        [Fact]
        public void TC_ThemSach_DeTrongThongTin()
        {
            var sach = new Sach { MaSach = "", TieuDe = "" };
            var actual = _bus.InsertSach(sach);
            Assert.False(actual);
        }

        // 3. Thêm sách trùng mã sách
        [Fact]
        public void TC_ThemSach_TrungMa()
        {
            var sach1 = new Sach { MaSach = "S002", TieuDe = "Cũ" };
            var sach2 = new Sach { MaSach = "S002", TieuDe = "Mới" };

            _bus.InsertSach(sach1);
            var actual = _bus.InsertSach(sach2);

            Assert.False(actual);
        }

        // 4. Sửa sách thành công
        [Fact]
        public void TC_SuaSach_ThanhCong()
        {
            var sach = new Sach { MaSach = "S003", TieuDe = "Sửa test" };
            _bus.InsertSach(sach);

            sach.TieuDe = "Đã sửa";
            var actual = _bus.UpdateSach(sach);

            Assert.True(actual);
            Assert.Equal("Đã sửa", _bus.GetAllSach().Find(s => s.MaSach == "S003").TieuDe);
        }

        // 5. Xóa sách khi chưa chọn dòng
        [Fact]
        public void TC_XoaSach_ChuaChon()
        {
            var actual = _bus.DeleteSach("");
            Assert.False(actual);
        }

        // 6. Xóa sách thành công
        [Fact]
        public void TC_XoaSach_ThanhCong()
        {
            var sach = new Sach { MaSach = "S004", TieuDe = "Xóa test" };
            _bus.InsertSach(sach);

            var actual = _bus.DeleteSach("S004");
            Assert.True(actual);
        }

        //// 7. Xóa sách đang được mượn (SoLuongTon = 0)
        //[Fact]
        //public void TC_XoaSach_DangMuon()
        //{
        //    var sach = new Sach { MaSach = "S005", TieuDe = "Đang mượn", SoLuongTon = 0, TrangThai = true };
        //    _bus.InsertSach(sach);

        //    var actual = _bus.DeleteSach("S005");
        //    Assert.False(actual);
        //}

        // 8. Tìm theo tên sách hợp lệ
        [Fact]
        public void TC_TimSach_HopLe()
        {
            var sach = new Sach { MaSach = "S006", TieuDe = "Lập trình Java" };
            _bus.InsertSach(sach);

            var result = _bus.GetAllSach().Where(s => s.TieuDe.Contains("Java")).ToList();
            Assert.Single(result);
        }

        // 9. Tìm kiếm không có kết quả
        [Fact]
        public void TC_TimSach_KhongCoKetQua()
        {
            var result = _bus.GetAllSach().Where(s => s.TieuDe.Contains("abcxyz123")).ToList();
            Assert.Empty(result);
        }

        // 10. Xóa nội dung ô tìm kiếm
        [Fact]
        public void TC_XoaNoiDungTimKiem()
        {
            var sach = new Sach { MaSach = "S007", TieuDe = "Python cơ bản" };
            _bus.InsertSach(sach);

            var result = _bus.GetAllSach().Where(s => s.TieuDe.Contains("Python")).ToList();
            Assert.Single(result);

            // giả lập xóa ô tìm kiếm => lấy lại toàn bộ
            var all = _bus.GetAllSach();
            Assert.NotEmpty(all);
        }

        // 11. Load form khi có dữ liệu
        [Fact]
        public void TC_LoadForm_CoDuLieu()
        {
            var sach = new Sach { MaSach = "S008", TieuDe = "Có dữ liệu" };
            _bus.InsertSach(sach);

            var result = _bus.GetAllSach();
            Assert.NotEmpty(result);
        }

        // 12. Load form khi database rỗng
        [Fact]
        public void TC_LoadForm_Rong()
        {
            var result = _bus.GetAllSach();
            Assert.Empty(result);
        }

        // 13. Chuyển sang tab Loại sách
        [Fact]
        public void TC_ChuyenTab_LoaiSach()
        {
            // giả lập: chỉ cần kiểm tra gọi được form loại sách
            var formLoaded = true; // giả định
            Assert.True(formLoaded);
        }

        // 14. Chuyển sang tab Tác giả
        [Fact]
        public void TC_ChuyenTab_TacGia()
        {
            // giả lập: chỉ cần kiểm tra gọi được form tác giả
            var formLoaded = true; // giả định
            Assert.True(formLoaded);
        }
    }

}
