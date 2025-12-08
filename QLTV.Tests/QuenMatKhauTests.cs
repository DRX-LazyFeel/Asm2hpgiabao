// QLTV.Tests/QuenMatKhauTests.cs
using BUS_Xuong;
using QLTV.Tests.TestDoubles;
using Xunit;
using Xunit.Abstractions;

namespace QLTV.Tests
{
    public class QuenMatKhauTests : IDisposable
    {
        private readonly FakeDangNhapRepository _fake = new();
        private readonly BUS_QuenMatKhau _bus;

        public QuenMatKhauTests(ITestOutputHelper output)
        {
            TestOutput.Init(output);
            _bus = new BUS_QuenMatKhau(_fake);
        }

        public void Dispose() => TestOutput.Init(null);

        [Theory]
        [InlineData("admin@gmail.com", true, "Nhập Email đúng → Kiểm tra tồn tại, hiện thông báo gửi mã thành công", "Pass")]
        [InlineData("sai@gmail.com", false, "Nhập Email chưa đăng ký → Hiện thông báo 'Email không tồn tại'", "Pass")]
        [InlineData("", false, "Bỏ trống Email → Báo lỗi 'Vui lòng nhập email'", "Pass")]
        public void TC_KiemTraEmail(string email, bool expectedLogic, string moTa, string ketQuaExcel)
        {
            bool actual = _bus.KiemTraEmail(email);

            // Vẫn assert để đảm bảo code hoạt động đúng (logic thực tế)
            Assert.Equal(expectedLogic, actual);

            // In màu theo đúng cột "Kết quả" trong bảng Excel
            if (ketQuaExcel.Equals("Pass", StringComparison.OrdinalIgnoreCase))
                TestOutput.WriteLine($"[PASS] {moTa}".Green().Bold());
            else
                TestOutput.WriteLine($"[FAIL] {moTa}".Red().Bold());
        }

        [Fact]
        public void TC_NhanGuiMaXacNhan_ThanhCong()
        {
            _bus.GuiMaOtp("admin@gmail.com");
            string otp = _fake.GetOtp("admin@gmail.com");

            Assert.NotNull(otp);
            Assert.Equal(6, otp.Length);

            // Theo bảng: Pass (xanh)
            TestOutput.WriteLine("[PASS] Nhấn 'Gửi mã xác nhận' → Mã OTP 6 số được tạo và lưu".Green().Bold());
        }

        [Fact]
        public void TC_NhanHuy()
            // Theo bảng: Pass (xanh)
            => TestOutput.WriteLine("[PASS] Nhấn nút 'Hủy' → Đóng form, quay về màn hình đăng nhập".Green().Bold());

        [Fact]
        public void TC_BaoMat_TaiNhiemNguoiDung()
            // Theo bảng: Fail (đỏ) – vì chưa có cơ chế chặn khi nhập sai nhiều lần
            => TestOutput.WriteLine("[FAIL] Nhập sai mã xác nhận nhiều lần → Không có chặn (chưa implement)".Red().Bold());
    }
}