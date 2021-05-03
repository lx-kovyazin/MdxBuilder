using MdxBuilder.Entity.Operator;
using MdxBuilder.Entity.Operator.Unary;
using Xunit;

namespace MdxBuilderTest.OperatorTests
{
    public class UnaryOperatorTests
        : OperatorTestsShared
    {
        [Fact]
        public void NegativeTest()
        {
            Assert.Equal(
                $"- {OP_0}",
                new Negative(op0).ToString()
            );
        }

        [Fact]
        public void PositiveTest()
        {
            Assert.Equal(
                $"+ {OP_0}",
                Positive.Do(op0).ToString()
            );
        }
    }
}
