using Microsoft.EntityFrameworkCore;
using GYMIND.API.Entities;
using Supabase.Gotrue;

public class SupabaseDbContext : DbContext
{
    public SupabaseDbContext(DbContextOptions<SupabaseDbContext> options)
        : base(options) { }

    public DbSet<Users> Users => Set<Users>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Users>(user =>
        {
            // Users table configuration
            user.ToTable("Users");            //  table name
            user.HasKey(u => u.userID);       // PK
            user.Property(u => u.fullName).IsRequired();
            user.Property(u => u.email).IsRequired();

            // Owned collection
            user.OwnsMany(u => u.AppMetadata, metadata =>
            {
                metadata.WithOwner()
                        .HasForeignKey("userID");   // matches FK column in UserAppMetadata

                metadata.ToTable("UserAppMetadata");  // exact table name in Supabase

                metadata.HasKey("userID", "Key");     // composite PK

                metadata.Property(m => m.Key)
                        .HasColumnName("Key")
                        .IsRequired();

                metadata.Property(m => m.Value)
                        .HasColumnName("Value");
            });
        });

    }
}

