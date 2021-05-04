using MdxBuilder.Builder;
using MdxBuilder.Entity.Abstract;

namespace MdxBuilder.Entity
{
    public sealed class FromExpression
        : BuildableEntityOfBuildableEntity<
            FromExpression,
            FromExpressionBuilder,
            SubCube,
            SubCubeBuilder
        >
    { }
}
