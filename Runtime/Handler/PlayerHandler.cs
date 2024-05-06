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
    }
}