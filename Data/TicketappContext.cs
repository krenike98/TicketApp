using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TicketApp.Data;

public partial class TicketappContext : IdentityDbContext
{
    public TicketappContext()
    {
    }

    public TicketappContext(DbContextOptions<TicketappContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Departuretime> Departuretimes { get; set; }

    public virtual DbSet<Line> Lines { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;Database=ticketapp;Uid=root;Pwd=root");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Departuretime>(entity =>
        {
            entity.HasKey(e => new { e.LineId, e.DepartureTimeId }).HasName("PRIMARY");

            entity.ToTable("departuretime");

            entity.HasIndex(e => e.DepartureTimeId, "DepartureTimeId").IsUnique();

            entity.Property(e => e.DepartureTimeId).ValueGeneratedOnAdd();
            entity.Property(e => e.Departure).HasColumnType("datetime");

            entity.HasOne(d => d.Line).WithMany(p => p.Departuretimes)
                .HasForeignKey(d => d.LineId)
                .HasConstraintName("LineIdInDeparture");
        });

        modelBuilder.Entity<Line>(entity =>
        {
            entity.HasKey(e => e.LineId).HasName("PRIMARY");

            entity.ToTable("line");

            entity.Property(e => e.ArrivalPlace).HasMaxLength(255);
            entity.Property(e => e.DeparturePlace).HasMaxLength(255);
            entity.Property(e => e.Duration).HasColumnType("time");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => new { e.LineId, e.UserId }).HasName("PRIMARY");

            entity.ToTable("order");

            entity.HasIndex(e => e.DepartureTimeId, "DepartureTimeId_idx");

            entity.HasIndex(e => e.UserId, "UserId_idx");

            entity.HasOne(d => d.DepartureTime).WithMany(p => p.Orders)
                .HasPrincipalKey(p => p.DepartureTimeId)
                .HasForeignKey(d => d.DepartureTimeId)
                .HasConstraintName("DepartureTimeId");

            entity.HasOne(d => d.Line).WithMany(p => p.Orders)
                .HasForeignKey(d => d.LineId)
                .HasConstraintName("LineId");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("UserId");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.Adress).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(255);
            entity.Property(e => e.Pwd).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
