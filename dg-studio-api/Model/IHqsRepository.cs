namespace dg_studio_api.Model
{
    public interface IHqsRepository
    {
        Task AddHqAsync(Hqs hq);
        List<Hqs> Get();
    }
}
