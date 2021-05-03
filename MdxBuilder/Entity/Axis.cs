using System;
using MdxBuilder.Builder;
using MdxBuilder.Entity.Abstract;

namespace MdxBuilder.Entity
{
    public sealed class Axis
        : BuildableEntityOfBuildableEntity<
            Axis,
            AxisBuilder,
            Set,
            SetBuilder
        >
    {
        private sbyte dimension;

        public sbyte Dimension
        {
            get => dimension;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                        nameof(Dimension),
                        value,
                        $"{nameof(Dimension)} must be at range from 0 to 127."
                    );
                dimension = value;
            }
        }
    }
}
