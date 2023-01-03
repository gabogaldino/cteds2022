using GamesAPI.Domains;
using Microsoft.EntityFrameworkCore;

namespace GamesAPI.Contexts;

public class Context : DbContext
{
    public virtual DbSet<UserType> UserTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Studio> Studios { get; set; }

    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserType>().HasData(
        new UserType
        {
            IdUserType = 1,
            Title = "Administrador"
        },
        new UserType
        {
            IdUserType = 2,
            Title = "Cliente"
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasData(
                new User
                {
                    IdUser = 1,
                    Email = "admin@admin.com",
                    Password = "admin",
                    IdUserType = 1
                },
                new User
                {
                    IdUser = 2,
                    Email = "cliente@cliente.com",
                    Password = "cliente",
                    IdUserType = 2
                });

            entity.HasIndex(u => u.Email).IsUnique();
        });

        modelBuilder.Entity<Studio>().HasData(
        new Studio { IdStudio = 1, StudioName = "Blizzard" },
        new Studio { IdStudio = 2, StudioName = "Rockstar Studios" },
        new Studio { IdStudio = 3, StudioName = "Square Enix" });

        base.OnModelCreating(modelBuilder);
    }
}
