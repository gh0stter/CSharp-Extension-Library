using Extensions;
using System;
using Xunit;

namespace StringExtensionTests
{
    public class RemoveLabel
    {
        [Fact]
        public void RemoveLabelTest()
        {
            const string TestString = "Foo Bar";
            const string TestCentence = "Why do I need to write so many tests.";

            Assert.Equal("Foo Bar", TestString.RemoveLabel(string.Empty));
            Assert.Equal(string.Empty, string.Empty.RemoveLabel(string.Empty));
            Assert.Equal(string.Empty, string.Empty.RemoveLabel("Foo"));

            //Test exclusion of single occurance
            Assert.Equal("Foo", TestString.RemoveLabel("Bar"));
            Assert.Equal("Bar", TestString.RemoveLabel("Foo "));

            //Test exclusion of multiple occurances
            Assert.Equal("Foo", "Bar Foo Bar".RemoveLabel("Bar"));

            //Test exclusion with split array of values
            Assert.Equal("Why do need to write so many.", TestCentence.RemoveLabel(" I| tests"));
            Assert.Equal("Why do I write tests.", TestCentence.RemoveLabel(" need| to| many| so"));

            Assert.Equal("source", Assert.Throws<ArgumentNullException>(() => ((string)null).RemoveLabel("test")).ParamName);
            Assert.Equal("exclusionLabel", Assert.Throws<ArgumentNullException>(() => TestString.RemoveLabel(null)).ParamName);
        }
    }
}
