namespace MdxBuilder.Entity.Operator.Comparison
{
    public sealed class EqualTo
        : BinaryOperator<EqualTo>
    {
        public EqualTo(Operand leftOp, Operand rightOp)
            : base(Type.Comparison, "=", (leftOp, rightOp))
        { }
    }
}
