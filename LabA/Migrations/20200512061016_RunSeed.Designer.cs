﻿// <auto-generated />
using System;
using LabA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LabA.Migrations
{
    [DbContext(typeof(PortfolioContext))]
    [Migration("20200512061016_RunSeed")]
    partial class RunSeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("LabA.Models.Company", b =>
                {
                    b.Property<string>("Name");

                    b.Property<string>("Contact");

                    b.Property<string>("Email");

                    b.Property<string>("Phone");

                    b.HasKey("Name");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("LabA.Models.InterviewRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyName");

                    b.Property<string>("Location");

                    b.Property<DateTime>("Time");

                    b.HasKey("Id");

                    b.HasIndex("CompanyName");

                    b.ToTable("InterviewRequests");
                });

            modelBuilder.Entity("LabA.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.Property<string>("Url");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("LabA.Models.Technology", b =>
                {
                    b.Property<string>("Name");

                    b.HasKey("Name");

                    b.ToTable("Technologies");
                });

            modelBuilder.Entity("LabA.Models.TechnologyProject", b =>
                {
                    b.Property<string>("TechnologyName");

                    b.Property<int>("ProjectId");

                    b.HasKey("TechnologyName", "ProjectId");

                    b.HasAlternateKey("ProjectId", "TechnologyName");

                    b.ToTable("TechnologyProjects");
                });

            modelBuilder.Entity("LabA.ViewModel.InterviewRequestVM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Company");

                    b.Property<string>("Contact");

                    b.Property<string>("Email");

                    b.Property<string>("Location");

                    b.Property<string>("Phone");

                    b.Property<DateTime>("Time");

                    b.HasKey("Id");

                    b.ToTable("InterviewRequestVM");
                });

            modelBuilder.Entity("LabA.Models.InterviewRequest", b =>
                {
                    b.HasOne("LabA.Models.Company", "Company")
                        .WithMany("InterviewRequests")
                        .HasForeignKey("CompanyName");
                });

            modelBuilder.Entity("LabA.Models.TechnologyProject", b =>
                {
                    b.HasOne("LabA.Models.Project", "Project")
                        .WithMany("TechnologyProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("LabA.Models.Technology", "Technology")
                        .WithMany("TechnologyProjects")
                        .HasForeignKey("TechnologyName")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
