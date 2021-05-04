namespace MdxBuilder.Entity.Function.Set
{
    /// <summary>
    /// Returns the set of children of a specified member.
    /// </summary>
    public sealed class Children
        : TailFunction<Children>
    {
        public Children(UniqueEntity arg)
            : base(Category.Set, nameof(Children), arg)
        { }
    }
}
