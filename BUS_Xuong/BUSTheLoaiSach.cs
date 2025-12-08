using DAL_Xuong;
using DTO_Xuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_Xuong
{
    public class BUSTheLoaiSach
    {
        private DALTheLoaiSach dalTheLoaiSach = new DALTheLoaiSach();
        public List<TheLoaiSach> GetAllTheLoaiSach()
        {
            return dalTheLoaiSach.LayDSTheLoaiSach();
        }
        public string InsertTheLoaiSach(TheLoaiSach s)
        {
            try
            {
                s.MaTheLoai = dalTheLoaiSach.generateMaTheLoaiSach();
                if (string.IsNullOrEmpty(s.MaTheLoai))
                {
                    return "Mã thể loại không hợp lệ.";
                }
                dalTheLoaiSach.ThemTheLoaiSach(s);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi khi thêm thể loại sách: " + ex.Message;
            }
        }
        public string GenerateMaTheLoaiSach()
        {
            try
            {
                string newMaTheLoai = dalTheLoaiSach.generateMaTheLoaiSach();
                return newMaTheLoai;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tạo mã thể loại sách: " + ex.Message);
            }
        }
        public string UpdateTheLoaiSach(TheLoaiSach s)
        {
            try
            {
                if (string.IsNullOrEmpty(s.MaTheLoai))
                {
                    return "Mã thể loại không hợp lệ.";
                }
                dalTheLoaiSach.CapNhatTheLoaiSach(s);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi khi cập nhật thể loại sách: " + ex.Message;
            }
        }
        public string DeleteTheLoaiSach(string maTheLoai)
        {
            try
            {
                if (string.IsNullOrEmpty(maTheLoai))
                {
                    return "Mã thể loại không hợp lệ.";
                }
                dalTheLoaiSach.XoaTheLoaiSach(maTheLoai);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi khi xóa thể loại sách: " + ex.Message;
            }
        }
    }
    
}
