using System;
using System.Collections;
using zscore_unity_sdk.Client;
using zscore_unity_sdk.Dto.Request.Player;
using zscore_unity_sdk.Dto.Response.Common;
using zscore_unity_sdk.Dto.Response.Player;

namespace zscore_unity_sdk.Handler
{
    public class PlayerTokensHandler : AbstractHandler

    {
        public PlayerTokensHandler(ZScoreClient client) : base(client)
        {
        }

        public IEnumerator GetPlayerTokens(TokenForPlayerRequest request, Action<TokenForPlayerResponse> onSuccess,
            Action<ZScoreErrorResponse> onError)
        {
            return Post("/public/auth/token/for-player", request, onSuccess, onError, SecurityType.PUBLIC);
        }
        
        public IEnumerator RefreshPlayerTokens(RefreshTokenForPlayerRequest request, Action<TokenForPlayerResponse> onSuccess,
            Action<ZScoreErrorResponse> onError)
        {
            return Post("/public/auth/token/for-player/refresh", request, onSuccess, onError, SecurityType.PUBLIC);
        }
    }
}