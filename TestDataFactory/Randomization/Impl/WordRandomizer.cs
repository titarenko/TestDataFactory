using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace TestDataFactory.Randomization.Impl
{
    /// <summary>
    /// Generates random words.
    /// </summary>
    public class WordRandomizer : IGenericRandomizer<string>
    {
        private readonly IList<string> words;
        private readonly IGenericRandomizer<int> randomizer;

        /// <summary>
        /// Initializes a new instance of the <see cref="WordRandomizer"/> class.
        /// </summary>
        /// <param name="fileName">Path to file with dictionary (each line = one word).</param>
        public WordRandomizer(string fileName)
        {
            try
            {
                words = File.ReadAllLines(fileName);
            }
            catch (FileNotFoundException)
            {
                words = new List<string>();
                var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fileName);
                if (stream == null)
                {
                    throw;
                }
                using (var reader = new StreamReader(stream))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        words.Add(line);
                    }
                }
            }
            randomizer = new IntRandomizer
                {
                    Min = 0,
                    Max = words.Count - 1
                };
        }

        /// <summary>
        /// Not supported.
        /// </summary>
        public string Min
        {
            get { throw new NotSupportedException(); }
            set { throw new NotSupportedException(); }
        }

        /// <summary>
        /// Not supported.
        /// </summary>
        public string Max
        {
            get { throw new NotSupportedException(); }
            set { throw new NotSupportedException(); }
        }

        /// <summary>
        /// Returns random word.
        /// </summary>
        /// <returns>Random word.</returns>
        public string GetRandom()
        {
            return words[randomizer.GetRandom()];
        }
    }
}