using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Scenario_based_questions
{
    public class Author
    {
        public string AuthorName { get; set; }
        public string Country { get; set; }
    }
    public class Book
    {
        public string? Title { get; set; }
        public int Price { get; set; }
        public Author? authorDetails;
        public Book(string title, int price, Author author)
        {
            Title = title;
            Price = price;
            authorDetails = author;
        }
        public void PrintDetails()
        {
            Console.WriteLine("Author Name: " + authorDetails.AuthorName);
            Console.WriteLine("Author Country: " + authorDetails.Country);
            Console.WriteLine("Price: " + Price);
            Console.WriteLine("Title: " + Title);
        }
    }
    public class Library_Composition
    {
        static void Main(String[] args)
        {
            Book book = new Book("Interstellar", 400, new Author
            {
                AuthorName = "Heinsberg",
                Country = "USA"
            });
            book.PrintDetails();
        }
    }
}
