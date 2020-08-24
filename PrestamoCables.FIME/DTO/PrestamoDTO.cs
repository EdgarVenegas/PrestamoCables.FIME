using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrestamoCables.FIME.DTO
{
    public class PrestamoDTO
    {
        public int ID_Prestamo { get; set; }
        public int ID_Usuario { get; set; }
        public int ID_Cable { get; set; }
        public DateTime FechaCreo { get; set; }
        public string Salon { get; set; }
        public string Hora { get; set; }
        public string Materia { get; set; }
        public bool Estado { get; set; }
    }
}
