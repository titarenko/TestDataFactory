namespace TestDataFactory.Randomization
{
    /// <summary>
    /// Generic version of <see cref="IRandomizer"/>.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    public interface IGenericRandomizer<T>
    {
        /// <summary>
        /// Entity from the left boundary of allowed range.
        /// Alternative interpretation is "very bottom".
        /// </summary>
        T Min { get; set; }

        /// <summary>
        /// Entity from the right boundary of allowed range.
        /// Alternative interpretation is "very top".
        /// </summary>
        T Max { get; set; }

        /// <summary>
        /// Returns random entity from specified range (<see cref="Min"/>, <see cref="Max"/>).
        /// </summary>
        /// <returns>Random entity from specified range (<see cref="Min"/>, <see cref="Max"/>).</returns>
        T GetRandom();
    }
}