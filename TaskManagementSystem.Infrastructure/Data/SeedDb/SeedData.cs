using Microsoft.AspNetCore.Identity;
using TaskManagementSystem.Infrastructure.Data.Models;

namespace TaskManagementSystem.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {
        public ApplicationUser AssigneeUser { get; set; }

        public ApplicationUser GuestUser { get; set; }

        public ApplicationUser AdminUser { get; set; }

        public Assignee Assignee { get; set; }

        public Assignee AdminAssignee { get; set; }

        public Category MinimalCategory { get; set; }

        public Category HighThreatCategory { get; set; }

        public Category CriticalCategory { get; set; }

        public Assignment FirstAssignment { get; set; }

        public Assignment SecondAssignment { get; set; }

        public Assignment ThirdAssignment { get; set; }

        public SeedData()
        {
            SeedUsers();
            SeedAssignees();
            SeedCategories();
            SeedAssignments();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            AssigneeUser = new ApplicationUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "assignee@mail.com",
                NormalizedUserName = "agent@mail.com",
                Email = "assignee@mail.com",
                NormalizedEmail = "assignee@mail.com",
                FirstName = "Assignee",
                LastName = "Assigneev"
            };

            AssigneeUser.PasswordHash =
                 hasher.HashPassword(AssigneeUser, "agent123");

            GuestUser = new ApplicationUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com",
                FirstName = "Guest",
                LastName = "Guestov"
            };

            GuestUser.PasswordHash =
            hasher.HashPassword(AssigneeUser, "guest123");

            AdminUser = new ApplicationUser()
            {
                Id = "15480979-8cbd-44cf-a085-f7e32c1b50f2",
                UserName = "admin@mail.com",
                NormalizedUserName = "admin@MAIL.COM",
                Email = "admin@mail.com",
                NormalizedEmail = "admin@MAIL.COM",
                FirstName = "Admin",
                LastName = "Adminov"
            };

            GuestUser.PasswordHash =
            hasher.HashPassword(AdminUser, "admin123");
        }

        private void SeedAssignees()
        {
            Assignee = new Assignee()
            {
                Id = 1,
                PhoneNumber = "+359888888888",
                UserId = AssigneeUser.Id
            };

            AdminAssignee = new Assignee()
            {
                Id = 6,
                PhoneNumber = "+359888888887",
                UserId = AdminUser.Id
            };
        }

        private void SeedCategories()
        {
            MinimalCategory = new Category()
            {
                Id = 1,
                Name = "Minimal"
            };

            HighThreatCategory = new Category()
            {
                Id = 2,
                Name = "High Threat"
            };

            CriticalCategory = new Category()
            {
                Id = 3,
                Name = "Critical"
            };
        }

        private void SeedAssignments()
        {
            FirstAssignment = new Assignment()
            {
                Id = 1,
                Title = "Domain Tables",
                Description = "The domain tables have the wrong properties.",
                Paid = 2100.00M,
                Assigned = "03/27/2024",
                DoneBy = "04/05/2024",
                CategoryId = CriticalCategory.Id,
                AssigneeId = Assignee.Id,
                WorkerId = GuestUser.Id
            };

            SecondAssignment = new Assignment()
            {
                Id = 2,
                Title = "More Data Seeded Needed (Testing Purposes)",
                Description = "We require more guest users, alongside a new level of threat inside the categories (modify the domain tables).",
                Paid = 2100.00M,
                Assigned = "03/23/2024",
                DoneBy = "05/22/2024",
                CategoryId = MinimalCategory.Id,
                AssigneeId = Assignee.Id,
                WorkerId = GuestUser.Id
            };

            ThirdAssignment = new Assignment()
            {
                Id = 3,
                Title = "Pressure Test",
                Description = "Find a way to test if the application is durable to pressure.",
                Paid = 2100.00M,
                Assigned = "03/01/2024",
                DoneBy = "04/15/2024",
                CategoryId = HighThreatCategory.Id,
                AssigneeId = Assignee.Id,
                WorkerId = GuestUser.Id
            };
        }

    }
}
