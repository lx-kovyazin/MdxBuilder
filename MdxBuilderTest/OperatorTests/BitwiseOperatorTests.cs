using MdxBuilder.Entity.Operator;
using MdxBuilder.Entity.Operator.Bitwise;
using Xunit;

namespace MdxBuilderTest.OperatorTests
{
    public class BitwiseOperatorTests
        : OperatorTestsShared
    {
        [Fact]
        public void AndTest()
        {
            Assert.Equal(
                $"{OP_0} AND {OP_1}",
                And.Do(op0, op1).ToString()
            );
        }

        [Fact]
        public void IsTest()
        {
            Assert.Equal(
                $"{OP_0} IS {OP_1}",
                new Is(op0, op1).ToString()
            );
        }

        [Fact]
        public void NotTest()
        {
            Assert.Equal(
                $"NOT {OP_0}",
                new Not(op0).ToString()
            );
        }

        [Fact]
        public void OrTest()
        {
            Assert.Equal(
                $"{OP_0} OR {OP_1}",
                Or.Do(op0, op1).ToString()
            );
        }

        [Fact]
        public void XorTest()
        {
            Assert.Equal(
                $"{OP_0} XOR {OP_1}",
                new Xor(op0, op1).ToString()
            );
        }
    }
}
