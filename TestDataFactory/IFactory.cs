using TestDataFactory.Randomization;

namespace TestDataFactory
{
    public interface IFactory
    {
        /// <summary>
        /// Obtains randomizer which returns English nouns.
        /// </summary>
        IGenericRandomizer<string> Noun { get; }

        /// <summary>
        /// Obtains randomizer which returns English adjectives.
        /// </summary>
        IGenericRandomizer<string> Adjective { get; }

        /// <summary>
        /// Obtains randomizer which returns English names (first names).
        /// </summary>
        IGenericRandomizer<string> Name { get; }

        /// <summary>
        /// Obtains randomizer which returns English surnames (last names).
        /// </summary>
        IGenericRandomizer<string> Surname { get; }

        /// <summary>
        /// Returns builder to create collection of instances of requested type.
        /// </summary>
        RequestForCollectionOf<T> CreateMany<T>(int howMany);
    }
}