using System;
using System.Collections.Generic;
using System.Text;
using MdxBuilder.Builder;
using MdxBuilder.Entity.Abstract;

namespace MdxBuilder.Entity
{
    public abstract class VariableEntity<T>
        : AbstractEntity
    {
    }

    public class Cube
        : UniqueEntity
    {
        public override string ToString()
            => UniqueName;
    }

    public class SubCube
        : BuildableEntityOfBuildableEntity<
            SubCube,
            SubCubeBuilder,
            Mdx.Query,
            Mdx.QueryBuilder
            >
    {
        public Cube Cube;
    }

    public class FromExpression
        : BuildableEntityOfBuildableEntity<
            FromExpression,
            FromExpressionBuilder,
            SubCube,
            SubCubeBuilder
        >
    {
    }
}
