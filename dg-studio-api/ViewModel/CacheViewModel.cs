namespace dg_studio_api.ViewModel
{
    public class CacheViewModel
    {
        public int id { get; set; }
        public string userid { get; private set; }
        public string reqtype { get; private set; }
        public string cachevalue { get; private set; }
        public DateTime expirationtime { get; private set; }
    }
}
