using Extensions;
using System;
using Xunit;

namespace StringExtensionTests
{
    public class Slice
    {
        [Fact]
        public void SliceTest()
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

            Assert.Equal(string.Empty, TestString.Slice(3, 3));
            Assert.Equal("4", TestString.Slice(3, 4));
            Assert.Equal("4567", TestString.Slice(3, 7));
            Assert.Equal("6789", TestString.Slice(5, 9));
            Assert.Equal("9", TestString.Slice(8, 9));
            Assert.Equal(string.Empty, TestString.Slice(8, 8));

            Assert.Equal(string.Empty, TestString.Slice(0, -9));
            Assert.Equal("1", TestString.Slice(0, -8));
            Assert.Equal("12", TestString.Slice(0, -7));
            Assert.Equal("123", TestString.Slice(0, -6));
            Assert.Equal("1234", TestString.Slice(0, -5));
            Assert.Equal("12345", TestString.Slice(0, -4));
            Assert.Equal("123456", TestString.Slice(0, -3));
            Assert.Equal("1234567", TestString.Slice(0, -2));
            Assert.Equal("12345678", TestString.Slice(0, -1));

            Assert.Equal("3456", TestString.Slice(2, -3));

            Assert.Equal("source", Assert.Throws<ArgumentNullException>(() => ((string)null).Slice(0, 1)).ParamName);
            Assert.Equal("startIndex", Assert.Throws<ArgumentOutOfRangeException>(() => TestString.Slice(-1, 9)).ParamName);
            Assert.Equal("startIndex", Assert.Throws<ArgumentOutOfRangeException>(() => TestString.Slice(9, 9)).ParamName);
            Assert.Equal("startIndex", Assert.Throws<ArgumentOutOfRangeException>(() => TestString.Slice(10, 9)).ParamName);
            Assert.Equal("endIndex", Assert.Throws<ArgumentOutOfRangeException>(() => TestString.Slice(0, 10)).ParamName);
            Assert.Equal("endIndex", Assert.Throws<ArgumentOutOfRangeException>(() => TestString.Slice(0, -10)).ParamName);
            Assert.Equal("endIndex", Assert.Throws<ArgumentOutOfRangeException>(() => TestString.Slice(5, 4)).ParamName);
        }
    }
}
