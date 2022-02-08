using DesignYourOwnAdventure.Core.Entities;
using DesignYourOwnAdventure.Infrastructure.FluentConfigurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DesignYourOwnAdventure.Infrastructure.Contexts;

public class AdventureContext : DbContext
{
	public AdventureContext() => DbPath = GetDatabasePath();

	public DbSet<BinaryTree<Question>> Adventures { get; set; }
	public DbSet<Answer> Answers { get; set; }
	public DbSet<User> Users { get; set; }

	public string DbPath { get; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new AdventureConfiguration());
		modelBuilder.ApplyConfiguration(new AnswerConfiguration());
		modelBuilder.ApplyConfiguration(new UserConfiguration());
	}

	protected override void OnConfiguring(DbContextOptionsBuilder options)
	{
		options.UseSqlite($"Data Source={DbPath}");
	}

	private string GetDatabasePath()
	{
        string path =
            Path.Combine(
                Path.GetDirectoryName(Assembly.Load("DesignYourOwnAdventure.Infrastructure").Location) ??
                string.Empty, "adventures.db");

        return path;
    }
}