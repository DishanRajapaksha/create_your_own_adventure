using DesignYourOwnAdventure.Core.Interfaces;
using DesignYourOwnAdventure.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DesignYourOwnAdventure.Core.Extensions;

public static class DependencyInjection
{
	public static void AddCoreServices(this IServiceCollection services)
	{
		services
			.AddScoped<IAdventureService, AdventureService>()
			.AddScoped<IAnswerService, AnswerService>()
			.AddScoped<IUserService, UserService>()
			.AddScoped<IBinaryTreeService, BinaryTreeService>();
	}
}