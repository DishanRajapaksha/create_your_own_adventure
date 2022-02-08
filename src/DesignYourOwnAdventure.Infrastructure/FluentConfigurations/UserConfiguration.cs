using DesignYourOwnAdventure.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesignYourOwnAdventure.Infrastructure.FluentConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.HasKey(x => x.UserId);

		builder.Property(x => x.UserId).ValueGeneratedOnAdd();

		builder.HasData(new User
		{
			UserId = 1,
			Email = "dishanrajapaksha@outlook.com",
			DisplayName = "Dishan"
		});
	}
}