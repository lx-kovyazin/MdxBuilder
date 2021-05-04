namespace MdxBuilder.Entity.Function.Set
{
    /// <summary>
    /// Returns the set of members in a dimension, level, or hierarchy.
    /// </summary>
    public sealed class Members
        : TailFunction<Members>
    {
        public Members(UniqueEntity arg)
            : base(Category.Set, nameof(Members), arg)
        { }
    }
}
