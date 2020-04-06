﻿// <auto-generated />
using System;
using CourseManager.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CourseManager.DataAccess.Migrations
{
    [DbContext(typeof(CourseManagerDbContext))]
    [Migration("20200406075315_AddUserIdToEntities")]
    partial class AddUserIdToEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CourseManager.ApplicationLogic.DataModel.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("CourseManager.ApplicationLogic.DataModel.CourseGrade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("GradeValue")
                        .HasColumnType("float");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("CourseGrades");
                });

            modelBuilder.Entity("CourseManager.ApplicationLogic.DataModel.CoursePresence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("PresenceValue")
                        .HasColumnType("bit");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("CoursePresences");
                });

            modelBuilder.Entity("CourseManager.ApplicationLogic.DataModel.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("CourseManager.ApplicationLogic.DataModel.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("CourseManager.ApplicationLogic.DataModel.Course", b =>
                {
                    b.HasOne("CourseManager.ApplicationLogic.DataModel.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("CourseManager.ApplicationLogic.DataModel.CourseGrade", b =>
                {
                    b.HasOne("CourseManager.ApplicationLogic.DataModel.Course", null)
                        .WithMany("CourseGrades")
                        .HasForeignKey("CourseId");

                    b.HasOne("CourseManager.ApplicationLogic.DataModel.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("CourseManager.ApplicationLogic.DataModel.CoursePresence", b =>
                {
                    b.HasOne("CourseManager.ApplicationLogic.DataModel.Course", null)
                        .WithMany("CoursePresences")
                        .HasForeignKey("CourseId");

                    b.HasOne("CourseManager.ApplicationLogic.DataModel.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("CourseManager.ApplicationLogic.DataModel.Student", b =>
                {
                    b.HasOne("CourseManager.ApplicationLogic.DataModel.Course", null)
                        .WithMany("Students")
                        .HasForeignKey("CourseId");
                });
#pragma warning restore 612, 618
        }
    }
}
