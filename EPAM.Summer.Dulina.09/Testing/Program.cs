using System;
using System.Threading;
using System.Threading.Tasks;
using Algorithms;
using Timers;

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

            TimerLauncher timer = new TimerLauncher();
            Expoder exploder = new Expoder();
            exploder.RegisterOnTimer(timer);
            TimeSpan time = new TimeSpan(0, 0, 10);
            timer.SimulateTimerLauncher("artem", time);

            //TimerLauncher timer2 = new TimerLauncher();
            //Expoder exploder2 = new Expoder();
            //exploder2.RegisterOnTimer(timer2);
            TimeSpan time2 = new TimeSpan(0, 0, 2);
            //timer2.SimulateTimerLauncher("fastPetr", time2);

            timer.SimulateTimerLauncher("fastPetr", time2);
            Console.ReadKey();
        }
    }
}
