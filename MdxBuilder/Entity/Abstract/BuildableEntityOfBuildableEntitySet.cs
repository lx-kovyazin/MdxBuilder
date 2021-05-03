using MdxBuilder.Builder.Abstract;

namespace MdxBuilder.Entity.Abstract
{
    public abstract class BuildableEntityOfBuildableEntitySet<
            TSelf,
            TBuilder,
            UEntity,
            UEntityBuilder
        >
        : BuildableEntityOfEntitySet<TSelf, TBuilder, UEntity>
        where TSelf          : BuildableEntityOfBuildableEntitySet<
                                   TSelf,
                                   TBuilder,
                                   UEntity,
                                   UEntityBuilder
                             >
        where TBuilder       : BuildableEntityOfBuildableEntitySetBuilder<
                                   TBuilder,
                                   TSelf,
                                   UEntityBuilder,
                                   UEntity
                             >
        where UEntity        : BuildableEntity<UEntity, UEntityBuilder>
        where UEntityBuilder : BuildableEntityBuilder<UEntityBuilder, UEntity>
    { }
}
