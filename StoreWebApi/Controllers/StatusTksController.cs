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
    [Route("api/[controller]")]
    [ApiController]
    public class StatusTksController : ControllerBase
    {
        private readonly JOOYCARContext _context;

        public StatusTksController(JOOYCARContext context)
        {
            _context = context;
        }

        // GET: api/StatusTks
        [HttpGet]
        public IEnumerable<StatusDTO> GetStatusTk()
        {
            return Mapper.Map<IEnumerable<StatusDTO>>(_context.StatusTk);
        }

        // GET: api/StatusTks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStatusTk([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var statusTk = await _context.StatusTk.FindAsync(id);

            if (statusTk == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<StatusDTO>(statusTk));
        }

        // PUT: api/StatusTks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusTk([FromRoute] string id, [FromBody] StatusDTO statusTk)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statusTk.MessageId)
            {
                return BadRequest();
            }

            _context.Entry(Mapper.Map<StatusTk>(statusTk)).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusTkExists(id))
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

        // POST: api/StatusTks
        [HttpPost]
        public async Task<IActionResult> PostStatusTk([FromBody] StatusDTO statusTk)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var map = Mapper.Map<StatusTk>(statusTk);

            _context.StatusTk.Add(map);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StatusTkExists(map.MessageId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStatusTk", new { id = map.MessageId }, statusTk);
        }

        // DELETE: api/StatusTks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusTk([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var statusTk = await _context.StatusTk.FindAsync(id);
            if (statusTk == null)
            {
                return NotFound();
            }

            _context.StatusTk.Remove(statusTk);
            await _context.SaveChangesAsync();

            return Ok(Mapper.Map<StatusDTO>(statusTk));
        }

        private bool StatusTkExists(string id)
        {
            return _context.StatusTk.Any(e => e.MessageId == id);
        }
    }
}