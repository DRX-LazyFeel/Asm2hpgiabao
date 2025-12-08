using BUS_Xuong;
using DTO_Xuong;
using DAL_Xuong.Interfaces; // chỉ dùng đúng namespace
using QLTV.Tests.TestDoubles;
using Xunit;
using static DTO_Xuong.ThongKe;
namespace QLTV.Tests
{

    public class ThongKeTests
    {
        private readonly BUSThongKe _bus;

        public ThongKeTests()
        {
            IThongKeRepository repo = new FakeThongKeRepository();
            _bus = new BUSThongKe(repo);
        }

        [Fact]
        public void TC_LoadForm_HienThiNhanVien()
        {
            var data = _bus.GetThongKe("ALL");
            Assert.Contains(data, x => x.MaNhanVien == "NV001");
        }

        [Fact]
        public void TC_ThongKeTatCa()
        {
            var data = _bus.GetThongKe("ALL");
            Assert.Equal(3, data.Count);
        }

        [Fact]
        public void TC_ThongKeTheoNV_CoDuLieu()
        {
            var data = _bus.GetThongKe("NV001");
            Assert.Single(data);
            Assert.Equal("NV001", data[0].MaNhanVien);
            Assert.True(data[0].TongSachMuon > 0);
        }

        [Fact]
        public void TC_ThongKeTheoNV_KhongCoDuLieu()
        {
            var data = _bus.GetThongKe("NV999");
            Assert.Empty(data);
        }

        [Fact]
        public void TC_SoSanhGiaTriThongKe()
        {
            var data = _bus.GetThongKe("NV001")[0];
            Assert.Equal(10, data.TongSachMuon);
            Assert.Equal(5, data.SoLuongPhieuMuon);
        }
    }
}