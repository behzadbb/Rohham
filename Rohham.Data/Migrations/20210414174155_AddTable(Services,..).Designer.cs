﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rohham.Data.Context;

namespace Rohham.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210414174155_AddTable(Services,..)")]
    partial class AddTableServices
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Rohham.Entities.Blogs.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<int>("CatId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<string>("ImageThumpUrl");

                    b.Property<string>("ImageUrl");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("RegisterDate");

                    b.Property<string>("Tags");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Url")
                        .HasMaxLength(150);

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CatId");

                    b.HasIndex("UserId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("Rohham.Entities.Blogs.Category", b =>
                {
                    b.Property<int>("CatId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("ParentId");

                    b.Property<string>("Title")
                        .HasMaxLength(50);

                    b.HasKey("CatId");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Rohham.Entities.Services.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<string>("Icon");

                    b.Property<string>("ImageUrl");

                    b.Property<int>("Name")
                        .HasMaxLength(100);

                    b.Property<int>("Priority");

                    b.Property<string>("Text");

                    b.Property<int>("Title")
                        .HasMaxLength(100);

                    b.HasKey("ServiceId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Rohham.Entities.Services.ServiceFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("Priority");

                    b.Property<int>("ServiceId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.ToTable("ServiceFeatures");
                });

            modelBuilder.Entity("Rohham.Entities.Services.ServiceFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate");

                    b.Property<int>("FileName")
                        .HasMaxLength(200);

                    b.Property<int>("Priority");

                    b.Property<int>("ServiceId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.ToTable("ServiceFiles");
                });

            modelBuilder.Entity("Rohham.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Facebook");

                    b.Property<string>("FirstName");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("ImageUrlThump");

                    b.Property<bool>("IsTeam");

                    b.Property<string>("LastName");

                    b.Property<string>("Linkedin");

                    b.Property<string>("Password")
                        .HasMaxLength(100);

                    b.Property<string>("Pinterest");

                    b.Property<string>("Position");

                    b.Property<int>("Priority");

                    b.Property<string>("Telegram");

                    b.Property<string>("Twitter");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Whatsapp");

                    b.Property<string>("Youtube");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Rohham.Entities.Blogs.Article", b =>
                {
                    b.HasOne("Rohham.Entities.Blogs.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CatId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rohham.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rohham.Entities.Blogs.Category", b =>
                {
                    b.HasOne("Rohham.Entities.Blogs.Category", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Rohham.Entities.Services.ServiceFeature", b =>
                {
                    b.HasOne("Rohham.Entities.Services.Service", "Service")
                        .WithMany("FeatureServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rohham.Entities.Services.ServiceFile", b =>
                {
                    b.HasOne("Rohham.Entities.Services.Service", "Service")
                        .WithMany("ServiceFiles")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
