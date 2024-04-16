namespace TaskManagementSystem.Core.Models.Admin
{
    public class AcceptServiceModel
    {
        public string AssignmentTitle { get; set; } = string.Empty;

        public string AssignmentDescription { get; set; } = string.Empty;

        public string AssigneeFullName { get; set; } = string.Empty;

        public string AssigneeEmail { get; set; } = string.Empty;

        public string WorkerFullName { get; set; } = string.Empty;

        public string WorkerEmail { get; set; } = string.Empty;
    }
}
