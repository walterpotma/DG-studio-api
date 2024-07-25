using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dg_studio_api.Model
{
    [Table("capitulos")]
    public class Capitulos
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string hq { get; set; }

        [Required]
        public int capitulo { get; set; }
    }
}
