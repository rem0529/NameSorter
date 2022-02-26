using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter
{
    public class NameFunctions
    {
        /// <summary>
        /// Takes a set of strings representing full names and return the sorted set of the names broken down into GivenNames LastName, sorted by LastName, GivenNames 
        /// </summary>
        /// <param name="names"></param>
        /// <returns></returns>
        public static IEnumerable<(string GivenNames, string LastName)> IdentifyAndSortNames(IEnumerable<string> names)
        {
            return names.Where(x => x != null && x.Trim() != "").
                         Select(x => IdentifyName(x)).
                         OrderBy(x => x.LastName).
                         ThenBy(x => x.GivenNames);

        }

        /// <summary>
        /// Identify Last name and given names
        /// </summary>
        /// <param name="name">A single name string to split into the GivenNames and LastName given the format of: [GivenNames] [LastName]</param>
        /// <returns></returns>
        public static (string GivenNames, string LastName) IdentifyName(string name)
        {
            var nameSplit = name.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            return (string.Join(" ", nameSplit.Take(nameSplit.Length - 1)), nameSplit.LastOrDefault());
        }
    }
}
