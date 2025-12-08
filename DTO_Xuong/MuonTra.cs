    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Xuong
{
    public class MuonTra
    {
        public string MaMuonTra { get; set; }
        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; } // ✅ Thêm để hiển thị tên khách
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; } // ✅ Thêm để hiển thị tên nhân viên
        public DateTime NgayMuon { get; set; }
        public DateTime NgayTra { get; set; }
        public string MaTrangThai { get; set; }
        public DateTime NgayTao { get; set; }

        public string TenTrangThai => MaTrangThai switch
    {
        "TT001" => "Đang mượn",
        "TT002" => "Đã trả",
        "TT003" => "Trễ hạn",
        "TT004" => "Đang xử lí"
    };

    }
}