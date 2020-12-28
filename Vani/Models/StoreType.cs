using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vani.Models
{
    public class StoreType
    {
        public int StoreTypeId { get; set; }
        //[Display(Name = "Nombre")]
        [StringLength(maximumLength: 20, ErrorMessage = "La longitud maxima es {1}")]
        public string Name { get; set; }
        public List<Store> Store { get; set; }
    }
}
