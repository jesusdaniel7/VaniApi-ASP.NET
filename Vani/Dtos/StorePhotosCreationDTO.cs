using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vani.Dtos
{
    public class StorePhotosCreationDTO
    {
        [Required]
        public IFormFile Photo { get; set; }
        [Required]
        public int StoreId { get; set; }
    }
}
