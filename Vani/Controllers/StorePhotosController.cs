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
using Vani.Models;
using Vani.Services;

namespace Vani.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorePhotosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IStockerAzureStorage stockerAzureStorage;
        private readonly string contenedor = "storephotos";

        public StorePhotosController(ApplicationDbContext context, IMapper mapper, IStockerAzureStorage stockerAzureStorage)
        {
            this.context = context;
            this.mapper = mapper;
            this.stockerAzureStorage = stockerAzureStorage;
        }


        [HttpGet]
        public async Task<ActionResult<List<StorePhotos>>> Get()
        {
            return await context.StorePhotos.ToListAsync();
        }

        [HttpGet("{id:int}", Name = "GetStorePhoto")]
        public async Task<ActionResult<StorePhotos>> Get(int id)
        {
            var StorePhoto = await context.StorePhotos.FirstOrDefaultAsync(x => x.Id == id);
            if (StorePhoto == null) { return NotFound(); }
            return StorePhoto;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] StorePhotosCreationDTO storePhotosCreationDTO)
        {
            var storePhoto = mapper.Map<StorePhotos>(storePhotosCreationDTO);
            if (storePhotosCreationDTO.Photo != null)
            {
                storePhoto.Photo = await stockerAzureStorage.GuardarArchivo(contenedor, storePhotosCreationDTO.Photo);
            }

            context.Add(storePhoto);
            await context.SaveChangesAsync();
            //return new CreatedAtRouteResult("GetStorePhoto", new { id = storePhoto.Id }, storePhotosCreationDTO);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var storePhoto = await context.StorePhotos.FirstOrDefaultAsync(x => x.Id == id);
            if(storePhoto == null) { return NotFound(); }
            context.Remove(storePhoto);
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}
