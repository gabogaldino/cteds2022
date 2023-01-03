using GamesAPI.Contexts;
using GamesAPI.Domains;
using GamesAPI.Interfaces;

namespace GamesAPI.Repositories;

public class StudioRepository : IStudio
{
    private readonly Context ctx;

    public StudioRepository(Context ctx)
    {
        this.ctx = ctx;
    }

    public Studio Create(Studio newStudio)
    {
        throw new NotImplementedException();
    }

    public void Delete(int idEstudio)
    {
        throw new NotImplementedException();
    }

    public List<Studio> List()
    {
        return ctx.Studios.ToList();
    }
}
