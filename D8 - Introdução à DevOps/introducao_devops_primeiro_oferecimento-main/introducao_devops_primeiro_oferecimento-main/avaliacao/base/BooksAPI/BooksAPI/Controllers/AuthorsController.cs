using BooksAPI.Contexts;
using BooksAPI.Interfaces;
using BooksAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BooksAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
    private IAuthor AuthorRepository { get; set; }

    public AuthorsController(Context ctx)
    {
        AuthorRepository = new AuthorRepository(ctx);
    }

    [HttpGet]
    public IActionResult List()
    {
        return Ok(AuthorRepository.List());
    }
}
