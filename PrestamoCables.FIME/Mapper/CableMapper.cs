using AutoMapper;
using PrestamoCables.FIME.DTO;
using PrestamoCables.FIME.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrestamoCables.FIME.Mapper
{
    public class CableMapper : Profile
    {
        public CableMapper()
        {
            CreateMap<Cable, CableDTO>().ReverseMap();
        }
    }
}
