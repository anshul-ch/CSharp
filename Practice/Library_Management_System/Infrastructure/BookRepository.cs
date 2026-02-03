using CSharp.Practice.Library_Management_System.Application;
using CSharp.Practice.Library_Management_System.Domain;

namespace CSharp.Practice.Library_Management_System.Infrastructure
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> _books = new List<Book>();

        public void Add(Book book)
        {
            _books.Add(book);
        }

        public List<Book> GetAll()
        {
            return _books;
        }
    }
}
