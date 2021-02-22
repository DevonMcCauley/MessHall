﻿// <auto-generated />
using MessHall.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MessHall.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210222224702_AddedIngredient")]
    partial class AddedIngredient
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MessHall.Models.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("CaloriesPerUnit")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("IngredientId");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            IngredientId = 1,
                            CaloriesPerUnit = 50.0,
                            Description = "An apple",
                            Name = "Apple"
                        },
                        new
                        {
                            IngredientId = 2,
                            CaloriesPerUnit = 10.0,
                            Description = "Some flour",
                            Name = "Flour"
                        },
                        new
                        {
                            IngredientId = 3,
                            CaloriesPerUnit = 100.0,
                            Description = "Some sauce",
                            Name = "Sauce"
                        },
                        new
                        {
                            IngredientId = 4,
                            CaloriesPerUnit = 150.0,
                            Description = "Turkey pepperoni",
                            Name = "Pepperoni"
                        });
                });

            modelBuilder.Entity("MessHall.Models.Recipe", b =>
                {
                    b.Property<int>("RecipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("Notes")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("RecipeId");

                    b.ToTable("Recipes");

                    b.HasData(
                        new
                        {
                            RecipeId = 1,
                            Description = "A delicious apple pie.",
                            Name = "Apple Pie",
                            Notes = "This apple pie contains 2 ingredients: apple and pie"
                        },
                        new
                        {
                            RecipeId = 2,
                            Description = "A hearty lasagna",
                            Name = "Lasagna",
                            Notes = "This this is a good lasagna"
                        },
                        new
                        {
                            RecipeId = 3,
                            Description = "A classic American pizza",
                            Name = "Pizza",
                            Notes = "This pizza is also good"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}