using System.ComponentModel.DataAnnotations;

public class Author
{
    public int Id { get; set; }

    [MaxLength(200)]
    public string Name { get; set; }

    public ICollection<Book> Books { get; set; }
}