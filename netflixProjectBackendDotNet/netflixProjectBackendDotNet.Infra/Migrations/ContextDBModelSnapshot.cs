﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using netflixProjectBackendDotNet.Infra.Context;

#nullable disable

namespace netflixProjectBackendDotNet.Infra.Migrations
{
    [DbContext(typeof(ContextDB))]
    partial class ContextDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("netflixProjectBackendDotNet.Domain.Entities.Category.CategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<int>("Position")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Action",
                            Position = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Documentary",
                            Position = 2
                        },
                        new
                        {
                            Id = 3,
                            Name = "Comedy",
                            Position = 3
                        },
                        new
                        {
                            Id = 4,
                            Name = "Drama",
                            Position = 4
                        },
                        new
                        {
                            Id = 5,
                            Name = "Fantasy",
                            Position = 5
                        },
                        new
                        {
                            Id = 6,
                            Name = "Adventure",
                            Position = 6
                        });
                });

            modelBuilder.Entity("netflixProjectBackendDotNet.Domain.Entities.Episode.EpisodeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<int>("SecondsLong")
                        .HasColumnType("integer");

                    b.Property<int>("SerieId")
                        .HasColumnType("integer");

                    b.Property<string>("Synopsis")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<string>("ThumbnailUrl")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<DateTime?>("UpdateAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("VideoUrl")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.HasIndex("SerieId");

                    b.ToTable("Episodes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 10, 5, 23, 27, 28, 722, DateTimeKind.Utc).AddTicks(3840),
                            Name = "Episode 1",
                            Order = 0,
                            SecondsLong = 325,
                            SerieId = 1,
                            Synopsis = "This is the Episode 1",
                            ThumbnailUrl = "/thumbnails/serie-7/hotd.jpg",
                            VideoUrl = "/videos/serie-7/Roger Waters - Another Brick In The Wall - Brasilia 2023.mp4"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 10, 5, 23, 27, 28, 722, DateTimeKind.Utc).AddTicks(4006),
                            Name = "Episode 2",
                            Order = 1,
                            SecondsLong = 325,
                            SerieId = 1,
                            Synopsis = "This is the Episode 2",
                            ThumbnailUrl = "/thumbnails/serie-7/hotd.jpg",
                            VideoUrl = "/videos/serie-7/Roger Waters - Another Brick In The Wall - Brasilia 2023.mp4"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 10, 5, 23, 27, 28, 722, DateTimeKind.Utc).AddTicks(4009),
                            Name = "Episode 3",
                            Order = 2,
                            SecondsLong = 325,
                            SerieId = 1,
                            Synopsis = "This is the Episode 3",
                            ThumbnailUrl = "/thumbnails/serie-7/hotd.jpg",
                            VideoUrl = "/videos/serie-7/Roger Waters - Another Brick In The Wall - Brasilia 2023.mp4"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2024, 10, 5, 23, 27, 28, 722, DateTimeKind.Utc).AddTicks(4010),
                            Name = "Episode 1",
                            Order = 0,
                            SecondsLong = 325,
                            SerieId = 7,
                            Synopsis = "This is the Episode 1",
                            ThumbnailUrl = "/thumbnails/serie-7/hotd.jpg",
                            VideoUrl = "/videos/serie-7/Roger Waters - Another Brick In The Wall - Brasilia 2023.mp4"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2024, 10, 5, 23, 27, 28, 722, DateTimeKind.Utc).AddTicks(4012),
                            Name = "Episode 1",
                            Order = 0,
                            SecondsLong = 325,
                            SerieId = 3,
                            Synopsis = "This is the Episode 1",
                            ThumbnailUrl = "/thumbnails/serie-7/hotd.jpg",
                            VideoUrl = "/videos/serie-7/Roger Waters - Another Brick In The Wall - Brasilia 2023.mp4"
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2024, 10, 5, 23, 27, 28, 722, DateTimeKind.Utc).AddTicks(4018),
                            Name = "Episode 1",
                            Order = 0,
                            SecondsLong = 325,
                            SerieId = 2,
                            Synopsis = "This is the Episode 1",
                            ThumbnailUrl = "/thumbnails/serie-7/hotd.jpg",
                            VideoUrl = "/videos/serie-7/Roger Waters - Another Brick In The Wall - Brasilia 2023.mp4"
                        });
                });

            modelBuilder.Entity("netflixProjectBackendDotNet.Domain.Entities.Favorite.FavoriteEntity", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("SerieId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("UserId", "SerieId");

                    b.HasIndex("SerieId");

                    b.ToTable("Favorites", (string)null);
                });

            modelBuilder.Entity("netflixProjectBackendDotNet.Domain.Entities.Like.LikeEntity", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("SerieId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int?>("SerieEntityId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("UserId", "SerieId");

                    b.HasIndex("SerieEntityId");

                    b.HasIndex("SerieId");

                    b.ToTable("Likes", (string)null);
                });

            modelBuilder.Entity("netflixProjectBackendDotNet.Domain.Entities.Serie.SerieEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<bool>("Featured")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<string>("Synopsis")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("ThumbnailUrl")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Series", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedAt = new DateTime(2024, 10, 5, 23, 27, 28, 721, DateTimeKind.Utc).AddTicks(9901),
                            Featured = true,
                            Name = "Prison Break",
                            Synopsis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            ThumbnailUrl = "/serie/prisonbreak.jpg"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            CreatedAt = new DateTime(2024, 10, 5, 23, 27, 28, 722, DateTimeKind.Utc).AddTicks(6),
                            Featured = true,
                            Name = "Breaking Bad",
                            Synopsis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            ThumbnailUrl = "/serie/breakingbad.jpg"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 6,
                            CreatedAt = new DateTime(2024, 10, 5, 23, 27, 28, 722, DateTimeKind.Utc).AddTicks(8),
                            Featured = true,
                            Name = "The Boys",
                            Synopsis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            ThumbnailUrl = "/serie/theboys.jpg"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 3,
                            CreatedAt = new DateTime(2024, 10, 5, 23, 27, 28, 722, DateTimeKind.Utc).AddTicks(9),
                            Featured = true,
                            Name = "Friends",
                            Synopsis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            ThumbnailUrl = "/serie/friends.jpg"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            CreatedAt = new DateTime(2024, 10, 5, 23, 27, 28, 722, DateTimeKind.Utc).AddTicks(10),
                            Featured = true,
                            Name = "How I Met Your Mother",
                            Synopsis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            ThumbnailUrl = "/serie/himym.jpg"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 5,
                            CreatedAt = new DateTime(2024, 10, 5, 23, 27, 28, 722, DateTimeKind.Utc).AddTicks(21),
                            Featured = true,
                            Name = "Game of Thrones",
                            Synopsis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            ThumbnailUrl = "/serie/got.jpg"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 5,
                            CreatedAt = new DateTime(2024, 10, 5, 23, 27, 28, 722, DateTimeKind.Utc).AddTicks(22),
                            Featured = true,
                            Name = "House of the Dragon",
                            Synopsis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            ThumbnailUrl = "/serie/hotd.jpg"
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 6,
                            CreatedAt = new DateTime(2024, 10, 5, 23, 27, 28, 722, DateTimeKind.Utc).AddTicks(23),
                            Featured = true,
                            Name = "The Last of Us",
                            Synopsis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            ThumbnailUrl = "/serie/tlou.jpg"
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 4,
                            CreatedAt = new DateTime(2024, 10, 5, 23, 27, 28, 722, DateTimeKind.Utc).AddTicks(24),
                            Featured = true,
                            Name = "Vikings",
                            Synopsis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            ThumbnailUrl = "/serie/vikings.jpg"
                        });
                });

            modelBuilder.Entity("netflixProjectBackendDotNet.Domain.Entities.User.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Birth = new DateTime(1991, 1, 1, 2, 0, 0, 0, DateTimeKind.Utc),
                            CreatedAt = new DateTime(2024, 10, 5, 23, 27, 28, 721, DateTimeKind.Utc).AddTicks(5686),
                            Email = "admin@email.com",
                            FirstName = "Admin",
                            LastName = "User",
                            Password = "$2a$12$Yy.Yal.jrqvAPlMDhUhKBOtRfQT5/LjIeYm329hgy2J0HSZR5WKsa",
                            Phone = "(31) 99999-9999",
                            Role = 0
                        });
                });

            modelBuilder.Entity("netflixProjectBackendDotNet.Domain.Entities.WatchTime.WatchTimeEntity", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("EpisodeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("SecondsLong")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("UserId", "EpisodeId");

                    b.HasIndex("EpisodeId");

                    b.ToTable("WatchTimes", (string)null);
                });

            modelBuilder.Entity("netflixProjectBackendDotNet.Domain.Entities.Episode.EpisodeEntity", b =>
                {
                    b.HasOne("netflixProjectBackendDotNet.Domain.Entities.Serie.SerieEntity", "Serie")
                        .WithMany("Episodes")
                        .HasForeignKey("SerieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Serie");
                });

            modelBuilder.Entity("netflixProjectBackendDotNet.Domain.Entities.Favorite.FavoriteEntity", b =>
                {
                    b.HasOne("netflixProjectBackendDotNet.Domain.Entities.Serie.SerieEntity", "Serie")
                        .WithMany()
                        .HasForeignKey("SerieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("netflixProjectBackendDotNet.Domain.Entities.User.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Serie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("netflixProjectBackendDotNet.Domain.Entities.Like.LikeEntity", b =>
                {
                    b.HasOne("netflixProjectBackendDotNet.Domain.Entities.Serie.SerieEntity", null)
                        .WithMany("Likes")
                        .HasForeignKey("SerieEntityId");

                    b.HasOne("netflixProjectBackendDotNet.Domain.Entities.Serie.SerieEntity", "Serie")
                        .WithMany()
                        .HasForeignKey("SerieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("netflixProjectBackendDotNet.Domain.Entities.User.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Serie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("netflixProjectBackendDotNet.Domain.Entities.Serie.SerieEntity", b =>
                {
                    b.HasOne("netflixProjectBackendDotNet.Domain.Entities.Category.CategoryEntity", "Category")
                        .WithMany("Series")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("netflixProjectBackendDotNet.Domain.Entities.WatchTime.WatchTimeEntity", b =>
                {
                    b.HasOne("netflixProjectBackendDotNet.Domain.Entities.Episode.EpisodeEntity", "Episode")
                        .WithMany()
                        .HasForeignKey("EpisodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("netflixProjectBackendDotNet.Domain.Entities.User.UserEntity", "User")
                        .WithMany("WatchTimes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Episode");

                    b.Navigation("User");
                });

            modelBuilder.Entity("netflixProjectBackendDotNet.Domain.Entities.Category.CategoryEntity", b =>
                {
                    b.Navigation("Series");
                });

            modelBuilder.Entity("netflixProjectBackendDotNet.Domain.Entities.Serie.SerieEntity", b =>
                {
                    b.Navigation("Episodes");

                    b.Navigation("Likes");
                });

            modelBuilder.Entity("netflixProjectBackendDotNet.Domain.Entities.User.UserEntity", b =>
                {
                    b.Navigation("WatchTimes");
                });
#pragma warning restore 612, 618
        }
    }
}
