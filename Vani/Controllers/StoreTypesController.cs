using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vani.Data;
using Vani.Models;

namespace Vani.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreTypesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public StoreTypesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreType>>> Get()
        {

            return await context.StoreTypes.ToListAsync();
        }

        [HttpGet("{id}", Name = "GetStoreType")]
        public async Task<ActionResult<StoreType>> Get(int id)
        {
            var storeType = await context.StoreTypes.FirstOrDefaultAsync(x => x.StoreTypeId == id);
            if(storeType == null) { return NotFound(); }
            return storeType;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] StoreType storeType)
        {
            context.StoreTypes.Add(storeType);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetStoreType", new { id = storeType.StoreTypeId }, storeType);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<StoreType>> Put([FromBody] StoreType storeType, int id)
        {
            if(id != storeType.StoreTypeId) { return BadRequest(); }
            context.Entry(storeType).State = EntityState.Modified;

            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!Exists(id)) { return NotFound(); }
            var storeType = await context.StoreTypes.FirstOrDefaultAsync(x => x.StoreTypeId == id);
            context.StoreTypes.Remove(storeType);
            await context.SaveChangesAsync();

            return NoContent();
        }

        public bool Exists(int id)
        {
            return context.StoreTypes.Any(x => x.StoreTypeId == id);
        }
    }
}
