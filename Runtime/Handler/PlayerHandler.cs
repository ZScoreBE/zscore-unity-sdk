using System;
using System.Collections;
using zscore_unity_sdk.Client;
using zscore_unity_sdk.Dto.Request;
using zscore_unity_sdk.Dto.Response.Common;
using zscore_unity_sdk.Dto.Response.Player;

namespace zscore_unity_sdk.Handler
{
    public sealed class PlayerHandler : AbstractHandler
    {
        public PlayerHandler(ZScoreClient client) : base(client)
        {
        }

        public IEnumerator CreatePlayer(
            PlayerRequest playerRequest, Action<PlayerResponse> onSuccess, Action<ZScoreErrorResponse> onError
        )
        {
            return Post("/external/players", playerRequest, onSuccess, onError, SecurityType.API_KEY);
        }

        public IEnumerator GetCurrentPlayer(Action<PlayerResponse> onSuccess, Action<ZScoreErrorResponse> onError)
        {
            return Get("/external/players/myself", onSuccess, onError);
        }

        public IEnumerator TakeLivesFromCurrentPlayer(Action<PlayerResponse> onSuccess,
            Action<ZScoreErrorResponse> onError, int amount = 1)
        {
            return Patch($"/external/players/myself/take-life?amount={amount}", null, onSuccess, onError);
        }
        
        public IEnumerator GiveLivesFromCurrentPlayer(Action<PlayerResponse> onSuccess,
            Action<ZScoreErrorResponse> onError, int amount = 1)
        {
            return Patch($"/external/players/myself/give-life?amount={amount}", null, onSuccess, onError);
        }
    }
}