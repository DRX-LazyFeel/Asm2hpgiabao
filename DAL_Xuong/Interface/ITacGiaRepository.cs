using DTO_Xuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Xuong.Interface
{
    public interface ITacGiaRepository
    {
        void ThemTacGia(TacGia tg);
        void SuaTacGia(TacGia tg);
        void XoaTacGia(string maTacGia);
        TacGia TimTacGiaTheoMa(string maTacGia);
        List<TacGia> LayTatCa();
    }

}
