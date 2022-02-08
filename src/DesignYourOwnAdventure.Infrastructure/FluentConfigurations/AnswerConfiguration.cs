using System.Text.Json;
using System.Text.Json.Serialization;
using DesignYourOwnAdventure.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesignYourOwnAdventure.Infrastructure.FluentConfigurations;

public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
{
	public void Configure(EntityTypeBuilder<Answer> builder)
	{
		JsonSerializerOptions options = new()
		{
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
		};

		builder.HasKey(x => x.AnswerId);

		builder.Property(x => x.AnswerId).ValueGeneratedOnAdd();

		builder.Property(x => x.Steps).HasConversion(
			y => JsonSerializer.Serialize(y, options),
			y => JsonSerializer.Deserialize<List<char>>(y, options));

		builder.HasData(new Answer
		{
			BinaryTreeId = 1,
			UserId = 1,
			AnswerId = 1,
			Steps = new List<char>
			{
				'L', 'L', 'R', 'L'
			}
		});
	}
}