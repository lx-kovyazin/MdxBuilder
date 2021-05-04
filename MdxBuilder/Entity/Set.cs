using MdxBuilder.Builder;
using MdxBuilder.Entity.Abstract;

namespace MdxBuilder.Entity
{
    public sealed class Set
        : BuildableEntityOfBuildableEntitySet<
            Set,
            SetBuilder,
            Tuple,
            TupleBuilder
        >
    { }
}
