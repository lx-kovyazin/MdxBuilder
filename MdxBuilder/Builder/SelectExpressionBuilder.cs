using MdxBuilder.Builder.Abstract;
using MdxBuilder.Entity;

namespace MdxBuilder.Builder
{
    public class SelectExpressionBuilder
        : BuildableEntityOfBuildableEntitySetBuilder<
            SelectExpressionBuilder,
            SelectExpression,
            AliasedAxisBuilder,
            AliasedAxis
        >
    {
        public override SelectExpression Build()
        {
            bodyBuilder.Clear();
            bodyBuilder.Append("SELECT ");
            bodyBuilder.Append(entity.NestedEntity.ToString());
            bodyBuilder.Append(" ");
            return base.Build();
        }
    }
}
