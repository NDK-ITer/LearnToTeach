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
    [DbContext(typeof(ClassroomDbContext))]
    [Migration("20231207081722_ClassroomService-updateColumn-UpdateDate")]
    partial class ClassroomServiceupdateColumnUpdateDate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Answer", b =>
                {
                    b.Property<string>("IdExercise")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdMember")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateAnswer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 12, 7, 15, 17, 22, 319, DateTimeKind.Local).AddTicks(6978));

                    b.Property<DateTime>("DateUpdateAnswer")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("LinkFile")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<float?>("Point")
                        .HasColumnType("real");

                    b.HasKey("IdExercise", "IdMember");

                    b.HasIndex("IdMember");

                    b.ToTable("Answer", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Classroom", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Avatar")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 12, 7, 15, 17, 22, 315, DateTimeKind.Local).AddTicks(6767));

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("bit");

                    b.Property<string>("KeyHash")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LinkAvatar")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Classrooms", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Exercise", b =>
                {
                    b.Property<string>("IdExercise")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 12, 7, 15, 17, 22, 319, DateTimeKind.Local).AddTicks(5489));

                    b.Property<DateTime?>("DeadLine")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FileName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("IdClassroom")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LinkFile")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdExercise");

                    b.HasIndex("IdClassroom");

                    b.ToTable("Exercise", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.LearningDocument", b =>
                {
                    b.Property<string>("NameFile")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("IdClassroom")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LinkFile")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("UploadDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 12, 7, 15, 17, 22, 319, DateTimeKind.Local).AddTicks(8567));

                    b.HasKey("NameFile");

                    b.HasIndex("IdClassroom");

                    b.ToTable("LearningDocument", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Member", b =>
                {
                    b.Property<string>("IdMember")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Avatar")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LinkAvatar")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdMember");

                    b.ToTable("Member", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.MemberClassroom", b =>
                {
                    b.Property<string>("IdUser")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("IdClass")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Role")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdUser", "IdClass");

                    b.HasIndex("IdClass");

                    b.ToTable("MemberClassroom", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.NotifyClassroom", b =>
                {
                    b.Property<string>("IdNotify")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 12, 7, 15, 17, 22, 319, DateTimeKind.Local).AddTicks(9855));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("IdClassroom")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("NameNotify")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.HasKey("IdNotify");

                    b.HasIndex("IdClassroom");

                    b.ToTable("NotifyClassroom", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Answer", b =>
                {
                    b.HasOne("Domain.Entities.Exercise", "Exercise")
                        .WithMany("ListAnswer")
                        .HasForeignKey("IdExercise")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Member", "Member")
                        .WithMany("ListAnswer")
                        .HasForeignKey("IdMember")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Domain.Entities.Exercise", b =>
                {
                    b.HasOne("Domain.Entities.Classroom", "Classroom")
                        .WithMany("ListExercise")
                        .HasForeignKey("IdClassroom");

                    b.Navigation("Classroom");
                });

            modelBuilder.Entity("Domain.Entities.LearningDocument", b =>
                {
                    b.HasOne("Domain.Entities.Classroom", "Classroom")
                        .WithMany("ListDocument")
                        .HasForeignKey("IdClassroom")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classroom");
                });

            modelBuilder.Entity("Domain.Entities.MemberClassroom", b =>
                {
                    b.HasOne("Domain.Entities.Classroom", "Classroom")
                        .WithMany("ListMemberClassroom")
                        .HasForeignKey("IdClass")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Member", "Member")
                        .WithMany("ListMemberClassroom")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classroom");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Domain.Entities.NotifyClassroom", b =>
                {
                    b.HasOne("Domain.Entities.Classroom", "Classroom")
                        .WithMany("ListNotifies")
                        .HasForeignKey("IdClassroom")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classroom");
                });

            modelBuilder.Entity("Domain.Entities.Classroom", b =>
                {
                    b.Navigation("ListDocument");

                    b.Navigation("ListExercise");

                    b.Navigation("ListMemberClassroom");

                    b.Navigation("ListNotifies");
                });

            modelBuilder.Entity("Domain.Entities.Exercise", b =>
                {
                    b.Navigation("ListAnswer");
                });

            modelBuilder.Entity("Domain.Entities.Member", b =>
                {
                    b.Navigation("ListAnswer");

                    b.Navigation("ListMemberClassroom");
                });
#pragma warning restore 612, 618
        }
    }
}
