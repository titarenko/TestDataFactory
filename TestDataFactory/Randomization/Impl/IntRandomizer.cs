namespace TestDataFactory.Randomization.Impl
{
    /// <summary>
    /// Generates random integer numbers from specified range.
    /// </summary>
    public class IntRandomizer : Randomizer<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IntRandomizer"/> class.
        /// </summary>
        /// <remarks>
        /// Default range is [0, 100].
        /// </remarks>
        public IntRandomizer()
        {
            Min = 0;
            Max = 1000;
        }

        /// <summary>
        /// Returns random integer number from specified range.
        /// </summary>
        /// <returns>Random integer number from specified range.</returns>
        public override int GetRandom()
        {
            return Min + (int) ((Max - Min + 1)*random.NextDouble());
        }
    }
}