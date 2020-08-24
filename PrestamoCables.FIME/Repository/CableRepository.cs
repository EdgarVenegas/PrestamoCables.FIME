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
    public class CableRepository : ICableRepository
    {
        private readonly PrestamoCablesDbContext _bdPrestamoCables;

        public CableRepository(PrestamoCablesDbContext bdPrestamoCables)
        {
            _bdPrestamoCables = bdPrestamoCables;
        }

        public int CreateCable(Cable DatosCable)
        {
            _bdPrestamoCables.Cables.Add(DatosCable);
            _bdPrestamoCables.SaveChanges();

            return DatosCable.ID_Cable;

            throw new NotImplementedException();
        }

        //public ICollection<int> CreateCable(ICollection<Cable> DatosCable)
        //{
        //    throw new NotImplementedException();
        //}

        public bool DeleteCable(int IdCable)
        {
            var item = _bdPrestamoCables.Cables.Where(x => x.ID_Cable == IdCable).FirstOrDefault();
            _bdPrestamoCables.Cables.Remove(item);
            _bdPrestamoCables.SaveChanges();
            return true;

            throw new NotImplementedException();
        }

        public bool DeleteCable(ICollection<int> IdCable)
        {
            var ListItem = _bdPrestamoCables.Cables.Where(x => IdCable.Contains(x.ID_Cable)).ToList();
            _bdPrestamoCables.Cables.RemoveRange(ListItem);
            _bdPrestamoCables.SaveChanges();

            throw new NotImplementedException();
        }

        public bool ExistsCable(string TipoCable)
        {
            return _bdPrestamoCables.Cables.Any(x => x.TipoCable.ToUpper() == TipoCable.ToUpper());

            throw new NotImplementedException();
        }

        public bool ExistsCable(int IdCable)
        {
            return _bdPrestamoCables.Cables.Any(x => x.ID_Cable == IdCable);
            throw new NotImplementedException();
        }

        public ICollection<Cable> GetCable()
        {
            return _bdPrestamoCables.Cables.ToList();

            throw new NotImplementedException();
        }

        public Cable GetCable(int IdCable)
        {
            return _bdPrestamoCables.Cables.Where(x => x.ID_Cable == IdCable).FirstOrDefault();

            throw new NotImplementedException();
        }

        public Cable UpdateCable(Cable DatosCable)
        {
            var Item = _bdPrestamoCables.Cables.Where(x => x.ID_Cable == DatosCable.ID_Cable).FirstOrDefault();

            Item.TipoCable = DatosCable.TipoCable;
            Item.Longitud = DatosCable.Longitud;
            Item.Estatus = DatosCable.Estatus;

            _bdPrestamoCables.SaveChanges();

            return Item;

            throw new NotImplementedException();
        }

        public ICollection<Cable> UpdateCable(ICollection<Cable> DatosCable)
        {
            var ListItem = _bdPrestamoCables.Cables.Where(x => DatosCable.Select(i => i.ID_Cable).ToList().Contains(x.ID_Cable)).ToList();

            // ForEach de Entity Framework
            ListItem.ForEach(u =>
            {
                u.TipoCable= DatosCable.Where(i => i.ID_Cable == u.ID_Cable).Select(n => n.TipoCable).FirstOrDefault();
                u.Longitud = DatosCable.Where(i => i.ID_Cable == u.ID_Cable).Select(n => n.Longitud).FirstOrDefault();
                u.Estatus = DatosCable.Where(i => i.ID_Cable == u.ID_Cable).Select(n => n.Estatus).FirstOrDefault();
            });

            _bdPrestamoCables.SaveChanges();

            return _bdPrestamoCables.Cables.Where(x => DatosCable.Select(i => i.ID_Cable).ToList().Contains(x.ID_Cable)).ToList();
            throw new NotImplementedException();
        }
    }
}
