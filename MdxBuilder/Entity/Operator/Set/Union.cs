namespace MdxBuilder.Entity.Operator.Set
{
    public sealed class Union
        : BinaryOperator<Union>
    {
        public Union(Operand leftOp, Operand rightOp)
            : base(Type.Set, "+", (leftOp, rightOp))
        { }
    }

}
