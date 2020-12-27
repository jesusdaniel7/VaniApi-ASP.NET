using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vani.Dtos
{
    public class StoreTypeDTO
    {
        public int StoreTypeId { get; set; }
        [Display(Name ="Categoria")]
        public string Name { get; set; }
        public List<StoreDTO> StoreDTO { get; set; }
    }
}
