using DTO_Xuong;
using System;
using System.Collections.Generic;

namespace DAL_Xuong.Interfaces
{
    public interface IThongKeRepository
    {
        List<ThongKe.ThongKeDTO> GetThongKe(string maNV = "ALL");
        List<ThongKe.ThongKeDTO> ThongKeMuonTheoNhanVien();
        ThongKe.ThongKeDTO ThongKeTheoMaNhanVien(string maNV);
        List<ThongKe.ThongKeDTO> LayThongKeTheoNhanVien(DateTime tuNgay, DateTime denNgay);
    }
}