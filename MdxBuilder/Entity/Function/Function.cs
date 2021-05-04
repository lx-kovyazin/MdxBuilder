using MdxBuilder.Entity.Abstract;

namespace MdxBuilder.Entity.Function
{
    public abstract class Function
        : AbstractEntity, INamedEntity
    {
        public enum Type
        {
            Subroutine,
            Tail
        }

        public enum Category
        {
            Array,
            Hierarchy,
            Level,
            Logical,
            Member,
            Numeric,
            Other,
            Set,
            String,
            Subcube,
            Tuple
        }

        private readonly string name;
        protected Function(Type type, Category category, string name)
        {
            FunctionType = type;
            FunctionCategory = category;
            this.name = name;
        }

        public Type FunctionType
        {
            get;
            private set;
        }

        public Category FunctionCategory
        {
            get;
            private set;
        }

        public UniqueEntity Result => new UniqueEntity(ToString());

        public string Name => name;

        public override string ToString() => Body;

    }
}
