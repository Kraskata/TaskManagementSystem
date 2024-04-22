using TaskManagementSystem.Core.Contracts;

namespace TaskManagementSystem.Core.Models.Assignment
{
    public class AssignmentDetailsViewModel : IAssignmentModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string DoneBy { get; set; } = string.Empty;

        public string Assigned { get; set; } = string.Empty;
    }
}
