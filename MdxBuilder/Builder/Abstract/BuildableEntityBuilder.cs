using System;
using System.Text;
using MdxBuilder.Entity.Abstract;

namespace MdxBuilder.Builder.Abstract
{
    public abstract class BuildableEntityBuilder<TSelf, TEntity>
        where TSelf   : BuildableEntityBuilder<TSelf, TEntity>
        where TEntity : BuildableEntity<TEntity, TSelf>
    {
        private bool isAlreadyBuilded;

        protected StringBuilder bodyBuilder;
        protected TEntity entity;

        protected BuildableEntityBuilder()
        {
            bodyBuilder = new StringBuilder();
            entity      = Activator.CreateInstance<TEntity>();
        }

        public virtual TEntity Build()
        {
            if (!isAlreadyBuilded)
            {
                entity.Body = bodyBuilder.ToString();
                isAlreadyBuilded = true;
            }

            return entity;
        }
    }
}
