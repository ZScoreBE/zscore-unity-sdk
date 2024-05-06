using System;
using System.Collections;
using zscore_unity_sdk.Client;
using zscore_unity_sdk.Dto.Response.Achievement;
using zscore_unity_sdk.Dto.Response.Common;

namespace zscore_unity_sdk.Handler
{
    public class AchievementHandler : AbstractHandler
    {
        public AchievementHandler(ZScoreClient client) : base(client)
        {
        }

        public IEnumerator getAchievements(int page, Action<Page<AchievementProgressResponse>> onSuccess,
            Action<ZScoreErrorResponse> onError)
        {
            return Get($"/external/achievements?page={page}&size{ZScoreClient.DEFAULT_PAGE_SIZE}", onSuccess, onError);
        }
        
        public IEnumerator completeAchievement(string achievementId, Action<AchievementProgressResponse> onSuccess,
            Action<ZScoreErrorResponse> onError)
        {
            return Patch($"/external/achievements/{achievementId}/complete", null, onSuccess, onError);
        }
        
        public IEnumerator increaseAchievementProgress(string achievementId, int amount, Action<AchievementProgressResponse> onSuccess,
            Action<ZScoreErrorResponse> onError)
        {
            return Patch($"/external/achievements/{achievementId}/increase?amount={amount}", null, onSuccess, onError);
        }
        
        public IEnumerator decreaseAchievementProgress(string achievementId, int amount, Action<AchievementProgressResponse> onSuccess,
            Action<ZScoreErrorResponse> onError)
        {
            return Patch($"/external/achievements/{achievementId}/decrease?amount={amount}", null, onSuccess, onError);
        }
    }
}