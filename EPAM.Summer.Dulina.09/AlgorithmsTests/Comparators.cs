using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTests
{
    public class RisingSort : IComparer<double>
    {
        public int Compare(double x, double y)
        {
            if (x > y)
                return 1;
            if (x < y)
                return -1;
            return 0;
        }
    }
}
