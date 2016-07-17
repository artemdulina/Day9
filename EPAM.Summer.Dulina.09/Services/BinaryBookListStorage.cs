using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Entities;

namespace Services
{
    public class BinaryBookListStorage : IBookListStorage
    {
        private string fileName;

        private readonly string baseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;

        public string FileName
        {
            get { return fileName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Null or empty", nameof(value));
                }
                fileName = value;
            }
        }

        public BinaryBookListStorage(string fileName)
        {
            FileName = fileName;
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
            return books;
        }

        public void SaveBooks(IEnumerable<Book> books)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(baseDirectoryPath + FileName, FileMode.Create, FileAccess.Write)))
            {
                foreach (Book book in books)
                {
                    writer.Write(book.Author);
                    writer.Write(book.Title);
                    writer.Write(book.Pages);
                    writer.Write(book.Year);
                }
            }
        }     
    }
}
