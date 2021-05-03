namespace MdxBuilder.Entity.Operator.Arithmetic
{
    public sealed class Divide
        : BinaryOperator<Divide>
    {
        public Divide(Operand leftOp, Operand rightOp)
            : base(Type.Arithmetic, "/", (leftOp, rightOp))
        { }
    }
}
