using DAL_Xuong;
using DTO_Xuong;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BUS_Xuong
{
    public class BUSKhachHang
    {
        private readonly DALKhachHang _dalKhachHang;

        // Constructor mặc định (dùng trong ứng dụng thật)
        public BUSKhachHang()
        {
            _dalKhachHang = new DALKhachHang();
        }

        // Constructor dành cho testing - nhận vào repository (có thể là fake)
        public BUSKhachHang(DALKhachHang dalKhachHang)
        {
            _dalKhachHang = dalKhachHang ?? throw new ArgumentNullException(nameof(dalKhachHang));
        }

        public List<KhachHang> GetKhachHangList()
        {
            return _dalKhachHang.selectAll();
        }

        public List<KhachHang> SearchKhachHang(string keyword)
        {
            try
            {
                return _dalKhachHang.SearchKhachHang(keyword);
            }
            catch
            {
                return new List<KhachHang>();
            }
        }

        public List<KhachHang> LoadComboKhachHang()
        {
            return _dalKhachHang.selectAll()
                .Where(kh => kh.TrangThai)
                .ToList();
        }

        public string InsertKhachHang(KhachHang kh)
        {
            try
            {
                kh.MaKhachHang = _dalKhachHang.generateMaKhachHang();
                if (string.IsNullOrEmpty(kh.MaKhachHang))
                    return "Không thể tạo mã khách hàng tự động.";

                if (_dalKhachHang.checkEmailExists(kh.Email))
                    return "Email đã tồn tại.";

                _dalKhachHang.insertKhachHang(kh);
                return string.Empty; // thành công
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }

        public string UpdateKhachHang(KhachHang kh)
        {
            try
            {
                if (string.IsNullOrEmpty(kh.MaKhachHang))
                    return "Mã khách hàng không hợp lệ.";

                _dalKhachHang.updateKhachHang(kh);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }

        public string DeleteKhachHang(string maKH)
        {
            try
            {
                if (string.IsNullOrEmpty(maKH))
                    return "Mã khách hàng không hợp lệ.";

                _dalKhachHang.deleteKhachHang(maKH);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }
    }
}