using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Entities;
using NLog;
using Services.Extensions;

namespace Services.Storages
{
    /// <summary>
    /// Class provides ability to load and save Entities.Book to the file using binary serialization.
    /// </summary>
    public class BinarySerializationStorage : IBookListStorage
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

        public BinarySerializationStorage(string fileName)
        {
            FileName = fileName;
            logger.Debug("Ctor was created");
        }

        /// <summary>
        /// Load books to the specified binary file.
        /// </summary>
        public List<Book> LoadBooks()
        {
            List<Book> books = new List<Book>();

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream(baseDirectoryPath + FileName, FileMode.OpenOrCreate))
            {
                books = (List<Book>)formatter.Deserialize(fileStream);
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
            if (books == null)
            {
                throw new ArgumentNullException(nameof(books));
            }

            int count = 0;
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream(baseDirectoryPath + FileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, books);
                count += books.Count();
            }

            logger.Info($"{count} books were written to the file");
        }
    }
}
