using TaskManagementSystem.Core.Models.Assignment;
using TaskManagementSystem.Infrastructure.Data.Models;

namespace System.Linq
{
    public static class IQuerableAssignmentExtention
    {
        public static IQueryable<AssignmentServiceModel> ProjectToAssignmentServiceModel(this IQueryable<Assignment> assignments)
        {
            return assignments
                .Select(a => new AssignmentServiceModel()
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    DoneBy = a.DoneBy,
                    IsAssigned = a.WorkerId != null,
                    Paid = a.Paid
                });
        }
    }
}
