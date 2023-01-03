using BooksAPI.Contexts;
using BooksAPI.Interfaces;
using BooksAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BooksAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private IBook BookRepository { get; set; }

    public BooksController(Context ctx)
    {
        BookRepository = new BookRepository(ctx);
    }

    [HttpGet]
    public IActionResult List()
    {
        return Ok(BookRepository.List());
    }
}
