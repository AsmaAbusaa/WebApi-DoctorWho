﻿// <auto-generated />
using System;
using DoctorWho.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    [DbContext(typeof(DoctorWhoCoreDbContext))]
    [Migration("20230205161849_createfunctions")]
    partial class createfunctions
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CompanionEpisode", b =>
                {
                    b.Property<int>("CompanionsCompanionId")
                        .HasColumnType("int");

                    b.Property<int>("EpisodesEpisodeId")
                        .HasColumnType("int");

                    b.HasKey("CompanionsCompanionId", "EpisodesEpisodeId");

                    b.HasIndex("EpisodesEpisodeId");

                    b.ToTable("CompanionEpisode");
                });

            modelBuilder.Entity("DoctorWho.Db.DataModels.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"));

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            AuthorId = 1000,
                            AuthorName = "Ahmad"
                        },
                        new
                        {
                            AuthorId = 1001,
                            AuthorName = "Mohammad"
                        },
                        new
                        {
                            AuthorId = 1002,
                            AuthorName = "Amr"
                        },
                        new
                        {
                            AuthorId = 1003,
                            AuthorName = "Subhi"
                        },
                        new
                        {
                            AuthorId = 1004,
                            AuthorName = "Rana"
                        });
                });

            modelBuilder.Entity("DoctorWho.Db.DataModels.Companion", b =>
                {
                    b.Property<int>("CompanionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanionId"));

                    b.Property<string>("CompanionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhoPlayed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanionId");

                    b.ToTable("Companions");

                    b.HasData(
                        new
                        {
                            CompanionId = 1,
                            CompanionName = "Susan Foreman",
                            WhoPlayed = "Carole Ann Ford"
                        },
                        new
                        {
                            CompanionId = 2,
                            CompanionName = "Polly",
                            WhoPlayed = "Anneke Wills"
                        },
                        new
                        {
                            CompanionId = 3,
                            CompanionName = "Liz Shaw",
                            WhoPlayed = "Caroline John"
                        },
                        new
                        {
                            CompanionId = 7,
                            CompanionName = "Mel Bush",
                            WhoPlayed = "Bonnie Langford"
                        },
                        new
                        {
                            CompanionId = 12,
                            CompanionName = "River Song",
                            WhoPlayed = "Alex Kingston"
                        });
                });

            modelBuilder.Entity("DoctorWho.Db.DataModels.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoctorId"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DoctorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DoctorNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("FirstEpisodeDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastEpisodeDate")
                        .HasColumnType("datetime2");

                    b.HasKey("DoctorId");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            DoctorId = 200,
                            BirthDate = new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Local),
                            DoctorName = "William Hartnell",
                            DoctorNumber = 1,
                            FirstEpisodeDate = new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Local),
                            LastEpisodeDate = new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Local)
                        },
                        new
                        {
                            DoctorId = 201,
                            BirthDate = new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Local),
                            DoctorName = "Peter Capaldi",
                            DoctorNumber = 2,
                            FirstEpisodeDate = new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Local),
                            LastEpisodeDate = new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Local)
                        },
                        new
                        {
                            DoctorId = 202,
                            BirthDate = new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Local),
                            DoctorName = "Jon Pertwee",
                            DoctorNumber = 3,
                            FirstEpisodeDate = new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Local),
                            LastEpisodeDate = new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Local)
                        },
                        new
                        {
                            DoctorId = 203,
                            BirthDate = new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Local),
                            DoctorName = "Patrick Troughton",
                            DoctorNumber = 4,
                            FirstEpisodeDate = new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Local),
                            LastEpisodeDate = new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Local)
                        },
                        new
                        {
                            DoctorId = 204,
                            BirthDate = new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Local),
                            DoctorName = "Sylvester McCoy",
                            DoctorNumber = 5,
                            FirstEpisodeDate = new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Local),
                            LastEpisodeDate = new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Local)
                        });
                });

            modelBuilder.Entity("DoctorWho.Db.DataModels.Enemy", b =>
                {
                    b.Property<int>("EnemyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnemyId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnemyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EnemyId");

                    b.ToTable("Enemies");

                    b.HasData(
                        new
                        {
                            EnemyId = 100,
                            Description = "Armies are small armadillo enemies that appear in Donkey Kong Country and Donkey Kong Land.",
                            EnemyName = "Army"
                        },
                        new
                        {
                            EnemyId = 101,
                            Description = "is a Koopa Troopa that has lost its shell and wears nothing more than an undershirt",
                            EnemyName = "Beach Koopa"
                        },
                        new
                        {
                            EnemyId = 102,
                            Description = "also named Green Zingers and Buzzers",
                            EnemyName = "Buzzes"
                        },
                        new
                        {
                            EnemyId = 103,
                            Description = "Croctopuses appear in blue and purple varieties, and their color scheme resembles the venomous blue-ringed octopus.",
                            EnemyName = "Croctopus"
                        },
                        new
                        {
                            EnemyId = 104,
                            Description = "are heavy enemies found in Wario Land II",
                            EnemyName = "Grunts"
                        });
                });

            modelBuilder.Entity("DoctorWho.Db.DataModels.Episode", b =>
                {
                    b.Property<int>("EpisodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EpisodeId"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EpisodeDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EpisodeNumber")
                        .HasColumnType("int");

                    b.Property<string>("EpisodeType")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Episode Type");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("No Notes");

                    b.Property<int>("SeriesNumber")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EpisodeId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("DoctorId");

                    b.ToTable("Episodes");

                    b.HasData(
                        new
                        {
                            EpisodeId = 300,
                            AuthorId = 1002,
                            DoctorId = 200,
                            EpisodeDate = new DateTime(1963, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EpisodeNumber = 2,
                            SeriesNumber = 1,
                            Title = "The Forest of Fear"
                        },
                        new
                        {
                            EpisodeId = 301,
                            AuthorId = 1000,
                            DoctorId = 200,
                            EpisodeDate = new DateTime(2013, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EpisodeNumber = 42,
                            SeriesNumber = 3,
                            Title = "An Unearthly Child"
                        },
                        new
                        {
                            EpisodeId = 302,
                            AuthorId = 1001,
                            DoctorId = 202,
                            EpisodeDate = new DateTime(2013, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EpisodeNumber = 241,
                            SeriesNumber = 9,
                            Title = "The Time of the Doctor"
                        },
                        new
                        {
                            EpisodeId = 303,
                            AuthorId = 1003,
                            DoctorId = 204,
                            EpisodeDate = new DateTime(2014, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EpisodeNumber = 21,
                            SeriesNumber = 8,
                            Title = "Deep Breath"
                        },
                        new
                        {
                            EpisodeId = 304,
                            AuthorId = 1004,
                            DoctorId = 201,
                            EpisodeDate = new DateTime(2013, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EpisodeNumber = 275,
                            SeriesNumber = 10,
                            Title = "The Doctor Falls"
                        });
                });

            modelBuilder.Entity("EnemyEpisode", b =>
                {
                    b.Property<int>("EnemiesEnemyId")
                        .HasColumnType("int");

                    b.Property<int>("EpisodesEpisodeId")
                        .HasColumnType("int");

                    b.HasKey("EnemiesEnemyId", "EpisodesEpisodeId");

                    b.HasIndex("EpisodesEpisodeId");

                    b.ToTable("EnemyEpisode");
                });

            modelBuilder.Entity("CompanionEpisode", b =>
                {
                    b.HasOne("DoctorWho.Db.DataModels.Companion", null)
                        .WithMany()
                        .HasForeignKey("CompanionsCompanionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoctorWho.Db.DataModels.Episode", null)
                        .WithMany()
                        .HasForeignKey("EpisodesEpisodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DoctorWho.Db.DataModels.Episode", b =>
                {
                    b.HasOne("DoctorWho.Db.DataModels.Author", "Author")
                        .WithMany("episodes")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoctorWho.Db.DataModels.Doctor", "Doctor")
                        .WithMany("Episodes")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("EnemyEpisode", b =>
                {
                    b.HasOne("DoctorWho.Db.DataModels.Enemy", null)
                        .WithMany()
                        .HasForeignKey("EnemiesEnemyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoctorWho.Db.DataModels.Episode", null)
                        .WithMany()
                        .HasForeignKey("EpisodesEpisodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DoctorWho.Db.DataModels.Author", b =>
                {
                    b.Navigation("episodes");
                });

            modelBuilder.Entity("DoctorWho.Db.DataModels.Doctor", b =>
                {
                    b.Navigation("Episodes");
                });
#pragma warning restore 612, 618
        }
    }
}