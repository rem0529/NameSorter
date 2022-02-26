using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;


namespace NameSorter
{
    class Program
    {
        private static int Main(string[] args)
        {
            try
            {
                //Load unsorted-names-list.txt file which was defined in Project > Debug > Application Arguments
                var unsortedFile = args.FirstOrDefault();
                                           
                //Read file when records exist
                var fileRecords = File.ReadAllLines(unsortedFile);

                //Sort names by last name then all given names
                var sortedList = NameFunctions.IdentifyAndSortNames(fileRecords).ToList();

                //Output to console
                sortedList.ForEach(x => Console.WriteLine($"{x.GivenNames} {x.LastName}"));

                //Output to file
                File.WriteAllLines("sorted-names-list.txt", sortedList.Select(x => $"{x.GivenNames} {x.LastName}"));

                return 0;

            }

            catch (Exception ex)
            when (System.Diagnostics.Debugger.IsAttached == false)
            {
                Console.WriteLine(ex.Message);
                return ex.HResult;
            }
        }
    }
}
