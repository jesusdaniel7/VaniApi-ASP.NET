using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vani.Models;

namespace Vani.Dtos
{
    public class ProvinceCreationDTO
    {
        [Required(ErrorMessage ="Este campo es requerido.")]
        public string Name { get; set; }
        public List<Store> Stores { get; set; }
    }
}
