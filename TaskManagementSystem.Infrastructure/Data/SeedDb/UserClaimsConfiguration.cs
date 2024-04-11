using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskManagementSystem.Infrastructure.Data.SeedDb
{
    public class UserClaimsConfiguration : IEntityTypeConfiguration<IdentityUserClaim<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
        {
            var data = new SeedData();

            builder.HasData(data.AssigneeUserClaim, data.GuestUserClaim, data.AdminUserClaim);
        }
    }
}