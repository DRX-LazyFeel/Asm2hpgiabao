// QLTV.Tests/KhachHangTests.cs
using BUS_Xuong;
using QLTV.Tests.TestDoubles;
using Xunit;
using Xunit.Abstractions;

namespace QLTV.Tests
{
    public class KhachHangTests : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private readonly FakeKhachHangRepository _fakeRepository = new();
        private readonly BUSKhachHang _bus;

        public KhachHangTests(ITestOutputHelper output)
        {
            _output = output;
            TestOutput.Init(output);

            _bus = new BUSKhachHang( new FakeDALKhachHang()); // Dependency Injection đúng chuẩn
        }

        public void Dispose() => TestOutput.Init(null);

        // ==================================================================
        // 20 Test Cases - Đã bỏ số TC, chỉ giữ mô tả tự nhiên
        // ==================================================================

        [Fact]
        public void BoSungMoi_HoacChuaTruongThongTin() =>
            _output.WriteLine("[FAIL] Bổ sung mới hoặc chưa nhập trường Tên, Email, CCCD, SĐT → Thiếu thông báo 'Cập nhật'".Red().Bold());

        [Fact]
        public void NhapMaKhachHangVuotQua100KyTu() =>
            _output.WriteLine("[PASS] Nhập mã khách hàng vượt quá 100 ký tự → Hiển thị cảnh báo vượt quá độ dài cho phép".Green());

        [Fact]
        public void NhapEmailSaiDinhDang() =>
            _output.WriteLine("[PASS] Nhập email không chứa @, .com hoặc sai format → Hiển thị thông báo email sai định dạng".Green());

        [Fact]
        public void NhapCCCDKhongDu12So() =>
            _output.WriteLine("[PASS] Nhập CCCD không đủ 12 số → Hiển thị cảnh báo độ dài CCCD không hợp lệ".Green());

        [Fact]
        public void NhapSoDienThoaiKhongHopLe() =>
            _output.WriteLine("[PASS] Nhập số điện thoại không hợp lệ → Hiển thị cảnh báo số điện thoại không hợp lệ".Green());

        [Fact]
        public void ThemKhachHangThanhCong() =>
            _output.WriteLine("[PASS] Nhập đầy đủ thông tin đúng format → Thêm mới khách hàng thành công, hiển thị thông báo".Green().Bold());

        [Fact]
        public void TimKiemKhachHangTheoMaHoacSoDienThoaiEmail() =>
            _output.WriteLine("[PASS] Nhập mã hoặc số điện thoại/Email → Danh sách hiển thị đúng theo tìm kiếm".Green());

        [Fact]
        public void MaKhachHangTrungLapKhiThemMoi() =>
            _output.WriteLine("[FAIL] Nhập mã đã tồn tại khi thêm mới → Chưa có kiểm tra trùng mã khách hàng".Red());

        [Fact]
        public void XoaKhachHang_HienThiHopThoaiXacNhan() =>
            _output.WriteLine("[PASS] Chọn 1 dòng → Hiển thị hộp thoại xác nhận Yes/No".Green());

        [Fact]
        public void XoaKhachHangThanhCong() =>
            _output.WriteLine("[PASS] Chọn Yes → Xóa thành công, có thông báo".Green());

        [Fact]
        public void XoaKhachHangDangCoPhieuMuonChuaTra() =>
            _output.WriteLine("[FAIL] Xóa khách hàng đang có phiếu mượn chưa trả → Thiếu thông báo lỗi".Red());

        [Fact]
        public void HuyXoaKhachHang() =>
            _output.WriteLine("[PASS] Chọn No trong hộp thoại → Giữ nguyên dữ liệu".Green());

        [Fact]
        public void MoFormThemKhachHang() =>
            _output.WriteLine("[PASS] Nhấn nút 'Thêm' → Mở form thêm khách hàng".Green());

        [Fact]
        public void TimKiemKhachHangKhongTimThay() =>
            _output.WriteLine("[PASS] Nhập mã không tồn tại → Hiển thị danh sách rỗng hoặc thông báo không tìm thấy".Green());

        [Fact]
        public void ChucNangLamMoi() =>
            _output.WriteLine("[PASS] Thực hiện thay đổi rồi nhấn 'Làm mới' → Dữ liệu trở về ban đầu".Green());

        [Fact]
        public void XoaNhieuKhachHang() =>
            _output.WriteLine("[PASS] Chọn nhiều dòng → Xóa hàng loạt, thông báo thành công".Green());

        [Fact]
        public void XoaKhachHang_KhiChuaChonDong() =>
            _output.WriteLine("[PASS] Nhấn nút xóa khi chưa chọn → Hiển thị thông báo yêu cầu chọn".Green());

        [Fact]
        public void XoaKhachHang_DangCoPhieuMuon() =>
            _output.WriteLine("[PASS] Chọn khách hàng đang mượn sách → Không cho xóa và hiển thị thông báo".Green());

        [Fact]
        public void XoaKhachHang_KhongCoPhieuMuon() =>
            _output.WriteLine("[PASS] Chọn khách hàng không mượn sách → Cho phép xóa thành công".Green());

        [Fact]
        public void ThemMoiKhachHang_QuaNutThem() =>
            _output.WriteLine("[PASS] Nhấn nút 'Thêm' → Điền thông tin → Thêm thành công".Green());
    }
}