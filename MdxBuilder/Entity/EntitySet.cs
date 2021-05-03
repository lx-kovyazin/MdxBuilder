using System.Collections.Generic;
using System.Linq;
using MdxBuilder.Entity.Abstract;

namespace MdxBuilder.Entity
{
    public class EntitySet<TEntity>
        : AbstractEntity
        where TEntity : AbstractEntity
    {
        public List<TEntity> items;

        public EntitySet()
            => items = new List<TEntity>();

        public override string ToString()
            => string.Join(", ", items.Select(i => i.ToString()));
    }
}
