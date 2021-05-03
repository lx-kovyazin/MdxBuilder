namespace MdxBuilder.Entity.Operator.Comparison
{
    public sealed class GreaterThanOrEqualTo
        : BinaryOperator<GreaterThanOrEqualTo>
    {
        public GreaterThanOrEqualTo(Operand leftOp, Operand rightOp)
            : base(Type.Comparison, ">=", (leftOp, rightOp))
        { }
    }
}
