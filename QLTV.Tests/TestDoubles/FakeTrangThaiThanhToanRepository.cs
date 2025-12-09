using DAL_Xuong.Interface; //nhớ using interface
using DTO_Xuong;
using System.Collections.Generic;
using System.Linq;

namespace QLTV.Tests.TestDoubles
{
    public class FakeTrangThaiThanhToanRepository : ITrangThaiThanhToanRepository
    {
        private readonly List<TrangThaiThanhToan> _list = new();

        public List<TrangThaiThanhToan> GetAll() => _list;

        public bool Insert(TrangThaiThanhToan t)
        {
            if (_list.Any(x => x.MaTrangThai == t.MaTrangThai)) return false;
            _list.Add(t);
            return true;
        }

        public bool Update(TrangThaiThanhToan t)
        {
            var item = _list.FirstOrDefault(x => x.MaTrangThai == t.MaTrangThai);
            if (item == null) return false;
            item.TenTrangThai = t.TenTrangThai;
            // Cập nhật các trường khác nếu có
            return true;
        }

        public bool Delete(string ma)
        {
            var item = _list.FirstOrDefault(x => x.MaTrangThai == ma);
            if (item == null) return false;
            return _list.Remove(item);
        }

        public string GetNextMa() => "TT_AUTO_" + (_list.Count + 1);
    }
}