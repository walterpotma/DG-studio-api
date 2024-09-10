namespace dg_studio_api.Model
{
    public interface IHqsRepository
    {
        Task AddHqAsync(Hqs hq);
        List<Hqs> Get();
        Task<Hqs> GetHqById(int id);
        Task<Hqs> GetHqByName(string nome);
        Task<List<Hqs>> GetHqFinalizada(string status);
        Task<List<Hqs>> GetHqAndamento(string status);
    }
}
