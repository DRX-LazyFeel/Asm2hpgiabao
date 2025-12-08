using System;
using System.Collections.Generic;
using DAL_Xuong.Interfaces;
using DTO_Xuong;

namespace QLTV.Tests.TestDoubles
{
    public class FakeThongKeRepository : IThongKeRepository
    {
        private readonly Dictionary<string, ThongKe.ThongKeDTO> _data =
            new Dictionary<string, ThongKe.ThongKeDTO>
            {
                { "NV001", new ThongKe.ThongKeDTO { MaNhanVien="NV001", TenNhanVien="Nguyễn Văn A", SoLuongPhieuMuon=5, TongSachMuon=10 } },
                { "NV002", new ThongKe.ThongKeDTO { MaNhanVien="NV002", TenNhanVien="Nguyễn Văn B", SoLuongPhieuMuon=3, TongSachMuon=7 } },
                { "NV003", new ThongKe.ThongKeDTO { MaNhanVien="NV003", TenNhanVien="Nguyễn Văn C", SoLuongPhieuMuon=0, TongSachMuon=0 } }
            };

        public List<ThongKe.ThongKeDTO> GetThongKe(string maNV = "ALL")
        {
            if (maNV == "ALL") return new List<ThongKe.ThongKeDTO>(_data.Values);
            return _data.ContainsKey(maNV) ? new List<ThongKe.ThongKeDTO> { _data[maNV] } : new List<ThongKe.ThongKeDTO>();
        }

        public List<ThongKe.ThongKeDTO> ThongKeMuonTheoNhanVien() => new List<ThongKe.ThongKeDTO>(_data.Values);

        public ThongKe.ThongKeDTO ThongKeTheoMaNhanVien(string maNV) => _data.ContainsKey(maNV) ? _data[maNV] : null;

        public List<ThongKe.ThongKeDTO> LayThongKeTheoNhanVien(DateTime tuNgay, DateTime denNgay) => new List<ThongKe.ThongKeDTO>(_data.Values);
    }
}