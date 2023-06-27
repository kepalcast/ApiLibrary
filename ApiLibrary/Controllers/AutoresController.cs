using ApiLibrary.Models;
using ApiLibrary.Models.Dto;
using ApiLibrary.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ApiLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly IAutoresRepository _autoresRepository;
        private readonly ILogger<AutoresController> _logger;
        private readonly IMapper _mapper;

        public AutoresController(ILogger<AutoresController> logger, IAutoresRepository autoresRepository, IMapper mapper)
        {
            _logger = logger;
            _autoresRepository = autoresRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AutoresDto>>> GetAutores()
        {
            _logger.LogInformation("Obtener los Autores");
            var autoresList = await _autoresRepository.GetAll();
            return Ok(_mapper.Map<IEnumerable<AutoresDto>>(autoresList));
        }

        [HttpGet("{id:int}", Name = "GetAutores")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AutoresDto>> GetAutores(int id)
        {
            if (id == 0)
            {
                _logger.LogError($"Error al traer al Autor con Id {id}");
                return BadRequest();
            }
            var autor = await _autoresRepository.Get(s => s.IdAutor == id);

            if (autor == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AutoresDto>(autor));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AutoresDto>> AddClient([FromBody] AutoresCreateDto autoresCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _autoresRepository.Get(s => s.AutorName.ToLower() == autoresCreateDto.AutorName.ToLower()) != null)
            {
                ModelState.AddModelError("NombreExiste", "¡El autor con ese Nombre ya existe!");
                return BadRequest(ModelState);
            }

            if (autoresCreateDto == null)
            {
                return BadRequest(autoresCreateDto);
            }

            Autores modelo = _mapper.Map<Autores>(autoresCreateDto);

            await _autoresRepository.Add(modelo);

            return CreatedAtRoute("GetAutores", new { id = modelo.IdAutor }, modelo);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DeleteClien(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var client = await _autoresRepository.Get(s => s.IdAutor == id);

            if (client == null)
            {
                return NotFound();
            }

            _autoresRepository.Remove(client);

            return NoContent();
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAutores(int id, [FromBody] AutoresUpdateDto autoresUpdateDto)
        {
            if (autoresUpdateDto == null || id != autoresUpdateDto.IdAutor)
            {
                return BadRequest();
            }

            Autores modelo = _mapper.Map<Autores>(autoresUpdateDto);
            _autoresRepository.Update(modelo);
            return NoContent();
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialAutores(int id, JsonPatchDocument<AutoresUpdateDto> patchDto)
        {
            if (patchDto == null || id == 0)
            {
                return BadRequest();
            }

            var client = await _autoresRepository.Get(s => s.IdAutor == id, tracked: false);

            AutoresUpdateDto autoresUpdateDto = _mapper.Map<AutoresUpdateDto>(client);

            if (client == null) return BadRequest();

            patchDto.ApplyTo(autoresUpdateDto, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Autores modelo = _mapper.Map<Autores>(autoresUpdateDto);

            _autoresRepository.Update(modelo);

            return NoContent();

        }
    }
}
