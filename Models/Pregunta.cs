using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoParcial3.Models
{
    [Table("Pregunta")]
    public class Pregunta
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Pregunta")]
        public string Nombre { get; set; }

        [Required]
        [ForeignKey("Competencia")]
        public int CompetenciaID { get; set; }
        public Competencia Competencia { get; set; }

        [Required]
        [ForeignKey("Afirmacion")]
        public int AfirmacionID { get; set; }
        public Afirmacion Afirmacion { get; set; }
    }
}