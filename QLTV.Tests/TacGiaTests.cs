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
    public class TacGiaTests
    {
        private readonly BUSTacGia _bus;

        public TacGiaTests()
        {
            var fakeRepo = new FakeTacGiaRepository();
            _bus = new BUSTacGia(fakeRepo);
        }

        [Fact]
        public void TC_ThemTacGia_ThanhCong()
        {
            var tg = new TacGia { MaTacGia = "TG001", TenTacGia = "Nguyễn Nhật Ánh", TrangThai = true };
            Assert.True(_bus.InsertTacGia(tg));
        }

        [Fact]
        public void TC_ThemTacGia_DeTrongThongTin()
        {
            var tg = new TacGia { MaTacGia = "", TenTacGia = "" };
            Assert.False(_bus.InsertTacGia(tg));
        }

        [Fact]
        public void TC_ThemTacGia_TrungMa()
        {
            var tg1 = new TacGia { MaTacGia = "TG002", TenTacGia = "Tác giả A" };
            var tg2 = new TacGia { MaTacGia = "TG002", TenTacGia = "Tác giả B" };
            _bus.InsertTacGia(tg1);
            Assert.False(_bus.InsertTacGia(tg2));
        }

        [Fact]
        public void TC_SuaTacGia_ThanhCong()
        {
            var tg = new TacGia { MaTacGia = "TG003", TenTacGia = "Tên cũ" };
            _bus.InsertTacGia(tg);
            tg.TenTacGia = "Tên mới";
            Assert.True(_bus.UpdateTacGia(tg));
            Assert.Equal("Tên mới", _bus.GetAllTacGia().Find(t => t.MaTacGia == "TG003").TenTacGia);
        }

        [Fact]
        public void TC_XoaTacGia_ChuaChon()
        {
            Assert.False(_bus.DeleteTacGia(""));
        }

        [Fact]
        public void TC_XoaTacGia_ThanhCong()
        {
            var tg = new TacGia { MaTacGia = "TG004", TenTacGia = "Xóa test" };
            _bus.InsertTacGia(tg);
            Assert.True(_bus.DeleteTacGia("TG004"));
        }

        [Fact]
        public void TC_XoaTacGia_DangCoSachLienKet()
        {
            var tg = new TacGia { MaTacGia = "TG005", TenTacGia = "Có sách", CoSachLienKet = true };
            _bus.InsertTacGia(tg);
            Assert.False(_bus.DeleteTacGia("TG005"));
        }

        [Fact]
        public void TC_TimTacGia_HopLe()
        {
            var tg = new TacGia { MaTacGia = "TG006", TenTacGia = "Nguyễn Văn A" };
            _bus.InsertTacGia(tg);
            var result = _bus.GetAllTacGia().Where(t => t.TenTacGia.Contains("Nguyễn")).ToList();
            Assert.Single(result);
        }

        [Fact]
        public void TC_TimTacGia_KhongCoKetQua()
        {
            var result = _bus.GetAllTacGia().Where(t => t.TenTacGia.Contains("abcxyz")).ToList();
            Assert.Empty(result);
        }

        [Fact]
        public void TC_XoaNoiDungTimKiem()
        {
            var tg = new TacGia { MaTacGia = "TG007", TenTacGia = "Tác giả test" };
            _bus.InsertTacGia(tg);
            var result = _bus.GetAllTacGia().Where(t => t.TenTacGia.Contains("test")).ToList();
            Assert.Single(result);
            var all = _bus.GetAllTacGia();
            Assert.NotEmpty(all);
        }

        [Fact]
        public void TC_LamMoi()
        {
            var tg = new TacGia { MaTacGia = "TG008", TenTacGia = "Refresh" };
            _bus.InsertTacGia(tg);
            Assert.Contains(_bus.GetAllTacGia(), t => t.MaTacGia == "TG008");
        }

        [Fact]
        public void TC_LoadForm_CoDuLieu()
        {
            var tg = new TacGia { MaTacGia = "TG009", TenTacGia = "Có dữ liệu" };
            _bus.InsertTacGia(tg);
            Assert.NotEmpty(_bus.GetAllTacGia());
        }

        [Fact]
        public void TC_LoadForm_Rong()
        {
            Assert.Empty(_bus.GetAllTacGia());
        }

        [Fact]
        public void TC_KiemTraCotTrangThai()
        {
            var tg1 = new TacGia { MaTacGia = "TG010", TenTacGia = "Hoạt động", TrangThai = true };
            var tg2 = new TacGia { MaTacGia = "TG011", TenTacGia = "Tạm khóa", TrangThai = false };
            _bus.InsertTacGia(tg1);
            _bus.InsertTacGia(tg2);
            var result = _bus.GetAllTacGia();
            Assert.Contains(result, t => t.TrangThai == true);
            Assert.Contains(result, t => t.TrangThai == false);
        }
    }

}
