using DTO_Xuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Xuong.Interface
{
    public class FakePhiSachRepository : IPhiSachRepository
    {
        private readonly List<PhiSach> _phiSachs = new();

        public void ThemPhiSach(PhiSach ps)
        {
            if (string.IsNullOrWhiteSpace(ps.MaPhiSach) || string.IsNullOrWhiteSpace(ps.MaSach))
                throw new Exception("Vui lòng nhập đầy đủ thông tin");

            if (_phiSachs.Any(p => p.MaPhiSach == ps.MaPhiSach))
                throw new Exception("Mã phí sách đã tồn tại");

            _phiSachs.Add(ps);
        }

        public void SuaPhiSach(PhiSach ps)
        {
            var index = _phiSachs.FindIndex(p => p.MaPhiSach == ps.MaPhiSach);
            if (index < 0)
                throw new Exception("Không tìm thấy phí sách để sửa");

            _phiSachs[index] = ps;
        }

        public void XoaPhiSach(string maPhiSach)
        {
            if (string.IsNullOrWhiteSpace(maPhiSach))
                throw new Exception("Vui lòng chọn phí sách cần xóa");

            var ps = _phiSachs.FirstOrDefault(p => p.MaPhiSach == maPhiSach);
            if (ps == null)
                throw new Exception("Không tìm thấy phí sách");

            if (ps.DangApDung)
                throw new Exception("Không thể xóa phí sách đang được áp dụng");

            _phiSachs.Remove(ps);
        }

        public PhiSach TimPhiSachTheoMa(string maPhiSach)
            => _phiSachs.FirstOrDefault(p => p.MaPhiSach == maPhiSach);

        public List<PhiSach> LayTatCa() => _phiSachs;
    }

}
