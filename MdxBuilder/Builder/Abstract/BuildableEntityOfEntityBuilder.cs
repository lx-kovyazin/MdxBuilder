using MdxBuilder.Entity.Abstract;

namespace MdxBuilder.Builder.Abstract
{
    public abstract class BuildableEntityOfEntityBuilder<TSelf, TEntity, UEntity>
        : BuildableEntityBuilder<TSelf, TEntity>
        where TSelf   : BuildableEntityOfEntityBuilder<TSelf, TEntity, UEntity>
        where TEntity : BuildableEntityOfEntity<TEntity, TSelf, UEntity>
        where UEntity : AbstractEntity
    {
        //protected UEntity nestedEntity;

        //protected BuildableEntityOfEntityBuilder()
        //    => nestedEntity = CreateEntity<UEntity>();

        public virtual TSelf Set(UEntity entity)
        {
            this.entity.NestedEntity = entity;
            return this as TSelf;
        }
    }
}
