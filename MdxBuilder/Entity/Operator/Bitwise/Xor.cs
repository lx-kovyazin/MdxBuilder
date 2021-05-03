namespace MdxBuilder.Entity.Operator.Bitwise
{
    public sealed class Xor
        : BinaryOperator<Xor>
    {
        public Xor(Operand leftOp, Operand rightOp)
            : base(Type.Bitwise, "XOR", (leftOp, rightOp))
        { }
    }
}
