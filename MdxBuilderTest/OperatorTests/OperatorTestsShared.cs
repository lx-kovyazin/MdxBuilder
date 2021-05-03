using MdxBuilder.Entity.Operator;

namespace MdxBuilderTest.OperatorTests
{
    public abstract class OperatorTestsShared
    {
        protected const string OP_0 = nameof(op0);
        protected const string OP_1 = nameof(op1);
        protected const string OP_2 = nameof(op2);

        protected readonly Operand op0 = new(OP_0);
        protected readonly Operand op1 = new(OP_1);
        protected readonly Operand op2 = new(OP_2);
    }
}
