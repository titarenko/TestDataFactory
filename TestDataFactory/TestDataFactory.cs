using TestDataFactory.Randomization;

namespace TestDataFactory
{
    /// <summary>
    /// Allows easily create test data.
    /// </summary>
    public class TestDataFactory
    {
        private readonly WordRandomizer nounRandomizer = new WordRandomizer("Randomization/EnglishNouns.txt");
        private readonly WordRandomizer adjectiveRandomizer = new WordRandomizer("Randomization/EnglishAdjectives.txt");
        private readonly WordRandomizer nameRandomizer = new WordRandomizer("Randomization/EnglishNames.txt");
        private readonly WordRandomizer surnameRandomizer = new WordRandomizer("Randomization/EnglishSurnames.txt");

        public IGenericRandomizer<string> Noun
        {
            get { return nounRandomizer; }
        }

        public IGenericRandomizer<string> Adjective
        {
            get { return adjectiveRandomizer; }
        }

        public IGenericRandomizer<string> Name
        {
            get { return nameRandomizer; }
        }

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