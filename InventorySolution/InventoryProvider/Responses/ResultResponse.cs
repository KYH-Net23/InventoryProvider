namespace InventoryProvider.Responses
{
    public static class ResultResponse
    {
        public static string Success { get; set; } = "Operation was successful";
        public static string Failed { get; set; } = "Operation failed.";

        // Method to return success response in JSON format
        public static object SuccessResponse()
        {
            return new { message = Success, success = true };
        }

        // Method to return failure response in JSON format
        public static object FailedResponse()
        {
            return new { message = Failed, success = false };
        }
    }
}
