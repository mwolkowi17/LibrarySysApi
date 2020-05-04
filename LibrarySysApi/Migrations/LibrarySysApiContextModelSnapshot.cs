﻿// <auto-generated />
using System;
using LibrarySysApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibrarySysApi.Migrations
{
    [DbContext(typeof(LibrarySysApiContext))]
    partial class LibrarySysApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LibrarySysApi.Models.BookC", b =>
                {
                    b.Property<int>("BookCID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AliasofReader")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AuthorC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DropOfData")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ReaderID")
                        .HasColumnType("int");

                    b.Property<DateTime>("RentData")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Rented")
                        .HasColumnType("bit");

                    b.Property<int>("RentedbyReader")
                        .HasColumnType("int");

                    b.Property<string>("TitleC")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookCID");

                    b.HasIndex("ReaderID");

                    b.ToTable("BookC");
                });

            modelBuilder.Entity("LibrarySysApi.Models.Reader", b =>
                {
                    b.Property<int>("ReaderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReaderID");

                    b.ToTable("Reader");
                });

            modelBuilder.Entity("LibrarySysApi.Models.BookC", b =>
                {
                    b.HasOne("LibrarySysApi.Models.Reader", null)
                        .WithMany("Books")
                        .HasForeignKey("ReaderID");
                });
#pragma warning restore 612, 618
        }
    }
}
