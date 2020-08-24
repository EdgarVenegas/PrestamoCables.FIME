using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrestamoCables.FIME.Model
{
    [Table("Prestamos", Schema = "FIME")]
    public class Prestamo
    {
        [Key]
        public int ID_Prestamo{ get; set; }

        [Required]
        public int ID_Usuario{ get; set; }

        [Required]
        public int ID_Cable{ get; set; }

        [Required]
        public DateTime FechaCreo { get; set; }

        [Required]
        [StringLength(25)]
        public string Salon { get; set; }

        [Required]
        [StringLength(2)]
        public string Hora { get; set; }

        [Required]
        [StringLength(100)]
        public string Materia { get; set; }

        [Required]
        public bool Estado { get; set; }
    }
}
