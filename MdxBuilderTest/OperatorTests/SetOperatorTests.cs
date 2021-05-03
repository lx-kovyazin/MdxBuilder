using MdxBuilder.Entity.Operator.Set;
using Xunit;

namespace MdxBuilderTest.OperatorTests
{
    public class SetOperatorTests
        : OperatorTestsShared
    {
        [Fact]
        public void ExceptTest()
        {
            Assert.Equal(
                $"{OP_0} - {OP_1}",
                new Except(op0, op1).ToString()
            );
        }

        [Fact]
        public void CrossjoinTest()
        {
            Assert.Equal(
                $"{OP_0} * {OP_1} * {OP_2}",
                Crossjoin.Do(op0, op1, op2).ToString()
            );
        }

        [Fact]
        public void RangeTest()
        {
            Assert.Equal(
                $"{OP_0} : {OP_1}",
                Range.Do(op0, op1).ToString()
            );
        }

        [Fact]
        public void UnionTest()
        {
            Assert.Equal(
                $"{OP_0} + {OP_1}",
                new Union(op0, op1).ToString()
            );
        }
    }
}
