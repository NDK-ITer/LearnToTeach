﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SagaOrchestration.Models;

#nullable disable

namespace SagaOrchestration.Migrations
{
    [DbContext(typeof(SagaDbContext))]
    [Migration("20231108134910_SeviceOrchestration-delete-1-row-1")]
    partial class SeviceOrchestrationdelete1row1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SagaStateMachine.ClassroomService.Classroom.AddClassroom.AddClassroomStateData", b =>
                {
                    b.Property<Guid>("CorrelationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CurrentState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdClassroom")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("IdUserHost")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CorrelationId");

                    b.ToTable("AddClassroomStateData");
                });

            modelBuilder.Entity("SagaStateMachine.ClassroomService.Member.AddMember.MemberModel", b =>
                {
                    b.Property<Guid>("idMemberModel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddMemberStateDataCorrelationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdMember")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameMember")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idMemberModel");

                    b.HasIndex("AddMemberStateDataCorrelationId");

                    b.ToTable("MemberModel");
                });

            modelBuilder.Entity("SagaStateMachine.ClassroomService.Member.AddMemberStateData", b =>
                {
                    b.Property<Guid>("CorrelationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CurrentState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdClassroom")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NameClassroom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CorrelationId");

                    b.ToTable("AddMemberStateData");
                });

            modelBuilder.Entity("SagaStateMachine.UserService.ConfirmUserEmail.ConfirmUserEmailStateData", b =>
                {
                    b.Property<Guid>("CorrelationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CorrelationId");

                    b.ToTable("ConfirmUserEmailStateData");
                });

            modelBuilder.Entity("SagaStateMachine.UserService.ResetPassword.ResetPasswordStateData", b =>
                {
                    b.Property<Guid>("CorrelationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CorrelationId");

                    b.ToTable("ResetPasswordStateData");
                });

            modelBuilder.Entity("SagaStateMachine.ClassroomService.Member.AddMember.MemberModel", b =>
                {
                    b.HasOne("SagaStateMachine.ClassroomService.Member.AddMemberStateData", null)
                        .WithMany("ListMember")
                        .HasForeignKey("AddMemberStateDataCorrelationId");
                });

            modelBuilder.Entity("SagaStateMachine.ClassroomService.Member.AddMemberStateData", b =>
                {
                    b.Navigation("ListMember");
                });
#pragma warning restore 612, 618
        }
    }
}
