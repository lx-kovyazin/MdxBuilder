using System;
using MdxBuilder.Entity.Abstract;
using MdxBuilder.Utils;

namespace MdxBuilder.Builder.Abstract
{
    public abstract class BuildableEntityOfBuildableEntityBuilder<
            TSelf,
            TEntity,
            UEntityBuilder,
            UEntity
        >
        : BuildableEntityOfEntityBuilder<TSelf, TEntity, UEntity>
        where TSelf          : BuildableEntityOfEntityBuilder<TSelf,
                                   TEntity,
                                   UEntity
                             >
        where TEntity        : BuildableEntityOfEntity<TEntity, TSelf, UEntity>
        where UEntityBuilder : BuildableEntityBuilder<UEntityBuilder, UEntity>
        where UEntity        : BuildableEntity<UEntity, UEntityBuilder>
    {
        public virtual TSelf Set(FluentFunc<UEntityBuilder> builder)
            => Set(
                builder.Invoke(Activator.CreateInstance<UEntityBuilder>())
                       .Build()
            );
    }
}
