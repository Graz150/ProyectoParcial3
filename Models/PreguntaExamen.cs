using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoParcial3.Models
{
    [Table("PreguntaExamen")]
    public class PreguntaExamen
    {
        public int ID { get; set; }
        
        [Required]
        [ForeignKey("Examen")]
        public int ExamenID { get; set; }
        public Examen Examen { get; set; }

        [Required]
        [ForeignKey("Pregunta")]
        public int PreguntaID { get; set; }
        public Pregunta Pregunta { get; set; }
    }
}