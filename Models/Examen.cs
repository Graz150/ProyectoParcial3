using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoParcial3.Models
{
    [Table("Examen")]
    public class Examen
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [StringLength(30, ErrorMessage = "Debe tener menos de 30 carácteres")]
        public string Nombre { get; set; }

        [Required]
        [FechaExamen]
        [Display(Name = "Fecha de Entrega")]
        [DataType(DataType.Date, ErrorMessage = "El formato de fecha no es válido")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaEntrega { get; set; } = DateTime.Now;
    }
}