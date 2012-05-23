using System;
using System.Collections.Generic;
using System.IO;

namespace TestDataFactory.Randomization
{
    public class WordRandomizer : IGenericRandomizer<string>
    {
        private readonly IList<string> words;
        private readonly IGenericRandomizer<int> randomizer;

        public WordRandomizer(string fileName)
        {
            words = File.ReadAllLines(fileName);
            randomizer = new IntRandomizer
                {
                    Min = 0,
                    Max = words.Count - 1
                };
        }

        public string Min
        {
            get { throw new NotSupportedException(); }
            set { throw new NotSupportedException(); }
        }

        public string Max
        {
            get { throw new NotSupportedException(); }
            set { throw new NotSupportedException(); }
        }

        public string GetRandom()
        {
            return words[randomizer.GetRandom()];
        }
    }
}