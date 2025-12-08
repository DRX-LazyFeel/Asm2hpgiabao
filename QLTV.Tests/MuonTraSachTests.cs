using Xunit;
using BUS_Xuong;
using DTO_Xuong;
using QLTV.Tests.TestDoubles;
using System;

namespace QLTV.Tests
{
    public class MuonTraSachTests
    {
        private readonly BUSMuonTraSach _bus;
        private readonly FakeMuonTraRepository _fakeRepo;

        public MuonTraSachTests()
        {
            // 1. Tạo kho giả
            _fakeRepo = new FakeMuonTraRepository();

            // 2. Nhét kho giả vào BUS
            _bus = new BUSMuonTraSach(_fakeRepo);
        }

        [Fact]
        public void ChoMuonSach_ThongTinDung_ThanhCong()
        {
            // 1. Arrange: Tạo đối tượng MuonTra
            // LƯU Ý: Kiểm tra lại file MuonTra.cs xem thuộc tính tên là 'MaDocGia' hay 'MaDG'
            // Nếu đỏ ở đâu thì sửa tên thuộc tính cho khớp với file DTO của bạn
            var phieu = new MuonTra
            {
                MaKhachHang = "DG01",
                MaMuonTra = "S01",
                NgayMuon = DateTime.Now
            };

            // 2. Act
            bool kq = _bus.ChoMuonSach(phieu);

            // 3. Assert
            Assert.True(kq);
            Assert.Single(_fakeRepo.GetDanhSachMuon()); // Kiểm tra list trong Fake đã có 1 phần tử
        }
    }
}