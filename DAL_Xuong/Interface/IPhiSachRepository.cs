using DTO_Xuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Xuong.Interface
{
    public interface IPhiSachRepository
    {
        void ThemPhiSach(PhiSach ps);
        void SuaPhiSach(PhiSach ps);
        void XoaPhiSach(string maPhiSach);
        PhiSach TimPhiSachTheoMa(string maPhiSach);
        List<PhiSach> LayTatCa();
    }

}
