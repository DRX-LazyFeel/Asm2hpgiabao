using DTO_Xuong;
using System.Collections.Generic;

namespace DAL_Xuong.Interface
{
    public interface ITrangThaiThanhToanRepository
    {
        List<TrangThaiThanhToan> GetAll();
        bool Insert(TrangThaiThanhToan t);
        bool Update(TrangThaiThanhToan t);
        bool Delete(string ma);
        string GetNextMa();
    }
}