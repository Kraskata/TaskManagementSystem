using System.ComponentModel.DataAnnotations;
using TaskManagementSystem.Core.Enumerations;

namespace TaskManagementSystem.Core.Models.Assignment
{
    public class AllAssignmentsQueryModel
    {
        public int AssignmentsPerPage { get; } = 6;

        public string Category { get; init; } = null!;

        [Display(Name = "Search")]
        public string SearchItem { get; init; } = null!;

        public AssignmentSorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalAssignmentsCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = null!;

        public IEnumerable<AssignmentServiceModel> Assignments { get; set; } = new List<AssignmentServiceModel>();
    }
}
