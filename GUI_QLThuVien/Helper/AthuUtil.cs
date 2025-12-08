using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Xuong;

namespace GUI_QLThuVien.Helper
{
    public class AuthUtil
    {
        public static NhanVien user { get; set; } = new NhanVien { MaNhanVien = "", VaiTro = false };

        public static bool IsLogin()
        {
            return user != null && !string.IsNullOrWhiteSpace(user.MaNhanVien);
        }

    }
}
