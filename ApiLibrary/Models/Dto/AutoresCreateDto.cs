using System.ComponentModel.DataAnnotations;

namespace ApiLibrary.Models.Dto
{
    public class AutoresCreateDto
    {

        [Required]
        [StringLength(50)]
        public string? AutorName { get; set; }

        public DateTime FechaNacimiento { get; set; }
    }
}
