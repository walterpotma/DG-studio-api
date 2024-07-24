namespace dg_studio_api.Model
{
    public interface ICacheRepository
    {
        Task AddTokenAsync(int userId, string type, string valor);
        Task<Cache> GetCacheById(int id);
    }
}
