// DAL_Xuong/DangNhapRepository.cs
using DAL_Xuong.Interfaces;

namespace DAL_Xuong
{
    public class DangNhapRepository : IDangNhapRepository
    {
        // Sau này sẽ thay bằng EF hoặc ADO.NET
        // Giờ tạm throw để compile được
        public bool KiemTraDangNhap(string email, string pass)
            => throw new NotImplementedException("Sẽ làm kết nối DB sau");

        public bool TonTaiEmail(string email)
            => throw new NotImplementedException();

        public void LuuOtp(string email, string otp)
            => throw new NotImplementedException();

        public string LayOtp(string email)
            => throw new NotImplementedException();

        public void DoiMatKhau(string email, string newPass)
            => throw new NotImplementedException();
    }
}