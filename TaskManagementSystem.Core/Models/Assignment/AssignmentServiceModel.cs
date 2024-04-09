using System.ComponentModel.DataAnnotations;
using TaskManagementSystem.Core.Contracts;
using static TaskManagementSystem.Core.Constants.MessageConstants;
using static TaskManagementSystem.Infrastructure.Constants.DataConstants;

namespace TaskManagementSystem.Core.Models.Assignment
{
    public class AssignmentServiceModel : IAssignmentModel
    {
        public  int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(AssignmentTitleMaxLength,
            MinimumLength = AssignmentTitleMinLength,
            ErrorMessage = LengthMessage)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(AssignmentDescriptionMaxLength,
            MinimumLength = AssignmentDescriptionMinLength,
            ErrorMessage = LengthMessage)]
        public string Description { get; set; } = string.Empty ;


        [Display(Name = "Issue date")]
        public string DoneBy { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal),
            AssignmentPaidMinimum,
            AssignmentPaidMaximum,
            ConvertValueInInvariantCulture = true,
            ErrorMessage = PricePaidIsValid)]
        [Display(Name = "Price Paid Upon Completion")]
        public decimal Paid { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Is Assigned")]
        public bool IsAssigned { get; set; }
    }
}