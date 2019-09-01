using System;
using Xunit;
using Moq;
using Expectable;
using Expectable.Matchers;
using System.Text.RegularExpressions;

namespace Expectable.Test
{
    [Collection("Matchers")]
    public class ExactMatcherTests
    {
        [Fact]
        public void ExactMatcher_StringConstructor_SetsPattern()
        {
            //arrange
            string pattern = "abc";
            IMatcher exactMatcher = new ExactMatcher(pattern);

            //act
            var matcherPattern = exactMatcher.Pattern;

            //assert
            Assert.NotNull(exactMatcher);
            Assert.NotNull(matcherPattern);
            Assert.Equal(pattern, matcherPattern);
        }

        [Fact]
        public void IsMatch_MatchingCondition_ReturnsTrue()
        {
            //arrange
            string pattern = "abc";
            IMatcher exactMatcher = new ExactMatcher(pattern);

            //act
            MatchResult matchResult = exactMatcher.IsMatch("abc");
            bool isMatch = matchResult.IsMatch;

            //assert
            Assert.NotNull(exactMatcher);
            Assert.NotNull(matchResult);
            Assert.True(isMatch);
        }

        [Fact]
        public void IsMatch_NonMatchingCondition_ReturnsFalse()
        {
            //arrange
            string pattern = "abc";
            IMatcher exactMatcher = new ExactMatcher(pattern);

            //act
            MatchResult matchResult = exactMatcher.IsMatch("now I know my abcs");
            bool isMatch = matchResult.IsMatch;

            //assert
            Assert.NotNull(exactMatcher);
            Assert.NotNull(matchResult);
            Assert.False(isMatch);
        }
    }
}
