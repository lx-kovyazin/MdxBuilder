using MdxBuilder.Entity;
using MdxBuilder.Entity.Abstract;

namespace MdxBuilder.Builder.Abstract
{
    public abstract class BuildableEntityOfEntitySetBuilder<
            TSelf,
            TEntity,
            UEntity
        >
        : BuildableEntityOfEntityBuilder<TSelf, TEntity, EntitySet<UEntity>>
        where TSelf   : BuildableEntityOfEntitySetBuilder<
                            TSelf,
                            TEntity,
                            UEntity
                      >
        where TEntity : BuildableEntityOfEntitySet<TEntity, TSelf, UEntity>
        where UEntity : AbstractEntity
    {
        public TSelf Add(UEntity item)
        {
            entity.NestedEntity.items.Add(item);
            return this as TSelf;
        }
    }
}
