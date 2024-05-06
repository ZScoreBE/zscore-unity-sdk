using System;

namespace zscore_unity_sdk.Dto.Response.Player
{
    public class PlayerResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public DateTime lastSignIn { get; set; }
    }
}