using Microsoft.EntityFrameworkCore;
using TestLiveCode.Model;

namespace TestLiveCode.Context
{
    public class DbContextExample : DbContext
    {
        public DbContextExample(DbContextOptions<DbContextExample> options) : base(options)
        {
            
        }
        public DbSet<Client> Client { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<UserLogin> UserLogin { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(e =>
            {
                e.HasKey(x => x.ClientId).HasName("CLIENT_ID");
                e.Property(x => x.Name).HasColumnName("NAME").HasMaxLength(500).HasColumnType("VARCHAR(500)");
                e.Property(x => x.IsTop500).HasColumnName("IS_TOP_500").HasColumnType("BIT");
                e.Property(x => x.Active).HasColumnName("ACTIVE").HasColumnType("BIT");
                e.Property(x => x.DateAdded).HasColumnName("DATE_ADDED").HasMaxLength(500).HasColumnType("DATETIME");
                e.Property(x => x.TasksToBeDone).HasColumnName("TASKS_TO_BE_DONE").HasColumnType("INT");
                e.Property(x => x.TasksDone).HasColumnName("TASKS_DONE").HasColumnType("INT");
                e.HasMany(c => c.Tickets)
                 .WithOne(t => t.Client)
                 .HasForeignKey(t => t.ClientId);
            });

            modelBuilder.Entity<Ticket>(e =>
            {
                e.HasKey(x => x.TicketId).HasName("TICKET_ID");
                e.Property(x => x.Name).HasColumnName("NAME");
                e.Property(x => x.Description).HasColumnName("DESCRIPTION");
                e.Property(x => x.Done).HasColumnName("DONE").HasColumnType("BIT");
                e.Property(x => x.Active).HasColumnName("ACTIVE").HasColumnType("BIT");
                e.Property(x => x.DateAdded).HasColumnName("DATE_ADDED").HasColumnType("DATETIME");
                e.Property(x => x.ClientId).HasColumnName("CLIENT_ID").HasColumnType("UNIQUEIDENTIFIER");
                e.HasOne(t => t.Client)
                 .WithMany(c => c.Tickets)
                 .HasForeignKey(t => t.ClientId);
            });

            modelBuilder.Entity<UserLogin>(e =>
            {
                e.HasKey(x => x.Id).HasName("USER_ID");
                e.Property(x => x.User).HasColumnName("USER").HasColumnType("VARCHAR(50)");
                e.Property(x => x.Password).HasColumnName("PASSWORD").HasColumnType("VARCHAR(50)");
                e.Property(x => x.Active).HasColumnName("ACTIVE").HasColumnType("BIT");
                e.Property(x => x.DateAdded).HasColumnName("DATE_ADDED").HasColumnType("DATETIME");
            });
        }

    }
}
