using DTO_Xuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Xuong.Interface
{
    public interface ISachRepository
    {
        void ThemSach(Sach sach);
        void XoaSach(string maSach);
        void SuaSach(Sach sach);
        Sach TimSachTheoMa(string maSach);
        List<Sach> LayTatCa();
    }
}
