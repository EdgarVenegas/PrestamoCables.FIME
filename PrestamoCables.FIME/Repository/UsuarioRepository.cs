using PrestamoCables.FIME.Infraestructure;
using PrestamoCables.FIME.Model;
using PrestamoCables.FIME.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Se realizan todas las operaciones necesarias de la lógia 
// para poder llamar los datos desde y hacia nuestra BD. 

namespace PrestamoCables.FIME.Repository
{
    //Implementación de la Interfaz
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly PrestamoCablesDbContext _bdPrestamoCables;

        public UsuarioRepository(PrestamoCablesDbContext bdPrestamoCables)
        {
            _bdPrestamoCables = bdPrestamoCables;
        }

        public int CreateUsuario(Usuario DatosUsuario)
        {
            _bdPrestamoCables.Usuarios.Add(DatosUsuario);
            _bdPrestamoCables.SaveChanges();

            return DatosUsuario.ID_Usuario;

            throw new NotImplementedException();
        }

        //public ICollection<int> CreateUsuario(ICollection<Usuario> DatosUsuario)
        //{
        //    throw new NotImplementedException();
        //}

        public bool DeleteUsuario(int IdUsuario)
        {
            var item = _bdPrestamoCables.Usuarios.Where(x => x.ID_Usuario == IdUsuario).FirstOrDefault();
            _bdPrestamoCables.Usuarios.Remove(item);
            _bdPrestamoCables.SaveChanges();
            return true;

            throw new NotImplementedException();
        }

        public bool DeleteUsuario(ICollection<int> IdUsuario)
        {
            var ListItem = _bdPrestamoCables.Usuarios.Where(x => IdUsuario.Contains(x.ID_Usuario)).ToList();
            _bdPrestamoCables.Usuarios.RemoveRange(ListItem);
            _bdPrestamoCables.SaveChanges();

            throw new NotImplementedException();
        }

        public bool ExistsUsuario(string Nombre, string Apellido)
        {
            return _bdPrestamoCables.Usuarios.Any(x => x.Nombre.ToUpper() + ' ' + x.Apellido.ToUpper() == Nombre.ToUpper() + ' ' + Apellido.ToUpper());
            
            throw new NotImplementedException();
        }

        public bool ExistsUsuario(int IdUsuario)
        {
            return _bdPrestamoCables.Usuarios.Any(x => x.ID_Usuario == IdUsuario);

            throw new NotImplementedException();
        }

        public ICollection<Usuario> GetUsuario()
        {
            return _bdPrestamoCables.Usuarios.ToList();

            throw new NotImplementedException();
        }

        public Usuario GetUsuario(int IdUsuario)
        {
            return _bdPrestamoCables.Usuarios.Where(x => x.ID_Usuario == IdUsuario).FirstOrDefault();

            throw new NotImplementedException();
        }

        public Usuario UpdateUsuario(Usuario DatosUsuario)
        {
            var Item = _bdPrestamoCables.Usuarios.Where(x => x.ID_Usuario == DatosUsuario.ID_Usuario).FirstOrDefault();

            Item.Matricula = DatosUsuario.Matricula;
            Item.Nombre = DatosUsuario.Nombre;
            Item.Apellido = DatosUsuario.Apellido;
            Item.Email = DatosUsuario.Email;
            Item.Password = DatosUsuario.Password;
            Item.TipoCuenta = DatosUsuario.TipoCuenta;
            Item.Activo = DatosUsuario.Activo;

            _bdPrestamoCables.SaveChanges();

            return Item;

            throw new NotImplementedException();
        }

        public ICollection<Usuario> UpdateUsuario(ICollection<Usuario> DatosUsuario)
        {
            var ListItem = _bdPrestamoCables.Usuarios.Where(x => DatosUsuario.Select(i => i.ID_Usuario).ToList().Contains(x.ID_Usuario)).ToList();

            // ForEach de Entity Framework
            ListItem.ForEach(u =>
            {
                u.Matricula= DatosUsuario.Where(i => i.ID_Usuario == u.ID_Usuario).Select(n => n.Matricula).FirstOrDefault();
                u.Nombre = DatosUsuario.Where(i => i.ID_Usuario == u.ID_Usuario).Select(n => n.Nombre).FirstOrDefault();
                u.Apellido = DatosUsuario.Where(i => i.ID_Usuario == u.ID_Usuario).Select(n => n.Apellido).FirstOrDefault();
                u.Email = DatosUsuario.Where(i => i.ID_Usuario == u.ID_Usuario).Select(n => n.Email).FirstOrDefault();
                u.Password = DatosUsuario.Where(i => i.ID_Usuario == u.ID_Usuario).Select(n => n.Password).FirstOrDefault();
                u.TipoCuenta = DatosUsuario.Where(i => i.ID_Usuario == u.ID_Usuario).Select(n => n.TipoCuenta).FirstOrDefault();
                u.Activo = DatosUsuario.Where(i => i.ID_Usuario == u.ID_Usuario).Select(n => n.Activo).FirstOrDefault();
            });

            _bdPrestamoCables.SaveChanges();

            return _bdPrestamoCables.Usuarios.Where(x => DatosUsuario.Select(i => i.ID_Usuario).ToList().Contains(x.ID_Usuario)).ToList();

            throw new NotImplementedException();
        }
    }
}
