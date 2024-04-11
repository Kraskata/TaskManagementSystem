using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TaskManagementSystem.Infrastructure.Constants.DataConstants;

namespace TaskManagementSystem.Infrastructure.Data.Models
{
    [Comment("Task To Do")]
    public class Assignment
    {
        [Key]
        [Comment("Task Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(AssignmentTitleMaxLength)]
        [Comment("Task Title/Name")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Comment("Task Description")]
        [MaxLength(AssignmentDescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Assignment Paid Upon Completion")]
        [Column(TypeName = "decimal(18,2)")]
        //[Range(typeof(decimal), AssignmentPaidMinimum, AssignmentPaidMaximum, ConvertValueInInvariantCulture = true)]
        public decimal Paid { get; set; }

        [Required]
        [Comment("Task Assigned Date")]
        public string Assigned { get; set; } = string.Empty;

        [Required]
        [Comment("Task Done By Date")]
        public string DoneBy { get; set; } = string.Empty;

        [Required]
        [Comment("Assignee identifier")]
        public int AssigneeId { get; set; }

        [Comment("User id of the worker accepting the task")]
        public string? WorkerId { get; set; }

        [Comment("Is house approved by an admin")]
        public bool IsApproved { get; set; }

        [Required]
        [Comment("Identifier For Task Category")]
        public int CategoryId { get; set; }

        [Comment("Task Category")]
        public Category Category { get; set; }

        public Assignee Assignee { get; set; } = null!;
    }
}
