
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 

namespace ProyectoParcial3.Models
{
    [Table("Ciudad")]
    public class Ciudad
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Ciudad")]
        public string Nombre { get; set; }
    }
}