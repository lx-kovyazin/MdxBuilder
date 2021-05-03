using MdxBuilder.Builder.Abstract;

namespace MdxBuilder.Entity.Abstract
{
    public abstract class BuildableEntityOfEntity<TSelf, TBuilder, UEntity>
        : BuildableEntity<TSelf, TBuilder>
        where TSelf    : BuildableEntityOfEntity<TSelf, TBuilder, UEntity>
        where TBuilder : BuildableEntityOfEntityBuilder<TBuilder, TSelf, UEntity>
        where UEntity  : AbstractEntity
    {
        public UEntity NestedEntity { get; set; }
    }
}
