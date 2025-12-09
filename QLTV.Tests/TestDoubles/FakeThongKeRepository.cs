using DAL_Xuong.Interface;
using System.Data;

namespace QLTV.Tests.TestDoubles
{
    public class FakeThongKeRepository : IThongKeRepository
    {
        public DataTable GetSachMuonNhieuNhat()
        {
            // Tạo một bảng giả trong RAM để test hiển thị
            DataTable dt = new DataTable();
            dt.Columns.Add("TenSach");
            dt.Columns.Add("SoLanMuon", typeof(int));

            dt.Rows.Add("Dế Mèn Phiêu Lưu Ký", 15);
            dt.Rows.Add("Harry Potter", 10);

            return dt;
        }
    }
}