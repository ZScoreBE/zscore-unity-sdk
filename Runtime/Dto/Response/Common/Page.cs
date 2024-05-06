namespace zscore_unity_sdk.Dto.Response.Common
{
    public class Page<T>
    {
        public T[] items { get; set; }
        public int currentPage { get; set; }
        public int count { get; set; }
        public int lastPage { get; set; }
        public int total { get; set; }
        public PageLinks links { get; set; }
    }
}