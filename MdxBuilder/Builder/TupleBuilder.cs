using MdxBuilder.Builder.Abstract;
using MdxBuilder.Entity;

namespace MdxBuilder.Builder
{
    public class TupleBuilder
        : BuildableEntityOfEntitySetBuilder<TupleBuilder, Tuple, UniqueEntity>
    {
        public override Tuple Build()
        {
            bodyBuilder.Clear();
            bodyBuilder.Append("(");
            bodyBuilder.Append(entity.NestedEntity.ToString());
            bodyBuilder.Append(")");
            return base.Build();
        }
    }
}
