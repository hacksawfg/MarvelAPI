﻿// <auto-generated />
using System;
using Marvel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Marvel.Data.Migrations
{
    [DbContext(typeof(MarvelDbContext))]
    [Migration("20220210220954_RemovedSomeTableHeaders")]
    partial class RemovedSomeTableHeaders
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CastCrewEntityMovieEntity", b =>
                {
                    b.Property<int>("MovieCastCrewId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesMovieId")
                        .HasColumnType("int");

                    b.HasKey("MovieCastCrewId", "MoviesMovieId");

                    b.HasIndex("MoviesMovieId");

                    b.ToTable("CastCrewEntityMovieEntity");
                });

            modelBuilder.Entity("Marvel.Data.Entities.CastCrewEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImdbPage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CastAndCrewMembers");
                });

            modelBuilder.Entity("Marvel.Data.Entities.MovieEntity", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MovieBoxOfficeUSD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieDirector")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MovieName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("MovieId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Marvel.Data.Entities.TeamEntity", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Leader")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Marvel.Data.MarvelCharacterEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CastCrewId")
                        .HasColumnType("int");

                    b.Property<string>("Gear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nemesis")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Powers")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CastCrewId")
                        .IsUnique()
                        .HasFilter("[CastCrewId] IS NOT NULL");

                    b.ToTable("MarvelCharacters");
                });

            modelBuilder.Entity("MarvelCharacterEntityMovieEntity", b =>
                {
                    b.Property<int>("MovieCharactersId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesMovieId")
                        .HasColumnType("int");

                    b.HasKey("MovieCharactersId", "MoviesMovieId");

                    b.HasIndex("MoviesMovieId");

                    b.ToTable("MarvelCharacterEntityMovieEntity");
                });

            modelBuilder.Entity("MarvelCharacterEntityTeamEntity", b =>
                {
                    b.Property<int>("TeamMembersId")
                        .HasColumnType("int");

                    b.Property<int>("TeamsTeamId")
                        .HasColumnType("int");

                    b.HasKey("TeamMembersId", "TeamsTeamId");

                    b.HasIndex("TeamsTeamId");

                    b.ToTable("MarvelCharacterEntityTeamEntity");
                });

            modelBuilder.Entity("MovieEntityTeamEntity", b =>
                {
                    b.Property<int>("MovieTeamsTeamId")
                        .HasColumnType("int");

                    b.Property<int>("TeamMoviesMovieId")
                        .HasColumnType("int");

                    b.HasKey("MovieTeamsTeamId", "TeamMoviesMovieId");

                    b.HasIndex("TeamMoviesMovieId");

                    b.ToTable("MovieEntityTeamEntity");
                });

            modelBuilder.Entity("CastCrewEntityMovieEntity", b =>
                {
                    b.HasOne("Marvel.Data.Entities.CastCrewEntity", null)
                        .WithMany()
                        .HasForeignKey("MovieCastCrewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Marvel.Data.Entities.MovieEntity", null)
                        .WithMany()
                        .HasForeignKey("MoviesMovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Marvel.Data.MarvelCharacterEntity", b =>
                {
                    b.HasOne("Marvel.Data.Entities.CastCrewEntity", "Actor")
                        .WithOne("Character")
                        .HasForeignKey("Marvel.Data.MarvelCharacterEntity", "CastCrewId");

                    b.Navigation("Actor");
                });

            modelBuilder.Entity("MarvelCharacterEntityMovieEntity", b =>
                {
                    b.HasOne("Marvel.Data.MarvelCharacterEntity", null)
                        .WithMany()
                        .HasForeignKey("MovieCharactersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Marvel.Data.Entities.MovieEntity", null)
                        .WithMany()
                        .HasForeignKey("MoviesMovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MarvelCharacterEntityTeamEntity", b =>
                {
                    b.HasOne("Marvel.Data.MarvelCharacterEntity", null)
                        .WithMany()
                        .HasForeignKey("TeamMembersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Marvel.Data.Entities.TeamEntity", null)
                        .WithMany()
                        .HasForeignKey("TeamsTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieEntityTeamEntity", b =>
                {
                    b.HasOne("Marvel.Data.Entities.TeamEntity", null)
                        .WithMany()
                        .HasForeignKey("MovieTeamsTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Marvel.Data.Entities.MovieEntity", null)
                        .WithMany()
                        .HasForeignKey("TeamMoviesMovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Marvel.Data.Entities.CastCrewEntity", b =>
                {
                    b.Navigation("Character");
                });
#pragma warning restore 612, 618
        }
    }
}