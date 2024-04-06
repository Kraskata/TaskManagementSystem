using System.ComponentModel.DataAnnotations;
using static TaskManagementSystem.Core.Constants.MessageConstants;
using static TaskManagementSystem.Infrastructure.Constants.DataConstants;

namespace TaskManagementSystem.Core.Models.Assignee
{
    public class BecomeAssigneeFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(AssigneePhoneMaxLength, 
            MinimumLength = AssigneePhoneMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Phone number")]
        [Phone]
        public string PhoneNumber { get; set; } = null!;
        

    }
}
