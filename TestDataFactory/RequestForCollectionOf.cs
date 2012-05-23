using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestDataFactory.Randomization;

namespace TestDataFactory
{
    /// <summary>
    /// Allows to create collection of instances of requested type. Follows Builder pattern.
    /// </summary>
    public class RequestForCollectionOf<T>
    {
        private readonly int collectionSize;
        private readonly IList<string> properties = new List<string>();
        private readonly IDictionary<string, IList<object>> values = new Dictionary<string, IList<object>>();
        private readonly IDictionary<Type, IRandomizer> randomizers = new Dictionary<Type, IRandomizer>
            {
                {typeof (int), new IntRandomizer()},
                {typeof (DateTime), new DateTimeRandomizer()}
            };

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestForCollectionOf&lt;T&gt;"/> class.
        /// </summary>
        public RequestForCollectionOf(int collectionSize)
        {
            this.collectionSize = collectionSize;
            properties = new List<string>();
            values = new Dictionary<string, IList<object>>();
        }

        /// <summary>
        /// Specifies property to fill during creation of each instance.
        /// </summary>
        public RequestForCollectionOf<T> FillProperty<TProperty>(Expression<Func<T, TProperty>> selector)
        {
            properties.Add(((MemberExpression)selector.Body).Member.Name);
            return this;
        }

        /// <summary>
        /// Specifies values to fill given property with. 
        /// Each value will be used for corresponding object instance creation.
        /// If values count is less than objects count, then they will be cycled.
        /// </summary>
        public RequestForCollectionOf<T> WithValues<TValue>(params TValue[] values)
        {
            this.values.Add(properties.Last(), values.Cast<object>().ToList());
            return this;
        }

        public RequestForCollectionOf<T> WithValues<TValue>(Func<int, TValue> generator)
        {
            return WithValues(Enumerable.Range(0, collectionSize).Select(generator).ToArray());
        }

        public RequestForCollectionOf<T> UsingRandomizer<TValue>(TValue min, TValue max)
        {
            var type = typeof(T).GetProperty(properties.Last()).PropertyType;
            var randomizer = (IGenericRandomizer<TValue>)randomizers[type];
            randomizer.Min = min;
            randomizer.Max = max;
            return WithValues(Enumerable.Range(0, collectionSize).Select(x => randomizer.GetRandom()).ToArray());
        }

        public RequestForCollectionOf<T> UsingRandomizer<TValue>()
        {
            var type = typeof (T).GetProperty(properties.Last()).PropertyType;
            var randomizer = (IGenericRandomizer<TValue>) randomizers[type];
            return WithValues(Enumerable.Range(0, collectionSize).Select(x => randomizer.GetRandom()).ToArray());
        }

        /// <summary>
        /// Builds and returns collection of instances.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> Go()
        {
            var properties = typeof(T).GetProperties()
                .Where(x => this.properties.Contains(x.Name))
                .ToDictionary(x => x.Name, x => x);

            return Enumerable.Range(0, collectionSize).Select(
                i =>
                    {
                        var instance = Activator.CreateInstance<T>();
                        foreach (var property in this.properties)
                        {
                            var values = this.values[property];
                            properties[property].SetValue(instance, values[i % values.Count], null);
                        }
                        return instance;
                    });
        }
    }
}