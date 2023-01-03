using Microsoft.EntityFrameworkCore;
using System;

namespace wpf_catalog.Data;

public class Context : DbContext
{
	public Context(DbContextOptions<Context> options) : base(options)
	{
		Database.EnsureCreated();
	}

	public DbSet<Product> Products { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Product>().HasData(GetProducts());
		base.OnModelCreating(modelBuilder);
	}

	private static Product[] GetProducts()
	{
		return new Product[]
		{
			new Product
			{
				Id = Guid.NewGuid(),
				SKU = "SM-G781BLVJZTO",
				Name = "Galaxy S20 FE 5G Violeta",
				Description = "Assista lives, vídeos e jogos com a extraordinária velocidade 5G.",
				Price = 1999.00
			},

			new Product
			{
                Id = Guid.NewGuid(),
                SKU = "SM-G781BZBJZTO",
                Name = "Galaxy S20 FE 5G Azul Marinho",
                Description = "Crie conteúdos extraordinários com a Selfie de 32MP.",
                Price = 1999.00
            }
		};
	}
}
