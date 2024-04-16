using TaskManagementSystem.Core.Models.Assignment;

namespace TaskManagementSystem.Core.Models.Admin
{
    public class MyAssignmentsViewModel
    {
        public IEnumerable<AssignmentServiceModel> AddedAssignments { get; set; } = new List<AssignmentServiceModel>();
        public IEnumerable<AssignmentServiceModel> AcceptedAssignments { get; set; } = new List<AssignmentServiceModel>();
    }
}