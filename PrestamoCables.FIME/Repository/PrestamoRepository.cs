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
    public class PrestamoRepository : IPrestamoRepository
    {
        private readonly PrestamoCablesDbContext _bdPrestamoCables;

        public PrestamoRepository(PrestamoCablesDbContext bdPrestamoCables)
        {
            _bdPrestamoCables = bdPrestamoCables;
        }

        public int CreatePrestamo(Prestamo DatosPrestamo)
        {
            _bdPrestamoCables.Prestamos.Add(DatosPrestamo);
            _bdPrestamoCables.SaveChanges();

            return DatosPrestamo.ID_Prestamo;

            throw new NotImplementedException();
        }

        //public ICollection<int> CreatePrestamo(ICollection<Prestamo> DatosPrestamo)
        //{
        //    throw new NotImplementedException();
        //}

        public bool DeletePrestamo(int IdPrestamo)
        {
            var item = _bdPrestamoCables.Prestamos.Where(x => x.ID_Prestamo == IdPrestamo).FirstOrDefault();
            _bdPrestamoCables.Prestamos.Remove(item);
            _bdPrestamoCables.SaveChanges();
            return true;

            throw new NotImplementedException();
        }

        public bool DeletePrestamo(ICollection<int> IdPrestamo)
        {
            var ListItem = _bdPrestamoCables.Prestamos.Where(x => IdPrestamo.Contains(x.ID_Prestamo)).ToList();
            _bdPrestamoCables.Prestamos.RemoveRange(ListItem);
            _bdPrestamoCables.SaveChanges();
            throw new NotImplementedException();
        }

        public bool ExistsPrestamo(int IdPrestamo)
        {
            return _bdPrestamoCables.Prestamos.Any(x => x.ID_Prestamo == IdPrestamo);
            throw new NotImplementedException();
        }

        public ICollection<Prestamo> GetPrestamo()
        {
            return _bdPrestamoCables.Prestamos.ToList();

            throw new NotImplementedException();
        }

        public Prestamo GetPrestamo(int IdPrestamo)
        {
            return _bdPrestamoCables.Prestamos.Where(x => x.ID_Prestamo == IdPrestamo).FirstOrDefault();

            throw new NotImplementedException();
        }

        public Prestamo UpdatePrestamo(Prestamo DatosPrestamo)
        {
            var Item = _bdPrestamoCables.Prestamos.Where(x => x.ID_Prestamo == DatosPrestamo.ID_Prestamo).FirstOrDefault();

            Item.ID_Usuario = DatosPrestamo.ID_Usuario;
            Item.ID_Cable = DatosPrestamo.ID_Cable;
            Item.FechaCreo = DatosPrestamo.FechaCreo;
            Item.Salon = DatosPrestamo.Salon;
            Item.Hora = DatosPrestamo.Hora;
            Item.Materia = DatosPrestamo.Materia;
            Item.Estado = DatosPrestamo.Estado;

            _bdPrestamoCables.SaveChanges();

            return Item;

            throw new NotImplementedException();
        }

        public ICollection<Prestamo> UpdatePrestamo(ICollection<Prestamo> DatosPrestamo)
        {
            var ListItem = _bdPrestamoCables.Prestamos.Where(x => DatosPrestamo.Select(i => i.ID_Prestamo).ToList().Contains(x.ID_Prestamo)).ToList();

            // ForEach de Entity Framework
            ListItem.ForEach(u =>
            {
                u.ID_Usuario = DatosPrestamo.Where(i => i.ID_Prestamo == u.ID_Prestamo).Select(n => n.ID_Usuario).FirstOrDefault();
                u.ID_Cable= DatosPrestamo.Where(i => i.ID_Prestamo == u.ID_Prestamo).Select(n => n.ID_Cable).FirstOrDefault();
                u.FechaCreo = DatosPrestamo.Where(i => i.ID_Prestamo == u.ID_Prestamo).Select(n => n.FechaCreo).FirstOrDefault();
                u.Salon = DatosPrestamo.Where(i => i.ID_Prestamo == u.ID_Prestamo).Select(n => n.Salon).FirstOrDefault();
                u.Hora = DatosPrestamo.Where(i => i.ID_Prestamo == u.ID_Prestamo).Select(n => n.Hora).FirstOrDefault();
                u.Materia= DatosPrestamo.Where(i => i.ID_Prestamo == u.ID_Prestamo).Select(n => n.Materia).FirstOrDefault();
                u.Estado = DatosPrestamo.Where(i => i.ID_Prestamo == u.ID_Prestamo).Select(n => n.Estado).FirstOrDefault();
            });

            _bdPrestamoCables.SaveChanges();

            return _bdPrestamoCables.Prestamos.Where(x => DatosPrestamo.Select(i => i.ID_Prestamo).ToList().Contains(x.ID_Prestamo)).ToList();

            throw new NotImplementedException();
        }
    }
}
