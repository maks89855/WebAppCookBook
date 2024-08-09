﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAppCookBook.DbContexts;

#nullable disable

namespace WebAppCookBook.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20231106171131_ChangedModelsV2")]
    partial class ChangedModelsV2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.21");

            modelBuilder.Entity("WebAppCookBook.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("NameCategory")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NameCategory = "first"
                        },
                        new
                        {
                            Id = 2,
                            NameCategory = "second"
                        },
                        new
                        {
                            Id = 3,
                            NameCategory = "third"
                        },
                        new
                        {
                            Id = 4,
                            NameCategory = "fourth"
                        });
                });

            modelBuilder.Entity("WebAppCookBook.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NameIngredient")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RecipeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Units")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("WebAppCookBook.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Recipes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Name = "first"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Name = "second"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Name = "third"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 3,
                            Name = "fourth"
                        });
                });

            modelBuilder.Entity("WebAppCookBook.Models.StepCook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RecipeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("StepCook");
                });

            modelBuilder.Entity("WebAppCookBook.Models.Ingredient", b =>
                {
                    b.HasOne("WebAppCookBook.Models.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("WebAppCookBook.Models.Recipe", b =>
                {
                    b.HasOne("WebAppCookBook.Models.Category", "Category")
                        .WithMany("Recipes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("WebAppCookBook.Models.StepCook", b =>
                {
                    b.HasOne("WebAppCookBook.Models.Recipe", "Recipe")
                        .WithMany("StepsCooking")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("WebAppCookBook.Models.Category", b =>
                {
                    b.Navigation("Recipes");
                });

            modelBuilder.Entity("WebAppCookBook.Models.Recipe", b =>
                {
                    b.Navigation("Ingredients");

                    b.Navigation("StepsCooking");
                });
#pragma warning restore 612, 618
        }
    }
}
