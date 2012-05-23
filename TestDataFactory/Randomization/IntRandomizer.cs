namespace TestDataFactory.Randomization
{
    public class IntRandomizer : Randomizer<int>
    {
        public IntRandomizer()
        {
            Min = 0;
            Max = 1000;
        }

        public override int GetRandom()
        {
            return Min + (int) ((Max - Min + 1)*random.NextDouble());
        }
    }
}