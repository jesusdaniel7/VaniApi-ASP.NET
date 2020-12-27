using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vani.Dtos
{
    public class ProvinceDTO
    {
        public int Id { get; set; }
        [Display(Name = "Provincia")]
        public string Name { get; set; }
        public List<StoreDTO> StoresDTO { get; set; }
    }
}
