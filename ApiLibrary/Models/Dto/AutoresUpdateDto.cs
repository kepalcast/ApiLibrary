using System.ComponentModel.DataAnnotations;

namespace ApiLibrary.Models.Dto
{
    public class AutoresUpdateDto
    {
        [Required]
        public int IdAutor { get; set; }

        [Required]
        [StringLength(50)]
        public string? AutorName { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
    }
}
