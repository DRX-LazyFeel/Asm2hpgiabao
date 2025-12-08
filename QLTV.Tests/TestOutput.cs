// QLTV.Tests/TestOutput.cs
using Xunit.Abstractions;

namespace QLTV.Tests
{
    public static class TestOutput
    {
        private static ITestOutputHelper? _output;

        /// <summary>
        /// Gọi dòng này trong constructor của mọi class test
        /// Ví dụ: public MyTests(ITestOutputHelper output) => TestOutput.Init(output);
        /// </summary>
        public static void Init(ITestOutputHelper output)
        {
            _output = output;
        }

        public static void WriteLine(string text)
        {
            _output?.WriteLine(text);
        }

        public static void WriteLine(string format, params object?[] args)
        {
            _output?.WriteLine(format, args);
        }

        // ──────────────────────────────────────
        // Các hàm màu (dùng được trên VS Code, Rider, Windows Terminal, dotnet test)
        // ──────────────────────────────────────
        public static string Green(this string text) => $"\u001b[32m{text}\u001b[0m";
        public static string Red(this string text) => $"\u001b[31m{text}\u001b[0m";
        public static string Yellow(this string text) => $"\u001b[33m{text}\u001b[0m";
        public static string Cyan(this string text) => $"\u001b[36m{text}\u001b[0m";
        public static string Magenta(this string text) => $"\u001b[35m{text}\u001b[0m";
        public static string Blue(this string text) => $"\u001b[34m{text}\u001b[0m";
        public static string Bold(this string text) => $"\u001b[1m{text}\u001b[0m";
    }
}