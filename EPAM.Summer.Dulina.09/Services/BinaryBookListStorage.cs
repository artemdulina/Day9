using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Entities;
using NLog;

namespace Services
{
    /// <summary>
    /// Class provides ability to load and save Entities.Book to the binary file.
    /// </summary>
    public class BinaryBookListStorage : IBookListStorage
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        private string fileName;

        private readonly string baseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;

        public string FileName
        {
            get
            {
                return fileName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    logger.Fatal(new ArgumentException("Null or empty", nameof(value)));
                    throw new ArgumentException("Null or empty", nameof(value));
                }

                fileName = value;
            }
        }

        public BinaryBookListStorage(string fileName)
        {
            FileName = fileName;
            logger.Debug("Ctor was created");
        }

        public List<Book> LoadBooks()
        {
            List<Book> books = new List<Book>();
            using (BinaryReader reader = new BinaryReader(File.Open(baseDirectoryPath + FileName, FileMode.Open, FileAccess.Read)))
            {
                while (!reader.Eof())
                {
                    books.Add(new Book(reader.ReadString(), reader.ReadString(), reader.ReadInt32(), reader.ReadInt32()));
                }
            }

            logger.Info($"{books.Count} books were loaded from the file");
            return books;
        }

        /// <summary>
        /// Saves books to the specified binary file.
        /// </summary>
        /// <param name="books"></param>
        public void SaveBooks(IEnumerable<Book> books)
        {
            int count = 0;
            using (BinaryWriter writer = new BinaryWriter(File.Open(baseDirectoryPath + FileName, FileMode.Create, FileAccess.Write)))
            {
                foreach (Book book in books)
                {
                    writer.Write(book.Author);
                    writer.Write(book.Title);
                    writer.Write(book.Pages);
                    writer.Write(book.Year);
                    count++;
                }
            }
            logger.Info($"{count} books were written to the file");
        }
    }
}
