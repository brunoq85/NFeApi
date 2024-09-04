using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NFeApi.Context;
using NFeApi.Dtos;
using NFeApi.Entities;

namespace NFeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmitenteController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public EmitenteController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmitenteDto>>> GetEmitentes()
        {
            var emitente = await _context.Emitentes.ToListAsync();

            return Ok(_mapper.Map<IEnumerable<EmitenteDto>>(emitente));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Emitente>> GetEmitente(int id)
        {
            var emitente = await _context.Emitentes.FindAsync(id);

            if (emitente == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EmitenteDto>(emitente));
        }

        [HttpPost]
        public async Task<ActionResult<EmitenteDto>> CreateEmitente(EmitenteDto emitenteDto)
        {
            var emitente = _mapper.Map<Emitente>(emitenteDto);
            _context.Emitentes.Add(emitente);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEmitente), new { id = emitente.Id }, emitente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmitente(int id, EmitenteDto emitenteDto)
        {
            if (id != emitenteDto.Id)
            {
                return BadRequest();
            }

            var emitente = _mapper.Map<Emitente>(emitenteDto);
            _context.Entry(emitente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmitenteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmitente(int id)
        {
            var emitente = await _context.Emitentes.FindAsync(id);
            if (emitente == null)
            {
                return NotFound();
            }

            _context.Emitentes.Remove(emitente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmitenteExists(int id)
        {
            return _context.Emitentes.Any(e => e.Id == id);
        }
    }
}
