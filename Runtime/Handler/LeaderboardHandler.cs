using System;
using System.Collections;
using zscore_unity_sdk.Client;
using zscore_unity_sdk.Dto.Response.Common;
using zscore_unity_sdk.Dto.Response.leaderboard;

namespace zscore_unity_sdk.Handler
{
    public class LeaderboardHandler : AbstractHandler
    {
        public LeaderboardHandler(ZScoreClient client) : base(client)
        {
        }

        public IEnumerator GetLeaderboards(int page, Action<Page<LeaderboardResponse>> onSuccess,
            Action<ZScoreErrorResponse> onError)
        {
            return Get($"/external/leaderboards?page={page}&size{ZScoreClient.DEFAULT_PAGE_SIZE}", onSuccess, onError);
        }

        public IEnumerator GetLeaderboardById(string leaderboardId, Action<LeaderboardResponse> onSuccess,
            Action<ZScoreErrorResponse> onError)
        {
            return Get($"/external/leaderboards/{leaderboardId}", onSuccess, onError);
        }

        public IEnumerator GetLeaderboardScores(string leaderboardId, int page,
            Action<Page<LeaderboardScoreResponse>> onSuccess,
            Action<ZScoreErrorResponse> onError)
        {
            return Get($"/external/leaderboards/{leaderboardId}/scores?page={page}&size{ZScoreClient.DEFAULT_PAGE_SIZE}", onSuccess, onError);
        }
    }
}