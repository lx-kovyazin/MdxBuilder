using MdxBuilder.Builder.Abstract;
using MdxBuilder.Entity;
using MdxBuilder.Utils;

namespace MdxBuilder.Builder
{
    public class SubCubeBuilder
        : BuildableEntityOfBuildableEntityBuilder<
            SubCubeBuilder,
            SubCube,
            Mdx.QueryBuilder,
            Mdx.Query
        >
    {
        public SubCubeBuilder Set(Cube cube)
        {
            entity.Cube = cube;
            entity.NestedEntity = null;
            return this;
        }

        public override SubCubeBuilder Set(Mdx.Query entity)
            => this.entity.Cube is null
                ? base.Set(entity)
                : this;

        public override SubCubeBuilder Set(FluentFunc<Mdx.QueryBuilder> builder)
            => entity.Cube is null
                ? base.Set(builder)
                : this;

        public override SubCube Build()
        {
            bodyBuilder.Append(
                entity.Cube is null
                    ? entity.NestedEntity.ToString()
                    : entity.Cube.ToString()
            );
            return base.Build();
        }
    }

    public class FromExpressionBuilder
        : BuildableEntityOfBuildableEntityBuilder<
            FromExpressionBuilder,
            FromExpression,
            SubCubeBuilder,
            SubCube
            >
    {
        public override FromExpression Build()
        {
            bodyBuilder.Append("FROM ");
            bodyBuilder.Append(entity.NestedEntity);
            return base.Build();
        }
    }
}
