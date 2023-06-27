using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiLibrary.Models.Dto
{
    public class LibrosDto
    {
        public string? ISBN { get; set; }
        [Required]
        [MaxLength(50)]
        public string? LibName { get; set; }

        public int numPaginas { get; set; }

        public int AutoresId { get; set; }
        

        
    }
}
