namespace dg_studio_api.Model
{
    public interface IUsuariosRepository
    {
        void Add(Usuarios usuarios);
        List<Usuarios> Get();
    }
}
