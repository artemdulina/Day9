using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class Search
    {

        /// <summary>
        /// Find index of found value in the sorted array.
        /// </summary>
        /// <param name="array">Sorted array to search.</param>
        /// <param name="value">Object to search for.</param>
        /// <param name="comparer">The System.Collections.Generic.IComparer'T' implementation to use when
        ///  comparing elements or null to use the System.IComparable'T'.</param>      
        /// <returns>Return index of fist found value or -1 if not found.</returns>
        /// <exception cref="ArgumentNullException">array is null.</exception>
        public static int BinarySearch<T>(T[] array, T value, IComparer<T> comparer = null)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if (comparer == null)
            {
                comparer = Comparer<T>.Default;
            }
            int left = 0;
            int right = array.Length - 1;
            while (left <= right)
            {
                int middleValue = left + (right - left) / 2;
                if (comparer.Compare(value, array[middleValue]) == 0)
                {
                    return middleValue;
                }
                if (comparer.Compare(value, array[middleValue]) == -1)
                {
                    right = middleValue - 1;
                }
                else
                {
                    left = middleValue + 1;
                }
            }
            return -1;
        }

        /// <summary>
        /// Find index of found value in the sorted array.
        /// </summary>
        /// <param name="array">Sorted array to search.</param>
        /// <param name="value">Object to search for.</param>
        /// <param name="comparison">The System.Comparison'T' implementation to use when
        ///  comparing elements or null to use the System.IComparable'T'.</param>      
        /// <returns>Return index of fist found value or -1 if not found.</returns>
        /// <exception cref="ArgumentNullException">array is null.</exception>
        public static int BinarySearch<T>(T[] array, T value, Comparison<T> comparison)
        {
            if (comparison == null)
            {
                comparison = Comparer<T>.Default.Compare;
            }
            IComparer<T> comparer = new ComparerOnFunction<T>(comparison);
            return BinarySearch(array, value, comparer);
        }
    }
}
