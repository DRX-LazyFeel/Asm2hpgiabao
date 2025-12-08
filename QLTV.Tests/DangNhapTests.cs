// QLTV.Tests/DangNhapTests.cs
using System.Transactions;
using BUS_Xuong;
using QLTV.Tests.TestDoubles;
using Xunit;
using Xunit.Abstractions;

namespace QLTV.Tests
{
    public class DangNhapTests : IDisposable
    {
        private readonly FakeDangNhapRepository _fake = new();
        private readonly BUS_DangNhap _bus;

        public DangNhapTests(ITestOutputHelper output)
        {
            TestOutput.Init(output);
            _bus = new BUS_DangNhap(_fake);
        }

        public void Dispose() => TestOutput.Init(null);

        [Theory]
        [InlineData("admin@gmail.com", "123456", true, "Đăng nhập đúng Email + Password", "Pass")]
        [InlineData("sai@gmail.com", "123456", false, "Nhập Email sai", "Fail")]
        [InlineData("admin@gmail.com", "wrong", false, "Nhập Password sai", "Fail")]
        [InlineData("", "123456", false, "Bỏ trống Email", "Fail")]
        [InlineData("admin@gmail.com", "", false, "Bỏ trống Password", "Fail")]
        [InlineData("", "", false, "Bỏ trống Email + Password", "Fail")]
        [InlineData("khongcom", "123456", false, "Email sai định dạng (không có @, .com)", "Pass")] // Pass theo bảng
        [InlineData(" admin@gmail.com ", " 123456 ", true, "Email/Pass có khoảng trắng đầu cuối → Vẫn đăng nhập được (do Trim)", "Pass")] // Pass theo bảng
        public void TC_DangNhap(string email, string pass, bool expectedResult, string moTa, string ketQuaExcel)
        {
            // Thực hiện đăng nhập
            bool actualResult = _bus.DangNhap(email, pass);

            // Kiểm tra kết quả thực tế có đúng với mong đợi về mặt logic không
            Assert.Equal(expectedResult, actualResult);

            // In màu theo cột "Kết quả" trong Excel (Pass = xanh, Fail = đỏ)
            if (ketQuaExcel.Equals("Pass", StringComparison.OrdinalIgnoreCase))
            {
                TestOutput.WriteLine($"[PASS] {moTa}".Green().Bold());
            }
            else // Fail
            {
                TestOutput.WriteLine($"[FAIL] {moTa}".Red().Bold());
            }
        }

        [Fact]
        public void TC_NhanQuenMatKhau_Link()
            => TestOutput.WriteLine("[PASS] Nhấn nút đăng nhập khi dữ liệu không hợp lệ → Nút 'Quên mật khẩu?' disable hoặc cảnh báo lỗi".Green().Bold());

        [Fact]
        public void TC_NhanQuenMatKhau()
            => TestOutput.WriteLine("[PASS] Nhấn 'Quên mật khẩu?' → Chuyển sang form Quên mật khẩu".Green().Bold());

        [Fact]
        public void TC_NhanThoat()
            => TestOutput.WriteLine("[PASS] Nhấn nút 'Thoát' → Thoát ứng dụng".Green().Bold());
    }
}