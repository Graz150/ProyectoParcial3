using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoParcial3.Models
{
    [Table("PreguntaEstudiante")]
    public class PreguntaEstudiante
    {
        public int ID { get; set; }

        [ForeignKey("Opcion")]
        public int? OpcionElegida { get; set; }
        public Opcion Opcion { get; set; }
        
        [Required]
        [ForeignKey("Pregunta")]
        public int? PreguntaID { get; set; }
        public Pregunta Pregunta { get; set; }
        

        [ForeignKey("ApplicationUser")]
        public string  User_Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
} 