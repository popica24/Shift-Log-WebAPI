using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShiftLogger.Models;

namespace ShiftLogger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftModelsController : ControllerBase
    {
        private readonly ShiftContext _context; 

        public ShiftModelsController(ShiftContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<ShiftModel>> Get()=> 
            await _context.Shifts.ToListAsync();

        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var shift = await _context.Shifts.FindAsync(id);
            return shift == null ? NotFound() : Ok(shift);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(ShiftModel shiftModel)
        {
            await _context.AddAsync(shiftModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = shiftModel.ShiftModelId }, shiftModel);
                
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, ShiftModel shiftModel)
        {
            if (id != shiftModel.ShiftModelId) return BadRequest();

            _context.Entry(shiftModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var shiftToDelete = await _context.Shifts.FindAsync(id);
            if (shiftToDelete == null) return NotFound();

            _context.Shifts.Remove(shiftToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
           
    }
}
