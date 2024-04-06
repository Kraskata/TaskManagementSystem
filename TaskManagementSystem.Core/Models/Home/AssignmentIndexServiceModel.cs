using TaskManagementSystem.Infrastructure.Data.Models;

namespace TaskManagementSystem.Core.Models.Home
{
    public class AssignmentIndexServiceModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public Category? Category { get; set; }
    }
}
