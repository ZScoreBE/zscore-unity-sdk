using zscore_unity_sdk.Dto.Response.Currency;

namespace zscore_unity_sdk.Dto.Response.Trigger
{
    public class TriggerResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public TriggerCostType costType { get; set; }
        public int? costAmount { get; set; }
        public CurrencyResponse costCurrency { get; set; }
        public TriggerRewardType rewardType { get; set; }
        public int? rewardAmount { get; set; }
        public CurrencyResponse rewardCurrency { get; set; }
        
    }
}