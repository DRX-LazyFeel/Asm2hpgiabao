using DAL_PolyCafe;
using DTO_Xuong;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Xuong
{
    public class DALMuonTraSach
    {
        public List<MuonTra> SelectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<MuonTra> list = new List<MuonTra>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    MuonTra entity = new MuonTra();
                    entity.MaMuonTra = reader.GetString("MaMuonTra");
                    entity.MaKhachHang = reader.GetString("MaKhachHang");
                    entity.MaNhanVien = reader.GetString("MaNhanVien");
                    entity.NgayMuon = reader.GetDateTime("NgayMuon");
                    entity.NgayTra = reader.GetDateTime("NgayTra");
                    entity.MaTrangThai = reader.GetString("MaTrangThai");
                    entity.NgayTao = reader.GetDateTime("NgayTao");
                    list.Add(entity);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }
        public string GenerateMuonTra()
        {
            using (SqlConnection conn = DBUtil.GetConnection())
            {
                conn.Open();
                string query = "SELECT TOP 1 MaMuonTra FROM MuonTraSach ORDER BY MaMuonTra DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        string lastMa = result.ToString(); // VD: MT00012
                        int number = int.Parse(lastMa.Substring(2)); // Lấy phần số
                        string newMa = "MT" + (number + 1).ToString("D5"); // Format: D5 = 5 chữ số
                        return newMa;
                    }
                    else
                    {
                        return "MT00001"; // Nếu chưa có dữ liệu
                    }
                }
            }
        }

        public List<MuonTra> selectAll()
        {
            List<MuonTra> list = new List<MuonTra>();
            string sql = @"
        SELECT 
            mt.MaMuonTra,
            mt.MaKhachHang,
            kh.TenKhachHang,
            mt.MaNhanVien,
            nv.Ten AS TenNhanVien,
            mt.NgayMuon,
            mt.NgayTra,
            mt.MaTrangThai,
            mt.NgayTao
        FROM MuonTraSach mt
        JOIN KhachHang kh ON mt.MaKhachHang = kh.MaKhachHang
        JOIN NhanVien nv ON mt.MaNhanVien = nv.MaNhanVien";

            try
            {
                SqlDataReader reader = DBUtil.Query(sql, new List<object>());
                while (reader.Read())
                {
                    MuonTra mt = new MuonTra
                    {
                        MaMuonTra = reader["MaMuonTra"].ToString(),
                        MaKhachHang = reader["MaKhachHang"].ToString(),
                        TenKhachHang = reader["TenKhachHang"].ToString(),
                        MaNhanVien = reader["MaNhanVien"].ToString(),
                        TenNhanVien = reader["TenNhanVien"].ToString(),
                        NgayMuon = Convert.ToDateTime(reader["NgayMuon"]),
                        NgayTra = Convert.ToDateTime(reader["NgayTra"]),
                        MaTrangThai = reader["MaTrangThai"].ToString(),
                        NgayTao = Convert.ToDateTime(reader["NgayTao"])
                    };
                    list.Add(mt);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách mượn trả: " + ex.Message);
            }

            return list;
        }

        public List<MuonTra> SearchMuonTra(string keyword)
        {
            string sql = "SELECT * FROM MuonTraSach WHERE MaKhachHang LIKE " + $"N'%{keyword}%' COLLATE Latin1_General_CI_AI" + " OR MaMuonTra LIKE " + $"N'%{keyword}%' COLLATE Latin1_General_CI_AI";
            // + " OR Email LIKE "+ $"N'%{keyword}%' COLLATE Latin1_General_CI_AI";
            List<object> thamSo = new List<object>();
            return SelectBySql(sql, thamSo);
        }


        public List<MuonTra> selectById(string id)
        {
            String sql = "SELECT * FROM MuonTraSach WHERE MaMuonTra=@0";
            List<object> thamSo = new List<object>();
            thamSo.Add(id);
            List<MuonTra> list = SelectBySql(sql, thamSo);
            return list ;
        }

        public void insertMuonTra(MuonTra mt)
        {
            try
            {
                string sql = @"INSERT INTO MuonTraSach (MaMuonTra, MaKhachHang, MaNhanVien, NgayMuon, NgayTra, MaTrangThai) 
                   VALUES (@0, @1, @2, @3, @4, @5)";
                List<object> thamSo = new List<object>();
                thamSo.Add(mt.MaMuonTra);
                thamSo.Add(mt.MaKhachHang);
                thamSo.Add(mt.MaNhanVien);
                thamSo.Add(mt.NgayMuon);
                thamSo.Add(mt.NgayTra);
                thamSo.Add(mt.MaTrangThai);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public string insertMuonTraReturn(MuonTra mt)
        {
            try
            {
                string sql = @"INSERT INTO MuonTraSach (MaMuonTra, MaKhachHang, MaNhanVien, NgayMuon, NgayTra, MaTrangThai) 
                   OUTPUT INSERTED.MaMuonTra VALUES (@0, @1, @2, @3, @4, @5)";
                List<object> thamSo = new List<object>();
                thamSo.Add(mt.MaMuonTra);
                thamSo.Add(mt.MaKhachHang);
                thamSo.Add(mt.MaNhanVien);
                thamSo.Add(mt.NgayMuon);
                thamSo.Add(mt.NgayTra);
                thamSo.Add(mt.MaTrangThai);
                return (string)DBUtil.ScalarQuery(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public void updateMuonTra(MuonTra mt)
        {
            try
            {
                string sql = @"UPDATE MuonTraSach 
                   SET MaKhachHang = @1, MaNhanVien = @2, NgayMuon = @3, NgayTra = @4, MaTrangThai = @5 
                   WHERE MaMuonTra = @0";
                List<object> thamSo = new List<object>();
                thamSo.Add(mt.MaMuonTra);
                thamSo.Add(mt.MaKhachHang);
                thamSo.Add(mt.MaNhanVien);
                thamSo.Add(mt.NgayMuon);
                thamSo.Add(mt.NgayTra);
                thamSo.Add(mt.MaTrangThai);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }

        }
    //    public bool InsertRange(List<ChiTietMuonTra> list, List<ChiTietMuonTra> listUpdate, List<string> listDelete)
    //    {
    //        string insertSql = @"
    //INSERT INTO ChiTietMuonSach (
    //MaChiTiet, MaMuonTra, MaSach, SoLuong, TrangThai
    //) VALUES (@0, @1, @2, @3, @4)";

    //        string updateSql = @"
    //UPDATE ChiTietMuonSach
    //SET 
    //MaMuonTra = @1,
    //MaSach = @2,
    //SoLuong = @3,
    //TrangThai = @4 
    //WHERE MaChiTiet = @0";

    //        using (SqlConnection conn = new SqlConnection(DBUtil.connString))
    //        {
    //            conn.Open();
    //            using (SqlTransaction trans = conn.BeginTransaction())
    //            {
    //                try
    //                {
    //                    // 1. DELETE
    //                    if (list != null && listDelete.Count > 0)
    //                    {
    //                        foreach (var ma in listDelete)
    //                        {
    //                            string deleteSql = "DELETE FROM ChiTietMuonSach WHERE MaChiTiet = @0";
    //                            using (SqlCommand cmd = new SqlCommand(deleteSql, conn, trans))
    //                            {
    //                                cmd.Parameters.AddWithValue("@0", ma);
    //                                cmd.ExecuteNonQuery();
    //                            }
    //                        }
    //                    }

    //                    // 2. INSERT
    //                    if (list != null && list.Count > 0)
    //                    {
    //                        foreach (var ct in list)
    //                        {
    //                            using (SqlCommand cmd = new SqlCommand(insertSql, conn, trans))
    //                            {
    //                                cmd.Parameters.AddWithValue("@0", ct.MaChiTiet);
    //                                cmd.Parameters.AddWithValue("@1", ct.MaMuonTra);
    //                                cmd.Parameters.AddWithValue("@2", ct.MaSach);
    //                                cmd.Parameters.AddWithValue("@3", ct.SoLuong);
    //                                cmd.Parameters.AddWithValue("@4", ct.TrangThai);
    //                                cmd.Parameters.AddWithValue("@5", (object?)ct.PhiMuon ?? DBNull.Value);
    //                                cmd.Parameters.AddWithValue("@6", (object?)ct.PhiPhat ?? DBNull.Value);
    //                                cmd.ExecuteNonQuery();
    //                            }
    //                        }
    //                    }

    //                    // 3. UPDATE
    //                    if (listUpdate != null && listUpdate.Count > 0)
    //                    {
    //                        foreach (var ct in listUpdate)
    //                        {
    //                            using (SqlCommand cmd = new SqlCommand(updateSql, conn, trans))
    //                            {
    //                                cmd.Parameters.AddWithValue("@0", ct.MaChiTiet);
    //                                cmd.Parameters.AddWithValue("@1", ct.MaMuonTra);
    //                                cmd.Parameters.AddWithValue("@2", ct.MaSach);
    //                                cmd.Parameters.AddWithValue("@3", ct.SoLuong);
    //                                cmd.Parameters.AddWithValue("@4", ct.TrangThai);
    //                                cmd.Parameters.AddWithValue("@5", (object?)ct.PhiMuon ?? DBNull.Value);
    //                                cmd.Parameters.AddWithValue("@6", (object?)ct.PhiPhat ?? DBNull.Value);
    //                                cmd.ExecuteNonQuery();
    //                            }
    //                        }
    //                    }

    //                    trans.Commit();
    //                    return true;
    //                }
    //                catch
    //                {
    //                    trans.Rollback();
    //                    throw;
    //                }
    //            }
    //        }

    //    }
    //    public string GenerateMaChiTiet()
    //    {
    //        string prefix = "CT";
    //        string sql = "SELECT MAX(MaChiTiet) FROM ChiTietMuonSach";
    //        object result = DBUtil.ScalarQuery(sql, new List<object>());

    //        if (result != null && result.ToString().StartsWith(prefix))
    //        {
    //            string maxCode = result.ToString().Substring(prefix.Length);
    //            if (int.TryParse(maxCode, out int number))
    //            {
    //                return $"{prefix}{(number + 1):D3}";
    //            }
    //        }

    //        return $"{prefix}001";
    //    }

    //    public string GetLastMaChiTiet()
    //    {
    //        string prefix = "CT";
    //        string sql = "SELECT MAX(MaChiTiet) FROM ChiTietMuonSach";
    //        object result = DBUtil.ScalarQuery(sql, new List<object>());
    //        if (result != null && result.ToString().StartsWith(prefix))
    //        {
    //            return result.ToString();
    //        }
    //        return $"{prefix}000";
    //    }

    //    public string GenerateMaChiTiet(string start)
    //    {
    //        string prefix = "CT";
    //        if (start != null && start.ToString().StartsWith(prefix))
    //        {
    //            string maxCode = start.ToString().Substring(prefix.Length);
    //            if (int.TryParse(maxCode, out int number))
    //            {
    //                return $"{prefix}{(number + 1):D3}";
    //            }
    //        }

    //        return $"{prefix}001";
    //    }

        public void deleteMuonTra(string maMuonTra)
        {
            try
            {
                string sql = "UPDATE MuonTraSach SET MaTrangThai = 'TT002' WHERE MaMuonTra = @0";
                List<object> thamSo = new List<object>();
                thamSo.Add(maMuonTra);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public string generateMuonTra()
        {
            string prefix = "MT";
            string sql = "SELECT MAX(MaMuonTra) FROM MuonTraSach";
            List<object> thamSo = new List<object>();
            object result = DBUtil.ScalarQuery(sql, thamSo);
            if (result != null && result.ToString().StartsWith(prefix))
            {
                string maxCode = result.ToString().Substring(2);
                int newNumber = int.Parse(maxCode) + 1;
                return $"{prefix}{newNumber:D3}";
            }

            return $"{prefix}001";
        }

    }
}
