using DesignYourOwnAdventure.Core.Entities;
using DesignYourOwnAdventure.Core.Interfaces;
using DesignYourOwnAdventure.Infrastructure.Contexts;
using DesignYourOwnAdventure.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DesignYourOwnAdventure.Infrastructure.Extensions;

public static class DependencyInjection
{
	public static void AddInfrastructureServices(this IServiceCollection services)
	{
		services.AddDbContext<AdventureContext>();
		services.AddScoped<IRepository<BinaryTree<Question>>, AdventureRepository>();
		services.AddScoped<IRepository<Answer>, AnswerRepository>();
		services.AddScoped<IRepository<User>, UserRepository>();
	}
	
	public static void MigrateDatabase(this IApplicationBuilder app)
	{
		using IServiceScope scope = app.ApplicationServices.CreateScope();
		IServiceProvider services = scope.ServiceProvider;
		AdventureContext context = services.GetRequiredService<AdventureContext>();
		context.Database.Migrate();
	}
}