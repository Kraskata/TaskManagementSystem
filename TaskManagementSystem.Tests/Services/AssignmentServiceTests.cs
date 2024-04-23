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

        private IAssigneeService assigneeService;

        private Assignee? assignee;

        [SetUp]
        public async Task Setup()
        {
            var options = new DbContextOptionsBuilder<TaskManagementDbContext>()
                .UseInMemoryDatabase(databaseName: "TaskManagementSystemDb")
                .Options;

            context = new TaskManagementDbContext(options);

            context.Database.EnsureCreated();

            SeedDatabase(context);

            repository = new Repository(context);

            assignmentService = new AssignmentService(repository);

            assigneeService = new AssigneeService(repository);
            assignee = await context.Assignees.FirstOrDefaultAsync(a => a.Id == 1);
        }

        [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
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

        [Test]
        public async Task ExistsAsyncShouldWorkReturnsTrue()
        {
            var assignment = await context.Assignments.FirstAsync(a => a.Title == "Domain Tables");

            var result = await assignmentService.ExistsAsync(assignment.Id);

            Assert.IsTrue(result);

        }

        [Test]
        public async Task HasAssigneeWithIdAsyncShouldWorkReturnsTrue()
        {
            var assignment = await context.Assignments.FirstAsync(a => a.Title == "Domain Tables");

            var result = await assignmentService.HasAssigneeWithIdAsync(assignment.Id, assignee.UserId);

            Assert.IsTrue(result);

        } 
        
        [Test]
        public async Task IsAcceptedAsyncShouldWorkReturnsTrue()
        {
            var assignment = await context.Assignments.FirstAsync(a => a.Title == "Domain Tables");

            var result = await assignmentService.IsAcceptedAsync(assignment.Id);

            Assert.IsTrue(result);

        }
        
        [Test]
        public async Task IsAcceptedByUserWithIdAsyncShouldWorkReturnsTrue()
        {
            var assignment = await context.Assignments.FirstOrDefaultAsync(a => a.Title == "Domain Tables");
            var worker = await context.Users.FirstOrDefaultAsync(w => w.Id == "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            var result = await assignmentService.IsAcceptedByUserWithIdAsync(assignment.Id, worker.Id);

            Assert.IsTrue(result);

        }
        
        [Test]
        public async Task LeaveAsyncShouldWorkReturnsFalse()
        {
            var assignment = await context.Assignments.FirstOrDefaultAsync(a => a.Title == "Domain Tables");
            var worker = await context.Users.FirstOrDefaultAsync(w => w.Id == "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");
            await assignmentService.LeaveAsync(assignment.Id, worker.Id);

            var result = await assignmentService.IsAcceptedByUserWithIdAsync(assignment.Id, worker.Id);

            Assert.IsFalse(result);

        }
    }
}