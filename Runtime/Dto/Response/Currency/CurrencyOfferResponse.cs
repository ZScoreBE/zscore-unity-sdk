namespace zscore_unity_sdk.Dto.Response.Currency
{
    public class CurrencyOfferResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public int amount { get; set; }
        public double? priceEx { get; set; }
        public double? discountPriceEx { get; set; }
    }
}