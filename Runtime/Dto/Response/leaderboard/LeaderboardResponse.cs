namespace zscore_unity_sdk.Dto.Response.leaderboard
{
    public class LeaderboardResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public LeaderboardDirection direction { get; set; }
        public LeaderboardScoringType scoreType { get; set; }
    }
}