using System;
using MdxBuilder.Entity.Abstract;
using MdxBuilder.Utils;

namespace MdxBuilder.Builder.Abstract
{
    public abstract class BuildableEntityOfBuildableEntitySetBuilder<
            TSelf,
            TEntity,
            UEntityBuilder,
            UEntity
        >
        : BuildableEntityOfEntitySetBuilder<TSelf, TEntity, UEntity>
        where TSelf          : BuildableEntityOfBuildableEntitySetBuilder<
                                   TSelf,
                                   TEntity,
                                   UEntityBuilder,
                                   UEntity
                             >
        where TEntity        : BuildableEntityOfBuildableEntitySet<
                                   TEntity,
                                   TSelf,
                                   UEntity,
                                   UEntityBuilder
                             >
        where UEntityBuilder : BuildableEntityBuilder<UEntityBuilder, UEntity>
        where UEntity        : BuildableEntity<UEntity, UEntityBuilder>
    {
        public TSelf Add(FluentFunc<UEntityBuilder> builder)
            => Add(
                builder.Invoke(Activator.CreateInstance<UEntityBuilder>())
                       .Build()
            );
    }
}
