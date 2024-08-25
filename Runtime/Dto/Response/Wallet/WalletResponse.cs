using zscore_unity_sdk.Dto.Response.Currency;

namespace zscore_unity_sdk.Dto.Response.Wallet
{
    public class WalletResponse
    {
        public string id { get; set; }
        public int amount { get; set; }
        public CurrencyResponse currency { get; set; }
    }
}