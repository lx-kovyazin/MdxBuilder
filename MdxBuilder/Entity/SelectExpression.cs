using MdxBuilder.Builder;
using MdxBuilder.Entity.Abstract;

namespace MdxBuilder.Entity
{
    public sealed class SelectExpression
        : BuildableEntityOfBuildableEntitySet<
            SelectExpression,
            SelectExpressionBuilder,
            AliasedAxis,
            AliasedAxisBuilder
        >
    { }
}
