using GamesAPI.Contexts;
using GamesAPI.Interfaces;
using GamesAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GamesAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudiosController : ControllerBase
{
    private IStudio StudioRepository { get; set; }

    public StudiosController(Context ctx)
    {
        StudioRepository = new StudioRepository(ctx);
    }

    [HttpGet]
    public IActionResult List()
    {
        return Ok(StudioRepository.List());
    }
}
