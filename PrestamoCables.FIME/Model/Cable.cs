using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrestamoCables.FIME.Model
{
    [Table("Cables", Schema = "FIME")]
    public class Cable
    {
        [Key]
        public int ID_Cable { get; set; }

        [Required]
        [StringLength(50)]
        public string TipoCable { get; set; }

        [Required]
        public int Longitud { get; set; }

        [Required]
        [StringLength(50)]
        public string Estatus { get; set; }
    }
}
