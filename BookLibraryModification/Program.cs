using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            int n = int.Parse(input[0]);
            Library l = new Library();
            l.Books = new List<Book>();

            for (int i = 1; i < n + 1; i++)
            {
                string[] line = input[i].Split(' ').ToArray();
                Book book = new Book();
                book = ReadBook(line);
                l.Books.Add(book);
            }

            DateTime givenDate = DateTime.ParseExact(input[n + 1],
                "dd.MM.yyyy", CultureInfo.InvariantCulture);
            PrintBooks(l, givenDate);
        }
        private static void PrintBooks(Library library, DateTime givenDate)
        {
            var ordered = library.Books
                .OrderBy(x => x.ReleaseDate)
                .ThenBy(x => x.Title);

            File.WriteAllText("output.txt", "");

            foreach (var book in ordered.Where(x => x.ReleaseDate > givenDate))
            {
                File.AppendAllText("output.txt", $"{book.Title} -> {book.ReleaseDate.ToString("dd.MM.yyyy")}{Environment.NewLine}");
                
            }
        }
        private static Book ReadBook(string[] input)
        {
            Book book = new Book();
            book.Title = input[0];
            book.Author = input[1];
            book.Publisher = input[2];
            book.ReleaseDate = DateTime.ParseExact(input[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
            book.ISBNNum = input[4];
            book.Price = double.Parse(input[5]);
            return book;
        }
    }

    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ISBNNum { get; set; }
        public double Price { get; set; }
    }

    class Library
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
