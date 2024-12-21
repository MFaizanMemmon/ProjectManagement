﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoApp.DBManageFolder;

#nullable disable

namespace ToDoApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241221161827_LocalDbCreate")]
    partial class LocalDbCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ToDoApp.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"));

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("TeamsTeamId")
                        .HasColumnType("int");

                    b.HasKey("ProjectId");

                    b.HasIndex("TeamsTeamId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("ToDoApp.Models.TeamMemberProjects", b =>
                {
                    b.Property<int>("TeamMemberProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamMemberProjectId"));

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("TeamMemberID")
                        .HasColumnType("int");

                    b.HasKey("TeamMemberProjectId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TeamMemberID");

                    b.ToTable("TeamProjects");
                });

            modelBuilder.Entity("ToDoApp.Models.Teams", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamId"));

                    b.Property<string>("MemberName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("ToDoApp.Models.ToDo", b =>
                {
                    b.Property<int>("TodoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TodoId"));

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileNames")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TodoId");

                    b.HasIndex("ProjectID");

                    b.ToTable("Todo");
                });

            modelBuilder.Entity("ToDoApp.Models.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ToDoApp.Models.Project", b =>
                {
                    b.HasOne("ToDoApp.Models.Teams", null)
                        .WithMany("Projects")
                        .HasForeignKey("TeamsTeamId");
                });

            modelBuilder.Entity("ToDoApp.Models.TeamMemberProjects", b =>
                {
                    b.HasOne("ToDoApp.Models.Project", "Project")
                        .WithMany("TeamMemberProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ToDoApp.Models.Teams", "Team")
                        .WithMany("TeamMemberProjects")
                        .HasForeignKey("TeamMemberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("ToDoApp.Models.ToDo", b =>
                {
                    b.HasOne("ToDoApp.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ToDoApp.Models.Project", b =>
                {
                    b.Navigation("TeamMemberProjects");
                });

            modelBuilder.Entity("ToDoApp.Models.Teams", b =>
                {
                    b.Navigation("Projects");

                    b.Navigation("TeamMemberProjects");
                });
#pragma warning restore 612, 618
        }
    }
}
