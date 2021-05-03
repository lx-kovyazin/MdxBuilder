using MdxBuilder.Builder.Abstract;
using MdxBuilder.Entity;

namespace MdxBuilder.Builder
{
    public class SetBuilder
        : BuildableEntityOfBuildableEntitySetBuilder<
            SetBuilder,
            Set,
            TupleBuilder,
            Tuple
            >
    {
        public override Set Build()
        {
            bodyBuilder.Clear();
            bodyBuilder.Append("{");
            bodyBuilder.Append(entity.NestedEntity.ToString());
            bodyBuilder.Append("}");
            return base.Build();
        }
    }
}
