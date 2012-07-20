using System;
using NUnit.Framework;
using System.Linq;

namespace TestDataFactory.Tests
{
    [TestFixture]
    public class RequestForCollectionOfTests
    {
        public class Entity
        {
            public string Name { get; set; }

            public DateTime CreationDate { get; set; }
        }

        // TODO: write tests, not usage example
        [Test]
        public void ApiUsageExample()
        {
            var factory = new Factory();

            var collection = factory.CreateMany<Entity>(100)
                .FillProperty(x => x.Name).WithValues(x => factory.Noun.GetRandom())
                .FillProperty(x => x.CreationDate).WithValues(new DateTime(2000, 1, 2), new DateTime(2001, 2, 3))
                .Go().ToList();

            Assert.AreEqual(100, collection.Count);

            Assert.IsNotNullOrEmpty(collection[0].Name); // please, pay attention to indexes - values were cycled
            Assert.IsNotNullOrEmpty(collection[2].Name);

            Assert.AreEqual(new DateTime(2000, 1, 2), collection[0].CreationDate); // please, pay attention to indexes - values were cycled
            Assert.AreEqual(new DateTime(2000, 1, 2), collection[2].CreationDate);
        }
    }
}