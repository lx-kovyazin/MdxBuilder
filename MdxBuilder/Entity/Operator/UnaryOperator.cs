using System;

namespace MdxBuilder.Entity.Operator
{
    public interface IUnaryOperatorSide { };
    public interface IUnaryOperatorLeftSide : IUnaryOperatorSide { };
    public interface IUnaryOperatorRightSide : IUnaryOperatorSide { };

    public abstract class UnaryOperator<TSelf, OpSide>
        : Operator
        where TSelf  : UnaryOperator<TSelf, OpSide>
        where OpSide : IUnaryOperatorSide
    {
        //private readonly Operand op;

        protected UnaryOperator(
            Type type,
            string name,
            Operand op
            )
            : base(type, name)
        {
            Body = typeof(OpSide).Equals(typeof(IUnaryOperatorLeftSide))
                ? $"{Name} {op.UniqueName}"
                : $"{op.UniqueName} {Name}"
                ;
        }

        public static Operand Do(Operand op)
            => (Activator.CreateInstance(typeof(TSelf), op) as TSelf).Result;
    }
}
