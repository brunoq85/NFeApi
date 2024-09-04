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
    public class NFeController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public NFeController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NFeDto>>> GetNFes()
        {
            var nfes = await _context.NFes.Include(n => n.Emitente).Include(n => n.ItensNFe).ToListAsync();

            return Ok(_mapper.Map<IEnumerable<NFeDto>>(nfes));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NFeDto>> GetNFe(int id)
        {
            var nfe = await _context.NFes.Include(n => n.Emitente).Include(n => n.ItensNFe).FirstOrDefaultAsync(n => n.Id == id);

            if (nfe == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<NFeDto>(nfe)); ;
        }

        [HttpPost]
        public async Task<ActionResult<NFeDto>> CreateNFe(NFeDto nfeDto)
        {
            var nfe = _mapper.Map<NFe>(nfeDto);
            _context.NFes.Add(nfe);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetNFe), new { id = nfe.Id }, nfe);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNFe(int id, NFeDto nfeDto)
        {
            if (id != nfeDto.Id)
            {
                return BadRequest();
            }

            var nfe = _mapper.Map<NFe>(nfeDto);

            _context.Entry(nfe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NFeExists(id))
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
        public async Task<IActionResult> DeleteNFe(int id)
        {
            var nfe = await _context.NFes.FindAsync(id);
            if (nfe == null)
            {
                return NotFound();
            }

            _context.NFes.Remove(nfe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NFeExists(int id)
        {
            return _context.NFes.Any(e => e.Id == id);
        }
    }
}
