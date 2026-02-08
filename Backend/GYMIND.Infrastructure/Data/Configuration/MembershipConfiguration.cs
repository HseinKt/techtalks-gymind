using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GYMIND.API.GYMIND.Infrastructure.Data.Configuration
{
    public class MembershipConfiguration : IEntityTypeConfiguration<Entities.Membership>
    {
        public void Configure(EntityTypeBuilder<Entities.Membership> entity)
        {
            entity.ToTable("memberships");
            entity.HasKey(m => m.MembershipID);

            entity.HasOne(m => m.User)
                .WithMany()
                .HasForeignKey(m => m.UserID);
        }
    }
}
