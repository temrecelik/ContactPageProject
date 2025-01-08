using System.ComponentModel.DataAnnotations;

namespace ContactPageProject.Extentions
{
    public class AllowedExtensionsAttribute : ValidationAttribute
    {


        private readonly string[] _extensions;

        public AllowedExtensionsAttribute(string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
                if (!_extensions.Contains(extension))
                {
                    return new ValidationResult($"Lütfen sadece {string.Join(", ", _extensions)} uzantılarına sahip dosyalar yükleyiniz.");
                }
            }

            return ValidationResult.Success!;
        }
    }
}
