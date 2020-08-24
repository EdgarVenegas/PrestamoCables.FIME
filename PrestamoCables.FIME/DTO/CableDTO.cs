using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrestamoCables.FIME.DTO
{
    public class CableDTO
    {
        public int ID_Cable { get; set; }
        public string TipoCable { get; set; }
        public int Longitud { get; set; }
        public string Estatus { get; set; }
    }
}
