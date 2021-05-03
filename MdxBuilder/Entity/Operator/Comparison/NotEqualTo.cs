namespace MdxBuilder.Entity.Operator.Comparison
{
    public sealed class NotEqualTo
        : BinaryOperator<NotEqualTo>
    {
        public NotEqualTo(Operand leftOp, Operand rightOp)
            : base(Type.Comparison, "<>", (leftOp, rightOp))
        { }
    }
}
