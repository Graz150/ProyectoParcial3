using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProyectoParcial3.Models
{
    [Table("Afirmacion")]
    public class Afirmacion
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Afirmacion")]
        public string Nombre { get; set; }
    }
}