using System;
using Xunit;
using Moq;

namespace Expectable.Test
{
    public class ExpectableTests
    {
        [Fact]
        public void Read_WithExpectableContent_ReturnsString()
        {
            //arrange
            var read = "abc";
            var expectable = new Mock<IExpectable>();
            expectable.Setup(e => e.Read()).Returns(read);

            //act
            var output = expectable.Object.Read();

            //assert
            Assert.NotNull(output);
            Assert.Equal(read, output);
        }

        [Fact]
        public void Write_WithString_NoException()
        {
            //arrange
            var expectable = new Mock<IExpectable>();

            //act
            expectable.Object.Write("test");

            //assert
            Assert.NotNull(expectable);
        }
    }
}
