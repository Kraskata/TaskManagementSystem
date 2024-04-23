using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Core.Models.Assignment;
using TaskManagementSystem.Core.Services;
using TaskManagementSystem.Infrastructure.Data;
using TaskManagementSystem.Infrastructure.Data.Common;
using TaskManagementSystem.Infrastructure.Data.Models;
using static TaskManagementSystem.Tests.Mocks.TestDatabaseSeed;

namespace TaskManagementSystem.Tests.Services
{
    [TestFixture]
    public class Tests
    {
        private TaskManagementDbContext context;

        private IRepository repository;

        private IAssignmentService assignmentService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<TaskManagementDbContext>()
                .UseInMemoryDatabase(databaseName: "TaskManagementSystemDb")
                .Options;

            context = new TaskManagementDbContext(options);

            context.Database.EnsureCreated();

            SeedDatabase(context);

            repository = new Repository(context);

            assignmentService = new AssignmentService(repository);
        }

        [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
        }

        [Test]
        public async Task RepositoryShouldReturnAllAssignments()
        {
            var result = repository.All<Assignment>();
            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.EqualTo(3));
        }

        [Test]
        public async Task RepositoryAddAsyncShouldWork()
        {
            var model = new Assignment()
            {
                Id = 4,
                Title = "Domain Table",
                Description = "The domain tables have the wrong properties 2.0.",
                Paid = 1500.00M,
                Assigned = "03/27/2024",
                DoneBy = "04/05/2024",
                CategoryId = 1,
                AssigneeId = 1,
                WorkerId = "6d5800ce - d726 - 4fc8 - 83d9 - d6b3ac1f591e"
            };
            await repository.AddAsync<Assignment>(model);
            await repository.SaveChangesAsync();
            var result = repository.All<Assignment>();
            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.EqualTo(4));
        }

        [Test]
        public async Task CheckRepositoryAddsInformationProperlyAndAssignmentDetailsByIdShouldWork()
        {
            var model = new Assignment()
            {
                Id = 4,
                Title = "Domain Table",
                Description = "The domain tables have the wrong properties 2.0.",
                Paid = 1500.00M,
                Assigned = "03/27/2024",
                DoneBy = "04/05/2024",
                CategoryId = 1,
                AssigneeId = 1,
                WorkerId = "6d5800ce - d726 - 4fc8 - 83d9 - d6b3ac1f591e"
            };

            await repository.AddAsync<Assignment>(model);
            await repository.SaveChangesAsync();
            var result = await assignmentService.AssignmentDetailsByIdAsync(4);

            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(model.Id));
            Assert.That(result.Title, Is.EqualTo(model.Title));
            Assert.That(result.Description, Is.EqualTo(model.Description));
            Assert.That(result.Paid, Is.EqualTo(model.Paid));
            Assert.That(result.Assigned, Is.EqualTo(model.Assigned));
            Assert.That(result.DoneBy, Is.EqualTo(model.DoneBy));
        }

        [Test]
        public async Task GetAssignmentByIdShouldThrowIsNull()
        {
            int nonExistingId = 4;

            var result = await context.Assignments.FindAsync(nonExistingId);

            Assert.IsNull(result);
        }

        [Test]
        public async Task EditAssignmentAsyncShouldWorkUpdateAssignment()
        {
            var assignment = await context.Assignments.FirstAsync(a => a.Title == "Domain Tables");

            var model = new AssignmentFormModel()
            {
                Title = assignment.Title + "Test",
                Description = assignment.Description,
                Paid = assignment.Paid,
                Assigned = assignment.Assigned,
                DoneBy = assignment.DoneBy
            };

            await assignmentService.EditAsync(assignment.Id, model);

            var result = await context.Assignments.FindAsync(assignment.Id);
            Assert.That(result!.Title, Is.EqualTo(model.Title));

        }

        [Test]
        public async Task DeleteAssignmentAsyncShouldWorkDeleteAssignment()
        {
            var assignment = await context.Assignments.FirstAsync(a => a.Title == "Domain Tables");

            await assignmentService.DeleteAsync(assignment.Id);

            var result = await context.Assignments.FindAsync(assignment.Id);
            Assert.IsNull(result);

        }
    }
}