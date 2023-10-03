using Microsoft.EntityFrameworkCore;

namespace Contact_Manager.EFCore
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options) { }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure shadow property for LastChangeTimestamp
            modelBuilder.Entity<Contact>()
                .Property<DateTime>("LastChangeTimestamp")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<Contact>()
            .HasIndex(c => c.Email)
            .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
