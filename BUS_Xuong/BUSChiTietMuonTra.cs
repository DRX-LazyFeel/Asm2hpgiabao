using DAL_Xuong;
using DTO_Xuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_Xuong
{
    public class BUSChiTietMuonTra
    {
        DALChiTietMuonTra dalChiTiet = new DALChiTietMuonTra();
        DALSach dalSach = new DALSach();

        public List<ChiTietMuonTra> GetAllChiTiet()
        {
            return dalChiTiet.selectAll();
        } // Lấy danh sách chi tiết theo mã mượn trả
        public List<ChiTietMuonTra> GetByMaMuonTra(string maMuonTra)
        {
            return dalChiTiet.selectByMaMuonTra(maMuonTra);
        }

        // Cập nhật 1 chi tiết mượn
        public string UpdateChiTietMuon(ChiTietMuonTra ct)
        {
            try
            {
                if (string.IsNullOrEmpty(ct.MaChiTiet))
                    return "Mã chi tiết không hợp lệ.";

                dalChiTiet.updateChiTiet(ct);
                return string.Empty; // thành công
            }
            catch (Exception ex)
            {
                return "Lỗi khi cập nhật chi tiết mượn: " + ex.Message;
            }
        }

        // Xóa nhiều chi tiết mượn
        public string DeleteRange(List<string> maChiTietList)
        {
            try
            {
                if (maChiTietList == null || maChiTietList.Count == 0)
                    return "Danh sách mã chi tiết trống.";

                dalChiTiet.DeleteRange(maChiTietList);
                return string.Empty; // thành công
            }
            catch (Exception ex)
            {
                return "Lỗi khi xóa danh sách chi tiết: " + ex.Message;
            }
        }

        // Sinh mã chi tiết tự động
        public string GenerateMaChiTiet()
        {
            return dalChiTiet.generateMaChiTiet();
        }
        public string InsertRange(List<ChiTietMuonTra> lstChiTiet, string maMuonTra)
        {
            try
            {
                if (lstChiTiet == null || lstChiTiet.Count == 0)
                {
                    return "Danh sách chi tiết không hợp lệ.";
                }

                List<ChiTietMuonTra> insert = new List<ChiTietMuonTra>();
                List<ChiTietMuonTra> update = new List<ChiTietMuonTra>();
                List<string> delete = new List<string>();

                // Lấy danh sách chi tiết hiện tại từ DB theo mã mượn
                List<ChiTietMuonTra> dbList = dalChiTiet.selectByMaMuonTra(maMuonTra);

                // Tạo danh sách các mã trong dữ liệu hiện tại (form)
                var maChiTietMoi = lstChiTiet
                    .Where(ct => !string.IsNullOrEmpty(ct.MaChiTiet))
                    .Select(ct => ct.MaChiTiet)
                    .ToHashSet();

                // Xác định mã cần xóa (có trong DB nhưng không có trong lstChiTiet)
                foreach (var ctDb in dbList)
                {
                    if (!maChiTietMoi.Contains(ctDb.MaChiTiet))
                    {
                        delete.Add(ctDb.MaChiTiet);
                    }
                }

                // Sinh mã mới và phân loại insert/update
                string lastMaChiTiet = dalChiTiet.GetLastMaChiTiet();

                foreach (var ct in lstChiTiet)
                {
                    ct.MaMuonTra = maMuonTra;
                    if (string.IsNullOrEmpty(ct.MaChiTiet))
                    {
                        ct.MaChiTiet = dalChiTiet.GenerateMaChiTiet(lastMaChiTiet);
                        lastMaChiTiet = ct.MaChiTiet;
                        insert.Add(ct);
                    }
                    else
                    {
                        update.Add(ct);
                    }
                }

                if (dalChiTiet.InsertRange(insert, update, delete))
                {
                    return string.Empty;
                }
                else
                {
                    return "Lỗi khi thêm danh sách chi tiết mượn trả.";
                }
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }

        }
        public List<ChiTietMuonTra> GetChiTietByMaMuonTra(string maMuonTra)
        {
            return dalChiTiet.selectByMaMuonTra(maMuonTra);
        }

        public List<Sach> LoadBangSach()
        {
            return dalSach.LayDSSach(); // Hoặc lọc sách còn tồn nếu cần
        }
        public bool XoaNhieuChiTiet(List<string> dsMaChiTiet)
        {
            return dalChiTiet.DeleteRange(dsMaChiTiet);
        }

        public string InsertChiTiet(ChiTietMuonTra ct)
        {
            try
            {
                ct.MaChiTiet = dalChiTiet.generateMaChiTiet();
                if (string.IsNullOrEmpty(ct.MaChiTiet))
                    return "Mã chi tiết không hợp lệ.";

                dalChiTiet.insertChiTietMuonTra(ct);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi khi thêm chi tiết mượn: " + ex.Message;
            }
        }

        public string UpdateChiTiet(ChiTietMuonTra ct)
        {
            try
            {
                if (string.IsNullOrEmpty(ct.MaChiTiet))
                    return "Mã chi tiết không hợp lệ.";

                dalChiTiet.updateChiTiet(ct);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi khi cập nhật chi tiết mượn: " + ex.Message;
            }
        }

        public string DeleteChiTiet(string maChiTiet)
        {
            try
            {
                if (string.IsNullOrEmpty(maChiTiet))
                    return "Mã chi tiết không hợp lệ.";

                dalChiTiet.deleteChiTiet(maChiTiet);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi khi xóa chi tiết mượn: " + ex.Message;
            }
        }
    }

}
