using System;
using System.Collections.Generic;
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

            PrintBooks(l);
        }

        private static void PrintBooks(Library library)
        {
            var ordered = library.Books
                .OrderByDescending(x => x.Price)
                .ThenBy(x => x.Author);
            File.WriteAllText("output.txt", "");
            foreach (var author in ordered.Select(x => x.Author).Distinct())
            {
                double sum = library.Books
                    .Where(x => x.Author == author)
                    .Sum(x => x.Price);
                File.AppendAllText("output.txt",$"{author} -> {sum:F2}{Environment.NewLine}");
            }
        }
        private static Book ReadBook(string[] input)
        {
            Book book = new Book();
            book.Title = input[0];
            book.Author = input[1];
            book.Publisher = input[2];
            book.ReleaseDate = input[3];
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
        public string ReleaseDate { get; set; }
        public string ISBNNum { get; set; }
        public double Price { get; set; }
    }

    class Library
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
