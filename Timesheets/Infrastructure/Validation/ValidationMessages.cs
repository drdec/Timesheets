namespace Timesheets.Infrastructure.Validation
{
    public static class ValidationMessages
    {
        public const string SheetAmountError = "Amount should be between 1 and 8 hours.";
        public const string InvalidValue = "Incorrect value";
        public const string RequestDataStarError = "Start date should be less than or equal to the end date";
        public const string RequestDataEndError = "End date should be greater than or equal to the start date";
    }
}
