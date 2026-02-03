using CSharp.Practice.Library_Management_System.Domain;

namespace CSharp.Practice.Library_Management_System.Application;

public interface IBookRepository
{
    void Add(Book book);
    List<Book> GetAll();
}
