using System;
using Xunit;
using Moq;
using Expectable.Matchers;

namespace Expectable.Test
{
    [Collection("Matchers")]
    public class ContainsMatcherTests
    {
        [Fact]
        public void ContainsMatcher_StringConstructor_SetsPattern()
        {
            //arrange
            string regex = "abc";
            IMatcher containsMatcher = new ContainsMatcher(regex);

            //act
            var pattern = containsMatcher.Pattern;

            //assert
            Assert.NotNull(containsMatcher);
            Assert.NotNull(pattern);
            Assert.Equal(regex, pattern);
        }

        [Fact]
        public void IsMatch_MatchingCondition_ReturnsTrue()
        {
            //arrange
            string regex = "abc";
            IMatcher containsMatcher = new ContainsMatcher(regex);

            //act
            MatchResult matchResult = containsMatcher.IsMatch("now I know my abcs");
            bool isMatch = matchResult.IsMatch;

            //assert
            Assert.NotNull(containsMatcher);
            Assert.NotNull(matchResult);
            Assert.True(isMatch);
        }

        [Fact]
        public void IsMatch_NonMatchingCondition_ReturnsFalse()
        {
            //arrange
            string regex = "abc";
            IMatcher containsMatcher = new ContainsMatcher(regex);

            //act
            MatchResult matchResult = containsMatcher.IsMatch("next time won't you sing with me");
            bool isMatch = matchResult.IsMatch;

            //assert
            Assert.NotNull(containsMatcher);
            Assert.NotNull(matchResult);
            Assert.False(isMatch);
        }
    }
}
