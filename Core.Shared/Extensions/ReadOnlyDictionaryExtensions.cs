using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Core.Shared.Extensions
{
    public static class ReadOnlyDictionaryExtensions
    {
        public static IReadOnlyDictionary<TKey, IReadOnlyCollection<TValue>> AsReadOnly<TKey, TValue>(this IDictionary<TKey, List<TValue>> input)
            where TKey : notnull
        {
            var readOnly = new Dictionary<TKey, IReadOnlyCollection<TValue>>();

            foreach (var entry in input ?? throw new ArgumentNullException())
            {
                readOnly.Add(entry.Key, new ReadOnlyCollection<TValue>(entry.Value.AsReadOnly()));
            }

            return new ReadOnlyDictionary<TKey, IReadOnlyCollection<TValue>>(readOnly);
        }

        public static IReadOnlyDictionary<TKey, IReadOnlyCollection<TValue>> AsReadOnly<TKey, TValue>(this IDictionary<TKey, IList<TValue>> input) => AsReadOnly(input.ToDictionary(x => x.Key, x => x.Value.ToList()));
        public static IReadOnlyDictionary<TKey, IReadOnlyCollection<TValue>> AsReadOnly<TKey, TValue>(this IDictionary<TKey, IEnumerable<TValue>> input) => AsReadOnly(input.ToDictionary(x => x.Key, x => x.Value.ToList()));
        public static IReadOnlyDictionary<TKey, IReadOnlyCollection<TValue>> AsReadOnly<TKey, TValue>(this IDictionary<TKey, ICollection<TValue>> input) => AsReadOnly(input.ToDictionary(x => x.Key, x => x.Value.ToList()));
        public static IReadOnlyDictionary<TKey, IReadOnlyCollection<TValue>> AsReadOnly<TKey, TValue>(this IDictionary<TKey, HashSet<TValue>> input) => AsReadOnly(input.ToDictionary(x => x.Key, x => x.Value.ToList()));
        public static IReadOnlyDictionary<TKey, IReadOnlyCollection<TValue>> AsReadOnly<TKey, TValue>(this IDictionary<TKey, Collection<TValue>> input) => AsReadOnly(input.ToDictionary(x => x.Key, x => x.Value.ToList()));
    }
}
