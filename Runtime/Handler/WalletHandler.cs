using System;
using System.Collections;
using zscore_unity_sdk.Client;
using zscore_unity_sdk.Dto.Request.Wallet;
using zscore_unity_sdk.Dto.Response.Common;
using zscore_unity_sdk.Dto.Response.Wallet;

namespace zscore_unity_sdk.Handler
{
    public class WalletHandler : AbstractHandler
    {
        public WalletHandler(ZScoreClient client) : base(client)
        {
        }

        public IEnumerator GetWallets(int page, Action<Page<WalletResponse>> onSuccess,
            Action<ZScoreErrorResponse> onError)
        {
            return Get($"/external/wallets?page={page}&size{ZScoreClient.DEFAULT_PAGE_SIZE}", onSuccess, onError);
        }

        public IEnumerator GetWallet(string walletId, Action<WalletResponse> onSuccess,
            Action<ZScoreErrorResponse> onError)
        {
            return Get($"/external/wallets/{walletId}", onSuccess, onError);
        }

        public IEnumerator GetWalletOperations(string walletId, int page, Action<Page<WalletOperationResponse>> onSuccess,
            Action<ZScoreErrorResponse> onError)
        {
            return Get($"/external/wallets/{walletId}/operations?page={page}&size{ZScoreClient.DEFAULT_PAGE_SIZE}",
                onSuccess, onError);
        }

        public IEnumerator CreateWalletOperation(string walletId, WalletOperationRequest operationRequest,
            Action<WalletOperationResponse> onSuccess, Action<ZScoreErrorResponse> onError)
        {
            return Post($"/external/wallets/{walletId}/operations", operationRequest, onSuccess, onError);
        }
    }
}