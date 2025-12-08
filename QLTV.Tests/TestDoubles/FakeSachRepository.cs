using DAL_Xuong.Interface;
using DTO_Xuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.Tests.TestDoubles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FakeSachRepository : ISachRepository
    {
        private readonly List<Sach> _sachs = new();

        public void ThemSach(Sach sach)
        {
            if (string.IsNullOrWhiteSpace(sach.MaSach))
                throw new Exception("Mã sách không được để trống");

            if (_sachs.Any(s => s.MaSach == sach.MaSach))
                throw new Exception("Mã sách đã tồn tại");

            _sachs.Add(sach);
        }

        public void XoaSach(string maSach)
        {
            if (!_sachs.Any(s => s.MaSach == maSach))
                throw new Exception("Không tìm thấy sách để xóa");

            _sachs.RemoveAll(s => s.MaSach == maSach);
        }

        public void SuaSach(Sach sach)
        {
            var index = _sachs.FindIndex(s => s.MaSach == sach.MaSach);
            if (index < 0)
                throw new Exception("Không tìm thấy sách để sửa");

            _sachs[index] = sach;
        }

        public Sach TimSachTheoMa(string maSach)
            => _sachs.FirstOrDefault(s => s.MaSach == maSach);

        public List<Sach> LayTatCa() => _sachs;
    }

}
