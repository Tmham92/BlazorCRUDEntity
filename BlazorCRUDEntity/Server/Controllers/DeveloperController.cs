using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorCRUDEntity.Server.Data;
using BlazorCRUDEntity.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUDEntity.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public DeveloperController(ApplicationDBContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var devs = await _context.Developers.ToListAsync();
            return Ok(devs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var dev = await _context.Developers.FirstOrDefaultAsync(d => d.Id == id);
            return Ok(dev);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Developer dev)
        {
            _context.Add(dev);
            await _context.SaveChangesAsync();
            return Ok(dev.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Developer dev)
        {
            _context.Entry(dev).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dev = new Developer { Id = id };
            _context.Remove(dev);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
