namespace MdxBuilder.Entity.Operator.Comparison
{
    public sealed class GreaterThan
        : BinaryOperator<GreaterThan>
    {
        public GreaterThan(Operand leftOp, Operand rightOp)
            : base(Type.Comparison, ">", (leftOp, rightOp))
        { }
    }
}
