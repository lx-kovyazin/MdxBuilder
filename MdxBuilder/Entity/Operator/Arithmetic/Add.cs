namespace MdxBuilder.Entity.Operator.Arithmetic
{
    public sealed class Add
        : BinaryOperator<Add>
    {
        public Add(Operand leftOp, Operand rightOp)
            : base(Type.Arithmetic, "+", (leftOp, rightOp))
        { }
    }
}
