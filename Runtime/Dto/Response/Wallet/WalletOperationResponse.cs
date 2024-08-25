using zscore_unity_sdk.Dto.Common;

namespace zscore_unity_sdk.Dto.Response.Wallet
{
    public class WalletOperationResponse
    {
        public string id { get; set; }
        public WalletOperationType type { get; set; }
        public int amount { get; set; }
        public WalletResponse wallet { get; set; }
    }
}