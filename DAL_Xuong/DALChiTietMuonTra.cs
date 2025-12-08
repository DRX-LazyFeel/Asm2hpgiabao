using DAL_PolyCafe;
using DTO_Xuong;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace DAL_Xuong
{
    public class DALChiTietMuonTra
    {
        public List<ChiTietMuonTra> SelectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<ChiTietMuonTra> list = new List<ChiTietMuonTra>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args, cmdType);
                while (reader.Read())
                {
                    ChiTietMuonTra ct = new ChiTietMuonTra();
                    ct.MaChiTiet = reader["MaChiTiet"].ToString();
                    ct.MaMuonTra = reader["MaMuonTra"].ToString();
                    ct.MaSach = reader["MaSach"].ToString();
                    ct.TenSach = reader["TieuDe"].ToString(); // ✅ lấy từ JOIN bảng Sach
                    ct.SoLuong = Convert.ToInt32(reader["SoLuong"]);
                    ct.NgayTao = Convert.ToDateTime(reader["NgayTao"]);
                    ct.TrangThai = Convert.ToBoolean(reader["TrangThai"]);
                    list.Add(ct);
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }


        public List<ChiTietMuonTra> selectAll()
        {
            string sql = @"SELECT 
                        ct.MaChiTiet,
                        ct.MaMuonTra,
                        ct.MaSach,
                        s.TieuDe,
                        ct.SoLuong,
                        ct.NgayTao,
                        ct.TrangThai
                    FROM ChiTietMuonSach ct
                    JOIN Sach s ON ct.MaSach = s.MaSach";
            return SelectBySql(sql, new List<object>());
        }

        public List<ChiTietMuonTra> selectByMaMuonTra(string maMuonTra)
        {
            string sql = @"SELECT 
                        ct.MaChiTiet,
                        ct.MaMuonTra,
                        ct.MaSach,
                        s.TieuDe,
                        ct.SoLuong,
                        ct.NgayTao,
                        ct.TrangThai
                    FROM ChiTietMuonSach ct
                    JOIN Sach s ON ct.MaSach = s.MaSach WHERE MaMuonTra = @0";
            List<object> args = new List<object> { maMuonTra };
            return SelectBySql(sql, args);
        }

        //public List<ChiTietMuonTra> selectByMaChiTiet(string maChiTiet)
        //{
        //    string sql = @"SELECT 
        //                ct.MaChiTiet,
        //                ct.MaMuonTra,
        //                ct.MaSach,
        //                s.TieuDe,
        //                ct.SoLuong,
        //                ct.NgayTao,
        //                ct.TrangThai
        //            FROM ChiTietMuonSach ct
        //            JOIN Sach s ON ct.MaSach = s.MaSach WHERE MaChiTiet = @0";
        //    List<object> args = new List<object> { maChiTiet };
        //    return SelectBySql(sql, args);
        //}

        public void insertChiTietMuonTra(ChiTietMuonTra ct)
        {
            string sql = @"INSERT INTO ChiTietMuonSach (MaChiTiet, MaMuonTra, MaSach, SoLuong, NgayTao, TrangThai) 
                       VALUES (@0, @1, @2, @3, @4, @5)";
            List<object> args = new List<object>
        {
            ct.MaChiTiet,
            ct.MaMuonTra,
            ct.MaSach,
            ct.SoLuong,
            ct.NgayTao,
            ct.TrangThai
        };
            DBUtil.Update(sql, args);
        }
        public bool DeleteRange(List<string> listMaChiTiet)
        {
            using (SqlConnection conn = DBUtil.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    foreach (string maChiTiet in listMaChiTiet)
                    {
                        string sql = "DELETE FROM ChiTietMuonSach WHERE MaChiTiet = @MaChiTiet";

                        using (SqlCommand cmd = new SqlCommand(sql, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@MaChiTiet", maChiTiet);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    trans.Commit();
                    return true;
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }
        //public bool InsertRange(List<ChiTietMuonTra> dsInsert , List<ChiTietMuonTra> dsUpdate)
        //{
        //    using (SqlConnection conn = DBUtil.GetConnection())
        //    {
        //        conn.Open();
        //        SqlTransaction tran = conn.BeginTransaction();

        //        try
        //        {
        //            if (dsInsert != null && dsInsert.Count > 0) {
        //                foreach (var ct in dsInsert)
        //                {
        //                    string sql = @"INSERT INTO ChiTietMuonSach 
        //                           (MaChiTiet, MaMuonTra, MaSach, SoLuong, TrangThai)
        //                           VALUES (@MaChiTiet, @MaMuonTra, @MaSach, @SoLuong, @TrangThai)";

        //                    SqlCommand cmd = new SqlCommand(sql, conn, tran);
        //                    cmd.Parameters.AddWithValue("@MaChiTiet", ct.MaChiTiet);
        //                    cmd.Parameters.AddWithValue("@MaMuonTra", ct.MaMuonTra);
        //                    cmd.Parameters.AddWithValue("@MaSach", ct.MaSach);
        //                    cmd.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
        //                    cmd.Parameters.AddWithValue("@TrangThai", ct.TrangThai);

        //                    cmd.ExecuteNonQuery();
        //                }

        //            }

        //            if (dsUpdate != null && dsUpdate.Count > 0)
        //            {
        //                foreach (ChiTietMuonTra ct in dsUpdate)
        //                {
        //                    string sql = @"
        //                        UPDATE ChiTietMuonTraSach SET
        //                            SoLuong = @SoLuong,
        //                            TrangThaiTra = @TrangThaiTra 
        //                        WHERE MaChiTiet = @MaChiTiet";

        //                    using (SqlCommand cmd = new SqlCommand(sql, conn, tran))
        //                    {
        //                        cmd.Parameters.AddWithValue("@MaChiTiet", ct.MaChiTiet);
        //                        cmd.Parameters.AddWithValue("@MaMuonTra", ct.MaMuonTra);
        //                        cmd.Parameters.AddWithValue("@MaSach", ct.MaSach);
        //                        cmd.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
        //                        cmd.Parameters.AddWithValue("@TrangThai", ct.TrangThai);

        //                        cmd.ExecuteNonQuery();
        //                    }
        //                }

        //            }
        //            tran.Commit();
        //            return true;
        //        }
        //        catch
        //        {
        //            tran.Rollback();
        //            return false;
        //        }
        //    }
        //}
        public bool InsertRange(List<ChiTietMuonTra> list, List<ChiTietMuonTra> listUpdate, List<string> listDelete)
        {
            string insertSql = @"
    INSERT INTO ChiTietMuonSach (
    MaChiTiet, MaMuonTra, MaSach, SoLuong, TrangThai
    ) VALUES (@0, @1, @2, @3, @4)";

            string updateSql = @"
    UPDATE ChiTietMuonSach
    SET 
    MaMuonTra = @1,
    MaSach = @2,
    SoLuong = @3,
    TrangThai = @4 
    WHERE MaChiTiet = @0";

            using (SqlConnection conn = new SqlConnection(DBUtil.connString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. DELETE
                        if (list != null && listDelete.Count > 0)
                        {
                            foreach (var ma in listDelete)
                            {
                                string deleteSql = "DELETE FROM ChiTietMuonSach WHERE MaChiTiet = @0";
                                using (SqlCommand cmd = new SqlCommand(deleteSql, conn, trans))
                                {
                                    cmd.Parameters.AddWithValue("@0", ma);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        // 2. INSERT
                        if (list != null && list.Count > 0)
                        {
                            foreach (var ct in list)
                            {
                                using (SqlCommand cmd = new SqlCommand(insertSql, conn, trans))
                                {
                                    cmd.Parameters.AddWithValue("@0", ct.MaChiTiet);
                                    cmd.Parameters.AddWithValue("@1", ct.MaMuonTra);
                                    cmd.Parameters.AddWithValue("@2", ct.MaSach);
                                    cmd.Parameters.AddWithValue("@3", ct.SoLuong);
                                    cmd.Parameters.AddWithValue("@4", ct.TrangThai);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        // 3. UPDATE
                        if (listUpdate != null && listUpdate.Count > 0)
                        {
                            foreach (var ct in listUpdate)
                            {
                                using (SqlCommand cmd = new SqlCommand(updateSql, conn, trans))
                                {
                                    cmd.Parameters.AddWithValue("@0", ct.MaChiTiet);
                                    cmd.Parameters.AddWithValue("@1", ct.MaMuonTra);
                                    cmd.Parameters.AddWithValue("@2", ct.MaSach);
                                    cmd.Parameters.AddWithValue("@3", ct.SoLuong);
                                    cmd.Parameters.AddWithValue("@4", ct.TrangThai);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        trans.Commit();
                        return true;
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }

        }
       
        //public string GenerateMaChiTiet()
        //{
        //    string prefix = "CT";
        //    string sql = "SELECT MAX(MaChiTiet) FROM ChiTietMuonSach";
        //    object result = DBUtil.ScalarQuery(sql, new List<object>());

        //    if (result != null && result.ToString().StartsWith(prefix))
        //    {
        //        string maxCode = result.ToString().Substring(prefix.Length);
        //        if (int.TryParse(maxCode, out int number))
        //        {
        //            return $"{prefix}{(number + 1):D3}";
        //        }
        //    }

        //    return $"{prefix}001";
        //}
          
        public void updateChiTiet(ChiTietMuonTra ct)
        {
            string sql = @"UPDATE ChiTietMuonSach 
                       SET MaMuonTra = @1, MaSach = @2, SoLuong = @3, NgayTao = @4, TrangThai = @5 
                       WHERE MaChiTiet = @0";
            List<object> args = new List<object>
        {
            ct.MaChiTiet,
            ct.MaMuonTra,
            ct.MaSach,
            ct.SoLuong,
            ct.NgayTao,
            ct.TrangThai
        };
            DBUtil.Update(sql, args);
        }

        public void deleteChiTiet(string maChiTiet)
        {
            string sql = "DELETE FROM ChiTietMuonSach WHERE MaChiTiet = @0";
            List<object> args = new List<object> { maChiTiet };
            DBUtil.Update(sql, args);
        }

        public string generateMaChiTiet()
        {
            string prefix = "CT";
            string sql = "SELECT MAX(MaChiTiet) FROM ChiTietMuonSach";
            List<object> args = new List<object>();
            object result = DBUtil.ScalarQuery(sql, args);
            if (result != null && result.ToString().StartsWith(prefix))
            {
                string maxCode = result.ToString().Substring(2);
                int newNumber = int.Parse(maxCode) + 1;
                return $"{prefix}{newNumber:D3}";
            }
            return $"{prefix}001";
        }
             
        public string GetLastMaChiTiet()
        {
            string prefix = "CT";
            string sql = "SELECT MAX(MaChiTiet) FROM ChiTietMuonSach";
            object result = DBUtil.ScalarQuery(sql, new List<object>());
            if (result != null && result.ToString().StartsWith(prefix))
            {
                return result.ToString();
            }
            return $"{prefix}000";
        }

        public string GenerateMaChiTiet(string start)
        {
            string prefix = "CT";
            if (start != null && start.ToString().StartsWith(prefix))
            {
                string maxCode = start.ToString().Substring(prefix.Length);
                if (int.TryParse(maxCode, out int number))
                {
                    return $"{prefix}{(number + 1):D3}";
                }
            }

            return $"{prefix}001";
        }
    }
}


