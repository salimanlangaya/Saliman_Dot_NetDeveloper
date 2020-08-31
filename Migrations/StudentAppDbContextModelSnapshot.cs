﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Saliman_Dot_NetDeveloper.Context;

namespace Saliman_Dot_NetDeveloper.Migrations
{
    [DbContext(typeof(StudentAppDbContext))]
    partial class StudentAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Saliman_Dot_NetDeveloper.Context.ClassMaster", b =>
                {
                    b.Property<int>("ClassID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.HasKey("ClassID");

                    b.ToTable("ClassMaster","dbo");
                });

            modelBuilder.Entity("Saliman_Dot_NetDeveloper.Context.StudentMaster", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassID")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.HasKey("StudentID");

                    b.HasIndex("ClassID");

                    b.ToTable("StudentMaster","dbo");
                });

            modelBuilder.Entity("Saliman_Dot_NetDeveloper.Context.StudentSubjectRef", b =>
                {
                    b.Property<int>("StudentSubjectRefID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Marks")
                        .HasColumnType("decimal(5,2)");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<int>("SubjectID")
                        .HasColumnType("int");

                    b.HasKey("StudentSubjectRefID");

                    b.HasIndex("StudentID");

                    b.HasIndex("SubjectID");

                    b.ToTable("StudentSubjectRef","dbo");
                });

            modelBuilder.Entity("Saliman_Dot_NetDeveloper.Context.SubjectMaster", b =>
                {
                    b.Property<int>("SubjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.HasKey("SubjectID");

                    b.ToTable("SubjectMaster","dbo");
                });

            modelBuilder.Entity("Saliman_Dot_NetDeveloper.Context.StudentMaster", b =>
                {
                    b.HasOne("Saliman_Dot_NetDeveloper.Context.ClassMaster", "Classes")
                        .WithMany()
                        .HasForeignKey("ClassID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Saliman_Dot_NetDeveloper.Context.StudentSubjectRef", b =>
                {
                    b.HasOne("Saliman_Dot_NetDeveloper.Context.StudentMaster", "Students")
                        .WithMany()
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Saliman_Dot_NetDeveloper.Context.SubjectMaster", "Subjects")
                        .WithMany()
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}