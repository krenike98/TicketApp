﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketApp.Data;

#nullable disable

namespace TicketApp.Migrations
{
    [DbContext(typeof(TicketappContext))]
    [Migration("20240109161026_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TicketApp.Data.Departuretime", b =>
                {
                    b.Property<int>("LineId")
                        .HasColumnType("int");

                    b.Property<int>("DepartureTimeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Departure")
                        .HasColumnType("datetime");

                    b.HasKey("LineId", "DepartureTimeId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "DepartureTimeId" }, "DepartureTimeId")
                        .IsUnique();

                    b.ToTable("departuretime", (string)null);
                });

            modelBuilder.Entity("TicketApp.Data.Line", b =>
                {
                    b.Property<int>("LineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ArrivalPlace")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DeparturePlace")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Distance")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<bool>("IsReservedSeated")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsSupplementTicketNeeded")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("NumberOfCarriages")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfSeats")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("LineId")
                        .HasName("PRIMARY");

                    b.ToTable("line", (string)null);
                });

            modelBuilder.Entity("TicketApp.Data.Order", b =>
                {
                    b.Property<int>("LineId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("DepartureTimeId")
                        .HasColumnType("int");

                    b.HasKey("LineId", "UserId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "DepartureTimeId" }, "DepartureTimeId_idx");

                    b.HasIndex(new[] { "UserId" }, "UserId_idx");

                    b.ToTable("order", (string)null);
                });

            modelBuilder.Entity("TicketApp.Data.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Adress")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Pwd")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId")
                        .HasName("PRIMARY");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("TicketApp.Data.Departuretime", b =>
                {
                    b.HasOne("TicketApp.Data.Line", "Line")
                        .WithMany("Departuretimes")
                        .HasForeignKey("LineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("LineIdInDeparture");

                    b.Navigation("Line");
                });

            modelBuilder.Entity("TicketApp.Data.Order", b =>
                {
                    b.HasOne("TicketApp.Data.Departuretime", "DepartureTime")
                        .WithMany("Orders")
                        .HasForeignKey("DepartureTimeId")
                        .HasPrincipalKey("DepartureTimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("DepartureTimeId");

                    b.HasOne("TicketApp.Data.Line", "Line")
                        .WithMany("Orders")
                        .HasForeignKey("LineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("LineId");

                    b.HasOne("TicketApp.Data.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("UserId");

                    b.Navigation("DepartureTime");

                    b.Navigation("Line");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TicketApp.Data.Departuretime", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("TicketApp.Data.Line", b =>
                {
                    b.Navigation("Departuretimes");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("TicketApp.Data.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}