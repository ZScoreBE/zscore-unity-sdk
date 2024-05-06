using zscore_unity_sdk.Dto.Response.Player;

namespace zscore_unity_sdk.Dto.Response.leaderboard
{
    public class LeaderboardScoreResponse
    {
        public string id { get; set; }
        public int score { get; set; }
        public PlayerResponse player;
    }
}