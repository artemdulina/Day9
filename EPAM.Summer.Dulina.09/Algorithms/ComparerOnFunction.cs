using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /// <summary>
    /// Object adapter for Comparison'T'.
    /// </summary>
    /// <typeparam name="T">The type of the objects to compare.</typeparam>
    public sealed class ComparisonAdapter<T> : IComparer<T>
    {
        private Comparison<T> comparison;

        public ComparisonAdapter(Comparison<T> comparison)
        {
            this.comparison = comparison;
        }

        public int Compare(T x, T y)
        {
            return comparison(x, y);
        }
    }
}
