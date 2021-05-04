using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace MdxBuilder.Entity.Function
{
    public abstract class SubroutineFunction<TSelf>
        : Function
        where TSelf : SubroutineFunction<TSelf>
    {
        [SuppressMessage(
            "Usage",
            "CC0057:Unused parameters",
            Justification = "The UnusedParametersAnalyzer bug."
        )]
        protected SubroutineFunction(Category category, string name, params UniqueEntity[] args)
            : base(Type.Subroutine, category, name)
            => Body = $"{Name} ({string.Join(", ", args.Select(e => e.Body))})";
        public static UniqueEntity Do(params UniqueEntity[] args)
            => (Activator.CreateInstance(typeof(TSelf), args) as TSelf).Result;
    }
}
