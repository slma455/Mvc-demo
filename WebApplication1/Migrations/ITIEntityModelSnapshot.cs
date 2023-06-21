﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Models;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ITIEntity))]
    partial class ITIEntityModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Models.Account", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("WebApplication1.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Degree")
                        .HasColumnType("int");

                    b.Property<int>("Dept_id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("minDegree")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Dept_id");

                    b.ToTable("courses");
                });

            modelBuilder.Entity("WebApplication1.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Manger")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("department");
                });

            modelBuilder.Entity("WebApplication1.Models.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Crs_id")
                        .HasColumnType("int");

                    b.Property<int>("Dept_id")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("Crs_id");

                    b.HasIndex("Dept_id");

                    b.ToTable("instructor");
                });

            modelBuilder.Entity("WebApplication1.Models.Trainee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Dept_id")
                        .HasColumnType("int");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Dept_id");

                    b.ToTable("trainee");
                });

            modelBuilder.Entity("WebApplication1.Models.crsCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Crs_id")
                        .HasColumnType("int");

                    b.Property<int>("Degree")
                        .HasColumnType("int");

                    b.Property<int>("Trainee_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Crs_id");

                    b.HasIndex("Trainee_id");

                    b.ToTable("crsCourses");
                });

            modelBuilder.Entity("WebApplication1.Models.Course", b =>
                {
                    b.HasOne("WebApplication1.Models.Department", "Department")
                        .WithMany("Course")
                        .HasForeignKey("Dept_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("WebApplication1.Models.Instructor", b =>
                {
                    b.HasOne("WebApplication1.Models.Course", "Course")
                        .WithMany("instructors")
                        .HasForeignKey("Crs_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Department", "Department")
                        .WithMany("Instructors")
                        .HasForeignKey("Dept_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("WebApplication1.Models.Trainee", b =>
                {
                    b.HasOne("WebApplication1.Models.Department", "Department")
                        .WithMany("Trainees")
                        .HasForeignKey("Dept_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("WebApplication1.Models.crsCourse", b =>
                {
                    b.HasOne("WebApplication1.Models.Course", "Course")
                        .WithMany("crs")
                        .HasForeignKey("Crs_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Trainee", "Trainee")
                        .WithMany("crs")
                        .HasForeignKey("Trainee_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Trainee");
                });

            modelBuilder.Entity("WebApplication1.Models.Course", b =>
                {
                    b.Navigation("crs");

                    b.Navigation("instructors");
                });

            modelBuilder.Entity("WebApplication1.Models.Department", b =>
                {
                    b.Navigation("Course");

                    b.Navigation("Instructors");

                    b.Navigation("Trainees");
                });

            modelBuilder.Entity("WebApplication1.Models.Trainee", b =>
                {
                    b.Navigation("crs");
                });
#pragma warning restore 612, 618
        }
    }
}
