namespace zscore_unity_sdk.Exception
{
    public class ZScoreApiException : System.Exception
    {
        public ZScoreApiException(string message) : base(message)
        {
        }

        public ZScoreApiException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}