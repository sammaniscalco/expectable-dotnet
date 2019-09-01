using System;
using Xunit;
using Moq;
using Expectable.Outputs;
using System.Collections.Generic;

namespace Expectable.Test
{
    [Collection("Outputs")]
    public class ListOutputTests
    {
        [Fact]
        public void ToString_MultipleItemListInput_ReturnsDelimitedString()
        {
            //arrange
            List<String> inputs = new List<string>() { "item1", "item2", "item3" };
            IOutput output = new ListOutput(inputs);

            //act
            string result = output.ToString();

            //assert
            Assert.NotNull(output);
            Assert.NotNull(result);
            Assert.Equal("item1|item2|item3", result);
        }

        [Fact]
        public void ToString_SingleItemListInput_ReturnsString()
        {
            //arrange
            List<String> inputs = new List<string>() { "item1" };
            IOutput output = new ListOutput(inputs);

            //act
            string result = output.ToString();

            //assert
            Assert.NotNull(output);
            Assert.NotNull(result);
            Assert.Equal("item1", result);
        }

        [Fact]
        public void ToList_MultipleItemListInput_ReturnsList()
        {
            //arrange
            List<String> inputs = new List<string>() { "item1","item2","item3" };
            IOutput output = new ListOutput(inputs);

            //act
            List<String> results = output.ToList();

            //assert
            Assert.NotNull(output);
            Assert.NotNull(results);
            Assert.NotEmpty(results);
            Assert.True(results.Count==3);
        }

        [Fact]
        public void ToList_SingleItemListInput_ReturnsList()
        {
            //arrange
            List<String> inputs = new List<string>() { "item1"};
            IOutput output = new ListOutput(inputs);

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
