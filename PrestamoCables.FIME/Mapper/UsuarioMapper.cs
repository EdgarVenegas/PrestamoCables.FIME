using AutoMapper;
using PrestamoCables.FIME.DTO;
using PrestamoCables.FIME.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrestamoCables.FIME.Mapper
{
    // Profile para insertar la librería de AutoMapper
    public class UsuarioMapper : Profile
    {
        public UsuarioMapper()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        }
    }
}
