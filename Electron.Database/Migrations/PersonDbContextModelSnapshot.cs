﻿// <auto-generated />
using System;
using Electron.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Electron.Database.Migrations
{
    [DbContext(typeof(PersonDbContext))]
    partial class PersonDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Electron.Database.Models.PersonDbModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("FatherId")
                        .HasColumnType("bigint");

                    b.Property<long?>("GrandFatherId")
                        .HasColumnType("bigint");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FatherId");

                    b.HasIndex("GrandFatherId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Electron.Database.Models.PersonDbModel", b =>
                {
                    b.HasOne("Electron.Database.Models.PersonDbModel", "Father")
                        .WithMany("Kids")
                        .HasForeignKey("FatherId");

                    b.HasOne("Electron.Database.Models.PersonDbModel", "GrandFather")
                        .WithMany()
                        .HasForeignKey("GrandFatherId");

                    b.Navigation("Father");

                    b.Navigation("GrandFather");
                });

            modelBuilder.Entity("Electron.Database.Models.PersonDbModel", b =>
                {
                    b.Navigation("Kids");
                });
#pragma warning restore 612, 618
        }
    }
}
