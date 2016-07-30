using System;
using System.Collections.Generic;
using System.IO;

namespace Algorithms
{
    /// <summary>
    /// Class provides a set of different searches.
    /// </summary>
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

            IComparer<T> comparer = new ComparisonAdapter<T>(comparison);
            return BinarySearch(array, value, comparer);
        }


        /// <summary>
        /// Find number of each word in the sourcePath and write the result into
        /// resultPath file.
        /// </summary>
        /// <param name="sourcePath">File to work with to find number of each words.</param>
        /// <param name="resultPath">File to write list of words and number of each words.</param>    
        /// <returns>Text file with the result.</returns>
        /// <exception cref="ArgumentNullException">sourcePath is null or resultPath is null.</exception>
        /// <exception cref="ArgumentException">sourcePath length is 0 or resultPath length is 0.</exception>
        public static void SearchNumberOfEachWord(string sourcePath, string resultPath)
        {
            if (sourcePath == null)
            {
                throw new ArgumentNullException(nameof(sourcePath));
            }
            if (sourcePath.Length == 0)
            {
                throw new ArgumentException("Cant'be empty", nameof(sourcePath));
            }
            if (resultPath == null)
            {
                throw new ArgumentNullException(nameof(resultPath));
            }
            if (resultPath.Length == 0)
            {
                throw new ArgumentException("Cant'be empty", nameof(resultPath));
            }
            string lines = File.ReadAllText(sourcePath);
            //FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
            string[] sourceWords = lines.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            //SortedList<string, int> resultSetOfValues = new SortedList<string, int>();
            //SortedDictionary<string, int> resultSetOfValues = new SortedDictionary<string, int>();
            Dictionary<string, int> resultSetOfValues = new Dictionary<string, int>();

            //Stopwatch timer = new Stopwatch();
            //timer.Start();
            foreach (var word in sourceWords)
            {
                int count;
                resultSetOfValues[word] = resultSetOfValues.TryGetValue(word, out count) ? count + 1 : 1;
            }

            //timer.Stop();
            //Console.WriteLine(timer.ElapsedMilliseconds);

            using (StreamWriter writer = new StreamWriter(resultPath, false))
            {
                foreach (KeyValuePair<string, int> pair in resultSetOfValues)
                    writer.WriteLine("{0} : {1}", pair.Key, pair.Value);
            }

        }
    }
}

