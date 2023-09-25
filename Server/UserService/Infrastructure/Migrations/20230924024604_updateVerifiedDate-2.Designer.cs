﻿// <auto-generated />
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AuthenticationDbContext))]
    [Migration("20230924024604_updateVerifiedDate-2")]
    partial class updateVerifiedDate2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Role", b =>
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
                            Id = "77d0ae4e-0466-4a77-8862-0d634371a049",
                            Description = "",
                            Name = "ADMIN",
                            NomalizeName = "Admin"
                        },
                        new
                        {
                            Id = "527428c3-5f67-42bc-a573-f11471706589",
                            Description = "",
                            Name = "USER",
                            NomalizeName = "User"
                        });
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
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

                    b.Property<string>("TokenAccess")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("VerifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            id = "d8b8ec79-cd6e-433e-8de6-7b7af589af7c",
                            Birthday = new DateTime(2023, 9, 24, 9, 46, 4, 3, DateTimeKind.Local).AddTicks(9206),
                            CreatedDate = new DateTime(2023, 9, 24, 9, 46, 4, 3, DateTimeKind.Local).AddTicks(9215),
                            FirstEmail = "test001@gmail.com",
                            FirstName = "test",
                            IsLock = false,
                            LastName = "account",
                            PasswordHash = "nSUQ/133didCpNJLsvcLvQ==",
                            PresentEmail = "test001@gmail.com",
                            RoleId = "527428c3-5f67-42bc-a573-f11471706589",
                            TokenAccess = "",
                            UserName = "testVersion_0001",
                            VerifiedDate = new DateTime(2023, 9, 24, 9, 46, 4, 3, DateTimeKind.Local).AddTicks(9216)
                        },
                        new
                        {
                            id = "71c27472-2948-483e-a54e-4d2a2d31da57",
                            Birthday = new DateTime(2023, 9, 24, 9, 46, 4, 3, DateTimeKind.Local).AddTicks(9316),
                            CreatedDate = new DateTime(2023, 9, 24, 9, 46, 4, 3, DateTimeKind.Local).AddTicks(9316),
                            FirstEmail = "admin001@gmail.com",
                            FirstName = "Admin",
                            IsLock = false,
                            LastName = "account",
                            PasswordHash = "VWBU8/+H4em26o8A92n+Tg==",
                            PresentEmail = "admin001@gmail.com",
                            RoleId = "77d0ae4e-0466-4a77-8862-0d634371a049",
                            TokenAccess = "",
                            UserName = "adminVersion_0001",
                            VerifiedDate = new DateTime(2023, 9, 24, 9, 46, 4, 3, DateTimeKind.Local).AddTicks(9317)
                        });
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.HasOne("Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
