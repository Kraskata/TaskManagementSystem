using System.ComponentModel.DataAnnotations;
using TaskManagementSystem.Core.Contracts;
using static TaskManagementSystem.Core.Constants.MessageConstants;
using static TaskManagementSystem.Infrastructure.Constants.DataConstants;

namespace TaskManagementSystem.Core.Models.Assignment
{
    public class AssignmentFormModel : IAssignmentModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(AssignmentTitleMaxLength,
            MinimumLength = AssignmentTitleMinLength,
            ErrorMessage = LengthMessage)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(AssignmentDescriptionMaxLength,
            MinimumLength = AssignmentDescriptionMinLength,
            ErrorMessage = LengthMessage)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal), 
            AssignmentPaidMinimum, 
            AssignmentPaidMaximum,
            ConvertValueInInvariantCulture = true,
            ErrorMessage = PricePaidIsValid)]
        [Display(Name = "Price Paid Upon Completion")]
        public decimal Paid { get; set; }

        [Display(Name = "Risk Category")]
        public int CategoryId { get; set; }

        public IEnumerable<AssignmentCategoryServiceModel> Categories { get; set; } = new List<AssignmentCategoryServiceModel>();

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Is Assigned")]
        public string DoneBy { get; set; } = null!;
    }
}
