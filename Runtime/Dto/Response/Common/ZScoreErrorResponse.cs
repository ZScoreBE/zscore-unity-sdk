using System.Collections.Generic;

namespace zscore_unity_sdk.Dto.Response.Common
{
    public class ZScoreErrorResponse
    {
        public int status { get; set; }
        public string errorKey { get; set; }
        public object detail { get; set; }
    }
}