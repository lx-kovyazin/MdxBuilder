namespace MdxBuilder.Entity.Operator.Comparison
{
    public sealed class LessThan
        : BinaryOperator<LessThan>
    {
        public LessThan(Operand leftOp, Operand rightOp)
            : base(Type.Comparison, "<", (leftOp, rightOp))
        { }
    }
}
