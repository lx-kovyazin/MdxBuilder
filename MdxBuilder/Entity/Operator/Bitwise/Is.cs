namespace MdxBuilder.Entity.Operator.Bitwise
{
    public sealed class Is
        : BinaryOperator<Is>
    {
        public Is(Operand leftOp, Operand rightOp)
            : base(Type.Bitwise, "IS", (leftOp, rightOp))
        { }
    }
}
