using DAL_Xuong.Interface;
using DTO_Xuong;
using System;
using System.Collections.Generic;

namespace BUS_Xuong
{
    public class BUSMuonTraSach
    {
        // Khai báo Interface chuẩn
        private readonly IMuonTraRepository _repo;

        // Constructor nhận Interface (Để tí nữa truyền Fake vào đây)
        public BUSMuonTraSach(IMuonTraRepository repo)
        {
            _repo = repo;
        }

        // Đã sửa: Dùng class MuonTra
        public bool ChoMuonSach(MuonTra mt)
        {
            // Logic kiểm tra nghiệp vụ
            if (string.IsNullOrEmpty(mt.MaKhachHang))
            {
                // Tùy code bạn xử lý lỗi thế nào, có thể return false hoặc throw
                return false;
            }

            return _repo.ThemMuonTra(mt);
        }
    }
}