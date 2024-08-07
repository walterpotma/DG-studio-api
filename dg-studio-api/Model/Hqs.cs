using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dg_studio_api.Model
{
    [Table("hqs")]
    public class Hqs
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string nome { get; set; }

        [Required]
        public string capa { get; set; }

        [Required]
        public string banner { get; set; }

        [Required]
        public string autor { get; set; }

        public string descricao { get; set; }

        public string generos { get; set; }
    }
}
