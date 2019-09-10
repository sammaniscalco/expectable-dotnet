using System;
using Xunit;
using Moq;
using Expectable;
using Expectable.Matchers;
using System.Text.RegularExpressions;

namespace Expectable.Test
{
    [Collection("Matchers")]
    public class RegexMatcherTests
    {
        [Fact]
        public void RegexMatcher_StringConstructor_SetsPattern()
        {
            //arrange
            string pattern = "abc.+[321]{3}s";
            IMatcher regexMatcher = new RegexMatcher(pattern);

            //act
            var matcherPattern = regexMatcher.Pattern;

            //assert
            Assert.NotNull(regexMatcher);
            Assert.NotNull(pattern);
            Assert.Equal(pattern, matcherPattern);
        }

        [Fact]
        public void RegexMatcher_RegexConstructor_SetsPattern()
        {
            //arrange
            Regex regex = new Regex("abc.+[321]{3}s");
            IMatcher regexMatcher = new RegexMatcher(regex);

            //act
            var matcherPattern = regexMatcher.Pattern;

            //assert
            Assert.NotNull(regexMatcher);
            Assert.NotNull(regex);
            Assert.Equal(regex.ToString(), matcherPattern);
        }

        [Fact]
        public void IsMatch_MatchingCondition_ReturnsTrue()
        {
            //arrange
            string pattern = "abc.+[321]{3}s";
            IMatcher regexMatcher = new RegexMatcher(pattern);

            //act
            MatchResult matchResult = regexMatcher.IsMatch("now I know my abcs and 123s");
            bool isMatch = matchResult.IsMatch;

            //assert
            Assert.NotNull(regexMatcher);
            Assert.NotNull(matchResult);
            Assert.True(isMatch);
        }

        [Fact]
        public void IsMatch_NonMatchingCondition_ReturnsFalse()
        {
            //arrange
            string pattern = "abc.+[321]{3}s";
            IMatcher regexMatcher = new RegexMatcher(pattern);

            //act
            MatchResult matchResult = regexMatcher.IsMatch("next time won't you sing with me");
            bool isMatch = matchResult.IsMatch;

            //assert
            Assert.NotNull(regexMatcher);
            Assert.NotNull(matchResult);
            Assert.False(isMatch);
        }
    }
}
