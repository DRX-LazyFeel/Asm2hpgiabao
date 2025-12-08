// BUS_Xuong/BUS_DangNhap.cs
using DAL_Xuong.Interfaces;

namespace BUS_Xuong
{
    public class BUS_DangNhap
    {
        private readonly IDangNhapRepository _repo;
        public BUS_DangNhap(IDangNhapRepository repo) => _repo = repo;

        public bool DangNhap(string email, string pass)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(pass)) return false;
            return _repo.KiemTraDangNhap(email.Trim(), pass.Trim());
        }
    }
}