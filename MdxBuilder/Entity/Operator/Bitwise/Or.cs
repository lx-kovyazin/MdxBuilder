namespace MdxBuilder.Entity.Operator.Bitwise
{
    public sealed class Or
        : BinaryOperator<Or>
    {
        public Or(Operand leftOp, Operand rightOp)
            : base(Type.Bitwise, "OR", (leftOp, rightOp))
        { }
    }
}
