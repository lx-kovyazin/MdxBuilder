using System;
using System.Collections.Generic;
using System.Linq;
using MdxBuilder.Entity;
using MdxBuilder.Entity.Operator;

namespace MdxBuilder.Utils
{
    public static class Extentions
    {
        public static void AddToCollection<T>(
            this T item,
            ICollection<T> collection,
            Predicate<T> predicate
            )
        {
            if (predicate.Invoke(item)) collection.Add(item);
        }

        public static void AddToCollectionIfNotNull<T>(
            this T item,
            ICollection<T> collection
            )
            => item.AddToCollection(collection, it => it != null);

        public static void AddIfNotNull<T>(
            this ICollection<T> collection,
            params T[] items
            )
            => items.ToList().ForEach(
                   item => item.AddToCollectionIfNotNull(collection)
            );

        public static Operand AsOp(this UniqueEntity uniqueEntity)
            => new Operand(uniqueEntity);

        public static Operand[] AsOp(this UniqueEntity[] uniqueEntities)
            => uniqueEntities.Select(ue => ue.AsOp()).ToArray();
    }
}
