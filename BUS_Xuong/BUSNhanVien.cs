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
    public class BUSNhanVien
    {
        private readonly INhanVienRepository _nhanVienRepo;

        public BUSNhanVien(INhanVienRepository nhanVienRepo)
        {
            _nhanVienRepo = nhanVienRepo ?? throw new ArgumentNullException(nameof(nhanVienRepo));
        }

        /// <summary>
        /// Lấy toàn bộ danh sách nhân viên
        /// </summary>
        public List<NhanVien> GetAllNhanVien()
        {
            return _nhanVienRepo.LayTatCa();
        }

        /// <summary>
        /// Thêm nhân viên mới
        /// </summary>
        public bool InsertNhanVien(NhanVien nv)
        {
            if (nv == null || string.IsNullOrWhiteSpace(nv.MaNhanVien) || string.IsNullOrWhiteSpace(nv.Ten))
                return false;

            if (string.IsNullOrWhiteSpace(nv.Email) || !nv.Email.Contains("@") || !nv.Email.Contains("."))
                return false;

            if (string.IsNullOrWhiteSpace(nv.MatKhau))
                return false;

            try
            {
                _nhanVienRepo.ThemNhanVien(nv);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Cập nhật thông tin nhân viên
        /// </summary>
        public bool UpdateNhanVien(NhanVien nv)
        {
            if (nv == null || string.IsNullOrWhiteSpace(nv.MaNhanVien))
                return false;

            try
            {
                _nhanVienRepo.SuaNhanVien(nv);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Xóa nhân viên theo mã
        /// </summary>
        public bool DeleteNhanVien(string maNV)
        {
            if (string.IsNullOrWhiteSpace(maNV))
                return false;

            try
            {
                _nhanVienRepo.XoaNhanVien(maNV);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Tìm nhân viên theo mã
        /// </summary>
        public NhanVien FindByMa(string maNV)
        {
            if (string.IsNullOrWhiteSpace(maNV))
                return null;

            return _nhanVienRepo.TimNhanVienTheoMa(maNV);
        }
    }


}
