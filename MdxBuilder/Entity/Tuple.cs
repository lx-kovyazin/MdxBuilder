using MdxBuilder.Builder;
using MdxBuilder.Entity.Abstract;

namespace MdxBuilder.Entity
{
    public class Tuple
        : BuildableEntityOfEntitySet<Tuple, TupleBuilder, UniqueEntity>
    { }
}
