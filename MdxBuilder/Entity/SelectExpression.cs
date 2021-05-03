using MdxBuilder.Builder;
using MdxBuilder.Entity.Abstract;

namespace MdxBuilder.Entity
{
    public class SelectExpression
        : BuildableEntityOfBuildableEntitySet<
            SelectExpression,
            SelectExpressionBuilder,
            AliasedAxis,
            AliasedAxisBuilder
        >
    { }
}
