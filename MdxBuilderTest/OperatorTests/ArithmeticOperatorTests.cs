using MdxBuilder.Entity.Operator.Arithmetic;
using Xunit;

namespace MdxBuilderTest.OperatorTests
{
    public class ArithmeticOperatorTests
        : OperatorTestsShared
    {
        [Fact]
        public void AddTest()
        {
            Assert.Equal(
                $"{OP_0} + {OP_1}",
                new Add(op0, op1).ToString()
            );
        }

        [Fact]
        public void SubtractTest()
        {
            Assert.Equal(
                $"{OP_0} - {OP_1} - {OP_2}",
                Subtract.Do(op0, op1, op2).ToString()
            );
        }

        [Fact]
        public void MultiplyTest()
        {
            Assert.Equal(
                $"{OP_0} * {OP_1}",
                new Multiply(op0, op1).ToString()
            );
        }

        [Fact]
        public void DivideTest()
        {
            Assert.Equal(
                $"{OP_0} / {OP_1}",
                Divide.Do(op0, op1).ToString()
            );
        }

        [Fact]
        public void PowerTest()
        {
            Assert.Equal(
                $"{OP_0} ^ {OP_1}",
                new Power(op0, op1).ToString()
            );
        }
    }
}
