using System;
using System.Collections;
using zscore_unity_sdk.Client;
using zscore_unity_sdk.Dto.Response.Common;
using zscore_unity_sdk.Dto.Response.Trigger;

namespace zscore_unity_sdk.Handler
{
    public class TriggerHandler : AbstractHandler
    {
        public TriggerHandler(ZScoreClient client) : base(client)
        {
        }
        
        public IEnumerator GetTriggers(int page, Action<Page<TriggerResponse>> onSuccess,
            Action<ZScoreErrorResponse> onError)
        {
            return Get($"/external/triggers?page={page}&size{ZScoreClient.DEFAULT_PAGE_SIZE}", onSuccess, onError);
        }

        public IEnumerator ExecuteTrigger(string triggerId, Action onSuccess,
            Action<ZScoreErrorResponse> onError)
        {
            return PostNoContent($"/external/triggers/{triggerId}/execute", null, onSuccess, onError);
        }
    }
}