using Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EnumerableExtensions
{
    public class Suffle
    {
        [Fact]
        [Trait("TestCategory", "Unit")]
        public void Shuffle()
        {
            var sourceSequence = Enumerable.Range(1, 20).ToList();
            for (int i = 0; i < 10; i++)
            {
                var shuffledResult = sourceSequence.Shuffle().ToList();
                // We check result is shuffled
                Assert.False(sourceSequence.SequenceEqual(shuffledResult));
                // check we have not lost any values
                Assert.True(sourceSequence.Count == shuffledResult.Count);
                foreach (int sourceItem in sourceSequence)
                {
                    Assert.True(shuffledResult.Contains(sourceItem));
                }
            }
            Assert.Equal("sequence", Assert.Throws<ArgumentNullException>(() => ((List<int>)null).Shuffle()).ParamName);
            Assert.Equal("Sequence contains no elements.", Assert.Throws<InvalidOperationException>(() => (new List<int>()).Shuffle()).Message);
        }
    }
}
