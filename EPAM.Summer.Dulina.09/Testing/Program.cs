using System;
using System.Collections.Generic;
using System.Globalization;
using Algorithms;
using Entities;
using Timers;
using Services;
using Services.Storages;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");
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
            // TimeSpan time = new TimeSpan(0, 0, 10);
            // timer.SimulateTimerLauncher("artem", time);

            //TimerLauncher timer2 = new TimerLauncher();
            //Expoder exploder2 = new Expoder();
            //exploder2.RegisterOnTimer(timer2);
            //TimeSpan time2 = new TimeSpan(0, 0, 2);
            //timer2.SimulateTimerLauncher("fastPetr", time2);

            // timer.SimulateTimerLauncher("fastPetr", time2);      

            BinaryBookListStorage binaryStorage = new BinaryBookListStorage("BookStorage.bin");
            BinarySerializationStorage binarySerializationStorage = new BinarySerializationStorage("books.dat");
            XmlBookListStorage xmlStorage = new XmlBookListStorage("Books.xml");
            List<Book> books = new List<Book>
            {
                new Book("Artem", "C#", 1456, 2016),
                new Book("Petr", "C++", 1230, 2015),
                new Book("Tirion", "Java", 1053, 2014)
            };
            binaryStorage.SaveBooks(books);
            binarySerializationStorage.SaveBooks(books);
            xmlStorage.SaveBooks(books);

            List<Book> readResultB = binaryStorage.LoadBooks();
            List<Book> readResultS = binarySerializationStorage.LoadBooks();
            List<Book> readResultXml = xmlStorage.LoadBooks();
            /*foreach (Book book in readResult)
            {
                Console.WriteLine(book);
            }*/

            //BookListService service = new BookListService(storage);
            /*if (service.FindBook(x => x.Pages < 1000) == null)
                Console.WriteLine("null");*/

            //service.AddBook(null);

        }
    }
}
