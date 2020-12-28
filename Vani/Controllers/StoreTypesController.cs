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
        public async Task<ActionResult<List<StoreType>>> Get([FromHeader] PaginateDTO paginateDTO)
        {
            var queryable = context.StoreTypes.AsQueryable();
            await HttpContext.InsertPaginationParameters(queryable, paginateDTO.RecordsPerPage);

            var storeTypes = await queryable.OrderBy(x => x.Name).Paginate(paginateDTO).ToListAsync();

            return storeTypes;
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
        public async Task<ActionResult> Put([FromBody] StoreTypeCreationDTO storeTypeCreationDTO, int id)
        {
            var storeTypeDb = await context.StoreTypes.AsNoTracking().FirstOrDefaultAsync(x => x.StoreTypeId == id);
            if (storeTypeDb == null) { return NotFound(); }

            var storeType = mapper.Map<StoreType>(storeTypeCreationDTO);
            storeType.StoreTypeId = id;
            context.Entry(storeType).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exist = context.StoreTypes.Any(x => x.StoreTypeId == id);
            if (!exist) { return NotFound(); }
           
            context.Remove(new StoreType() { StoreTypeId = id});
            await context.SaveChangesAsync();

            return NoContent();
        }

    }
}
