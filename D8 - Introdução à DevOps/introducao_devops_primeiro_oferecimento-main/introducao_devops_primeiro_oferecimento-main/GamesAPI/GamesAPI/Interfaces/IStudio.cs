using GamesAPI.Domains;

namespace GamesAPI.Interfaces;

public interface IStudio
{
    List<Studio> List();

    Studio Create(Studio newStudio);

    void Delete(int idStudio);
}
