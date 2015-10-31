using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FH.SEv.UFO.Server.Model.Commands
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
}
