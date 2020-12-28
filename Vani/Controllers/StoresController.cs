using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Vani.Data;
using Vani.Dtos;
using Vani.Helpers;
using Vani.Models;
using Vani.Services;

namespace Vani.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;
        private readonly IStockerAzureStorage stockerAzureStorage;
        private readonly IHttpClientFactory clientFactory;
        private readonly string contenedor = "stores";

        public StoresController(ApplicationDbContext context, IMapper mapper, IStockerAzureStorage stockerAzureStorage, IHttpClientFactory clientFactory)
        {
            _context = context;
            this.mapper = mapper;
            this.stockerAzureStorage = stockerAzureStorage;
            this.clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreDTO>>> Get([FromHeader] PaginateDTO paginateDTO)
        {
            var queryable = _context.Stores.AsQueryable();
            await HttpContext.InsertPaginationParameters(queryable, paginateDTO.RecordsPerPage);

            var store = await queryable.OrderBy(x => x.Name).Paginate(paginateDTO).ToListAsync();
            var storeDTO = mapper.Map<List<StoreDTO>>(store);
            return storeDTO;
        }

        [HttpGet("{id}", Name = "GetStore")]
        public async Task<ActionResult<StoreDTO>> Get(int id)
        {
            var store = await _context.Stores.Include(x => x.Province).Include(x => x.StoreType).Include(x => x.Photos).FirstOrDefaultAsync(x => x.StoreId == id);
            var storeDTO = mapper.Map<StoreDTO>(store);

            if (store == null)
            {
                return NotFound();
            }

            return storeDTO;
        }

        [HttpPost]
        public async Task<ActionResult<Store>> Post([FromForm] StoreCreationDTO storeCreationDTO)
        {
            //string url = $"https://www.instagram.com/{storeCreationDTO.InstagramAccount}/?__a=1";
            //var json = new WebClient().DownloadString(url);
            //dynamic api = JsonConvert.DeserializeObject(json);
            //bool privacidad = api.graphql.user.is_private;

            //if (privacidad) { return BadRequest("The account cannot be private."); }
            var store = mapper.Map<Store>(storeCreationDTO);
            //store.Photo = api.graphql.user.profile_pic_url_hd;

            if (storeCreationDTO.Photo != null)
            {
                store.Photo = await stockerAzureStorage.GuardarArchivo(contenedor, storeCreationDTO.Photo);
            }
            _context.Stores.Add(store);
            await _context.SaveChangesAsync();
            var storeDTO = mapper.Map<StoreDTO>(store);

            return new CreatedAtRouteResult("GetStore", new { id = storeDTO.StoreId }, storeDTO);
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
