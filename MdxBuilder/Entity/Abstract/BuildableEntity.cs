using MdxBuilder.Builder.Abstract;

namespace MdxBuilder.Entity.Abstract
{
    public abstract class BuildableEntity<TSelf, TBuilder>
        : AbstractEntity
        where TSelf    : BuildableEntity<TSelf, TBuilder>
        where TBuilder : BuildableEntityBuilder<TBuilder, TSelf>
    {
        public override string ToString() => Body;
    }
}
