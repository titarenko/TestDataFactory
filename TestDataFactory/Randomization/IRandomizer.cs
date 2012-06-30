namespace TestDataFactory.Randomization
{
    /// <summary>
    /// Defines entity which can return random entities from specified range.
    /// </summary>
    public interface IRandomizer
    {
        /// <summary>
        /// Entity from the left boundary of allowed range.
        /// Alternative interpretation is "very bottom".
        /// </summary>
        object Min { get; set; }

        /// <summary>
        /// Entity from the right boundary of allowed range.
        /// Alternative interpretation is "very top".
        /// </summary>
        object Max { get; set; }

        /// <summary>
        /// Returns random entity from specified range (<see cref="Min"/>, <see cref="Max"/>).
        /// </summary>
        /// <returns>Random entity from specified range (<see cref="Min"/>, <see cref="Max"/>).</returns>
        object GetRandom();
    }
}