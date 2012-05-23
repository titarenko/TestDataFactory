using System;

namespace TestDataFactory.Randomization
{
    public class DateTimeRandomizer : Randomizer<DateTime>
    {
        public DateTimeRandomizer()
        {
            Min = new DateTime(2000, 1, 1);
            Max = DateTime.Now.Date;
        }

        public override DateTime GetRandom()
        {
            return Min.AddMilliseconds((Max - Min).TotalMilliseconds*random.NextDouble());
        }
    }
}