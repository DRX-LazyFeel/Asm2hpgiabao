using DAL_Xuong.Interfaces;
using DTO_Xuong;
using System;
using System.Collections.Generic;
using static DTO_Xuong.ThongKe;

namespace BUS_Xuong
{
    public class BUSThongKe
    {
        private readonly IThongKeRepository _repo;

        public BUSThongKe(IThongKeRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public List<ThongKeDTO> GetThongKe(string maNV = "ALL")
        {
            return _repo.GetThongKe(maNV);
        }
    }
}