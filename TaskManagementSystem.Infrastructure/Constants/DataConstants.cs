namespace TaskManagementSystem.Infrastructure.Constants
{
    public static class DataConstants
    {
        public const int CategoryNameMaxLength = 50;

        public const int AssignmentTitleMaxLength = 50;

        public const int AssignmentTitleMinLength = 10;

        public const int AssignmentDescriptionMaxLength = 500;

        public const int AssignmentDescriptionMinLength = 50;

        public const string AssignmentPaidMaximum = "1500";

        public const string AssignmentPaidMinimum = "150";

        public const int AssigneePhoneMaxLength = 15;

        public const int AssigneePhoneMinLength = 7;

        public const string GmailRegex = "^[\\w.+\\-]+@gmail\\.com$";

        public const string DateFormatString = "mm/dd/yyyy";
    }
}