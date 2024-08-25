using System;
using System.Collections;
using zscore_unity_sdk.Client;
using zscore_unity_sdk.Dto.Response.Common;
using zscore_unity_sdk.Dto.Response.Currency;

namespace zscore_unity_sdk.Handler
{
    public class CurrenciesHandler : AbstractHandler
    {
        public CurrenciesHandler(ZScoreClient client) : base(client)
        {
        }

        public IEnumerator GetCurrencies(int page, Action<Page<CurrencyResponse>> onSuccess,
            Action<ZScoreErrorResponse> onError)
        {
            return Get($"/external/currencies?page={page}&size{ZScoreClient.DEFAULT_PAGE_SIZE}", onSuccess, onError);
        }

        public IEnumerator GetCurrencyOffers(string currencyId, int page, Action<Page<CurrencyOfferResponse>> onSuccess,
            Action<ZScoreErrorResponse> onError)
        {
            return Get($"/external/currencies/{currencyId}/offers?page={page}&size{ZScoreClient.DEFAULT_PAGE_SIZE}",
                onSuccess, onError);
        }
    }
}