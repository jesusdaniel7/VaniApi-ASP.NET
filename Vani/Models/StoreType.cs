using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vani.Models
{
    public class StoreType
    {
        public int StoreTypeId { get; set; }
        public string Name { get; set; }
        public List<Store> Store { get; set; }
    }
}
