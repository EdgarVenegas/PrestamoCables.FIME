using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrestamoCables.FIME.Model
{
    [Table("Usuarios", Schema = "FIME")]
    public class Usuario
    {
        [Key]
        public int ID_Usuario { get; set; }

        [Required]
        public int Matricula { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string TipoCuenta { get; set; }

        [Required]
        public bool Activo { get; set; }
    }
}
