using DAL_Xuong;
using DAL_Xuong.Interface;
using DTO_Xuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_Xuong
{
    public class BUSTacGia
    {
        private readonly ITacGiaRepository _repo;

        // Nhận repository qua constructor
        public BUSTacGia(ITacGiaRepository repo)
        {
            _repo = repo;
        }

        public List<TacGia> GetAllTacGia()
        {
            return _repo.LayTatCa();
        }

        public bool InsertTacGia(TacGia tg)
        {
            try
            {
                _repo.ThemTacGia(tg);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateTacGia(TacGia tg)
        {
            try
            {
                _repo.SuaTacGia(tg);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteTacGia(string maTacGia)
        {
            try
            {
                _repo.XoaTacGia(maTacGia);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

}
