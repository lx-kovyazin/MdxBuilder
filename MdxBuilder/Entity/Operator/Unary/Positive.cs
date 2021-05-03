namespace MdxBuilder.Entity.Operator.Unary
{
    public sealed class Positive
        : UnaryOperator<Positive, IUnaryOperatorLeftSide>
    {
        public Positive(Operand op)
            : base(Type.Unary, "+", op)
        { }
    }
}
