using PrestamoCables.FIME.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrestamoCables.FIME.Repository.IRepository
{
    // Se define la interfaz como pública. 
    public interface ICableRepository
    {
        //Retorna todos los Cables.
        ICollection<Cable> GetCable();

        //Retorna un solo Cable. 
        Cable GetCable(int IdCable);

        //Booleano que dice si existe un Cable. 
        bool ExistsCable(string TipoCable);

        //Booleano que dice si existe un Cable según ID.
        bool ExistsCable(int IdCable);

        //Devuelve el ID que se le ha asignado al Cable. 
        int CreateCable(Cable DatosCable);

        //Devuelve el ID que se le ha asignado a varios Cables. 
        //ICollection<int> CreateCable(ICollection<Cable> DatosCable);

        //Elimina un Cable por medio de un ID.
        bool DeleteCable(int IdCable);

        //Elimina una Lista de Cables.
        bool DeleteCable(ICollection<int> IdCable);

        //Nos muestra el resultado después de una Actualización de Cable. 
        Cable UpdateCable(Cable DatosCable);

        //Nos muestra el resultado después de una Actualización de varios Cables. 
        ICollection<Cable> UpdateCable(ICollection<Cable> DatosCable);
    }
}
