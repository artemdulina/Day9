using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Entities;
using NLog;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Services.Storages
{
    /// <summary>
    /// Class provides ability to load and save Entities.Book to the xml file.
    /// </summary>
    public class XmlBookListStorage : IBookListStorage
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

        public XmlBookListStorage(string fileName)
        {
            FileName = fileName;
            logger.Debug("Ctor was created");
        }

        /// <summary>
        /// Saves books to the specified xml file.
        /// </summary>
        public List<Book> LoadBooks()
        {
            List<Book> books = new List<Book>();

            XDocument xmlXDocument = XDocument.Load(baseDirectoryPath + FileName);
            var items = from book in xmlXDocument.Element("books").Elements("book")
                        select new Book(book.Element("author").Value, book.Element("title").Value,
                            Convert.ToInt32(book.Element("pages").Value), Convert.ToInt32(book.Element("year").Value));

            books = items.ToList();
            /*XmlDocument booksFromXml = new XmlDocument();
            booksFromXml.Load(baseDirectoryPath + FileName);
            XmlElement rootElement = booksFromXml.DocumentElement;
            foreach (XmlNode node in rootElement)
            {
                string author = "";
                string title = "";
                int pages = 0;
                int year = 0;
                foreach (XmlNode childnode in node.ChildNodes)
                {
                    if (childnode.Name == "author") author = childnode.InnerText;
                    if (childnode.Name == "title") title = childnode.InnerText;
                    if (childnode.Name == "pages") pages = Convert.ToInt32(childnode.InnerText);
                    if (childnode.Name == "year") year = Convert.ToInt32(childnode.InnerText);
                }
                books.Add(new Book(author, title, pages, year));
            }*/

            logger.Info($"{books.Count} books were loaded from the file");
            return books;
        }

        /// <summary>
        /// Saves books to the specified xml file.
        /// </summary>
        /// <param name="books"></param>
        public void SaveBooks(IEnumerable<Book> books)
        {
            if (books == null)
            {
                throw new ArgumentNullException(nameof(books));
            }
            int count = 0;
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Encoding = Encoding.UTF8,
                Indent = true
            };

            XDocument document = new XDocument(new XElement("books"));

            using (XmlWriter writer = XmlWriter.Create(baseDirectoryPath + FileName, settings))
            {
                foreach (Book book in books)
                {
                    document.Root.Add(
                  new XElement("book",
                      new XElement("author", book.Author),
                      new XElement("title", book.Title),
                      new XElement("pages", book.Pages),
                      new XElement("year", book.Year)
                      )
                      );
                    count++;
                }
                document.Save(writer);
            }
            /*XmlDocument booksXml = new XmlDocument();
            XmlDeclaration xmlDeclaration = booksXml.CreateXmlDeclaration("1.0", "UTF-8", null);
            booksXml.AppendChild(xmlDeclaration);

            XmlElement root = booksXml.CreateElement("books");
            booksXml.AppendChild(root);

            int count = 0;
            foreach (Book book in books)
            {
                XmlNode bookNode = booksXml.CreateElement("book");

                XmlNode bookAuthor = booksXml.CreateElement("author");
                XmlNode bookTitle = booksXml.CreateElement("title");
                XmlNode bookPages = booksXml.CreateElement("pages");
                XmlNode bookYear = booksXml.CreateElement("year");

                bookNode.AppendChild(bookAuthor);
                bookNode.AppendChild(bookTitle);
                bookNode.AppendChild(bookPages);
                bookNode.AppendChild(bookYear);

                bookNode["author"].InnerText = book.Author;
                bookNode["title"].InnerText = book.Title;
                bookNode["pages"].InnerText = book.Pages.ToString();
                bookNode["year"].InnerText = book.Year.ToString();

                root.AppendChild(bookNode);
                count++;
            }

            booksXml.Save(baseDirectoryPath + FileName);*/
            logger.Info($"{count} books were written to the file");
        }
    }
}
