using System;

namespace TestDataFactory.Randomization
{
    /// <summary>
    /// Base implementation of both <see cref="IRandomizer"/> and <see cref="IGenericRandomizer{T}"/>.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    public abstract class Randomizer<T> : IRandomizer, IGenericRandomizer<T>
    {
        /// <summary>
        /// Standard randomizer from FCL (<see cref="Random"/>).
        /// </summary>
        protected readonly Random random;

        /// <summary>
        /// Initializes a new instance of the <see cref="Randomizer&lt;T&gt;"/> class.
        /// </summary>
        protected Randomizer() : this((int)DateTime.Now.Ticks)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Randomizer&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="seed">The seed to set up the randomizer.</param>
        protected Randomizer(int seed)
        {
            random = new Random(seed);
        }

        /// <summary>
        /// Entity from the left boundary of allowed range.
        /// Alternative interpretation is "very bottom".
        /// </summary>
        public T Min { get; set; }

        /// <summary>
        /// Entity from the right boundary of allowed range.
        /// Alternative interpretation is "very top".
        /// </summary>
        object IRandomizer.Max
        {
            get { return Max; }
            set { Max = (T)value; }
        }

        /// <summary>
        /// Returns random entity from specified range (<see cref="Min"/>, <see cref="Max"/>).
        /// </summary>
        /// <returns>
        /// Random entity from specified range (<see cref="Min"/>, <see cref="Max"/>).
        /// </returns>
        object IRandomizer.GetRandom()
        {
            return GetRandom();
        }

        /// <summary>
        /// Entity from the left boundary of allowed range.
        /// Alternative interpretation is "very bottom".
        /// </summary>
        object IRandomizer.Min
        {
            get { return Min; }
            set { Min = (T)value; }
        }

        /// <summary>
        /// Entity from the right boundary of allowed range.
        /// Alternative interpretation is "very top".
        /// </summary>
        public T Max { get; set; }

        /// <summary>
        /// Returns random entity from specified range (<see cref="Min"/>, <see cref="Max"/>).
        /// </summary>
        /// <returns>Random entity from specified range (<see cref="Min"/>, <see cref="Max"/>).</returns>
        public abstract T GetRandom();
    }
}