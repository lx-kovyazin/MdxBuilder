namespace MdxBuilder.Entity.Function.Set
{
    /// <summary>
    /// Returns a set that contains all members, including calculated members,
    /// of the specified dimension, hierarchy, or level.
    /// </summary>
    public sealed class AllMembers
        : TailFunction<AllMembers>
    {
        public AllMembers(UniqueEntity arg)
            : base(Category.Set, nameof(AllMembers), arg)
        { }
    }
}
