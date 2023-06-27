using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiLibrary.Models.Dto
{
    public class LibrosCreateDto
    {
        [Required]
        [StringLength(50)]
        public string? LibName { get; set; }

        public int numPaginas { get; set; }

        public int AutoresId { get; set; }
      
    }
}
