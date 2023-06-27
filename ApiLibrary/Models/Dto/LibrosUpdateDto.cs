using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiLibrary.Models.Dto
{
    public class LibrosUpdateDto
    {
        [Required]
        public string? ISBN { get; set; }
        [Required]
        [StringLength(50)]
        public string? LibName { get; set; }

        [Required]
        public int numPaginas { get; set; }
        [Required]
        public int AutoresId { get; set; }
       

        
    }
}
