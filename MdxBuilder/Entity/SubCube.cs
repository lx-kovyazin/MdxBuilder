using MdxBuilder.Builder;
using MdxBuilder.Entity.Abstract;

namespace MdxBuilder.Entity
{
    public sealed class SubCube
        : BuildableEntityOfBuildableEntity<
            SubCube,
            SubCubeBuilder,
            Mdx.Query,
            Mdx.QueryBuilder
            >
    {
        public Cube Cube;
    }
}
