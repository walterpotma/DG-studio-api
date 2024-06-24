namespace dg_studio_api.Model
{
    public interface ICacheRepository
    {
        void Add(Cache cache);
        List<Cache> Get();
        void Update(Cache cache);
    }
}
