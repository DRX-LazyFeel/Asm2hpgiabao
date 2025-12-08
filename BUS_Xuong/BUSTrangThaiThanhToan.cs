using DAL_Xuong.Interface; // Nhớ using Interface
using DTO_Xuong;
using System.Collections.Generic;

namespace BUS_Xuong
{
    public class BUSTrangThaiThanhToan
    {
        // Khai báo Interface
        private readonly ITrangThaiThanhToanRepository _repo;

        // Constructor nhận Interface (Dependency Injection)
        public BUSTrangThaiThanhToan(ITrangThaiThanhToanRepository repo)
        {
            _repo = repo;
        }

        public string GetNextMaSach() => _repo.GetNextMa();
        public List<TrangThaiThanhToan> GetAll() => _repo.GetAll();
        public bool Insert(TrangThaiThanhToan t) => _repo.Insert(t);
        public bool Update(TrangThaiThanhToan t) => _repo.Update(t);
        public bool Delete(string ma) => _repo.Delete(ma);
    }
}