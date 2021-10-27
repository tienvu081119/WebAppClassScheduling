﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp.Models;

namespace WebApp.Migrations
{
    [DbContext(typeof(CSContext))]
    [Migration("20211027132727_Add_Group_Table")]
    partial class Add_Group_Table
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApp.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("GroupId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("Size")
                        .HasColumnType("smallint")
                        .HasColumnName("GroupSize");

                    b.HasKey("Id");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("WebApp.Models.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ModuleId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ModuleCode");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ModuleName");

                    b.HasKey("Id");

                    b.ToTable("Module");
                });

            modelBuilder.Entity("WebApp.Models.ModuleProfessor", b =>
                {
                    b.Property<int>("ModuleId")
                        .HasColumnType("int");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("int");

                    b.HasKey("ModuleId", "ProfessorId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("ModuleProfessor");
                });

            modelBuilder.Entity("WebApp.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProfessorId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Professor");
                });

            modelBuilder.Entity("WebApp.Models.ProfessorChecked", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProfessorId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Checked")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("professorCheckeds");
                });

            modelBuilder.Entity("WebApp.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RoomId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("Capacity")
                        .HasColumnType("smallint");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("RoomNumber");

                    b.HasKey("Id");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("WebApp.Models.Timeslot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TimeslotId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<TimeSpan>("End")
                        .HasColumnType("time")
                        .HasColumnName("EndTime");

                    b.Property<TimeSpan>("Start")
                        .HasColumnType("time")
                        .HasColumnName("StartTime");

                    b.Property<string>("Weekday")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Timeslot");
                });

            modelBuilder.Entity("WebApp.Models.ModuleProfessor", b =>
                {
                    b.HasOne("WebApp.Models.Module", "Module")
                        .WithMany("ModuleProfessors")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp.Models.Professor", "Professor")
                        .WithMany("ModuleProfessors")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Module");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("WebApp.Models.Module", b =>
                {
                    b.Navigation("ModuleProfessors");
                });

            modelBuilder.Entity("WebApp.Models.Professor", b =>
                {
                    b.Navigation("ModuleProfessors");
                });
#pragma warning restore 612, 618
        }
    }
}
