using Extensions;
using System;
using Xunit;

namespace StringExtensionTests
{
    public class Slice
    {
        [Fact]
        public void Test1()
        {
            const string TestString = "123456789";

            Assert.Equal(string.Empty, TestString.Slice(0, 0));
            Assert.Equal("1", TestString.Slice(0, 1));
            Assert.Equal("12", TestString.Slice(0, 2));
            Assert.Equal("123", TestString.Slice(0, 3));
            Assert.Equal("1234", TestString.Slice(0, 4));
            Assert.Equal("12345", TestString.Slice(0, 5));
            Assert.Equal("123456", TestString.Slice(0, 6));
            Assert.Equal("1234567", TestString.Slice(0, 7));
            Assert.Equal("12345678", TestString.Slice(0, 8));
            Assert.Equal("123456789", TestString.Slice(0, 9));
            Assert.Equal("123456789", TestString.Slice(0, TestString.Length));

            Assert.Equal(string.Empty, TestString.Slice(0, -9));
            Assert.Equal("1", TestString.Slice(0, -8));
            Assert.Equal("12", TestString.Slice(0, -7));
            Assert.Equal("123", TestString.Slice(0, -6));
            Assert.Equal("1234", TestString.Slice(0, -5));
            Assert.Equal("12345", TestString.Slice(0, -4));
            Assert.Equal("123456", TestString.Slice(0, -3));
            Assert.Equal("1234567", TestString.Slice(0, -2));
            Assert.Equal("12345678", TestString.Slice(0, -1));

            Assert.Throws<ArgumentNullException>(() => ((string)null).Slice(0, 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => TestString.Slice(0, 10));
            Assert.Throws<ArgumentOutOfRangeException>(() => TestString.Slice(-1, 9));
            Assert.Throws<ArgumentOutOfRangeException>(() => TestString.Slice(0, -10));
        }
    }
}
