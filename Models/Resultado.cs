
using System.ComponentModel.DataAnnotations.Schema;
 

namespace ProyectoParcial3.Models
{
    [Table("Resultado")]
    public class Resultado
    {
        public int ID { get; set; }

        public int NumeroIncorrectas { get; set; }

        public int NumeroCorrectas { get; set; }

        public string Puntuacion_total { get; set; }

        [ForeignKey("Examen")]
        public int? ExamenID { get; set; }
        public Examen Examen { get; set; }

        [ForeignKey("ApplicationUser")]
        public string User_Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}