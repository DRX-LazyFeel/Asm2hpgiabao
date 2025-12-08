using BUS_Xuong;
using DAL_Xuong.Interface;
using DTO_Xuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.Tests
{
    public class PhiSachTests
    {
        private readonly BUSPhiSach _bus;

        public PhiSachTests()
        {
            var fakeRepo = new FakePhiSachRepository();
            _bus = new BUSPhiSach(fakeRepo);
        }

        [Fact] public void TC_ThemPhiSach_ThanhCong() { var ps = new PhiSach { MaPhiSach = "PS001", MaSach = "S001", PhiMuon = 1000, PhiPhat = 500, TrangThai = true }; Assert.True(_bus.InsertPhiSach(ps)); }
        [Fact] public void TC_ThemPhiSach_DeTrongThongTin() { var ps = new PhiSach { MaPhiSach = "", MaSach = "", PhiMuon = 1000, PhiPhat = 500 }; Assert.False(_bus.InsertPhiSach(ps)); }
        [Fact] public void TC_ThemPhiSach_TrungMa() { var ps1 = new PhiSach { MaPhiSach = "PS002", MaSach = "S001" }; var ps2 = new PhiSach { MaPhiSach = "PS002", MaSach = "S002" }; _bus.InsertPhiSach(ps1); Assert.False(_bus.InsertPhiSach(ps2)); }
        [Fact] public void TC_SuaPhiSach_ThanhCong() { var ps = new PhiSach { MaPhiSach = "PS003", MaSach = "S001", PhiMuon = 1000, PhiPhat = 500 }; _bus.InsertPhiSach(ps); ps.PhiMuon = 2000; Assert.True(_bus.UpdatePhiSach(ps)); Assert.Equal(2000, _bus.GetAllPhiSach().Find(p => p.MaPhiSach == "PS003").PhiMuon); }
        [Fact] public void TC_XoaPhiSach_ChuaChon() { Assert.False(_bus.DeletePhiSach("")); }
        [Fact] public void TC_XoaPhiSach_ThanhCong() { var ps = new PhiSach { MaPhiSach = "PS004", MaSach = "S001" }; _bus.InsertPhiSach(ps); Assert.True(_bus.DeletePhiSach("PS004")); }
        [Fact] public void TC_XoaPhiSach_DangApDung() { var ps = new PhiSach { MaPhiSach = "PS005", MaSach = "S001", DangApDung = true }; _bus.InsertPhiSach(ps); Assert.False(_bus.DeletePhiSach("PS005")); }
        [Fact] public void TC_TimKiemTheoMaPhiSach() { var ps = new PhiSach { MaPhiSach = "PS006", MaSach = "S001" }; _bus.InsertPhiSach(ps); var result = _bus.GetAllPhiSach().Where(p => p.MaPhiSach.Contains("PS006")).ToList(); Assert.Single(result); }
        [Fact] public void TC_TimKiemTheoMaSach() { var ps = new PhiSach { MaPhiSach = "PS007", MaSach = "S001" }; _bus.InsertPhiSach(ps); var result = _bus.GetAllPhiSach().Where(p => p.MaSach == "S001").ToList(); Assert.Single(result); }
        [Fact] public void TC_TimKiem_KhongCoKetQua() { var result = _bus.GetAllPhiSach().Where(p => p.MaPhiSach.Contains("xyz123")).ToList(); Assert.Empty(result); }
        [Fact] public void TC_XoaNoiDungTimKiem() { var ps = new PhiSach { MaPhiSach = "PS008", MaSach = "S001" }; _bus.InsertPhiSach(ps); var result = _bus.GetAllPhiSach().Where(p => p.MaPhiSach.Contains("PS008")).ToList(); Assert.Single(result); var all = _bus.GetAllPhiSach(); Assert.NotEmpty(all); }
        [Fact] public void TC_LamMoi() { var ps = new PhiSach { MaPhiSach = "PS009", MaSach = "S001" }; _bus.InsertPhiSach(ps); Assert.Contains(_bus.GetAllPhiSach(), p => p.MaPhiSach == "PS009"); }
        [Fact] public void TC_LoadForm_CoDuLieu() { var ps = new PhiSach { MaPhiSach = "PS010", MaSach = "S001" }; _bus.InsertPhiSach(ps); Assert.NotEmpty(_bus.GetAllPhiSach()); }
        [Fact] public void TC_LoadForm_Rong() { Assert.Empty(_bus.GetAllPhiSach()); }
        [Fact] public void TC_KiemTraCotTrangThai() { var ps1 = new PhiSach { MaPhiSach = "PS011", MaSach = "S001", TrangThai = true }; var ps2 = new PhiSach { MaPhiSach = "PS012", MaSach = "S002", TrangThai = false }; _bus.InsertPhiSach(ps1); _bus.InsertPhiSach(ps2); var result = _bus.GetAllPhiSach(); Assert.Contains(result, p => p.TrangThai == true); Assert.Contains(result, p => p.TrangThai == false); }
    }

}
