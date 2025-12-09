using Xunit;
using BUS_Xuong;
using QLTV.Tests.TestDoubles;
using System.Data;

namespace QLTV.Tests
{
    public class ThongKeTests
    {
        private readonly BusThongKe _bus;
        private readonly FakeThongKeRepository _fakeRepo;

        public ThongKeTests()
        {
            _fakeRepo = new FakeThongKeRepository();
            _bus = new BusThongKe(_fakeRepo);
        }

        [Fact]
        public void HienThiSachHot_TraVeDuLieuGia_ThanhCong()
        {
            // Act
            DataTable dt = _bus.HienThiSachHot();

            // Assert
            Assert.NotNull(dt);
            Assert.Equal(2, dt.Rows.Count); // Vì mình fake 2 dòng
            Assert.Equal("Dế Mèn Phiêu Lưu Ký", dt.Rows[0]["TenSach"]);
        }
    }
}