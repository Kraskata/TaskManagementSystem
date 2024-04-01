using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TaskManagementSystem.Infrastructure.Constants.DataConstants;

namespace TaskManagementSystem.Infrastructure.Data.Models
{
    public class Assignee
    {
        [Key]
        [Comment("Assignee identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(AssigneePhoneMaxLength)]
        [Comment("Assignee's phone")]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        [MaxLength(AssigneePhoneMaxLength)]
        [RegularExpression(GmailRegex)]
        [Comment("Assignee's Gmail, Must Be G-Mail, Regex Checked")]
        public string Gmail { get; set; } = string.Empty;

        [Required]
        [Comment("User Identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        public List<Assignment> Assignments { get; set; } = new List<Assignment>();
    }
}
