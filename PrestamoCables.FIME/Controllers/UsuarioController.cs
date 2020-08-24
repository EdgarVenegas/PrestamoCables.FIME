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
    public class UsuarioController : ControllerBase
    {
        // Una vez creado el controlador, se procede a crear dos variables de solo lecutra.

        // - Repositorio de Funciones
        private readonly IUsuarioRepository _UsuarioRepo;
        // - AutoMapper
        private readonly IMapper _Mapper;


        public UsuarioController(IUsuarioRepository UsuarioRepository, IMapper Mapper)
        {
            _UsuarioRepo = UsuarioRepository;
            _Mapper = Mapper;
        }


        // Petición Get
        [HttpGet]
        public ActionResult GetUsuario()
        {
            var LstUsuario = _UsuarioRepo.GetUsuario();
            var LstUsuarioLDTO = new List<UsuarioDTO>();
            foreach (var lst in LstUsuario)
            {
                LstUsuarioLDTO.Add(_Mapper.Map<UsuarioDTO>(lst));

            }

            return Ok(LstUsuarioLDTO);
        }


        [HttpGet("{IdUsuario:int}", Name = "GetUsuario")]
        public ActionResult GetUsuario(int IdUsuario)
        {
            var ItemUsuario = _UsuarioRepo.GetUsuario(IdUsuario);
            if (ItemUsuario == null)
            {
                return NotFound();
            }

            var UsuarioDTO = _Mapper.Map<UsuarioDTO>(ItemUsuario);

            return Ok(UsuarioDTO);
        }


        // Petición Post: Crear contenido
        [HttpPost]
        public IActionResult CreateUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {
                return BadRequest(ModelState);
            }
            else if (_UsuarioRepo.ExistsUsuario(usuarioDTO.Nombre, usuarioDTO.Apellido))
            {
                ModelState.AddModelError("", "El usuario " + usuarioDTO.Nombre + ' ' + usuarioDTO.Apellido + ", ya existe.");
                return StatusCode(404, ModelState);
            }

            var Usuario = _Mapper.Map<Model.Usuario>(usuarioDTO);

            int IdUsuario = _UsuarioRepo.CreateUsuario(Usuario);

            if (IdUsuario == 0)
            {
                ModelState.AddModelError("", "El usuario" + usuarioDTO.Nombre + ' ' + usuarioDTO.Apellido + ", no se pudo crear.");
                return StatusCode(500, ModelState);

            }

            return Ok(IdUsuario);
        }


        // Petición Patch: Actualizar - ID , Route
        [HttpPatch("{IdUsuario:int}", Name = "UpdateUsuario")]
        public IActionResult UpdateUsuario(int IdUsuario, [FromBody] UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {
                return BadRequest(ModelState);
            }

            var Usuario = _Mapper.Map<Model.Usuario>(usuarioDTO);

            var item = _UsuarioRepo.UpdateUsuario(Usuario);

            if (item == null)
            {
                ModelState.AddModelError("", "El usuario no se pudo actualizar");
                return StatusCode(500, ModelState);
            }

            return Ok(Usuario);

        }


        // Petición Delete: Eliminar - ID , Route
        [HttpDelete("{IdUsuario:int}", Name = "DeleteUsuario")]
        public IActionResult DeleteUsuario(int IdUsuario)
        {
            if (!_UsuarioRepo.ExistsUsuario(IdUsuario))
            {
                return NotFound();
            }

            if (!_UsuarioRepo.DeleteUsuario(IdUsuario))
            {
                ModelState.AddModelError("", "El usuario no se pudo borrar");
                return StatusCode(500, ModelState);

            }

            return NoContent();
        }
    }
}
