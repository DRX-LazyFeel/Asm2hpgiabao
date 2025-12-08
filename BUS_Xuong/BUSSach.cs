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
    public class BUSSach
    {
        private readonly ISachRepository _repo;

        public BUSSach(ISachRepository repo)
        {
            _repo = repo;
        }

        public List<Sach> GetAllSach() => _repo.LayTatCa();

        public List<Sach> GetSachChoMuon()
        {
            var allSach = _repo.LayTatCa();
            return allSach.Where(s => s.SoLuongTon > 0 && s.TrangThai).ToList();
        }

        public bool InsertSach(Sach s)
        {
            try { _repo.ThemSach(s); return true; }
            catch { return false; }
        }

        public bool UpdateSach(Sach s)
        {
            try { _repo.SuaSach(s); return true; }
            catch { return false; }
        }

        public bool DeleteSach(string maSach)
        {
            try { _repo.XoaSach(maSach); return true; }
            catch { return false; }
        }
    }
}