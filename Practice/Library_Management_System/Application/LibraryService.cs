using CSharp.Practice.Library_Management_System.Domain;

namespace CSharp.Practice.Library_Management_System.Application
{
    public class LibraryService
    {
        private readonly IBookRepository _repository;
        private int _idCounter = 1;

        public LibraryService(IBookRepository repository)
        {
            _repository = repository;
        }

        // Add books
        public void AddBook(string title, string author, string genre, int pubYear)
        {
            Book book = new Book
            {
                Id = _idCounter++,
                Title = title,
                Author = author,
                Genre = genre.ToLower(),
                PublicationYear = pubYear,
            };
            _repository.Add(book);
        }

        // Group books by Genre
        public SortedDictionary<string, List<Book>> GroupBooksByGenre()
        {
            return new SortedDictionary<string, List<Book>>(
                _repository.GetAll().GroupBy(b => b.Genre).ToDictionary(g => g.Key, g => g.ToList())
            );
        }

        // Get books by author
        public List<Book> GetBooksByAuthor(string author)
        {
            return _repository.GetAll().Where(b => b.Author.ToLower() == author.ToLower()).ToList();
        }

        // Get toal number of books
        public int GetTotalBooks()
        {
            return _repository.GetAll().Count;
        }
    }
}
