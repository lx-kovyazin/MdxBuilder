using MdxBuilder.Builder;
using MdxBuilder.Entity.Abstract;

namespace MdxBuilder.Entity
{
    public class Set
        : BuildableEntityOfBuildableEntitySet<
            Set,
            SetBuilder,
            Tuple,
            TupleBuilder
        >
    { }
}
