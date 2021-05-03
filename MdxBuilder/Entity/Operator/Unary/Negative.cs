namespace MdxBuilder.Entity.Operator.Unary
{
    public sealed class Negative
        : UnaryOperator<Negative, IUnaryOperatorLeftSide>
    {
        public Negative(Operand op)
            : base(Type.Unary, "-", op)
        { }
    }
}
