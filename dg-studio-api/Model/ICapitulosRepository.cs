namespace dg_studio_api.Model
{
    public interface ICapitulosRepository
    {
        Task AddCapituloAsync(Capitulos cap);
        Task<Capitulos> GetCapituloByIdAsync(int id);
        Task<List<Capitulos>> GetUltimosCaps();
        Task<Capitulos> ListarCapitulosHq(string hq);
        Task<List<Capitulos>> ListarTodosCapitulosHq(string hq);
    }
}
