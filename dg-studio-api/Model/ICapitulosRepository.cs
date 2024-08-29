namespace dg_studio_api.Model
{
    public interface ICapitulosRepository
    {
        Task AddCapituloAsync(Capitulos cap);
        Task<Capitulos> GetCapituloByIdAsync(int id);
        List<Capitulos> Get();
        Task<Capitulos> ListarCapitulosHq(string hq);
    }
}
