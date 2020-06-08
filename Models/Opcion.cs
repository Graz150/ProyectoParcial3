using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoParcial3.Models
{
    [Table("Opcion")]
    public class Opcion
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Opcion")]
        public string Nombre { get; set; }

        [Required]
        [ForeignKey("Pregunta")]
        [Display(Name = "Pregunta")]
        public int PreguntaID { get; set; }
        public Pregunta Pregunta { get; set; }

        [Required]
        [Display(Name = "TipoOpcion")]
        [DefaultValue(TipoOpcion.Falsa)]
        public TipoOpcion Tipo { get; set; }
    }
}