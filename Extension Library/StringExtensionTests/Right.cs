using System;
using Extensions;
using Xunit;

namespace StringExtensionTests
{
    public class Right
    {
        [Fact]
        public void RightTest()
        {
            Assert.Equal(string.Empty, string.Empty.Right(10));
            Assert.Equal(string.Empty, "12345".Right(0));

            Assert.Equal("1", "1".Right(10));
            Assert.Equal("1", "1".Right(1));
            Assert.Equal("123", "123".Right(10));
            Assert.Equal("3", "123".Right(1));

            Assert.Equal("1", "0987654321".Right(1));
            Assert.Equal("21", "0987654321".Right(2));
            Assert.Equal("321", "0987654321".Right(3));
            Assert.Equal("4321", "0987654321".Right(4));
            Assert.Equal("54321", "0987654321".Right(5));
            Assert.Equal("654321", "0987654321".Right(6));
            Assert.Equal("7654321", "0987654321".Right(7));
            Assert.Equal("87654321", "0987654321".Right(8));
            Assert.Equal("987654321", "0987654321".Right(9));
            Assert.Equal("0987654321", "0987654321".Right(10));
            Assert.Equal("0987654321", "0987654321".Right(11));
            Assert.Equal("0987654321", "0987654321".Right(12));

            Assert.Equal("source", Assert.Throws<ArgumentNullException>(() => ((string)null).Right(10)).ParamName);
            Assert.Equal("length", Assert.Throws<ArgumentOutOfRangeException>(() => "12345".Right(-1)).ParamName);
        }
    }
}
