using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GYMIND.API.Data.Configuration
{
    public class GymConfiguration : IEntityTypeConfiguration<Entities.Gym>
    {
        public void Configure(EntityTypeBuilder<Entities.Gym> entity)
        {
            entity.ToTable("gym");
            entity.HasKey(g => g.GymId);
            entity.Property(g => g.GymId).HasColumnName("gymid");
            entity.Property(g => g.IsApproved).HasColumnName("isapproved");
            entity.Property(g => g.CreatedAt).HasColumnName("createdat");

            entity.Property(g => g.Name).HasMaxLength(255).IsRequired().HasColumnName("name");
            
        }
    }

    public class GymBranchConfiguration : IEntityTypeConfiguration<Entities.GymBranch>
    {
        public void Configure(EntityTypeBuilder<Entities.GymBranch> entity)
        {
            entity.ToTable("gymbranch");
            entity.HasKey(gb => gb.GymBranchID);

            // Mapping JsonDocument for OperatingHours
            entity.Property(gb => gb.OperatingHours).HasColumnType("jsonb");
            entity.Property(gb => gb.Name).HasColumnName("name");
            entity.Property(gb => gb.ServiceDescription).HasColumnName("servicedescription");
            entity.Property(gb => gb.CoverImageUrl).HasColumnName("coverimageurl");
            entity.Property(gb => gb.IsActive).HasColumnName("isactive");
            entity.Property(gb => gb.GymID).HasColumnName("gymid");
            entity.Property(gb => gb.LocationID).HasColumnName("locationid");

            entity.HasOne(gb => gb.Gym)
                .WithMany(g => g.Branches) 
                .HasForeignKey(gb => gb.GymID);

            entity.HasOne(gb => gb.Location)
                .WithMany()
                .HasForeignKey(gb => gb.LocationID);
        }
    }
}