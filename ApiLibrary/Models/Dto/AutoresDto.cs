using System.ComponentModel.DataAnnotations;

namespace ApiLibrary.Models.Dto
{
    public class AutoresDto
    {
        public int IdAutor { get; set; }

        [Required]
        [MaxLength(50)]
        public string? AutorName { get; set; }

        public DateTime FechaNacimiento { get; set; }


    }
}
