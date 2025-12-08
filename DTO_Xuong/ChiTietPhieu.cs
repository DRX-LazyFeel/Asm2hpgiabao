using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Xuong
{
     public class ChiTietMuonTra
    {
        public string MaMuonTra { get; set; }
        public string MaChiTiet { get; set; }
        public string MaSach { get; set; }
        public int SoLuong { get; set; }
        public bool TrangThai { get; set; }
        public decimal PhiMuon { get; set; }
        public int PhiPhat { get; set; }
        public string TenSach { get; set; }
        public string MaTinhTrangSach { get; set; }
        public string TenTinhTrangSach { get; set; }
        public string GhiChu { get; set; }
        public DateTime NgayTao { get; set; }
        public string TrangThaiText => TrangThai ? "Đã trả" : "Chưa trả";
    }
}
