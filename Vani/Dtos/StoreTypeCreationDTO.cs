using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vani.Dtos
{
    public class StoreTypeCreationDTO
    {
        public string Name { get; set; }
        public List<StoreDTO> StoreDTO { get; set; }
    }
}
