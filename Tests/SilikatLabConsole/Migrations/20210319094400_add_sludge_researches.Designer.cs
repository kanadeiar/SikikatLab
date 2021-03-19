﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SilikatLabConsole.Data;

namespace SilikatLabConsole.Migrations
{
    [DbContext(typeof(SPLaboratoryDb))]
    [Migration("20210319094400_add_sludge_researches")]
    partial class add_sludge_researches
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SilikatLab.lib.Models.Laboratorian", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Laboratorians");
                });

            modelBuilder.Entity("SilikatLab.lib.Models.Research", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("LaboratorianId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("ResearchObjectId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.Property<int>("WorkShiftId")
                        .HasColumnType("int");

                    b.Property<int>("WorkTaskId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LaboratorianId");

                    b.HasIndex("ResearchObjectId");

                    b.HasIndex("WorkShiftId");

                    b.HasIndex("WorkTaskId");

                    b.ToTable("Researches");
                });

            modelBuilder.Entity("SilikatLab.lib.Models.ResearchObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(160)
                        .HasColumnType("nvarchar(160)");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("ResearchObjects");
                });

            modelBuilder.Entity("SilikatLab.lib.Models.TypeResearch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("TypeResult")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TypeResearches");
                });

            modelBuilder.Entity("SilikatLab.lib.Models.UserLogin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Access")
                        .HasColumnType("int");

                    b.Property<int?>("LaboratorianId")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("LaboratorianId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("SilikatLab.lib.Models.WorkShift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("WorkShifts");
                });

            modelBuilder.Entity("SilikatLab.lib.Models.WorkTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgainInMinutes")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("ResearchObjectId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TaskDateTime")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int?>("TypeResearchId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ResearchObjectId");

                    b.HasIndex("TypeResearchId");

                    b.ToTable("WorkTasks");
                });

            modelBuilder.Entity("SilikatLab.lib.Models.Researches.BlockQualityResearch", b =>
                {
                    b.HasBaseType("SilikatLab.lib.Models.Research");

                    b.Property<float>("AfterDensity")
                        .HasColumnType("real");

                    b.Property<float>("AfterWeight")
                        .HasColumnType("real");

                    b.Property<float>("BeforeDensity")
                        .HasColumnType("real");

                    b.Property<float>("BeforeWeight")
                        .HasColumnType("real");

                    b.Property<float>("Coefficient")
                        .HasColumnType("real");

                    b.Property<string>("Format")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<float>("Humidity")
                        .HasColumnType("real");

                    b.Property<float>("Load")
                        .HasColumnType("real");

                    b.Property<float>("SizeX")
                        .HasColumnType("real");

                    b.Property<float>("SizeY")
                        .HasColumnType("real");

                    b.Property<float>("SizeZ")
                        .HasColumnType("real");

                    b.Property<float>("Strength")
                        .HasColumnType("real");

                    b.Property<string>("Trademark")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.ToTable("BlockQualityReearches");
                });

            modelBuilder.Entity("SilikatLab.lib.Models.Researches.SludgeResearch", b =>
                {
                    b.HasBaseType("SilikatLab.lib.Models.Research");

                    b.Property<float>("Density")
                        .HasColumnType("real");

                    b.Property<float>("Gypsum")
                        .HasColumnType("real");

                    b.Property<float>("Humidity")
                        .HasColumnType("real");

                    b.Property<float>("Sieve0_045")
                        .HasColumnType("real");

                    b.Property<float>("Sieve0_09")
                        .HasColumnType("real");

                    b.Property<float>("Sieve0_8")
                        .HasColumnType("real");

                    b.Property<float>("Surface")
                        .HasColumnType("real");

                    b.ToTable("SludgeResearch");
                });

            modelBuilder.Entity("SilikatLab.lib.Models.Research", b =>
                {
                    b.HasOne("SilikatLab.lib.Models.Laboratorian", "Laboratorian")
                        .WithMany("Researches")
                        .HasForeignKey("LaboratorianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SilikatLab.lib.Models.ResearchObject", "ResearchObject")
                        .WithMany("Researches")
                        .HasForeignKey("ResearchObjectId");

                    b.HasOne("SilikatLab.lib.Models.WorkShift", "WorkShift")
                        .WithMany("Researches")
                        .HasForeignKey("WorkShiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SilikatLab.lib.Models.WorkTask", "WorkTask")
                        .WithMany("ResearchResults")
                        .HasForeignKey("WorkTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Laboratorian");

                    b.Navigation("ResearchObject");

                    b.Navigation("WorkShift");

                    b.Navigation("WorkTask");
                });

            modelBuilder.Entity("SilikatLab.lib.Models.UserLogin", b =>
                {
                    b.HasOne("SilikatLab.lib.Models.Laboratorian", "Laboratorian")
                        .WithMany()
                        .HasForeignKey("LaboratorianId");

                    b.Navigation("Laboratorian");
                });

            modelBuilder.Entity("SilikatLab.lib.Models.WorkTask", b =>
                {
                    b.HasOne("SilikatLab.lib.Models.ResearchObject", "ResearchObject")
                        .WithMany("WorkTasks")
                        .HasForeignKey("ResearchObjectId");

                    b.HasOne("SilikatLab.lib.Models.TypeResearch", "TypeResearch")
                        .WithMany("WorkTasks")
                        .HasForeignKey("TypeResearchId");

                    b.Navigation("ResearchObject");

                    b.Navigation("TypeResearch");
                });

            modelBuilder.Entity("SilikatLab.lib.Models.Researches.BlockQualityResearch", b =>
                {
                    b.HasOne("SilikatLab.lib.Models.Research", null)
                        .WithOne()
                        .HasForeignKey("SilikatLab.lib.Models.Researches.BlockQualityResearch", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SilikatLab.lib.Models.Researches.SludgeResearch", b =>
                {
                    b.HasOne("SilikatLab.lib.Models.Research", null)
                        .WithOne()
                        .HasForeignKey("SilikatLab.lib.Models.Researches.SludgeResearch", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SilikatLab.lib.Models.Laboratorian", b =>
                {
                    b.Navigation("Researches");
                });

            modelBuilder.Entity("SilikatLab.lib.Models.ResearchObject", b =>
                {
                    b.Navigation("Researches");

                    b.Navigation("WorkTasks");
                });

            modelBuilder.Entity("SilikatLab.lib.Models.TypeResearch", b =>
                {
                    b.Navigation("WorkTasks");
                });

            modelBuilder.Entity("SilikatLab.lib.Models.WorkShift", b =>
                {
                    b.Navigation("Researches");
                });

            modelBuilder.Entity("SilikatLab.lib.Models.WorkTask", b =>
                {
                    b.Navigation("ResearchResults");
                });
#pragma warning restore 612, 618
        }
    }
}
