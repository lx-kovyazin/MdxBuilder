using System;
using System.Diagnostics.CodeAnalysis;
using MdxBuilder.Entity.Abstract;

namespace MdxBuilder.Entity
{
    public class UniqueEntity
        : AbstractEntity, IUnique
    {
        public string UniqueName
        {
            get => Body;
            set => Body = value;
        }

        public UniqueEntity()
            : this(string.Empty)
        { }

        [SuppressMessage(
            "Usage",
            "CC0057:Unused parameters",
            Justification = "The UnusedParametersAnalyzer bug."
        )]
        public UniqueEntity(string uniqueName)
            => UniqueName = uniqueName
                         ?? throw new ArgumentNullException(nameof(uniqueName));

        public UniqueEntity(UniqueEntity uniqueEntity)
            : this(uniqueEntity.UniqueName)
        { }

        public override string ToString()
            => UniqueName;

        public static UniqueEntity Empty => new UniqueEntity();
    }
}
