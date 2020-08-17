using Microsoft.EntityFrameworkCore;
using NetworkMarketing.BL.Entities;

namespace NetworkMarketing.DB
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Distributor> Distributors { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<IdentityInfo> IdentityInfo { get; set; }
        public DbSet<ContactInfo> ContactInfo { get; set; }
        public DbSet<AddressInfo> AddressInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Distributor>().HasMany(i => i.Recomendators).WithOne().HasForeignKey(x => x.RecomendatorId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Distributor>()
           .Property(x => x.RecomendatorId)
           .IsRequired(false);


            modelBuilder.Entity<Distributor>()
            .Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(50);

            modelBuilder.Entity<Distributor>()
            .Property(x => x.DateOfBirth)
            .IsRequired();

            modelBuilder.Entity<Distributor>()
           .Property(x => x.Gender)
           .IsRequired();

            modelBuilder.Entity<Distributor>()
            .Property(x => x.Gender)
            .IsRequired();

            modelBuilder.Entity<IdentityInfo>()
            .Property(x => x.IdentityType)
            .IsRequired();

            modelBuilder.Entity<IdentityInfo>()
            .Property(x => x.Serie)
            .IsRequired()
            .HasMaxLength(10);

            modelBuilder.Entity<IdentityInfo>()
            .Property(x => x.Number)
            .IsRequired()
            .HasMaxLength(10);

            modelBuilder.Entity<IdentityInfo>()
            .Property(x => x.ValidFrom)
            .IsRequired();

            modelBuilder.Entity<IdentityInfo>()
            .Property(x => x.ValidTo)
            .IsRequired();

            modelBuilder.Entity<IdentityInfo>()
            .Property(x => x.PersonalId)
            .IsRequired()
            .HasMaxLength(50);

            modelBuilder.Entity<IdentityInfo>()
            .Property(x => x.Issuer)
            .IsRequired()
            .HasMaxLength(100);

            modelBuilder.Entity<ContactInfo>()
            .Property(x => x.ContactType)
            .IsRequired();

            modelBuilder.Entity<ContactInfo>()
           .Property(x => x.Contact)
           .IsRequired()
           .HasMaxLength(100);

            modelBuilder.Entity<AddressInfo>()
           .Property(x => x.addressType)
           .IsRequired();

            modelBuilder.Entity<AddressInfo>()
           .Property(x => x.Address)
           .IsRequired()
           .HasMaxLength(100);
        }
    }
}
