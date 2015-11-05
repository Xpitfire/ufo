using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace FH.SEv.UFO.Server.Model.Helper
{
    /// <summary>
    /// Delegate to create filters for APIs, such as DAO.
    /// </summary>
    /// <typeparam name="TResult">Type of the resulting collection.</typeparam>
    /// <typeparam name="TCriteria">Type of the filter criteria.</typeparam>
    /// <param name="enumerable">Collection of elements.</param>
    /// <param name="criteria">The data component used to filter.</param>
    /// <returns>A collection of TResult values.</returns>
    public delegate IEnumerable<TResult> Filter<TResult, in TCriteria>(IEnumerable<TResult> enumerable, TCriteria criteria);

    public static class Extensions
    {
        /// <summary>
        /// Add multiple items from a collection to the concurrent collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">Concurrent collection for adding.</param>
        /// <param name="toAdd">Normal collection from where the elements will be add.</param>
        public static void AddRange<T>(this BlockingCollection<T> collection, IEnumerable<T> toAdd)
        {
            toAdd.AsParallel().ForAll(collection.Add);
        }
    }
}
