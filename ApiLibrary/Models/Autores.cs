using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiLibrary.Models
{
    public class Autores
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdAutor { get; set; }

        [Required]
        [StringLength(50)]
        public string? AutorName { get; set; }
        
        public DateTime FechaNacimiento { get; set; }
    }
}
