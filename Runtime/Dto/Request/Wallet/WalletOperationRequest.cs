using zscore_unity_sdk.Dto.Common;

namespace zscore_unity_sdk.Dto.Request.Wallet
{
    public class WalletOperationRequest
    {
        public WalletOperationType type { get; set; }
        public int amount { get; set; }
    }
}