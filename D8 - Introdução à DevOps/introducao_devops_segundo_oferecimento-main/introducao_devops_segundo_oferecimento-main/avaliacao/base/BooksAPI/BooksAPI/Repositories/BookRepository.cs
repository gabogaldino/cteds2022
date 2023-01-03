using BooksAPI.Contexts;
using BooksAPI.Domains;
using BooksAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BooksAPI.Repositories;

public class BookRepository : IBook
{
    private readonly Context ctx;

	public BookRepository(Context ctx)
	{
		this.ctx = ctx;
	}

	public List<Book> List()
	{
        return ctx.Books.Include(d => d.Author).ToList();
    }
}
