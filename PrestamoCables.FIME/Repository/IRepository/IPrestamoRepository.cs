using PrestamoCables.FIME.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrestamoCables.FIME.Repository.IRepository
{
    // Se define la interfaz como pública. 
    public interface IPrestamoRepository
    {
        //Retorna todos los Prestamos.
        ICollection<Prestamo> GetPrestamo();

        //Retorna un solo Prestamo. 
        Prestamo GetPrestamo(int IdPrestamo);

        //Booleano que dice si existe un Prestamo según ID.
        bool ExistsPrestamo(int IdPrestamo);

        //Devuelve el ID que se le ha asignado al Prestamo. 
        int CreatePrestamo(Prestamo DatosPrestamo);

        //Devuelve el ID que se le ha asignado a varios Prestamos. 
        //ICollection<int> CreatePrestamo(ICollection<Prestamo> DatosPrestamo);

        //Elimina un Prestamo por medio de un ID.
        bool DeletePrestamo(int IdPrestamo);

        //Elimina una Lista de Prestamos.
        bool DeletePrestamo(ICollection<int> IdPrestamo);

        //Nos muestra el resultado después de una Actualización de Prestamo. 
        Prestamo UpdatePrestamo(Prestamo DatosPrestamo);

        //Nos muestra el resultado después de una Actualización de varios Prestamos. 
        ICollection<Prestamo> UpdatePrestamo(ICollection<Prestamo> DatosPrestamo);
    }
}
