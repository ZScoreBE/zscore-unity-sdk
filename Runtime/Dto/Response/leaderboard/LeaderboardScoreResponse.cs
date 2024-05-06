using zscore_unity_sdk.Dto.Response.Player;

namespace zscore_unity_sdk.Dto.Response.Leaderboard
{
    public class LeaderboardScoreResponse
    {
        public string id { get; set; }
        public int score { get; set; }
        public PlayerResponse player;
    }
}