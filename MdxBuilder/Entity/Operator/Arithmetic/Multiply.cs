namespace MdxBuilder.Entity.Operator.Arithmetic
{
    public sealed class Multiply
        : BinaryOperator<Multiply>
    {
        public Multiply(Operand leftOp, Operand rightOp)
            : base(Type.Arithmetic, "*", (leftOp, rightOp))
        { }
    }
}
