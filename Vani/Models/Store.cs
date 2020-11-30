using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vani.Models
{
    public class Store
    {
        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string InstagramAccount { get; set; }
        public string Province { get; set; }
        public string WhatsAppNum { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public string Photo { get; set; }
        public int StoretypeId { get; set; }
        public StoreType StoreType { get; set; }

    }
}
