﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Context;

namespace WebApi.Migrations
{
    [DbContext(typeof(WebApiContext))]
    partial class WebApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApi.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday");

                    b.Property<DateTime?>("DateOfDeath");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Author","api");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Birthday = new DateTime(1969, 5, 31, 9, 11, 54, 801, DateTimeKind.Local).AddTicks(6989),
                            DateOfDeath = new DateTime(2018, 5, 20, 9, 11, 54, 802, DateTimeKind.Local).AddTicks(9757),
                            FirstName = "Fake",
                            LastName = "Author"
                        });
                });

            modelBuilder.Entity("WebApi.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId");

                    b.Property<string>("Descrition")
                        .IsRequired()
                        .HasMaxLength(600);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Book","api");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Descrition = "The book represents a series of murders and homicides that have been made by some misterious Guy named Mr. Crazyand calls the attention of two young investigators named Tommy and Tuppence who try to stop him",
                            Title = "Misterious Mr. Crazy"
                        });
                });

            modelBuilder.Entity("WebApi.Entities.Book", b =>
                {
                    b.HasOne("WebApi.Entities.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
