namespace MdxBuilder.Entity.Operator.Bitwise
{
    public sealed class And
        : BinaryOperator<And>
    {
        public And(Operand leftOp, Operand rightOp)
            : base(Type.Bitwise, "AND", (leftOp, rightOp))
        { }
    }
}
