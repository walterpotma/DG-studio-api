using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dg_studio_api.Model
{
    [Table("cache")]
    public class Cache
    {
        [Key]
        public int id { get; set; }

        [Required]
        public int userid { get; set; }

        [Required]
        [StringLength(50)]
        public string type { get; set; } // Tipo do token, por exemplo, "access" ou "refresh"

        [Required]
        public string value { get; set; } // Valor do token
    }
}
