namespace dg_studio_api.Model
{
    public interface IPaginasRepository
    {
        Task AddPaginaAsync(Paginas pagina);
        Task<List<Paginas>> GetPaginaByIdAsync(int capitulo_id);
        List<Paginas> Get();
    }
}
