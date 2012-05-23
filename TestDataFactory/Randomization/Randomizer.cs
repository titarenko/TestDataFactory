using System;

namespace TestDataFactory.Randomization
{
    public abstract class Randomizer<T> : IRandomizer, IGenericRandomizer<T>
    {
        protected readonly Random random;

        protected Randomizer() : this((int)DateTime.Now.Ticks)
        {
        }

        protected Randomizer(int seed)
        {
            random = new Random(seed);
        }

        public T Min { get; set; }

        object IRandomizer.Max
        {
            get { return Max; }
            set { Max = (T)value; }
        }

        object IRandomizer.GetRandom()
        {
            return GetRandom();
        }

        object IRandomizer.Min
        {
            get { return Min; }
            set { Min = (T)value; }
        }

        public T Max { get; set; }

        public abstract T GetRandom();
    }
}