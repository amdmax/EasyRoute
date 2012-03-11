using System.Collections.Generic;
using Routing.Rest.Common;

namespace Routing.Rest.Routing
{
    public static class CollectionExtensions
    {
        public static void Add<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            Guard.ThrowIfNull(collection, "collection");
            foreach(var item in items)
            {
                collection.Add(item);
            }
        }

        public static void Add<T>(this ICollection<T> collection, params T[] items)
        {
            Guard.ThrowIfNull(collection, "collection");
            foreach (var item in items)
            {
                collection.Add(item);
            }
        }

        public static void AddNoUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, params KeyValuePair<TKey, TValue>[] keyValuePairs)
        {
            Guard.ThrowIfNull(dictionary, "dictionary");
            foreach (var keyValuePair in keyValuePairs)
            {
                if(!dictionary.ContainsKey(keyValuePair.Key))
                    dictionary.Add(keyValuePair);
            }
        }

        public static void AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, params KeyValuePair<TKey, TValue>[] keyValuePairs)
        {
            Guard.ThrowIfNull(dictionary, "dictionary");
            foreach (var keyValuePair in keyValuePairs)
            {
                if (!dictionary.ContainsKey(keyValuePair.Key))
                    dictionary.Add(keyValuePair);
                else
                {
                    dictionary[keyValuePair.Key] = keyValuePair.Value;
                }
            }
        }
    }
}