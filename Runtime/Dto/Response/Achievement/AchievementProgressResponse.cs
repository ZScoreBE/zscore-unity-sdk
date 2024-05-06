namespace zscore_unity_sdk.Dto.Response.Achievement
{
    public class AchievementProgressResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public AchievementType type { get; set; }
        public int? neededCount { get; set; }
        public int? currentCount { get; set; }
        public bool completed { get; set; }
    }
}