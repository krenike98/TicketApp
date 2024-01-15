using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TicketApp.Data;

public partial class TicketappContext : IdentityDbContext<IdentityUser>
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

    public virtual DbSet<Ticket> Tickets { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;Database=ticketapp;Uid=root;Pwd=root");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        

        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Ticket>()
            .HasOne(e => e.User)
            .WithMany()
            .HasForeignKey(e => e.UserId)
            .IsRequired();
    }
}
