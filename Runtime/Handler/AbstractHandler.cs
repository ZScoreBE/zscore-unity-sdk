using System;
using System.Collections;
using System.Text;
using UnityEngine.Networking;
using zscore_unity_sdk.Client;
using zscore_unity_sdk.Dto.Response.Common;
using zscore_unity_sdk.Exception;
using zscore_unity_sdk.Utils;

namespace zscore_unity_sdk.Handler
{
    public abstract class AbstractHandler
    {
        protected enum SecurityType
        {
            PUBLIC,
            API_KEY,
            JWT_TOKEN
        }
        
        private const string AUTH_HEADER = "Authorization";
        private const string CONTENT_TYPE_HEADER_KEY = "Content-Type";
        private const string CONTENT_TYPE_HEADER_VALUE = "application/json";

        private readonly ZScoreClient client;

        protected AbstractHandler(ZScoreClient client)
        {
            this.client = client;
        }

        protected IEnumerator Post<T>(string uri, object body, Action<T> onSuccess,
            Action<ZScoreErrorResponse> onError, SecurityType securityType = SecurityType.JWT_TOKEN)
        {
            UnityWebRequest request = createBaseRequest(uri, UnityWebRequest.kHttpVerbPOST, securityType);

            if (body != null)
            {
                string jsonBody = JsonUtils.Serialize(body);
                request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(jsonBody));
            }

            yield return request.SendWebRequest();

            HandleResponse(request, onSuccess, onError);
        }
        
        protected IEnumerator PostNoContent(string uri, object body, Action onSuccess,
            Action<ZScoreErrorResponse> onError, SecurityType securityType = SecurityType.JWT_TOKEN)
        {
            UnityWebRequest request = createBaseRequest(uri, UnityWebRequest.kHttpVerbPOST, securityType);

            if (body != null)
            {
                string jsonBody = JsonUtils.Serialize(body);
                request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(jsonBody));
            }

            yield return request.SendWebRequest();

            HandleResponseNoContent(request, onSuccess, onError);
        }

        protected IEnumerator Get<T>(string uri, Action<T> onSuccess,
            Action<ZScoreErrorResponse> onError, SecurityType securityType = SecurityType.JWT_TOKEN)
        {
            UnityWebRequest request = createBaseRequest(uri, UnityWebRequest.kHttpVerbGET, securityType);

            yield return request.SendWebRequest();

            HandleResponse(request, onSuccess, onError);
        }

        protected IEnumerator Patch<T>(string uri, object body, Action<T> onSuccess,
            Action<ZScoreErrorResponse> onError, SecurityType securityType = SecurityType.JWT_TOKEN)
        {
            UnityWebRequest request = createBaseRequest(uri, "PATCH", securityType);

            if (body != null)
            {
                string jsonBody = JsonUtils.Serialize(body);
                request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(jsonBody));
            }

            yield return request.SendWebRequest();

            HandleResponse(request, onSuccess, onError);
        }

        protected IEnumerator Delete<T>(string uri, Action<T> onSuccess,
            Action<ZScoreErrorResponse> onError, SecurityType securityType = SecurityType.JWT_TOKEN)
        {
            UnityWebRequest request = createBaseRequest(uri, UnityWebRequest.kHttpVerbDELETE, securityType);

            yield return request.SendWebRequest();

            HandleResponse(request, onSuccess, onError);
        }

        private UnityWebRequest createBaseRequest(string uri, string httpVerb, SecurityType securityType)
        {
            UnityWebRequest request = new UnityWebRequest(client.baseApiUrl + uri, httpVerb);
            request.timeout = 20;
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader(CONTENT_TYPE_HEADER_KEY, CONTENT_TYPE_HEADER_VALUE);

            // Authentication
            if (securityType == SecurityType.API_KEY)
            {
                if (string.IsNullOrWhiteSpace(client.apiKey))
                {
                    throw new ZScoreApiException("No API key configured in the ZScoreClient");
                }

                request.SetRequestHeader(AUTH_HEADER, $"ApiKey {client.apiKey}");
            }
            else if (securityType == SecurityType.JWT_TOKEN)
            {
                if (string.IsNullOrWhiteSpace(client.playerAccessToken))
                {
                    throw new ZScoreApiException("No player access token configured in the ZScoreClient");
                }

                request.SetRequestHeader(AUTH_HEADER, $"Bearer {client.playerAccessToken}");
            }

            return request;
        }

        private static void HandleResponse<T>(UnityWebRequest request, Action<T> onSuccess,
            Action<ZScoreErrorResponse> onError)
        {
            if (request.result == UnityWebRequest.Result.Success)
            {
                T response = JsonUtils.Deserialize<T>(request.downloadHandler.text);
                onSuccess?.Invoke(response);
            }
            else
            {
                ZScoreErrorResponse response = JsonUtils.Deserialize<ZScoreErrorResponse>(request.downloadHandler.text);
                onError?.Invoke(response);
            }
        }
        
        private static void HandleResponseNoContent(UnityWebRequest request, Action onSuccess,
            Action<ZScoreErrorResponse> onError)
        {
            if (request.result == UnityWebRequest.Result.Success)
            {
                onSuccess?.Invoke();
            }
            else
            {
                ZScoreErrorResponse response = JsonUtils.Deserialize<ZScoreErrorResponse>(request.downloadHandler.text);
                onError?.Invoke(response);
            }
        }
    }
}