using PrestamoCables.FIME.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrestamoCables.FIME.Repository.IRepository
{
    // Se define la interfaz como pública. 
    public interface IUsuarioRepository
    {
        //Retorna todos los Usuarios.
        ICollection<Usuario> GetUsuario();

        //Retorna un solo Usuario. 
        Usuario GetUsuario(int IdUsuario);

        //Booleano que dice si existe un Usuario. 
        bool ExistsUsuario(string Nombre, string Apellido);

        //Booleano que dice si existe un Usuario según ID.
        bool ExistsUsuario(int IdUsuario);

        //Devuelve el ID que se le ha asignado al Usuario. 
        int CreateUsuario(Usuario DatosUsuario);

        //Devuelve el ID que se le ha asignado a varios Usuarios. 
        //ICollection<int> CreateUsuario(ICollection<Usuario> DatosUsuario);

        //Elimina un Usuario por medio de un ID.
        bool DeleteUsuario(int IdUsuario);

        //Elimina una Lista de Usuarios.
        bool DeleteUsuario(ICollection<int> IdUsuario);

        //Nos muestra el resultado después de una Actualización de Usuario.
        Usuario UpdateUsuario(Usuario DatosUsuario);

        //Nos muestra el resultado después de una Actualización de varios Usuarios. 
        ICollection<Usuario> UpdateUsuario(ICollection<Usuario> DatosUsuario);
    }
}
