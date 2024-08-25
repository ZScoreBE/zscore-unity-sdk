using System.Collections.Generic;
using UnityEngine.Networking;
using zscore_unity_sdk.Handler;

namespace zscore_unity_sdk.Client
{
    public class ZScoreClient
    {
        public const int DEFAULT_PAGE_SIZE = 25;
        
        public string baseApiUrl { get; set; }
        public string apiKey { get; set; }
        public string playerAccessToken { get; set; }
        public string playerRefreshToken { get; set; }

        public PlayerHandler Players()
        {
            return new PlayerHandler(this);
        }

        public PlayerTokensHandler AuthTokens()
        {
            return new PlayerTokensHandler(this);
        }

        public LeaderboardHandler Leaderboards()
        {
            return new LeaderboardHandler(this);
        }

        public AchievementHandler Achievements()
        {
            return new AchievementHandler(this);
        }

        public CurrenciesHandler Currencies()
        {
            return new CurrenciesHandler(this);
        }
    }
}