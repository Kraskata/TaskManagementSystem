using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static TaskManagementSystem.Infrastructure.Constants.DataConstants;

namespace TaskManagementSystem.Infrastructure.Data.Models
{
    [Comment("Task Category")]
    public class Category
    {
        [Key]
        [Comment("Category Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        [Comment("Category Name")]
        public string Name { get; set; } = string.Empty;

        public List<Assignment> Assignments { get; set; } = new List<Assignment>();
    }
}
