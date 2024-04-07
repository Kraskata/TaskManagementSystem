using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Core.Contracts;
using TaskManagementSystem.Core.Enumerations;
using TaskManagementSystem.Core.Models.Assignment;
using TaskManagementSystem.Core.Models.Home;
using TaskManagementSystem.Infrastructure.Data.Common;
using TaskManagementSystem.Infrastructure.Data.Models;

namespace TaskManagementSystem.Core.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IRepository repository;

        public AssignmentService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<AssignmentQueryServiceModel> AllAsync(string? category = null, string? searchItem = null, AssignmentSorting sorting = AssignmentSorting.Newest, int currentPage = 1, int assignmentsPerPage = 4)
        {
            var assignmentsToShow = repository.AllReadOnly<Assignment>();

            if (category != null)
            {
                assignmentsToShow = assignmentsToShow
                    .Where(h => h.Category.Name == category);
            }

            if (searchItem != null)
            {
                string normalizedSearchItem = searchItem.ToLower();
                assignmentsToShow = assignmentsToShow
                    .Where(a => (a.Title.ToLower().Contains(normalizedSearchItem) ||
                                 a.Description.ToLower().Contains(normalizedSearchItem)));
            }

            assignmentsToShow = sorting switch
            {
                AssignmentSorting.Paid =>assignmentsToShow.OrderBy(a => a.Paid),

                AssignmentSorting.NotAssignedFirst => assignmentsToShow
                    .OrderBy(a => a.WorkerId != null)
                    .ThenByDescending(a => a.Id),

                _ => assignmentsToShow
                    .OrderByDescending(a => a.Id)
            };

            var assignments = await assignmentsToShow
                .Skip((currentPage - 1) * assignmentsPerPage)
                .Take(assignmentsPerPage)
                .Select(a => new AssignmentServiceModel()
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    DoneBy = a.DoneBy,
                    IsAssigned = a.WorkerId != null,
                    Paid = a.Paid
                })
                .ToListAsync();

            int totalAssignments = await assignmentsToShow.CountAsync();

            return new AssignmentQueryServiceModel()
            {
                Assignments = assignments,
                TotalAssignmentsCount = totalAssignments,
            };
        }

        public async Task<IEnumerable<AssignmentCategoryServiceModel>> AllCategoriesAsync()
        {
            return await repository.AllReadOnly<Category>()
                .Select(c => new AssignmentCategoryServiceModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
        {
            return await repository.AllReadOnly<Category>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<bool> CategoryExistsAsync(int categoryId)
        {
            return await repository.AllReadOnly<Category>()
                .AnyAsync(c => c.Id == categoryId);
        }

        public async Task<int> CreateAsync(AssignmentFormModel model, int assigneeId)
        {
            Assignment assignment = new Assignment()
            {
                Description = model.Description,
                AssigneeId = assigneeId,
                CategoryId = model.CategoryId,
                Paid = model.Paid,
                Title = model.Title,
                DoneBy = model.DoneBy,
            };
            await repository.AddAsync(assignment);
            await repository.SaveChangesAsync();

            return assignment.Id;
        }

        public async Task<IEnumerable<AssignmentIndexServiceModel>> NewestThreeAssignmentsAsync()
        {
            return await repository
                .AllReadOnly<Infrastructure.Data.Models.Assignment>()
                .OrderBy(a => a.Id)
                .Take(3)
                .Select(a => new AssignmentIndexServiceModel()
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    Category = a.Category
                })
                .ToListAsync();
        }
    }
}
