﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShelterApi.Models;

#nullable disable

namespace ShelterApi.Migrations
{
    [DbContext(typeof(ShelterApiContext))]
    [Migration("20230818161429_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ShelterApi.Models.Cat", b =>
                {
                    b.Property<int>("CatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Age")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("HealthSocialNeeds")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Personality")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CatId");

                    b.ToTable("Cats");

                    b.HasData(
                        new
                        {
                            CatId = 1,
                            Age = "3m",
                            Gender = "Female",
                            HealthSocialNeeds = "Need time to adjust to new environment.",
                            Name = "Dinky",
                            Personality = "Sensitive, shy, worried around new people and environements"
                        },
                        new
                        {
                            CatId = 2,
                            Age = "2y 3m",
                            Gender = "Male",
                            HealthSocialNeeds = "None.",
                            Name = "Chester",
                            Personality = "Affectionate"
                        },
                        new
                        {
                            CatId = 3,
                            Age = "8y",
                            Gender = "Male",
                            HealthSocialNeeds = "Deaf. Should be in a home with no other pets.",
                            Name = "Trooper",
                            Personality = "Loud and friendly!"
                        });
                });

            modelBuilder.Entity("ShelterApi.Models.Dog", b =>
                {
                    b.Property<int>("DogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Age")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("HealthSocialNeeds")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Personality")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("DogId");

                    b.ToTable("Dogs");

                    b.HasData(
                        new
                        {
                            DogId = 1,
                            Age = "1y 8m",
                            Gender = "Male",
                            HealthSocialNeeds = "Would do best in an environment with older children.",
                            Name = "Houdini",
                            Personality = "High Energy and Goofy!"
                        },
                        new
                        {
                            DogId = 2,
                            Age = "2y 4m",
                            Gender = "Male",
                            HealthSocialNeeds = "While not needed, would do better in a home that has another dog for him to play with.",
                            Name = "Jelly Bean",
                            Personality = "Very Social"
                        },
                        new
                        {
                            DogId = 3,
                            Age = "7y",
                            Gender = "Female",
                            HealthSocialNeeds = "Blind. Would do better in an environment with no children",
                            Name = "Farrah",
                            Personality = "Shy and Nervous"
                        });
                });

            modelBuilder.Entity("ShelterApi.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            EmailAddress = "TestUser@gmail.com",
                            Password = "Test",
                            UserName = "TestUser"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}