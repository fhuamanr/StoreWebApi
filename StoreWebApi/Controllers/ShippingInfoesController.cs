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
    public class ShippingInfoesController : ControllerBase
    {
        private readonly JOOYCARContext _context;

        public ShippingInfoesController(JOOYCARContext context)
        {
            _context = context;
        }

        // GET: api/ShippingInfoes
        [HttpGet]
        public IEnumerable<ShippingInfoDTO> GetShippingInfo()
        {
            return Mapper.Map<IEnumerable<ShippingInfoDTO>>(_context.ShippingInfo);
        }

        // GET: api/ShippingInfoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShippingInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shippingInfo = await _context.ShippingInfo.FindAsync(id);

            if (shippingInfo == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<ShippingInfoDTO>(shippingInfo));
        }

        // PUT: api/ShippingInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShippingInfo([FromRoute] int id, [FromBody] ShippingInfoDTO shippingInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shippingInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(Mapper.Map<ShippingInfo>(shippingInfo)).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShippingInfoExists(id))
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

        // POST: api/ShippingInfoes
        [HttpPost]
        public async Task<IActionResult> PostShippingInfo([FromBody] ShippingInfo shippingInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var map = Mapper.Map<ShippingInfo>(shippingInfo);

            _context.ShippingInfo.Add(map);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShippingInfo",
                                   new { id = map.Id },
                                   shippingInfo);
        }

        // DELETE: api/ShippingInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShippingInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shippingInfo = await _context.ShippingInfo.FindAsync(id);
            if (shippingInfo == null)
            {
                return NotFound();
            }

            _context.ShippingInfo.Remove(shippingInfo);
            await _context.SaveChangesAsync();

            return Ok(Mapper.Map<ShippingInfoDTO>(shippingInfo));
        }

        private bool ShippingInfoExists(int id)
        {
            return _context.ShippingInfo.Any(e => e.Id == id);
        }
    }
}