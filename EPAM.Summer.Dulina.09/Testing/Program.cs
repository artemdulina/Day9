using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 4, 564, 64, 56, 684, 21, 351, 31, 321, -1, 212, 3, 2 };
            int[] arrayB = { 4, 534, 564, 56, 64, 21, 351, 31, 321, -45, 212, 3 };
            Array.Sort(array);
            Array.Sort(arrayB);
            //Console.WriteLine(Search.BinarySearch(arrayB, 564));
            Search.SearchNumberOfEachWord(AppDomain.CurrentDomain.BaseDirectory + "TextFile.txt",
                AppDomain.CurrentDomain.BaseDirectory + "TextFile1456.txt");
        }
    }
}
