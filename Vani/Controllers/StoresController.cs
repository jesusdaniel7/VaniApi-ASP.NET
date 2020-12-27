using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vani.Data;
using Vani.Dtos;
using Vani.Models;

namespace Vani.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;

        public StoresController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Store>>> Get()
        {
            return await _context.Stores.ToListAsync();
        }

        [HttpGet("{id}", Name = "GetStore")]
        public async Task<ActionResult<Store>> Get(int id)
        {
            var store = await _context.Stores.Include(x => x.Province).Include(x => x.StoreType).FirstOrDefaultAsync(x => x.ProvinceId == id);

            if (store == null)
            {
                return NotFound();
            }

            return store;
        }

        [HttpPost]
        public async Task<ActionResult<Store>> Post(Store store)
        {
            _context.Stores.Add(store);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetStore", new { id = store.StoreId }, store);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Store store)
        {
            if (id != store.StoreId)
            {
                return BadRequest();
            }

            _context.Entry(store).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreExists(id))
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
        public async Task<IActionResult> Delete(int id)
        {
            var store = await _context.Stores.FindAsync(id);
            if (store == null)
            {
                return NotFound();
            }

            _context.Stores.Remove(store);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StoreExists(int id)
        {
            return _context.Stores.Any(e => e.StoreId == id);
        }
    }
}
