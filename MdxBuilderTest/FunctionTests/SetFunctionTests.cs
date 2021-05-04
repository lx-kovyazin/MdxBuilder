using MdxBuilder.Entity;
using MdxBuilder.Entity.Function.Set;
using Xunit;

namespace MdxBuilderTest.FunctionTests
{
    public class SetFunctionTests
    {
        protected const string UE_0 = nameof(ue0);
        protected const string UE_1 = nameof(ue1);

        protected readonly UniqueEntity ue0 = new(UE_0);
        protected readonly UniqueEntity ue1 = new(UE_1);

        [Fact]
        public void MembersTest()
        {
            Assert.Equal(
                $"{UE_0}.Members",
                Members.Do(ue0).ToString()
            );
        }

        [Fact]
        public void AllMembersTest()
        {
            Assert.Equal(
                $"{UE_0}.AllMembers",
                new AllMembers(ue0).ToString()
            );
        }

        [Fact]
        public void ChildrenTest()
        {
            Assert.Equal(
                $"{UE_0}.Children",
                new Children(ue0).ToString()
            );
        }

        [Fact]
        public void CrossjoinTest()
        {
            Assert.Equal(
                $"Crossjoin ({UE_0}, {UE_1})",
                Crossjoin.Do(ue0, ue1).ToString()
            );
        }
    }
}
