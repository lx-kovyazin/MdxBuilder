using System.Collections.Generic;
using System.Linq;
using MdxBuilder.Builder.Abstract;
using MdxBuilder.Entity.Abstract;
using MdxBuilder.Entity;
using MdxBuilder.Builder;
using MdxBuilder.Utils;

namespace MdxBuilder
{
    public static partial class Mdx
    {
        public class QueryBuilder
            : BuildableEntityBuilder<QueryBuilder, Query>
        {
            private readonly Dictionary<string, AbstractEntity> entityMap
                = new Dictionary<string, AbstractEntity>
                {
                    //[nameof(With)]   = null,
                    [nameof(Select)] = null,
                    [nameof(From)]   = null,
                    //[nameof(Where)]  = null
                };

            public QueryBuilder Select(SelectExpression select)
            {
                entityMap[nameof(Select)] = select;
                return this;
            }

            public QueryBuilder Select(FluentFunc<SelectExpressionBuilder> selectBuilder)
                => Select(selectBuilder.Invoke(new SelectExpressionBuilder()).Build());

            public QueryBuilder From(FromExpression from)
            {
                entityMap[nameof(From)] = from;
                return this;
            }

            public QueryBuilder From(FluentFunc<FromExpressionBuilder> fromBuilder)
                => From(fromBuilder.Invoke(new FromExpressionBuilder()).Build());

            public override Query Build()
            {
                entityMap.Values.ToList().ForEach(
                    value => bodyBuilder.Append(value.ToString())
                    );

                return base.Build();
            }
        }
    }
}
