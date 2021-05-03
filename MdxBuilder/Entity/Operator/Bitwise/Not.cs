namespace MdxBuilder.Entity.Operator.Bitwise
{
    public sealed class Not
        : UnaryOperator<Not, IUnaryOperatorLeftSide>
    {
        public Not(Operand op)
            : base(Type.Bitwise, "NOT", op)
        { }
    }
}
