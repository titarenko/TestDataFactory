namespace TestDataFactory.Randomization
{
    public interface IRandomizer
    {
        object Min { get; set; }
        object Max { get; set; }

        object GetRandom();
    }
}