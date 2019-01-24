﻿// <auto-generated />
using System;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
//using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infra.Data.Migrations
{
    [DbContext(typeof(TestTaskDbContext))]
    [Migration("20190124143226_Add_CategoryFields")]
    partial class Add_CategoryFields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846");

            modelBuilder.Entity("Domain.Commands.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Domain.Commands.Models.CategoryField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryFieldTypeId");

                    b.Property<int?>("CategoryId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CategoryFieldTypeId");

                    b.HasIndex("CategoryId");

                    b.ToTable("CategoryFields");
                });

            modelBuilder.Entity("Domain.Commands.Models.CategoryFieldType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("CategoryFieldTypes");
                });

            modelBuilder.Entity("Domain.Commands.Models.CategoryField", b =>
                {
                    b.HasOne("Domain.Commands.Models.CategoryFieldType", "CategoryFieldType")
                        .WithMany()
                        .HasForeignKey("CategoryFieldTypeId");

                    b.HasOne("Domain.Commands.Models.Category", "Category")
                        .WithMany("CategoryFields")
                        .HasForeignKey("CategoryId");
                });
#pragma warning restore 612, 618
        }
    }
}