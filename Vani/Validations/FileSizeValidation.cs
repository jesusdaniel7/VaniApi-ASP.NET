using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vani.Validations
{
    public class FileSizeValidation : ValidationAttribute
    {
        private readonly int maxFileSizeMB;
        public FileSizeValidation(int MaxFileSizeMB)
        {
            this.maxFileSizeMB = MaxFileSizeMB;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value == null) { return ValidationResult.Success; }

            IFormFile formfile = value as IFormFile;
            if(formfile == null) { return ValidationResult.Success; }

            if(formfile.Length > maxFileSizeMB * 1024 * 1024)
            {
                return new ValidationResult($"The file size must be {maxFileSizeMB} or less.");
            }
            return ValidationResult.Success;
        }
    }
}
