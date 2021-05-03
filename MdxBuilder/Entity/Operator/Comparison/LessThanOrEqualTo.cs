namespace MdxBuilder.Entity.Operator.Comparison
{
    public sealed class LessThanOrEqualTo
        : BinaryOperator<LessThanOrEqualTo>
    {
        public LessThanOrEqualTo(Operand leftOp, Operand rightOp)
            : base(Type.Comparison, "<=", (leftOp, rightOp))
        { }
    }
}
