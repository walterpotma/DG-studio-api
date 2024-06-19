using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dg_studio_api.Model
{
    [Table("usuarios")]
    public class Usuarios
    {
        [Key]
        public int id { get; private set; }
        public string? nome { get; private set; }
        public string? email { get; private set; }
        public string? senha { get; private set; }
        public string? categoria { get; private set; }
        
        public Usuarios(string nome, string email, string senha, string categoria)
        {
            this.nome = nome;
            this.email = email;
            this.senha = senha;
            this.categoria = categoria;
        }
    }
}
