using System.Collections.Generic;
using MdxBuilder.Builder;
using MdxBuilder.Entity.Abstract;

namespace MdxBuilder.Entity
{
    public sealed class AliasedAxis
        : BuildableEntityOfBuildableEntity<
            AliasedAxis,
            AliasedAxisBuilder,
            Set,
            SetBuilder
        >
    {
        public enum Alias
            : sbyte
        {
            Columns = 0,
            Rows,
            Pages,
            Sections,
            Chapters
        }

        private readonly static Dictionary<Alias, string> aliasMap
            = new Dictionary<Alias, string>
            {
                [Alias.Columns]  = "COLUMNS",
                [Alias.Rows]     = "ROWS",
                [Alias.Pages]    = "PAGES",
                [Alias.Sections] = "SECTIONS",
                [Alias.Chapters] = "CHAPTERS"
            };

        internal Axis axis;

        public string AliasedDimension => aliasMap[(Alias)axis.Dimension];
    }
}
