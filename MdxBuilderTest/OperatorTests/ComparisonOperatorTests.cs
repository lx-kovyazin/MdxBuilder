using MdxBuilder.Entity.Operator;
using MdxBuilder.Entity.Operator.Comparison;
using Xunit;

namespace MdxBuilderTest.OperatorTests
{
    public class ComparisonOperatorTests
        : OperatorTestsShared
    {
        [Fact]
        public void EqualToTest()
        {
            Assert.Equal(
                $"{OP_0} = {OP_1}",
                new EqualTo(op0, op1).ToString()
            );
        }

        [Fact]
        public void NotEqualToTest()
        {
            Assert.Equal(
                $"{OP_0} <> {OP_1}",
                new NotEqualTo(op0, op1).ToString()
            );
        }

        [Fact]
        public void GreaterThanTest()
        {
            Assert.Equal(
                $"{OP_0} > {OP_1}",
                new GreaterThan(op0, op1).ToString()
            );
        }

        [Fact]
        public void GreaterThanOrEqualToTest()
        {
            Assert.Equal(
                $"{OP_0} >= {OP_1}",
                new GreaterThanOrEqualTo(op0, op1).ToString()
            );
        }

        [Fact]
        public void LessThanTest()
        {
            Assert.Equal(
                $"{OP_0} < {OP_1}",
                new LessThan(op0, op1).ToString()
            );
        }

        [Fact]
        public void LessThanOrEqualToTest()
        {
            Assert.Equal(
                $"{OP_0} <= {OP_1}",
                new LessThanOrEqualTo(op0, op1).ToString()
            );
        }
    }
}
