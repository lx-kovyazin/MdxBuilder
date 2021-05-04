namespace MdxBuilder.Entity.Function.Set
{
    /// <summary>
    /// Returns the cross product of one or more sets.
    /// </summary>
    public sealed class Crossjoin
        : SubroutineFunction<Crossjoin>
    {
        public Crossjoin(params UniqueEntity[] args)
            : base(Category.Set, nameof(Crossjoin), args)
        { }
    }
}
