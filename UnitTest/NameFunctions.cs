using System;
using Xunit;
using System.Linq;
using System.Diagnostics;

namespace UnitTest
{
    public class NameFunctions
    {
        [Fact]
        public void Sort()
        {
            string[] input = { "Romina Manalac Espinosa", "Jane Doe", "John Doe"};
            var output = NameSorter.NameFunctions.IdentifyAndSortNames(input).Select(x => $"{x.GivenNames} {x.LastName}");
            string [] expected = { "Jane Doe", "John Doe", "Romina Manalac Espinosa"};

            Debug.Assert(output.SequenceEqual(expected), "Names not in expected order");
        }

        [Fact]
        public void Identify()
        {
            var input = "Romina Manalac Espinosa";
            var output = NameSorter.NameFunctions.IdentifyName(input);
            var expected = ("Romina Manalac","Espinosa");

            Debug.Assert(output == expected, $"Expected: {expected} Got: {output}");
        }
    }
}
