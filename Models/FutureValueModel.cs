using System.ComponentModel.DataAnnotations;
namespace FutureValue.Models
{
    public class FutureValueModel
    {
        [Required(ErrorMessage = "Please enter a name.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please enter a date of birth.")]
        [Range(1900, 2012, ErrorMessage =
        "Date of birth must be between 1900 and 2012")]
        public int? DOB { get; set; }

        public int? AgeThisYear()
        {
            int? currentYear = 2025;
            return currentYear - DOB;
        }
    }
}