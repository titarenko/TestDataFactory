using TestDataFactory.Randomization;
using TestDataFactory.Randomization.Impl;

namespace TestDataFactory
{
    /// <summary>
    /// Allows easy creation of large amounts of test data.
    /// </summary>
    public class TestDataFactory
    {
        private const string @namespace = "TestDataFactory.Randomization.Impl.";

        private readonly WordRandomizer nounRandomizer = new WordRandomizer(@namespace + "EnglishNouns.txt");
        private readonly WordRandomizer adjectiveRandomizer = new WordRandomizer(@namespace + "EnglishAdjectives.txt");
        private readonly WordRandomizer nameRandomizer = new WordRandomizer(@namespace + "EnglishNames.txt");
        private readonly WordRandomizer surnameRandomizer = new WordRandomizer(@namespace + "EnglishSurnames.txt");

        /// <summary>
        /// Obtains randomizer which returns English nouns.
        /// </summary>
        public IGenericRandomizer<string> Noun
        {
            get { return nounRandomizer; }
        }

        /// <summary>
        /// Obtains randomizer which returns English adjectives.
        /// </summary>
        public IGenericRandomizer<string> Adjective
        {
            get { return adjectiveRandomizer; }
        }

        /// <summary>
        /// Obtains randomizer which returns English names (first names).
        /// </summary>
        public IGenericRandomizer<string> Name
        {
            get { return nameRandomizer; }
        }

        /// <summary>
        /// Obtains randomizer which returns English surnames (last names).
        /// </summary>
        public IGenericRandomizer<string> Surname
        {
            get { return surnameRandomizer; }
        }

        /// <summary>
        /// Returns builder to create collection of instances of requested type.
        /// </summary>
        public RequestForCollectionOf<T> CreateMany<T>(int howMany)
        {
            return new RequestForCollectionOf<T>(howMany);
        }
    }
}