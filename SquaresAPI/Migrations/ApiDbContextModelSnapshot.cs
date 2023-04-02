﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SquaresAPI.Data;

#nullable disable

namespace SquaresAPI.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SquaresAPI.Data.Entities.Plane", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateUpdated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Processed")
                        .HasColumnType("boolean");

                    b.Property<int>("TotalSquares")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Planes");
                });

            modelBuilder.Entity("SquaresAPI.Data.Entities.Point", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateUpdated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PlaneId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SquareId")
                        .HasColumnType("uuid");

                    b.Property<int>("X")
                        .HasColumnType("integer");

                    b.Property<int>("Y")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PlaneId");

                    b.HasIndex("SquareId");

                    b.ToTable("Points");
                });

            modelBuilder.Entity("SquaresAPI.Data.Entities.Square", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateUpdated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("PlaneId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PlaneId");

                    b.ToTable("Squares");
                });

            modelBuilder.Entity("SquaresAPI.Data.Entities.Point", b =>
                {
                    b.HasOne("SquaresAPI.Data.Entities.Plane", "Plane")
                        .WithMany("Points")
                        .HasForeignKey("PlaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Plane_Point");

                    b.HasOne("SquaresAPI.Data.Entities.Square", "Square")
                        .WithMany("Points")
                        .HasForeignKey("SquareId")
                        .HasConstraintName("FK_Square_Point");

                    b.Navigation("Plane");

                    b.Navigation("Square");
                });

            modelBuilder.Entity("SquaresAPI.Data.Entities.Square", b =>
                {
                    b.HasOne("SquaresAPI.Data.Entities.Plane", "Plane")
                        .WithMany("Squares")
                        .HasForeignKey("PlaneId")
                        .HasConstraintName("FK_Plane_Square");

                    b.Navigation("Plane");
                });

            modelBuilder.Entity("SquaresAPI.Data.Entities.Plane", b =>
                {
                    b.Navigation("Points");

                    b.Navigation("Squares");
                });

            modelBuilder.Entity("SquaresAPI.Data.Entities.Square", b =>
                {
                    b.Navigation("Points");
                });
#pragma warning restore 612, 618
        }
    }
}
