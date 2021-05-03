using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MdxBuilder
{
    public class EntityType<T>
        where T : Entity
    {
        private readonly Type type;

        public EntityType()
            => type = typeof(T);

        public T CreateInstance(params object[] args)
            => Activator.CreateInstance(type, args) as T;
    }

    public abstract class BuildableEntityBuilder<TSelf, TEntity>
        where TSelf   : BuildableEntityBuilder<TSelf, TEntity>
        where TEntity : BuildableEntity<TEntity, TSelf>
    {
        protected StringBuilder bodyBuilder;
        protected TEntity entity;

        protected BuildableEntityBuilder()
        {
            bodyBuilder = new StringBuilder();
            entity = CreateEntity<TEntity>();
        }

        protected static IEntity CreateEntity<IEntity>(TSelf self)
            where IEntity : TEntity
            => Activator.CreateInstance(typeof(IEntity), self) as IEntity;

        protected virtual IEntity CreateEntity<IEntity>()
            where IEntity : TEntity
            => CreateEntity<IEntity>(this as TSelf);

        public abstract TEntity Build();
    }

    public abstract class BuildableEntity<TSelf, TBuilder>
        : Entity
        where TSelf    : BuildableEntity<TSelf, TBuilder>
        where TBuilder : BuildableEntityBuilder<TBuilder, TSelf>
    {
        private readonly TBuilder builder;

        protected BuildableEntity(TBuilder builder)
            => this.builder = builder;

        public override string ToString()
            => builder.Build().Body;
    }

    public delegate T FluentFunc<T>(T arg);

    public abstract class BuildableEntityOfEntity<TSelf, TBuilder, UEntity>
        : BuildableEntity<TSelf, TBuilder>
        where TSelf    : BuildableEntityOfEntity<TSelf, TBuilder, UEntity>
        where TBuilder : BuildableEntityOfEntityBuilder<TBuilder, TSelf, UEntity>
        where UEntity  : Entity
    {
        protected UEntity nestedEntity;

        protected BuildableEntityOfEntity(TBuilder builder)
            : base(builder)
        { }
    }

    public abstract class BuildableEntityOfEntityBuilder<TSelf, TEntity, UEntity>
        : BuildableEntityBuilder<TSelf, TEntity>
        where TSelf   : BuildableEntityOfEntityBuilder<TSelf, TEntity, UEntity>
        where TEntity : BuildableEntityOfEntity<TEntity, TSelf, UEntity>
        where UEntity : Entity
    {
        protected UEntity nestedEntity;

        protected BuildableEntityOfEntityBuilder(UEntity nestedEntity)
            => this.nestedEntity = nestedEntity;

        public TSelf Set(UEntity e)
        {
            return this as TSelf;
        }
    }

    public class EntitySet<TEntity>
        : Entity
        where TEntity : Entity
    {
        public List<TEntity> items;

        public EntitySet()
            => items = new List<TEntity>();

        public override string ToString()
            => string.Join(",\n", items.Select(i => i.ToString()));
    }

    public abstract class BuildableEntityOfEntitySet<TSelf, TBuilder, UEntity>
        : BuildableEntity<TSelf, TBuilder>
        where TSelf    : BuildableEntityOfEntitySet<TSelf, TBuilder, UEntity>
        where TBuilder : BuildableEntityOfEntitySetBuilder<TBuilder, TSelf, UEntity>
        where UEntity  : Entity
    {
        public List<UEntity> items;

        protected BuildableEntityOfEntitySet(TBuilder builder)
            : base(builder)
            => items = new List<UEntity>();
    }

    public abstract class BuildableEntityOfEntitySetBuilder<TSelf, TEntity, UEntity>
        : BuildableEntityBuilder<TSelf, TEntity>
        where TSelf   : BuildableEntityOfEntitySetBuilder<TSelf, TEntity, UEntity>
        where TEntity : BuildableEntityOfEntitySet<TEntity, TSelf, UEntity>
        where UEntity : Entity
    {
        public TSelf Add(UEntity item)
        {
            entity.items.Add(item);
            return this as TSelf;
        }
    }

    public abstract class BuildableEntityOfBuildableEntitySet<TSelf, TBuilder, UEntity, UEntityBuilder>
        : BuildableEntityOfEntitySet<TSelf, TBuilder, UEntity>
        where TSelf          : BuildableEntityOfBuildableEntitySet<TSelf, TBuilder, UEntity, UEntityBuilder>
        where TBuilder       : BuildableEntityOfBuildableEntitySetBuilder<TBuilder, TSelf, UEntityBuilder, UEntity>
        where UEntity        : BuildableEntity<UEntity, UEntityBuilder>
        where UEntityBuilder : BuildableEntityBuilder<UEntityBuilder, UEntity>
    {
        protected BuildableEntityOfBuildableEntitySet(TBuilder builder)
            : base(builder)
        { }
    }

    public abstract class BuildableEntityOfBuildableEntitySetBuilder<TSelf, TEntity, UEntityBuilder, UEntity>
        : BuildableEntityOfEntitySetBuilder<TSelf, TEntity, UEntity>
        where TSelf          : BuildableEntityOfBuildableEntitySetBuilder<TSelf, TEntity, UEntityBuilder, UEntity>
        where TEntity        : BuildableEntityOfBuildableEntitySet<TEntity, TSelf, UEntity, UEntityBuilder>
        where UEntityBuilder : BuildableEntityBuilder<UEntityBuilder, UEntity>
        where UEntity        : BuildableEntity<UEntity, UEntityBuilder>
    {
        public TSelf Add(FluentFunc<UEntityBuilder> builder)
            => Add(builder.Invoke(Activator.CreateInstance<UEntityBuilder>()).Build());
    }

    public class Set
        : BuildableEntityOfBuildableEntitySet<Set, SetBuilder, Tuple, TupleBuilder>
    {
        public Set(SetBuilder builder)
            : base(builder)
        { }
    }

    public class SetBuilder
        : BuildableEntityOfBuildableEntitySetBuilder<SetBuilder, Set, TupleBuilder, Tuple>
    {
        public override Set Build()
        {
            bodyBuilder.Clear();
            bodyBuilder.Append("{");
            bodyBuilder.Append(
                string.Join(",", entity.items.Select(i => $"\n  {i.Body}"))
            );
            bodyBuilder.Append("\n}");
            entity.Body = bodyBuilder.ToString();
            return entity;
        }
    }

    public class Tuple
        : BuildableEntityOfEntitySet<Tuple, TupleBuilder, UniqueItem>
    {
        public Tuple(TupleBuilder builder)
            : base(builder)
        { }
    }

    public class TupleBuilder
        : BuildableEntityOfEntitySetBuilder<TupleBuilder, Tuple, UniqueItem>
    {
        public override Tuple Build()
        {
            bodyBuilder.Clear();
            bodyBuilder.Append("(");
            bodyBuilder.Append(
                string.Join(",", entity.items.Select(i => $"\n  {i.UniqueName}"))
            );
            bodyBuilder.Append("\n)");
            entity.Body = bodyBuilder.ToString();
            return entity;
        }
    }
}
