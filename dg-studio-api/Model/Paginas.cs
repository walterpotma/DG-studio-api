using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dg_studio_api.Model
{
    [Table("paginas")]
    public class Paginas
    {
        [Key]
        public int id { get; set; }

        [Required]
        public int capitulo_id { get; set; }

        [Required]
        public int numero { get; set; }

        [Required]
        public string imagem { get; set; }
    }
}
