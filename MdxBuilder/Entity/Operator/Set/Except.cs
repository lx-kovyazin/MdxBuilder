namespace MdxBuilder.Entity.Operator.Set
{
    public sealed class Except
        : BinaryOperator<Except>
    {
        public Except(Operand leftOp, Operand rightOp)
            : base(Type.Set, "-", (leftOp, rightOp))
        { }
    }
}
