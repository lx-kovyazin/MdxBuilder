using MdxBuilder.Builder.Abstract;
using MdxBuilder.Entity;

namespace MdxBuilder.Builder
{
    public class AliasedAxisBuilder
        : BuildableEntityOfBuildableEntityBuilder<
            AliasedAxisBuilder,
            AliasedAxis,
            SetBuilder,
            Set
        >
    {
        private readonly AxisBuilder axisBuilder;

        public AliasedAxisBuilder()
            => axisBuilder = new AxisBuilder();

        public AliasedAxisBuilder SetDimension(AliasedAxis.Alias dimension)
        {
            axisBuilder.SetDimension((sbyte)dimension);
            return this;
        }

        public override AliasedAxis Build()
        {
            axisBuilder.Set(entity.NestedEntity);
            entity.axis = axisBuilder.Build();
            bodyBuilder.Append(entity.NestedEntity.ToString());
            bodyBuilder.Append($" ON {entity.AliasedDimension}");
            return base.Build();
        }
    }
}
