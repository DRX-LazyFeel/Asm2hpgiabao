using DTO_Xuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Xuong.Interface
{
    public interface INhanVienRepository
    {
        void ThemNhanVien(NhanVien nv);
        void SuaNhanVien(NhanVien nv);
        void XoaNhanVien(string maNV);
        NhanVien TimNhanVienTheoMa(string maNV);
        List<NhanVien> LayTatCa();
    }

}
