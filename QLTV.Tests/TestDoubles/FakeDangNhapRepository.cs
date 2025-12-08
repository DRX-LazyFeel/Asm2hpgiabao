// QLTV.Tests/TestDoubles/FakeDangNhapRepository.cs
using DAL_Xuong.Interfaces;
using System.Collections.Generic;

namespace QLTV.Tests.TestDoubles
{
    public class FakeDangNhapRepository : IDangNhapRepository
    {
        private readonly Dictionary<string, string> _users = new()
        {
            { "admin@gmail.com", "123456" },
            { "user@gmail.com", "abc123" }
        };
        private readonly Dictionary<string, string> _otps = new();

        public bool KiemTraDangNhap(string email, string pass)
            => _users.TryGetValue(email.Trim(), out var p) && p == pass.Trim();

        public bool TonTaiEmail(string email)
            => _users.ContainsKey(email.Trim());

        public void LuuOtp(string email, string otp)
            => _otps[email.Trim()] = otp;

        public string LayOtp(string email)
            => _otps.TryGetValue(email.Trim(), out var o) ? o : null;

        public void DoiMatKhau(string email, string newPass)
        {
            email = email.Trim();
            if (_users.ContainsKey(email))
                _users[email] = newPass;
        }

        // 2 hàm helper để test dễ lấy giá trị
        public string GetOtp(string email) => LayOtp(email);
        public bool IsValid(string email, string pass) => KiemTraDangNhap(email, pass);
    }
}