using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vani.Dtos
{
    public class StoreDTO
    {
        public int StoreId { get; set; }
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Display(Name = "Descripción")]
        public string Description { get; set; }
        [Display(Name = "Cuenta de instagram")]
        public string InstagramAccount { get; set; }
        [Display(Name = "Provincia")]
        public int ProvinceId { get; set; }
        [Display(Name = "Número de WhatsApp")]
        public string WhatsApp { get; set; }
        [Display(Name = "Latitud")]
        public string Lat { get; set; }
        [Display(Name = "Longitud")]
        public string Long { get; set; }
        [Display(Name = "Foto")]
        public string Photo { get; set; }
        [Display(Name = "Categoria")]
        public int StoretypeId { get; set; }
        public StoreTypeDTO StoreTypeDTO { get; set; }
        public ProvinceDTO ProvinceDTO { get; set; }
    }
}
