using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vani.Models
{
    public class StorePhotos
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }

    }
}
