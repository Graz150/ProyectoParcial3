using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoParcial3.Models
{
    [Table("Programa")]
    public class Programa
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Programa")]
        public string Nombre { get; set; }
    }
}