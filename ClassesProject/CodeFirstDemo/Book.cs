using System.ComponentModel.DataAnnotations;

public class Book
{
    public int Id { get; set; }

    [MaxLength(200)]
    public string Title { get; set; }

    public int AuthorId { get; set; }

    public Author Author { get; set; }
}