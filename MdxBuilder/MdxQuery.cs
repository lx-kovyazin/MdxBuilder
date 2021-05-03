using System;
using System.Collections.Generic;
using System.Text;
using MdxBuilder.Entity.Abstract;
using MdxBuilder.Builder;

namespace MdxBuilder
{
    public static partial class Mdx
    {
        public class Query
            : BuildableEntity<Query, QueryBuilder>
        { }
    }
}
