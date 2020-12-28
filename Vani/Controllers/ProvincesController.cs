using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vani.Data;
using Vani.Dtos;
using Vani.Helpers;
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
        public async Task<IEnumerable<ProvinceDTO>> Get([FromHeader] PaginateDTO paginateDTO)
        {
            //    var queryable = _context.Stores.AsQueryable();
            //    await HttpContext.InsertPaginationParameters(queryable, paginateDTO.RecordsPerPage);

            //    var store = await queryable.OrderBy(x => x.Name).Paginate(paginateDTO).ToListAsync();
            //    var storeDTO = mapper.Map<List<StoreDTO>>(store);
            //    return storeDTO;

            var queryable = context.Provinces.AsQueryable();
            await HttpContext.InsertPaginationParameters(queryable, paginateDTO.RecordsPerPage);

            var province = await queryable.OrderBy(x => x.Name).Paginate(paginateDTO).Include(x => x.Stores).ToListAsync();
            var provinceDTO = mapper.Map<List<ProvinceDTO>>(province);

            return provinceDTO;
        }

        [HttpGet("{id:int}", Name = "GetProvince")]
        public async Task<ActionResult<ProvinceDTO>> Get(int id)
        {
            if (!Exists(id)) { return NotFound(); }
            var province = await context.Provinces.Include(x => x.Stores).FirstOrDefaultAsync(x => x.Id == id);
            var provinceDTO = mapper.Map<ProvinceDTO>(province);
            return provinceDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProvinceCreationDTO provinceCreation)
        {
            var province = mapper.Map<Province>(provinceCreation);
            context.Provinces.Add(province);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetProvince", new { id = province.Id }, province);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] ProvinceCreationDTO provinceCreation, int id)
        {
            var province = await context.Provinces.FirstOrDefaultAsync(x => x.Id == id);
            if(province == null) { return NotFound(); }
            province = mapper.Map(provinceCreation, province);
            province.Id = id;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!Exists(id))
            { return BadRequest(); }
            var province = await context.Provinces.FirstOrDefaultAsync(x => x.Id == id);
            context.Provinces.Remove(province);
            return NoContent();
        }

        protected bool Exists(int id) => context.Provinces.Any(x => x.Id == id);
    }
}
