using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vani.Models
{
    public class Store
    {
        [Key]
        public int StoreId { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Este campo es requerido")]
        [MaxLength(50, ErrorMessage = "este nombre excede los {1} caracteres")]
        public string Name { get; set; }
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
        public string Photo { get; set; }
        [Display(Name = "Categoria")]
        public int StoretypeId { get; set; }
        public StoreType StoreType { get; set; }
        public Province Province { get; set; }
        public List<StorePhotos> Photos { get; set; }

    }
}
