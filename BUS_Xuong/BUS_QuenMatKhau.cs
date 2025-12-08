// BUS_Xuong/BUS_QuenMatKhau.cs
using DAL_Xuong.Interfaces;

namespace BUS_Xuong
{
    public class BUS_QuenMatKhau
    {
        private readonly IDangNhapRepository _repo;
        public BUS_QuenMatKhau(IDangNhapRepository repo) => _repo = repo;

        public bool KiemTraEmail(string email) => _repo.TonTaiEmail(email.Trim());

        public void GuiMaOtp(string email)
        {
            if (!KiemTraEmail(email)) return;
            string otp = new Random().Next(100000, 999999).ToString("D6");
            _repo.LuuOtp(email.Trim(), otp);
        }

        public bool KiemTraOtp(string email, string otp)
            => _repo.LayOtp(email.Trim()) == otp;

        public bool DoiMatKhau(string email, string newPass)
        {
            if (string.IsNullOrWhiteSpace(newPass) || !KiemTraEmail(email)) return false;
            _repo.DoiMatKhau(email.Trim(), newPass);
            return true;
        }
    }
}