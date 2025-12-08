using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Xuong
{
    public class PhiSach
    {
        public string MaPhiSach { get; set; }
        public string MaSach { get; set; }
        public decimal PhiMuon { get; set; }
        public decimal PhiPhat { get; set; }
        public bool TrangThai { get; set; }
        public DateTime NgayTao { get; set; } = DateTime.Now; // thêm thuộc tính này
        public bool DangApDung { get; set; } = false;
    }


}
