namespace MdxBuilder.Entity.Operator.Set
{
    public sealed class Crossjoin
        : BinaryOperator<Crossjoin>
    {
        public Crossjoin(Operand leftOp, Operand rightOp)
            : base(Type.Set, "*", (leftOp, rightOp))
        { }
    }
}
