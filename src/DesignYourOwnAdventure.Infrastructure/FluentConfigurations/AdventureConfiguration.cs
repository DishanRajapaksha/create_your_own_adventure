﻿using System.Text.Json;
using System.Text.Json.Serialization;
using DesignYourOwnAdventure.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesignYourOwnAdventure.Infrastructure.FluentConfigurations;

public class AdventureConfiguration : IEntityTypeConfiguration<BinaryTree<Question>>
{
	public void Configure(EntityTypeBuilder<BinaryTree<Question>> builder)
	{
		JsonSerializerOptions options = new()
		{
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
		};

		builder.HasKey(x => x.BinaryTreeId);

		builder.Property(x => x.BinaryTreeId).ValueGeneratedOnAdd();

		builder.Property(x => x.Root).HasConversion(
			y => JsonSerializer.Serialize(y, options),
			y => JsonSerializer.Deserialize<BinaryTreeNode<Question>>(y, options));

		builder.HasData(new BinaryTree<Question>
		{
			BinaryTreeId = 1,
			Root = new BinaryTreeNode<Question>
			{
				Data = new Question("Do I want a Donut?"),
				Left = new BinaryTreeNode<Question>
				{
					Data = new Question("Do I deserve it?"),
					Left = new BinaryTreeNode<Question>
					{
						Data = new Question("Are you sure?"),
						Left = new BinaryTreeNode<Question>
						{
							Data = new Question("Get it")
						},
						Right = new BinaryTreeNode<Question>
						{
							Data = new Question("Do jumping jacks first!")
						}
					},
					Right = new BinaryTreeNode<Question>
					{
						Data = new Question("Is it a good donut?"),
						Left = new BinaryTreeNode<Question>
						{
							Data = new Question("What are you waiting for? Grab it now.")
						},
						Right = new BinaryTreeNode<Question>
						{
							Data = new Question("Wait till you find a sinful, unforgettable doughnut.")
						}
					}
				},
				Right = new BinaryTreeNode<Question>
				{
					Data = new Question("Maybe you want an apple?")
				}
			}
		});
	}
}