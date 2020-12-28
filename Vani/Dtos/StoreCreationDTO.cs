using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vani.Validations;

namespace Vani.Dtos
{
    public class StoreCreationDTO
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Este campo es requerido")]
        [MaxLength(50, ErrorMessage = "este nombre excede los {1} caracteres")]
        public string Name { get; set; }
        [Display(Name = "Categoria")]
        public int StoretypeId { get; set; }
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Este campo es requerido")]
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
        [FileSizeValidation(10)]
        [ContentTypeValidation(contentTypeGroup: ContentTypeGroup.Photo)]
        public IFormFile Photo { get; set; }
      
    }
}
