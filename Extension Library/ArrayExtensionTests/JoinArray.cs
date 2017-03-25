using Extensions;
using System;
using System.Linq;
using Xunit;

namespace ArrayExtensionTests
{
    public class JoinArray
    {
        [Fact]
        public void JoinArrayTest()
        {
            var a1 = new[] { 1, 2, 3 };
            var a2 = new[] { 4, 5, 6 };
            var a3 = new[] { 7, 8, 9 };
            var result = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Assert.True(result.SequenceEqual(a1.JoinArrays(a2, a3)));
            Assert.True(result.SequenceEqual(a1.JoinArrays(new[] { a2, a3 })));
            Assert.True(result.SequenceEqual(new[] { a1, a2, a3 }.JoinArrays()));

            var arrayContainsNull = new[] { a1, null, a2 };
            Assert.Equal("sourceArray", Assert.Throws<ArgumentNullException>(() => a1.JoinArrays(null)).ParamName);
            Assert.Equal("sourceArray", Assert.Throws<ArgumentNullException>(() => ((int[])null).JoinArrays(a1)).ParamName);
            Assert.Equal("arrays", Assert.Throws<ArgumentNullException>(() => a1.JoinArrays(arrayContainsNull)).ParamName);
            Assert.Equal("arrays", Assert.Throws<ArgumentNullException>(() => arrayContainsNull.JoinArrays()).ParamName);
        }
    }
}
