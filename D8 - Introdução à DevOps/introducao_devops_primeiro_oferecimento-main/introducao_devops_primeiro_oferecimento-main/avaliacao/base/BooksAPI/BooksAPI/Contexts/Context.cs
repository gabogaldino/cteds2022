using BooksAPI.Domains;
using Microsoft.EntityFrameworkCore;

namespace BooksAPI.Contexts;

public class Context : DbContext
{
    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasData(
                new Author
                {
                    AuthorId = 1,
                    Name = "Stieg Larsson",
                    Birthdate = "15/08/1954",
                    Deathdate = "09/11/2004"
                },
                new Author
                {
                    AuthorId = 2,
                    Name = "George Orwell",
                    Birthdate = "25/06/1903",
                    Deathdate = "21/01/1950"
                });

            entity.HasIndex(u => u.Name).IsUnique();
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasData(
                new Book
                {
                    BookId = 1,
                    Name = "Os homens que não amavam as mulheres (Millennium #1)",
                    PublicationYear = "2008",
                    AuthorId = 1,
                    Pages = "522"
                },
                new Book
                {
                    BookId = 2,
                    Name = "A Revolução dos Bichos",
                    PublicationYear = "2007",
                    AuthorId = 2,
                    Pages = "152"
                });
        });

        base.OnModelCreating(modelBuilder);
    }
}
