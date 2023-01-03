using GamesAPI.Contexts;
using GamesAPI.Domains;
using GamesAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GamesTest;

public class StudioTest
{
    [Fact]
    public void List_GetStudios_AllStudios()
    {
        // Arrange (Preparação)
        var options = new DbContextOptionsBuilder<Context>()
            .UseInMemoryDatabase(databaseName: "StudioListDatabase")
            .Options;

        using (var context = new Context(options))
        {
            context.Studios.Add(new Studio { IdStudio = 1, StudioName = "Blizzard" });
            context.Studios.Add(new Studio { IdStudio = 2, StudioName = "Rockstar Studios" });
            context.Studios.Add(new Studio { IdStudio = 3, StudioName = "Square Enix" });
            context.SaveChanges();
        }

        using (var context = new Context(options))
        {
            // Act (Execução do método testado)
            StudioRepository studioRepository = new(context);
            List<Studio> listStudios = studioRepository.List();

            // Assert (Comparação de resultados)
            Assert.Equal(3, listStudios.Count);
            Assert.Equal("Blizzard", listStudios[0].StudioName);
            Assert.Equal("Rockstar Studios", listStudios[1].StudioName);
            Assert.Equal("Square Enix", listStudios[2].StudioName);
        }
    }
}
