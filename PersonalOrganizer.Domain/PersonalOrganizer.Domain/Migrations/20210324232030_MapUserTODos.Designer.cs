﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PersonalOrganizer.Domain.DataAccess;

namespace PersonalOrganizer.Domain.Migrations
{
    [DbContext(typeof(TrackerDbContext))]
    [Migration("20210324232030_MapUserTODos")]
    partial class MapUserTODos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("PersonalOrganizer.Domain.Models.AppUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("IdProvider")
                        .HasColumnType("text");

                    b.Property<string>("UserEamil")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("PersonalOrganizer.Domain.Models.Note", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("NoteDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("NoteText")
                        .HasColumnType("text");

                    b.HasKey("NoteId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("PersonalOrganizer.Domain.Models.ToDo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("AppUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DateCompleted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("ToDos");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            DateCreated = new DateTime(2021, 3, 24, 19, 20, 29, 961, DateTimeKind.Local).AddTicks(9410),
                            Description = "Feed the dog",
                            IsCompleted = false
                        },
                        new
                        {
                            Id = 2L,
                            DateCreated = new DateTime(2021, 3, 24, 19, 20, 29, 974, DateTimeKind.Local).AddTicks(220),
                            Description = "Feed the cat",
                            IsCompleted = false
                        },
                        new
                        {
                            Id = 3L,
                            DateCreated = new DateTime(2021, 3, 24, 19, 20, 29, 974, DateTimeKind.Local).AddTicks(250),
                            Description = "Walk the dog",
                            IsCompleted = false
                        },
                        new
                        {
                            Id = 4L,
                            DateCreated = new DateTime(2021, 3, 24, 19, 20, 29, 974, DateTimeKind.Local).AddTicks(260),
                            Description = "Change cat litter",
                            IsCompleted = false
                        });
                });

            modelBuilder.Entity("PersonalOrganizer.Domain.Models.ToDo", b =>
                {
                    b.HasOne("PersonalOrganizer.Domain.Models.AppUser", null)
                        .WithMany("UserToDos")
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("PersonalOrganizer.Domain.Models.AppUser", b =>
                {
                    b.Navigation("UserToDos");
                });
#pragma warning restore 612, 618
        }
    }
}
