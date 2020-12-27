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
    public class ProvincesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProvincesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<Province>> Get()
        {
            return await context.Provinces.ToListAsync();
        }

        [HttpGet("{id:int}", Name = "GetProvince")]
        public async Task<ActionResult<Province>> Get(int id)
        {
            if (!Exits(id)) { return NotFound(); }
            var province = await context.Provinces.FirstOrDefaultAsync(x => x.Id == id);
            return province;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Province province)
        {
            context.Provinces.Add(province);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetProvince", new { id = province.Id }, province);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] Province province, int id)
        {
            if(id != province.Id) { return BadRequest(); }
            context.Entry(province).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!Exits(id)) { return BadRequest(); }
            var province = await context.Provinces.FirstOrDefaultAsync(x => x.Id == id);
            context.Provinces.Remove(province);
            return NoContent();
        }

        public bool Exits(int id)
        {
            return context.Provinces.Any(x => x.Id == id);
        }
    }
}
