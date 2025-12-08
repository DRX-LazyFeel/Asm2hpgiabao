using DAL_Xuong.Interface;
using DTO_Xuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.Tests.TestDoubles
{
    public class FakeNhanVienRepository : INhanVienRepository
    {
        private readonly List<NhanVien> _nhanViens = new();

        public void ThemNhanVien(NhanVien nv)
        {
            if (string.IsNullOrWhiteSpace(nv.MaNhanVien) || string.IsNullOrWhiteSpace(nv.Ten))
                throw new Exception("Thiếu thông tin bắt buộc");

            if (!nv.Email.Contains("@") || !nv.Email.Contains("."))
                throw new Exception("Email không hợp lệ");

            if (_nhanViens.Any(x => x.Email == nv.Email))
                throw new Exception("Email đã tồn tại");

            if (string.IsNullOrWhiteSpace(nv.MatKhau))
                throw new Exception("Mật khẩu không được để trống");

            _nhanViens.Add(nv);
        }

        public void SuaNhanVien(NhanVien nv)
        {
            var index = _nhanViens.FindIndex(x => x.MaNhanVien == nv.MaNhanVien);
            if (index < 0) throw new Exception("Không tìm thấy nhân viên");
            _nhanViens[index] = nv;
        }

        public void XoaNhanVien(string maNV)
        {
            var nv = _nhanViens.FirstOrDefault(x => x.MaNhanVien == maNV);
            if (nv == null) throw new Exception("Không tìm thấy nhân viên");
            _nhanViens.Remove(nv);
        }

        public NhanVien TimNhanVienTheoMa(string maNV) => _nhanViens.FirstOrDefault(x => x.MaNhanVien == maNV);
        public List<NhanVien> LayTatCa() => _nhanViens;
    }

}
