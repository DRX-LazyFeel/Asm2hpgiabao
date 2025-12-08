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
    public class BUSPhiSach
    {
        private readonly IPhiSachRepository _repo;

        public BUSPhiSach(IPhiSachRepository repo)
        {
            _repo = repo;
        }

        public List<PhiSach> GetAllPhiSach() => _repo.LayTatCa();

        public bool InsertPhiSach(PhiSach ps)
        {
            try { _repo.ThemPhiSach(ps); return true; }
            catch { return false; }
        }

        public bool UpdatePhiSach(PhiSach ps)
        {
            try { _repo.SuaPhiSach(ps); return true; }
            catch { return false; }
        }

        public bool DeletePhiSach(string maPhiSach)
        {
            try { _repo.XoaPhiSach(maPhiSach); return true; }
            catch { return false; }
        }
    }

}
