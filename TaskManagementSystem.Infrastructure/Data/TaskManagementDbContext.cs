using TaskManagementSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Infrastructure.Data.SeedDb;

namespace TaskManagementSystem.Infrastructure.Data
{
    public class TaskManagementDbContext : IdentityDbContext<ApplicationUser>
    {
        public TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new AssigneeConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new AssignmentConfiguration());
            builder.ApplyConfiguration(new UserClaimsConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<Assignee> Assignees { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Assignment> Assignments { get; set; } = null!;
    }
}