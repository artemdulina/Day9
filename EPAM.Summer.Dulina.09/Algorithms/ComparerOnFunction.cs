using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public sealed class ComparerOnFunction<T> : IComparer<T>
    {
        private Comparison<T> comparison;

        public ComparerOnFunction(Comparison<T> comparison)
        {
            this.comparison = comparison;
        }

        public int Compare(T x, T y)
        {
            return comparison(x, y);
        }
    }
}
