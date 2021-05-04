using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

        [SuppressMessage(
            "Usage",
            "CC0057:Unused parameters",
            Justification = "The UnusedParametersAnalyzer bug."
        )]
        public EntitySet(IEnumerable<TEntity> entities)
            => items = entities.ToList();

        public override string ToString()
            => string.Join(", ", items.Select(i => i.ToString()));
    }
}
