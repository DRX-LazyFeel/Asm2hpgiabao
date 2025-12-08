using DAL_Xuong.Interface;
using DTO_Xuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.Tests.TestDoubles
{
    public class FakeTacGiaRepository : ITacGiaRepository
    {
        private readonly List<TacGia> _tacGias = new();

        public void ThemTacGia(TacGia tg)
        {
            if (string.IsNullOrWhiteSpace(tg.MaTacGia) || string.IsNullOrWhiteSpace(tg.TenTacGia))
                throw new Exception("Thông tin bắt buộc không được để trống");

            if (_tacGias.Any(t => t.MaTacGia == tg.MaTacGia))
                throw new Exception("Mã tác giả đã tồn tại");

            _tacGias.Add(tg);
        }

        public void SuaTacGia(TacGia tg)
        {
            var index = _tacGias.FindIndex(t => t.MaTacGia == tg.MaTacGia);
            if (index < 0)
                throw new Exception("Không tìm thấy tác giả để sửa");

            _tacGias[index] = tg;
        }

        public void XoaTacGia(string maTacGia)
        {
            if (string.IsNullOrWhiteSpace(maTacGia))
                throw new Exception("Chưa chọn tác giả để xóa");

            var tg = _tacGias.FirstOrDefault(t => t.MaTacGia == maTacGia);
            if (tg == null)
                throw new Exception("Không tìm thấy tác giả");

            if (tg.CoSachLienKet)
                throw new Exception("Không thể xóa vì đang có sách liên kết");

            _tacGias.Remove(tg);
        }

        public TacGia TimTacGiaTheoMa(string maTacGia)
            => _tacGias.FirstOrDefault(t => t.MaTacGia == maTacGia);

        public List<TacGia> LayTatCa() => _tacGias;
    }

}
