using TaskManagementSystem.Core.Models.Home;

namespace TaskManagementSystem.Core.Contracts.Assignment
{
    public interface IAssignmentService
    {
        Task<IEnumerable<AssignmentIndexServiceModel>> NewestThreeAssignments();
    }
}
