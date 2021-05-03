namespace MdxBuilder.Entity.Operator.Arithmetic
{
    public sealed class Subtract
        : BinaryOperator<Subtract>
    {
        public Subtract(Operand leftOp, Operand rightOp)
            : base(Type.Arithmetic, "-", (leftOp, rightOp))
        { }
    }
}
