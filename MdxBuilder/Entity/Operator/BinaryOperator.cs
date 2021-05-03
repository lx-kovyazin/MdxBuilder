using System;
using System.Diagnostics.CodeAnalysis;

namespace MdxBuilder.Entity.Operator
{
    public abstract class BinaryOperator<TSelf>
        : Operator
        where TSelf : BinaryOperator<TSelf>
    {
        //private readonly (Operand leftOp, Operand rightOp) ops;

        protected BinaryOperator(
            Type type,
            string name,
            (Operand leftOp, Operand rightOp) ops
            )
            : base(type, name)
        {
            //this.ops = ops;
            Body = string.Join(" ",
                ops.leftOp.UniqueName,
                Name,
                ops.rightOp.UniqueName
            );
        }

        public static Operand Do(Operand leftOp, Operand rightOp)
            => Do(new Operand[] { leftOp, rightOp });

        public static Operand Do(params Operand[] items)
        {
            if (items.Length < 2)
                throw new ArgumentOutOfRangeException(
                    nameof(items.Length),
                    items.Length,
                    "A binary operator can perform on more than 2 operands."
                );

            var leftOp = items[0];
            for (int i = 1; i < items.Length; i++)
            {
                var rightOp = items[i];
                leftOp = (Activator.CreateInstance(typeof(TSelf), leftOp, rightOp) as TSelf).Result;
            }

            return leftOp;
        }
    }
}
