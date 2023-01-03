using BooksAPI.Contexts;
using BooksAPI.Domains;
using BooksAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BooksAPI.Repositories;

public class AuthorRepository : IAuthor
{
    private readonly Context ctx;

	public AuthorRepository(Context ctx)
	{
		this.ctx = ctx;
	}

	public List<Author> List()
	{
        return ctx.Authors.Include(d => d.Books).ToList();
    }
}
