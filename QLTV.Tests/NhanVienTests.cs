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
    public class NhanVienTests
    {
        private readonly BUSNhanVien _bus;

        public NhanVienTests()
        {
            var fakeRepo = new FakeNhanVienRepository();
            _bus = new BUSNhanVien(fakeRepo);
        }

        [Fact]
        public void TC_ThemNhanVien_ThanhCong()
        {
            var nv = new NhanVien
            {
                MaNhanVien = "NV008",
                Ten = "Lê Văn Tét",
                SoDienThoai = "0912345678",
                Email = "tetle@gmail.com",
                MatKhau = "123456aA@",
                VaiTro = false,
                TrangThai = true
            };
            Assert.True(_bus.InsertNhanVien(nv));
        }

        [Fact]
        public void TC_BoTrongTruongBatBuoc()
        {
            var nv = new NhanVien { MaNhanVien = "NV009", Ten = "", Email = "abc@gmail.com", MatKhau = "123" };
            Assert.False(_bus.InsertNhanVien(nv));
        }

        [Fact]
        public void TC_EmailKhongHopLe()
        {
            var nv = new NhanVien { MaNhanVien = "NV010", Ten = "Test", Email = "test.com", MatKhau = "123" };
            Assert.False(_bus.InsertNhanVien(nv));
        }

        [Fact]
        public void TC_EmailTrung()
        {
            var nv1 = new NhanVien { MaNhanVien = "NV011", Ten = "A", Email = "a@gmail.com", MatKhau = "123" };
            var nv2 = new NhanVien { MaNhanVien = "NV012", Ten = "B", Email = "a@gmail.com", MatKhau = "123" };
            _bus.InsertNhanVien(nv1);
            Assert.False(_bus.InsertNhanVien(nv2));
        }

        [Fact]
        public void TC_MatKhauKhongHopLe()
        {
            var nv = new NhanVien { MaNhanVien = "NV013", Ten = "C", Email = "c@gmail.com", MatKhau = "" };
            Assert.False(_bus.InsertNhanVien(nv));
        }

        [Fact]
        public void TC_NutHuy()
        {
            // giả lập hủy: không insert
            Assert.Empty(_bus.GetAllNhanVien());
        }

        [Fact]
        public void TC_TimKiemTheoMaNV()
        {
            var nv = new NhanVien { MaNhanVien = "NV004", Ten = "Phạm Minh Tùng", Email = "pmt@gmail.com", MatKhau = "123" };
            _bus.InsertNhanVien(nv);
            var result = _bus.GetAllNhanVien().Where(x => x.MaNhanVien == "NV004").ToList();
            Assert.Single(result);
        }

        [Fact]
        public void TC_TimKiemTheoHoTen()
        {
            var nv = new NhanVien { MaNhanVien = "NV001", Ten = "Nguyễn Văn Hòa", Email = "hoa@gmail.com", MatKhau = "123" };
            _bus.InsertNhanVien(nv);
            var result = _bus.GetAllNhanVien().Where(x => x.Ten.Contains("Hòa")).ToList();
            Assert.Single(result);
        }

        [Fact]
        public void TC_TimKiemKhongCoKetQua()
        {
            var result = _bus.GetAllNhanVien().Where(x => x.Ten.Contains("ABCXYZ")).ToList();
            Assert.Empty(result);
        }

        [Fact]
        public void TC_XoaNhanVien_ThanhCong()
        {
            var nv = new NhanVien { MaNhanVien = "NV007", Ten = "Trần Mạnh Tiến", Email = "tmt@gmail.com", MatKhau = "123" };
            _bus.InsertNhanVien(nv);
            Assert.True(_bus.DeleteNhanVien("NV007"));
        }

        [Fact]
        public void TC_HuyXoa()
        {
            var nv = new NhanVien { MaNhanVien = "NV006", Ten = "Nhật Huy", Email = "huy@gmail.com", MatKhau = "123" };
            _bus.InsertNhanVien(nv);
            // giả lập hủy: không delete
            Assert.Contains(_bus.GetAllNhanVien(), x => x.MaNhanVien == "NV006");
        }

        [Fact]
        public void TC_LamMoi()
        {
            var nv = new NhanVien { MaNhanVien = "NV004", Ten = "Phạm Minh Tùng", Email = "pmt@gmail.com", MatKhau = "123" };
            _bus.InsertNhanVien(nv);
            var result = _bus.GetAllNhanVien();
            Assert.NotEmpty(result);
        }
    }

}
