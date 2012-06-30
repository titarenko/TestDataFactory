using System;

namespace TestDataFactory.Randomization.Impl
{
    /// <summary>
    /// Generates random dates from specified range.
    /// </summary>
    public class DateTimeRandomizer : Randomizer<DateTime>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimeRandomizer"/> class.
        /// </summary>
        /// <remarks>
        /// Default range is [2000-01-01, Now].
        /// </remarks>
        public DateTimeRandomizer()
        {
            Min = new DateTime(2000, 1, 1);
            Max = DateTime.Now.Date;
        }

        /// <summary>
        /// Returns random date from specified range.
        /// </summary>
        /// <returns>Random date from specified range.</returns>
        public override DateTime GetRandom()
        {
            return Min.AddMilliseconds((Max - Min).TotalMilliseconds*random.NextDouble());
        }
    }
}