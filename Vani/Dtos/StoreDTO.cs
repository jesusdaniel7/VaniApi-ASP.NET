using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vani.Models;

namespace Vani.Dtos
{
    public class StoreDTO
    {
        public int StoreId { get; set; }
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string InstagramAccount { get; set; }
        public int ProvinceId { get; set; }
        public string WhatsApp { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public string Photo { get; set; }
        public int StoretypeId { get; set; }
        public StoreTypeDTO StoreTypeDTO { get; set; }
        public Province Province { get; set; }
    }
}
