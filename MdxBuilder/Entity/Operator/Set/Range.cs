namespace MdxBuilder.Entity.Operator.Set
{
    public sealed class Range
        : BinaryOperator<Range>
    {
        public Range(Operand leftOp, Operand rightOp)
            : base(Type.Set, ":", (leftOp, rightOp))
        { }
    }

}
