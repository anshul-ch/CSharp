using CSharp.Practice.Library_Management_System.Application;
using CSharp.Practice.Library_Management_System.Infrastructure;

namespace CSharp.Practice.Library_Management_System.Presentation
{
    public class Program
    {
        public static void Main(String[] args)
        {
            BookRepository bookRepository = new BookRepository();
            LibraryService libraryService = new LibraryService(bookRepository);

            while (true)
            {
                Console.WriteLine("Library Management System");
                Console.WriteLine("1. Add book");
                Console.WriteLine("2: View Book by genre");
                Console.WriteLine("3: View book by author");
                Console.WriteLine("4. Get total books");
                Console.WriteLine("5. exit");
                string choice = Console.ReadLine();

                if (choice == "5")
                {
                    break;
                }
                else if (choice == "1")
                {
                    Console.WriteLine("Enter title: ");
                    string title = Console.ReadLine();
                    Console.WriteLine("Enter genre: ");
                    string genre = Console.ReadLine();
                    Console.WriteLine("Enter Author: ");
                    string author = Console.ReadLine();
                    Console.WriteLine("Enter publication year");
                    int year = Convert.ToInt32(Console.ReadLine());

                    libraryService.AddBook(title, author, genre, year);
                    Console.WriteLine("Book added succerssfully");
                }
                else if (choice == "2")
                {
                    var bookByGenre = libraryService.GroupBooksByGenre();
                    foreach (var book in bookByGenre)
                    {
                        Console.WriteLine("genre: " + book.Key);
                        foreach (var books in book.Value)
                        {
                            Console.WriteLine(books.Title);
                        }
                    }
                }
                else if (choice == "3")
                {
                    Console.WriteLine("Enter author name: ");
                    string author = Console.ReadLine();
                    var booksByAuthor = libraryService.GetBooksByAuthor(author);
                    foreach (var books in booksByAuthor)
                    {
                        Console.WriteLine(books.Author + " | " + books.Title);
                    }
                }
                else if (choice == "4")
                {
                    Console.WriteLine("Total books: " + libraryService.GetTotalBooks());
                }
                else
                {
                    Console.WriteLine("Invlaid operation, eneter correct number");
                }
            }
        }
    }
}
