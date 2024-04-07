namespace TaskManagementSystem.Core.Models.Assignment
{
    public class AssignmentQueryServiceModel
    {
        public int TotalAssignmentsCount { get; set; }

        public IEnumerable<AssignmentServiceModel> Assignments { get; set; } = new List<AssignmentServiceModel>();
    }
}
