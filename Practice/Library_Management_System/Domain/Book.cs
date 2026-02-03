namespace CSharp.Practice.Library_Management_System.Domain;

public class Book
{
    public int Id { get; set; } // will auto increment
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int PublicationYear { get; set; }
}
