using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vani.Dtos;
using Vani.Models;

namespace Vani.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Store, StoreDTO>();
            CreateMap<StoreCreationDTO, Store>();
            CreateMap<StoreTypeCreationDTO, StoreType>();
            CreateMap<StorePhotosCreationDTO, StorePhotos>();
            CreateMap<Province, ProvinceDTO>();
            CreateMap<ProvinceCreationDTO,Province>();
        }
    }
}
