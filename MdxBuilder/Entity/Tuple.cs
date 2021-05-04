using MdxBuilder.Builder;
using MdxBuilder.Entity.Abstract;

namespace MdxBuilder.Entity
{
    public sealed class Tuple
        : BuildableEntityOfEntitySet<Tuple, TupleBuilder, UniqueEntity>
    { }
}
