namespace MdxBuilder.Entity.Operator
{
    public class Operand
        : UniqueEntity
    {
        public Operand()
            : base()
        { }

        public Operand(string uniqueName)
            : base(uniqueName)
        { }

        public Operand(UniqueEntity uniqueEntity)
            : base(uniqueEntity)
        { }
    }
}
