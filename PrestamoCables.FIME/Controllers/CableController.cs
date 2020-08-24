using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrestamoCables.FIME.DTO;
using PrestamoCables.FIME.Repository.IRepository;

namespace PrestamoCables.FIME.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CableController : ControllerBase
    {
        // Una vez creado el controlador, se procede a crear dos variables de solo lecutra.

        // - Repositorio de Funciones
        private readonly ICableRepository _CableRepo;
        // - AutoMapper
        private readonly IMapper _Mapper;


        public CableController(ICableRepository CableRepository, IMapper Mapper)
        {
            _CableRepo = CableRepository;
            _Mapper = Mapper;
        }


        // Petición Get
        [HttpGet]
        public ActionResult GetCable()
        {
            var LstCable = _CableRepo.GetCable();
            var LstCableLDTO = new List<CableDTO>();
            foreach (var lst in LstCable)
            {
                LstCableLDTO.Add(_Mapper.Map<CableDTO>(lst));

            }

            return Ok(LstCableLDTO);
        }


        [HttpGet("{IdCable:int}", Name = "GetCable")]
        public ActionResult GetCable(int IdCable)
        {
            var ItemCable = _CableRepo.GetCable(IdCable);
            if (ItemCable == null)
            {
                return NotFound();
            }

            var CableDTO = _Mapper.Map<CableDTO>(ItemCable);

            return Ok(CableDTO);
        }


        // Petición Post: Crear contenido
        [HttpPost]
        public IActionResult CreateCable([FromBody] CableDTO cableDTO)
        {
            if (cableDTO == null)
            {
                return BadRequest(ModelState);
            }
            else if (_CableRepo.ExistsCable(cableDTO.TipoCable))
            {
                ModelState.AddModelError("", "El cable " + cableDTO.TipoCable + ", ya existe.");
                return StatusCode(404, ModelState);
            }

            var Cable = _Mapper.Map<Model.Cable>(cableDTO);

            int IdCable = _CableRepo.CreateCable(Cable);

            if (IdCable == 0)
            {
                ModelState.AddModelError("", "El cable" + cableDTO.TipoCable + ", no se pudo crear.");
                return StatusCode(500, ModelState);

            }

            return Ok(IdCable);
        }


        // Petición Patch: Actualizar - ID , Route
        [HttpPatch("{IdCable:int}", Name = "UpdateCable")]
        public IActionResult UpdateCable(int IdCable, [FromBody] CableDTO cableDTO)
        {
            if (cableDTO == null)
            {
                return BadRequest(ModelState);
            }

            var Cable = _Mapper.Map<Model.Cable>(cableDTO);

            var item = _CableRepo.UpdateCable(Cable);

            if (item == null)
            {
                ModelState.AddModelError("", "El cable no se pudo actualizar");
                return StatusCode(500, ModelState);
            }

            return Ok(Cable);

        }


        // Petición Delete: Eliminar - ID , Route
        [HttpDelete("{IdCable:int}", Name = "DeleteCable")]
        public IActionResult DeleteCable(int IdCable)
        {
            if (!_CableRepo.ExistsCable(IdCable))
            {
                return NotFound();
            }

            if (!_CableRepo.DeleteCable(IdCable))
            {
                ModelState.AddModelError("", "El cable no se pudo borrar");
                return StatusCode(500, ModelState);

            }

            return NoContent();
        }
    }
}
