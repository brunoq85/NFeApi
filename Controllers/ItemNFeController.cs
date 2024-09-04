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
    public class ItemNFeController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ItemNFeController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Produces("application/xml")]
        public async Task<ActionResult<IEnumerable<ItemNFeDto>>> GetItens()
        {
            var itemNfe = await _context.ItensNFe.ToListAsync();

            return Ok(_mapper.Map<IEnumerable<ItemNFeDto>>(itemNfe));
        }

        [HttpGet("{id}")]
        [Produces("application/xml")]
        public async Task<ActionResult<ItemNFeDto>> GetItem(int id)
        {
            var itemNFe = await _context.ItensNFe.FindAsync(id);

            if (itemNFe == null)
            {
                return NotFound();
            }

            return _mapper.Map<ItemNFeDto>(itemNFe);
        }

        [HttpPost]
        [Produces("application/xml")]
        public async Task<ActionResult<ItemNFeDto>> CreateItem(ItemNFeDto itemNFeDto)
        {
            var itemNFe = _mapper.Map<ItemNFe>(itemNFeDto);
            _context.ItensNFe.Add(itemNFe);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetItem), new { id = itemNFe.Id }, itemNFe);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, ItemNFeDto itemNFeDto)
        {
            if (id != itemNFeDto.Id)
            {
                return BadRequest();
            }

            var itemNFe = _mapper.Map<ItemNFe>(itemNFeDto);
            _context.Entry(itemNFe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
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
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _context.ItensNFe.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.ItensNFe.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemExists(int id)
        {
            return _context.ItensNFe.Any(e => e.Id == id);
        }
    }
}
