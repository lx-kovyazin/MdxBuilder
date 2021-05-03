namespace MdxBuilder.Entity.Operator.Arithmetic
{
    public sealed class Power
        : BinaryOperator<Power>
    {
        public Power(Operand leftOp, Operand rightOp)
            : base(Type.Arithmetic, "^", (leftOp, rightOp))
        { }
    }
}
