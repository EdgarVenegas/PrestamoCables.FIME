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
    public class PrestamoController : ControllerBase
    {
        // Una vez creado el controlador, se procede a crear dos variables de solo lecutra.

        // - Repositorio de Funciones
        private readonly IPrestamoRepository _PrestamoRepo;
        // - AutoMapper
        private readonly IMapper _Mapper;


        public PrestamoController(IPrestamoRepository PrestamoRepository, IMapper Mapper)
        {
            _PrestamoRepo = PrestamoRepository;
            _Mapper = Mapper;
        }


        // Petición Get
        [HttpGet]
        public ActionResult GetPrestamo()
        {
            var LstPrestamo = _PrestamoRepo.GetPrestamo();
            var LstPrestamoLDTO = new List<PrestamoDTO>();
            foreach (var lst in LstPrestamo)
            {
                LstPrestamoLDTO.Add(_Mapper.Map<PrestamoDTO>(lst));

            }

            return Ok(LstPrestamoLDTO);
        }


        [HttpGet("{IdPrestamo:int}", Name = "GetPrestamo")]
        public ActionResult GetPrestamo(int IdPrestamo)
        {
            var ItemPrestamo = _PrestamoRepo.GetPrestamo(IdPrestamo);
            if (ItemPrestamo == null)
            {
                return NotFound();
            }

            var PrestamoDTO = _Mapper.Map<PrestamoDTO>(ItemPrestamo);

            return Ok(PrestamoDTO);
        }


        // Petición Post: Crear contenido
        [HttpPost]
        public IActionResult CreatePrestamo([FromBody] PrestamoDTO prestamoDTO)
        {
            if (prestamoDTO == null)
            {
                return BadRequest(ModelState);
            }
            else if (_PrestamoRepo.ExistsPrestamo(prestamoDTO.ID_Prestamo))
            {
                ModelState.AddModelError("", "El prestamo " + prestamoDTO.ID_Prestamo + ", ya existe.");
                return StatusCode(404, ModelState);
            }

            var Prestamo = _Mapper.Map<Model.Prestamo>(prestamoDTO);

            int IdPrestamo = _PrestamoRepo.CreatePrestamo(Prestamo);

            if (IdPrestamo == 0)
            {
                ModelState.AddModelError("", "El prestamo" + prestamoDTO.ID_Prestamo + ", no se pudo crear.");
                return StatusCode(500, ModelState);

            }

            return Ok(IdPrestamo);
        }


        // Petición Patch: Actualizar - ID , Route
        [HttpPatch("{IdPrestamo:int}", Name = "UpdatePrestamo")]
        public IActionResult UpdatePrestamo(int IdPrestamo, [FromBody] PrestamoDTO prestamoDTO)
        {
            if (prestamoDTO == null)
            {
                return BadRequest(ModelState);
            }

            var Prestamo = _Mapper.Map<Model.Prestamo>(prestamoDTO);

            var item = _PrestamoRepo.UpdatePrestamo(Prestamo);

            if (item == null)
            {
                ModelState.AddModelError("", "El prestamo no se pudo actualizar");
                return StatusCode(500, ModelState);
            }

            return Ok(Prestamo);

        }


        // Petición Delete: Eliminar - ID , Route
        [HttpDelete("{IdPrestamo:int}", Name = "DeletePrestamo")]
        public IActionResult DeletePrestamo(int IdPrestamo)
        {
            if (!_PrestamoRepo.ExistsPrestamo(IdPrestamo))
            {
                return NotFound();
            }

            if (!_PrestamoRepo.DeletePrestamo(IdPrestamo))
            {
                ModelState.AddModelError("", "El prestamo no se pudo borrar");
                return StatusCode(500, ModelState);

            }

            return NoContent();
        }
    }
}
