using MdxBuilder.Builder.Abstract;
using MdxBuilder.Entity;

namespace MdxBuilder.Builder
{
    public class AxisBuilder
        : BuildableEntityOfBuildableEntityBuilder<
            AxisBuilder,
            Axis,
            SetBuilder,
            Set
        >
    {
        public AxisBuilder SetDimension(sbyte dimension)
        {
            entity.Dimension = dimension;
            return this;
        }

        public override Axis Build()
        {
            bodyBuilder.Append(entity.NestedEntity.ToString());
            bodyBuilder.Append($" ON {entity.Dimension}");
            return base.Build();
        }
    }
}
