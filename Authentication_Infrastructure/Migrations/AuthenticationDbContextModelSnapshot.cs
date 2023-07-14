﻿// <auto-generated />
using System;
using Authentication_Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Authentication_Infrastructure.Migrations
{
    [DbContext(typeof(AuthenticationDbContext))]
    partial class AuthenticationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Authentication_Data.Entites.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("NomalizeName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "14ee1a43-5970-4108-b1ed-45e669bcdf83",
                            Description = "",
                            Name = "ADMIN",
                            NomalizeName = "Admin"
                        },
                        new
                        {
                            Id = "88a3020e-e0e0-4abb-ad1c-63c52a0364a2",
                            Description = "",
                            Name = "USER",
                            NomalizeName = "User"
                        });
                });

            modelBuilder.Entity("Authentication_Data.Entites.User", b =>
                {
                    b.Property<string>("id")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstEmail")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsLock")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PresentEmail")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            id = "a7c915d6-d121-4eed-acd9-52628530ae48",
                            Birthday = new DateTime(2023, 7, 13, 12, 12, 15, 409, DateTimeKind.Local).AddTicks(3100),
                            CreatedDate = new DateTime(2023, 7, 13, 12, 12, 15, 409, DateTimeKind.Local).AddTicks(3111),
                            FirstEmail = "test001@gmail.com",
                            FirstName = "test",
                            IsLock = false,
                            LastName = "account",
                            PasswordHash = "$2a$10$XD1mRo8wZ/h9aJtAD0i2yOmR3PPKb/3R4bIcwHaWu6gV5RAh3c7pG",
                            PresentEmail = "test001@gmail.com",
                            RoleId = "88a3020e-e0e0-4abb-ad1c-63c52a0364a2",
                            UserName = "testVersion_0001"
                        },
                        new
                        {
                            id = "e7d048ec-81c2-4541-ac58-bf02f69f6721",
                            Birthday = new DateTime(2023, 7, 13, 12, 12, 15, 409, DateTimeKind.Local).AddTicks(3118),
                            CreatedDate = new DateTime(2023, 7, 13, 12, 12, 15, 409, DateTimeKind.Local).AddTicks(3119),
                            FirstEmail = "admin001@gmail.com",
                            FirstName = "Admin",
                            IsLock = false,
                            LastName = "account",
                            PasswordHash = "$2a$10$3cfpf9Kd5RWjGwIJB6acRuCJErWLuvtrrbys2OwxDJZNnRMUtGTha",
                            PresentEmail = "admin001@gmail.com",
                            RoleId = "14ee1a43-5970-4108-b1ed-45e669bcdf83",
                            UserName = "adminVersion_0001"
                        });
                });

            modelBuilder.Entity("Authentication_Data.Entites.User", b =>
                {
                    b.HasOne("Authentication_Data.Entites.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Authentication_Data.Entites.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
