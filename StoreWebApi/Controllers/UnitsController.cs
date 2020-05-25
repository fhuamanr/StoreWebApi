using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreWebApi.Models;
using StoreWebApi.DTOs;
using AutoMapper;

namespace StoreWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly JOOYCARContext _context;

        public UnitsController(JOOYCARContext context)
        {
            _context = context;
        }

        // GET: api/Units
        [HttpGet]
        public IEnumerable<UnitsDTO> GetUnits()
        {
            return Mapper.Map<IEnumerable<UnitsDTO>>(_context.Units);
        }

        // GET: api/Units/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUnits([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var units = await _context.Units.FindAsync(id);

            if (units == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<UnitsDTO>(units));
        }

        // PUT: api/Units/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnits([FromRoute] int id, [FromBody] UnitsDTO units)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != units.Id)
            {
                return BadRequest();
            }

            _context.Entry(Mapper.Map<Units>(units)).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitsExists(id))
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

        // POST: api/Units
        [HttpPost]
        public async Task<IActionResult> PostUnits([FromBody] UnitsDTO units)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var map = Mapper.Map<Units>(units);

            _context.Units.Add(map);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "GetUnits", new { id = map.Id }, units);
        }

        // DELETE: api/Units/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnits([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var units = await _context.Units.FindAsync(id);
            if (units == null)
            {
                return NotFound();
            }

            _context.Units.Remove(units);
            await _context.SaveChangesAsync();

            return Ok(Mapper.Map<UnitsDTO>(units));
        }

        private bool UnitsExists(int id)
        {
            return _context.Units.Any(e => e.Id == id);
        }
    }
}