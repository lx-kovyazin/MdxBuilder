using System.Diagnostics;
using MdxBuilder;
using MdxBuilder.Builder;
using MdxBuilder.Entity;
using MdxBuilder.Entity.Operator.Set;
using MdxBuilder.Utils;
using Xunit;

namespace MdxBuilderTest
{
    public class UnitTest1
    {
        private readonly UniqueEntity ui0 = new() { UniqueName = nameof(ui0) };
        private readonly UniqueEntity ui1 = new() { UniqueName = nameof(ui1) };
        private readonly UniqueEntity ui2 = new() { UniqueName = nameof(ui2) };
        private readonly UniqueEntity ui3 = new() { UniqueName = nameof(ui3) };
        private readonly UniqueEntity ui4 = new() { UniqueName = nameof(ui4) };
        private readonly UniqueEntity ui5 = new() { UniqueName = nameof(ui5) };
        private readonly UniqueEntity ui6 = new() { UniqueName = nameof(ui6) };
        private readonly UniqueEntity ui7 = new() { UniqueName = nameof(ui7) };
        private readonly UniqueEntity ui8 = new() { UniqueName = nameof(ui8) };
        private readonly Cube cube        = new() { UniqueName = nameof(cube) };

        [Fact]
        public void TupleBuilderTest()
        {
            var expectedBody = $"({ui0}, {ui1}, {ui2})";
            var actualBody = new TupleBuilder()
                .Add(ui0).Add(ui1).Add(ui2)
                .Build()
                .Body
                ;

            Assert.Equal(expectedBody, actualBody);
        }

        [Fact]
        public void SetBuilderTest()
        {
            var expectedBody = $"{{({ui0}, {ui1}, {ui2}), ({ui3}, {ui4}, {ui5})}}";
            var actualBody = new SetBuilder()
                .Add(new TupleBuilder().Add(ui0).Add(ui1).Add(ui2).Build())
                .Add(tb => tb.Add(ui3).Add(ui4).Add(ui5))
                .Build()
                .Body
                ;

            Assert.Equal(expectedBody, actualBody);
        }

        [Fact]
        public void AxisBuilderTest()
        {
            var expectedBody = $"{{({ui0}, {ui1}, {ui2}), ({ui3}, {ui4}, {ui5})}} ON 1";
            var actualBody = new AxisBuilder()
                .SetDimension(1)
                .Set(sb => sb
                    .Add(new TupleBuilder().Add(ui0).Add(ui1).Add(ui2).Build())
                    .Add(tb => tb.Add(ui3).Add(ui4).Add(ui5))
                )
                .Build()
                .Body
                ;

            Assert.Equal(expectedBody, actualBody);
        }

        [Fact]
        public void AliasedAxisBuilderTest()
        {
            var expectedBody = $"{{({ui0}, {ui1}, {ui2}), ({ui3}, {ui4}, {ui5})}} ON ROWS";
            var actualBody = new AliasedAxisBuilder()
                .SetDimension(AliasedAxis.Alias.Rows)
                .Set(sb => sb
                    .Add(new TupleBuilder().Add(ui0).Add(ui1).Add(ui2).Build())
                    .Add(tb => tb.Add(ui3).Add(ui4).Add(ui5))
                )
                .Build()
                .Body
                ;

            Assert.Equal(expectedBody, actualBody);
        }

        [Fact]
        public void SelectExpressionBuilderTest()
        {
            var expectedBody = "SELECT"
                             + $" {{({ui0}, {ui1}, {ui2}), ({ui3}, {ui4}, {ui5})}} ON COLUMNS,"
                             + $" {{({ui6}, {ui7}, {ui8})}} ON ROWS ";
            var actualBody = new SelectExpressionBuilder()
                .Add(aab => aab
                    .SetDimension(AliasedAxis.Alias.Columns)
                    .Set(sb => sb
                        .Add(new TupleBuilder().Add(ui0).Add(ui1).Add(ui2).Build())
                        .Add(tb => tb.Add(ui3).Add(ui4).Add(ui5))
                    )
                )
                .Add(aab => aab
                    .SetDimension(AliasedAxis.Alias.Rows)
                    .Set(sb => sb.Add(tb => tb.Add(ui6).Add(ui7).Add(ui8)))
                )
                .Build()
                .Body
                ;

            Assert.Equal(expectedBody, actualBody);
        }

        [Fact]
        public void SubCubeBuilderCubeTest()
        {
            var expectedBody = $"{cube}";
            var actualBody = new SubCubeBuilder().Set(cube).Build().Body;

            Assert.Equal(expectedBody, actualBody);
        }

        [Fact]
        public void SubCubeBuilderSubCubeTest()
        {
            var expectedBody = $"SELECT"
                             + $" {{({ui0}, {ui1}), ({ui2}, {ui3})}} ON COLUMNS,"
                             + $" {{({ui4}, {ui5}), ({ui6}, {ui7})}} ON ROWS "
                             + $"FROM {cube}"
                             ;
            var actualBody = new SubCubeBuilder()
                .Set(scb => scb
                    .Select(seb => seb
                        .Add(aab => aab
                            .SetDimension(AliasedAxis.Alias.Columns)
                            .Set(sb => sb
                                .Add(tb => tb
                                    .Add(ui0)
                                    .Add(ui1)
                                )
                                .Add(tb => tb
                                    .Add(ui2)
                                    .Add(ui3)
                                )
                            )
                        )
                        .Add(aab => aab
                            .SetDimension(AliasedAxis.Alias.Rows)
                            .Set(sb => sb
                                .Add(tb => tb
                                    .Add(ui4)
                                    .Add(ui5)
                                )
                                .Add(tb => tb
                                    .Add(ui6)
                                    .Add(ui7)
                                )
                            )
                        )
                    )
                    .From(feb => feb.Set(scb => scb.Set(cube)))
                )
                .Build()
                .Body;

            Assert.Equal(expectedBody, actualBody);
        }

        [Fact]
        public void FromExpressionBuilderCubeTest()
        {
            var expectedBody = $"FROM SELECT"
                             + $" {{({ui0}, {ui1}), ({ui2}, {ui3})}} ON COLUMNS,"
                             + $" {{({ui4}, {ui5}), ({ui6}, {ui7})}} ON ROWS "
                             + $"FROM {cube}"
                             ;
            var subCube = new SubCubeBuilder()
                .Set(scb => scb
                    .Select(seb => seb
                        .Add(aab => aab
                            .SetDimension(AliasedAxis.Alias.Columns)
                            .Set(sb => sb
                                .Add(tb => tb
                                    .Add(ui0)
                                    .Add(ui1)
                                )
                                .Add(tb => tb
                                    .Add(ui2)
                                    .Add(ui3)
                                )
                            )
                        )
                        .Add(aab => aab
                            .SetDimension(AliasedAxis.Alias.Rows)
                            .Set(sb => sb
                                .Add(tb => tb
                                    .Add(ui4)
                                    .Add(ui5)
                                )
                                .Add(tb => tb
                                    .Add(ui6)
                                    .Add(ui7)
                                )
                            )
                        )
                    )
                    .From(feb => feb.Set(scb => scb.Set(cube)))
                )
                .Build();

            var actualBody = new FromExpressionBuilder()
                .Set(subCube)
                .Build()
                .Body
                ;

            Assert.Equal(expectedBody, actualBody);
        }

        [Fact]
        public void FromExpressionBuilderSubCubeTest()
        {
            var expectedBody = $"FROM {cube}";
            var actualBody = new FromExpressionBuilder()
                .Set(cb => cb.Set(cube))
                .Build()
                .Body
                ;

            Assert.Equal(expectedBody, actualBody);
        }

        [Fact]
        public void QueryBuilderTest()
        {
            var expectedQuery = "SELECT"
                              + $" {{({ui0} * {ui1}, {ui1}, {ui2}),"
                              + $" ({ui3}, {ui4}, {ui5})}} ON COLUMNS,"
                              + $" {{({ui6}, {ui7}, {ui8})}} ON ROWS"
                              + $" FROM cube";
            var actualQuery = Mdx.Create()
                .Select(select => select
                    .Add(cols => cols
                        .SetDimension(AliasedAxis.Alias.Columns)
                        .Set(set => set
                            .Add(tuple => tuple
                                .Add(Crossjoin.Do(ui0.AsOp(), ui1.AsOp()))
                                .Add(ui1)
                                .Add(ui2)
                            )
                            .Add(tuple => tuple
                                .Add(ui3)
                                .Add(ui4)
                                .Add(ui5)
                            )
                        )
                    )
                    .Add(rows => rows
                        .SetDimension(AliasedAxis.Alias.Rows)
                        .Set(set => set
                            .Add(tuple => tuple
                                .Add(ui6)
                                .Add(ui7)
                                .Add(ui8)
                            )
                        )
                    )
                )
                .From(fb => fb.Set(scb => scb.Set(cube)))
                .Build()
                .Body;
            Debug.Print($"Mdx query:\n{actualQuery}");
            Assert.Equal(actualQuery, expectedQuery);
        }
    }
}
