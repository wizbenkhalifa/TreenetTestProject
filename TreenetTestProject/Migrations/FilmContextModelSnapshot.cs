﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TreenetTestProject.Data;

namespace TreenetTestProject.Migrations
{
    [DbContext(typeof(FilmContexts))]
    partial class FilmContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TreenetTestProject.Models.Film", b =>
                {
                    b.Property<string>("filmID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("duration")
                        .HasColumnType("int");

                    b.Property<string>("producer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("filmID");

                    b.ToTable("Film");
                });
#pragma warning restore 612, 618
        }
    }
}
