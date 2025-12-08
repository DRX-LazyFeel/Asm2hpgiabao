// DAL_Xuong/Interfaces/IDangNhapRepository.cs
namespace DAL_Xuong.Interfaces   // ← phải có .Interfaces
{
    public interface IDangNhapRepository
    {
        bool KiemTraDangNhap(string email, string pass);
        bool TonTaiEmail(string email);
        void LuuOtp(string email, string otp);
        string LayOtp(string email);
        void DoiMatKhau(string email, string newPass);
    }
}