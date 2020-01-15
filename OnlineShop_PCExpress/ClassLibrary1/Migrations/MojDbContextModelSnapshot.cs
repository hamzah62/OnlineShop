﻿// <auto-generated />
using System;
using ClassLibrary1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClassLibrary1.Migrations
{
    [DbContext(typeof(MojDbContext))]
    partial class MojDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClassLibrary1.Models.Artikal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cijena")
                        .HasColumnType("float");

                    b.Property<int?>("KategorijaID")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PodkategorijaID")
                        .HasColumnType("int");

                    b.Property<double>("Popust")
                        .HasColumnType("float");

                    b.Property<string>("Sifra")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Slika")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("ID");

                    b.HasIndex("KategorijaID");

                    b.HasIndex("PodkategorijaID");

                    b.ToTable("Artikal");
                });

            modelBuilder.Entity("ClassLibrary1.Models.Kategorija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Kategorija");
                });

            modelBuilder.Entity("ClassLibrary1.Models.Podkategorija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("KategorijaID")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("KategorijaID");

                    b.ToTable("Podkategorija");
                });

            modelBuilder.Entity("ClassLibrary1.Models.Artikal", b =>
                {
                    b.HasOne("ClassLibrary1.Models.Kategorija", "Kategorija")
                        .WithMany()
                        .HasForeignKey("KategorijaID");

                    b.HasOne("ClassLibrary1.Models.Podkategorija", "Podkategorija")
                        .WithMany()
                        .HasForeignKey("PodkategorijaID");
                });

            modelBuilder.Entity("ClassLibrary1.Models.Podkategorija", b =>
                {
                    b.HasOne("ClassLibrary1.Models.Kategorija", "Kategorija")
                        .WithMany()
                        .HasForeignKey("KategorijaID");
                });
#pragma warning restore 612, 618
        }
    }
}
