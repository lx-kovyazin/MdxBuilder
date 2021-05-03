using MdxBuilder.Builder.Abstract;

namespace MdxBuilder.Entity.Abstract
{
    public abstract class BuildableEntityOfBuildableEntity<
            TSelf,
            TBuilder,
            UEntity,
            UEntityBuilder
        >
        : BuildableEntityOfEntity<TSelf, TBuilder, UEntity>
        where TSelf          : BuildableEntityOfEntity<
                                   TSelf,
                                   TBuilder,
                                   UEntity
                             >
        where TBuilder       : BuildableEntityOfEntityBuilder<
                                   TBuilder,
                                   TSelf,
                                   UEntity
                             >
        where UEntity        : BuildableEntity<UEntity, UEntityBuilder>
        where UEntityBuilder : BuildableEntityBuilder<UEntityBuilder, UEntity>
    { }
}
