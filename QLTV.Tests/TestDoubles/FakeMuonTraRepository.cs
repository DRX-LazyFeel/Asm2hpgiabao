using DAL_Xuong.Interface;
using DTO_Xuong;
using System.Collections.Generic;

namespace QLTV.Tests.TestDoubles
{
    // Fake này đóng vai trò thay thế SQL
    public class FakeMuonTraRepository : IMuonTraRepository
    {
        // Đã sửa: List chứa các object 'MuonTra'
        private readonly List<MuonTra> _list = new List<MuonTra>();

        public bool ThemMuonTra(MuonTra mt)
        {
            _list.Add(mt);
            return true;
        }

        public List<MuonTra> GetDanhSachMuon()
        {
            return _list;
        }
    }
}