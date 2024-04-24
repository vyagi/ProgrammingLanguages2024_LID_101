using Microsoft.EntityFrameworkCore;

public class LibraryDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    
    public DbSet<Author> Authors { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //this is not the best approach (it is actually the worst) to handle connection strings. But the proper ways - next semester
        optionsBuilder.UseSqlServer(
            "Data Source=localhost,1433;Initial Catalog=Library;User ID=sa;Password=password-1234;Encrypt=False");
    }
}