using MdxBuilder.Entity.Abstract;

namespace MdxBuilder.Entity.Operator
{
    /// <summary>
    /// <see cref="https://docs.microsoft.com/en-us/sql/mdx/operators-mdx-syntax?view=sql-server-ver15"/>
    /// </summary>
    public abstract class Operator
        : AbstractEntity, INamedEntity
    {
        public enum Type
        {
            Assigment,
            Arithmetic,
            Bitwise,
            Comparison,
            Concatenation,
            Set,
            Unary
        }

        private readonly string name;

        protected Operator(Type type, string name)
        {
            OperatorType = type;
            this.name = name;
        }

        public Type OperatorType
        {
            get;
            private set;
        }

        public Operand Result => new Operand(ToString());

        public string Name => name;

        public override string ToString()
            => Body;
    }
}
