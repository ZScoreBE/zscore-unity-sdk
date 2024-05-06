using zscore_unity_sdk.Libs.ZeroDepJson;

namespace zscore_unity_sdk.Utils
{
    public static class JsonUtils
    {
        private static readonly JsonOptions DEFAULT_JSON_OPTIONS = new JsonOptions(
            JsonSerializationOptions.UseXmlIgnore | 
            JsonSerializationOptions.UseScriptIgnore | 
            JsonSerializationOptions.SerializeFields | 
            JsonSerializationOptions.AutoParseDateTime | 
            JsonSerializationOptions.UseJsonAttribute | 
            JsonSerializationOptions.SkipDefaultValues | 
            JsonSerializationOptions.SkipZeroValueTypes | 
            JsonSerializationOptions.SkipNullPropertyValues | 
            JsonSerializationOptions.SkipNullDateTimeValues
        );

        public static string Serialize(object obj)
        {
            return Json.Serialize(obj, DEFAULT_JSON_OPTIONS);
        }

        public static T Deserialize<T>(string json)
        {
            return Json.Deserialize<T>(json, DEFAULT_JSON_OPTIONS);
        }
    }
}