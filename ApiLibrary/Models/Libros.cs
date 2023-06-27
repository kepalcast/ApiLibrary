using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiLibrary.Models
{
    public class Libros
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? ISBN { get; set; }
        [Required]
        public string? LibName { get; set; }

        public int numPaginas { get; set; }
        
        public int AutoresId { get; set; }
        [ForeignKey("AutoresId")]

        public Autores Autores { get; set; }
    }
}
