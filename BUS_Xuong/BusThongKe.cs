using DAL_Xuong.Interface;
using System.Data;

namespace BUS_Xuong
{
    public class BusThongKe
    {
        private readonly IThongKeRepository _repo;

        public BusThongKe(IThongKeRepository repo)
        {
            _repo = repo;
        }

        public DataTable HienThiSachHot()
        {
            return _repo.GetSachMuonNhieuNhat();
        }
    }
}