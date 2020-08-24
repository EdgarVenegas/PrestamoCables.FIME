using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrestamoCables.FIME.DTO
{
    public class UsuarioDTO
    {
        public int ID_Usuario { get; set; }
        public int Matricula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string TipoCuenta { get; set; }
        public bool Activo { get; set; }
    }
}
