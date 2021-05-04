using System;
using System.Diagnostics.CodeAnalysis;

namespace MdxBuilder.Entity.Function
{
    public abstract class TailFunction<TSelf>
        : Function
        where TSelf : TailFunction<TSelf>
    {
        [SuppressMessage(
            "Usage",
            "CC0057:Unused parameters",
            Justification = "The UnusedParametersAnalyzer bug."
        )]
        protected TailFunction(Category category, string name, UniqueEntity arg)
            : base(Type.Tail, category, name)
            => Body = $"{arg}.{Name}";

        public static UniqueEntity Do(UniqueEntity arg)
            => (Activator.CreateInstance(typeof(TSelf), arg) as TSelf).Result;
    }
}
