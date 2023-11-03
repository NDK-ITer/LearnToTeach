﻿// <auto-generated />
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ClassroomDbContext))]
    partial class ClassroomDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Classroom", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("AvatarUserHost")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 11, 3, 13, 50, 46, 361, DateTimeKind.Local).AddTicks(7606));

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("IdUserHost")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("bit");

                    b.Property<string>("KeyHash")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameUserHost")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Classrooms", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "ee546ce7-842a-4dee-86d0-0db1ff3b64b4",
                            CreateDate = new DateTime(2023, 11, 3, 13, 50, 46, 362, DateTimeKind.Local).AddTicks(5101),
                            IdUserHost = "193ba283-bf34-40ad-a3be-10b1780cba0e",
                            IsPrivate = true,
                            KeyHash = "cA4FigUKj7deRjen/4NWmw==",
                            Name = "Class_1"
                        },
                        new
                        {
                            Id = "0a006921-b4a4-40de-a1e6-9497daf09a2f",
                            CreateDate = new DateTime(2023, 11, 3, 13, 50, 46, 362, DateTimeKind.Local).AddTicks(5277),
                            IdUserHost = "2c75293b-f8e5-4862-9b13-5894a64895cd",
                            IsPrivate = false,
                            Name = "Class_2"
                        });
                });

            modelBuilder.Entity("Domain.Entities.MemberClassroom", b =>
                {
                    b.Property<string>("IdUser")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("IdClass")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Role")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdUser", "IdClass");

                    b.HasIndex("IdClass");

                    b.ToTable("MemberClassroom", (string)null);

                    b.HasData(
                        new
                        {
                            IdUser = "2c75293b-f8e5-4862-9b13-5894a64895cd",
                            IdClass = "ee546ce7-842a-4dee-86d0-0db1ff3b64b4",
                            Avatar = "",
                            Description = "",
                            Name = "Admin account",
                            Role = ""
                        },
                        new
                        {
                            IdUser = "193ba283-bf34-40ad-a3be-10b1780cba0e",
                            IdClass = "0a006921-b4a4-40de-a1e6-9497daf09a2f",
                            Avatar = "",
                            Description = "",
                            Name = "test account",
                            Role = ""
                        });
                });

            modelBuilder.Entity("Domain.Entities.MemberClassroom", b =>
                {
                    b.HasOne("Domain.Entities.Classroom", "classroom")
                        .WithMany("ListUserId")
                        .HasForeignKey("IdClass")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("classroom");
                });

            modelBuilder.Entity("Domain.Entities.Classroom", b =>
                {
                    b.Navigation("ListUserId");
                });
#pragma warning restore 612, 618
        }
    }
}
