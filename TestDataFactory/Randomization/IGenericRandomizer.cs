namespace TestDataFactory.Randomization
{
    public interface IGenericRandomizer<T>
    {
        T Min { get; set; }
        T Max { get; set; }

        T GetRandom();
    }
}