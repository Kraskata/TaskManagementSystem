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

        public async Task<IEnumerable<AssignmentServiceModel>> AllAssignmentsByAssigneeIdAsync(int assigneeId)
        {
            return await repository.AllReadOnly<Assignment>()
                .Where(a => a.AssigneeId == assigneeId)
                .ProjectToAssignmentServiceModel()
                .ToListAsync();
        }

        public async Task<IEnumerable<AssignmentServiceModel>> AllAssignmentsByUserId(string userId)
        {
            return await repository.AllReadOnly<Assignment>()
                .Where(a => a.WorkerId == userId)
                .ProjectToAssignmentServiceModel()
                .ToListAsync();
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
                AssignmentSorting.Paid =>assignmentsToShow.OrderByDescending(a => a.Paid),

                AssignmentSorting.NotAssignedFirst => assignmentsToShow
                    .OrderBy(a => a.WorkerId != null)
                    .ThenByDescending(a => a.Id),

                _ => assignmentsToShow
                    .OrderByDescending(a => a.Id)
            };

            var assignments = await assignmentsToShow
                .Skip((currentPage - 1) * assignmentsPerPage)
                .Take(assignmentsPerPage)
                .ProjectToAssignmentServiceModel()
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

        public async Task<AssignmentDetailsServiceModel> AssignmentDetailsByIdAsync(int id)
        {
            return await repository.AllReadOnly<Assignment>()
                .Where(a => a.Id == id)
                .Select(a => new AssignmentDetailsServiceModel()
                {
                    Id = a.Id,
                    Description = a.Description,
                    Assignee = new Models.Assignee.AssigneeServiceModel()
                    {
                        Gmail = a.Assignee.User.Email,
                        PhoneNumber = a.Assignee.PhoneNumber
                    },
                    Category = a.Category.Name,
                    IsAssigned = a.WorkerId != null,
                    Paid = a.Paid,
                    DoneBy = a.DoneBy,
                    Title = a.Title
                    
                })
                .FirstAsync();
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

        public async Task EditAsync(int assignmentId, AssignmentFormModel model)
        {
            var assignment = await repository.GetByIdAsync<Assignment>(assignmentId);

            if (assignment != null)
            {
                assignment.Description = model.Description;
                assignment.CategoryId = model.CategoryId;
                assignment.Title = model.Title;
                assignment.Paid = model.Paid;
                assignment.DoneBy = model.DoneBy;

                await repository.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await repository.AllReadOnly<Assignment>()
                .AnyAsync(a => a.Id == id);
        }

        public async Task<AssignmentFormModel?> GetAssignmentFormModelByIdAsync(int id)
        {
            var assignment = await repository.AllReadOnly<Assignment>()
                .Where(a => a.Id == id)
                .Select(a => new AssignmentFormModel()
                {
                    DoneBy = a.DoneBy,
                    Paid = a.Paid,
                    Title = a.Title,
                    Description = a.Description,
                    CategoryId = a.CategoryId

                })
                .FirstOrDefaultAsync();

            if (assignment != null)
            {
                assignment.Categories = await AllCategoriesAsync();
            }

            return assignment;
        }

        public async Task<bool> HasAssigneeWithIdAsync(int assignmentId, string userId)
        {
            return await repository.AllReadOnly<Assignment>()
                .AnyAsync(a => a.Id == assignmentId && a.Assignee.UserId == userId);
        }

        public async Task<IEnumerable<AssignmentIndexServiceModel>> NewestFourAssignmentsAsync()
        {
            return await repository
                .AllReadOnly<Infrastructure.Data.Models.Assignment>()
                .OrderBy(a => a.Id)
                .Take(4)
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
