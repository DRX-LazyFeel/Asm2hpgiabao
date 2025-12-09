using Xunit;
using BUS_Xuong;
using DTO_Xuong;
using QLTV.Tests.TestDoubles; //nhớ using TestDoubles
using System.Linq;

namespace QLTV.Tests
{
    public class TrangThaiThanhToanTests
    {
        private readonly BUSTrangThaiThanhToan _bus;
        private readonly FakeTrangThaiThanhToanRepository _fakeRepo;

        public TrangThaiThanhToanTests()
        {
            _fakeRepo = new FakeTrangThaiThanhToanRepository();
            _bus = new BUSTrangThaiThanhToan(_fakeRepo);
        }

        [Fact]
        public void Insert_ThemMoi_ThanhCong()
        {
            var item = new TrangThaiThanhToan { MaTrangThai = "TT01", TenTrangThai = "Chưa Trả" };
            bool kq = _bus.Insert(item);
            Assert.True(kq);
            Assert.Single(_fakeRepo.GetAll());
        }

        [Fact]
        public void Delete_XoaTonTai_ThanhCong()
        {
            _fakeRepo.Insert(new TrangThaiThanhToan { MaTrangThai = "TT01" });
            bool kq = _bus.Delete("TT01");
            Assert.True(kq);
            Assert.Empty(_fakeRepo.GetAll());
        }
    }
}