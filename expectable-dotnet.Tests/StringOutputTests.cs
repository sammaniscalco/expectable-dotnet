using System;
using Xunit;
using Moq;
using System.Collections.Generic;
using Expectable.Outputs;

namespace Expectable.Test
{
    [Collection("Outputs")]
    public class StringsOutputTests
    {
        [Fact]
        public void ToString_StringInput_ReturnsString()
        {
            //arrange
            string input = "item1";
            IOutput output = new StringOutput(input);

            //act
            string result = output.ToString();

            //assert
            Assert.NotNull(output);
            Assert.NotNull(result);
            Assert.Equal("item1", result);
        }

        [Fact]
        public void ToList_StringInput_ReturnsListWithSingleItem()
        {
            //arrange
            string input = "item1";
            IOutput output = new StringOutput(input);

            //act
            List<String> results = output.ToList();

            //assert
            Assert.NotNull(output);
            Assert.NotNull(results);
            Assert.NotEmpty(results);
            Assert.True(results.Count == 1);
        }
    }
}
