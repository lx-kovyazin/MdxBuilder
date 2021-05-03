using MdxBuilder.Builder.Abstract;

namespace MdxBuilder.Entity.Abstract
{
    public abstract class BuildableEntityOfEntitySet<TSelf, TBuilder, UEntity>
        : BuildableEntityOfEntity<TSelf, TBuilder, EntitySet<UEntity>>
        where TSelf    : BuildableEntityOfEntitySet<TSelf, TBuilder, UEntity>
        where TBuilder : BuildableEntityOfEntitySetBuilder<
                             TBuilder,
                             TSelf,
                             UEntity
                       >
        where UEntity  : AbstractEntity
    {
        protected BuildableEntityOfEntitySet()
            => NestedEntity = new EntitySet<UEntity>();
    }
}
