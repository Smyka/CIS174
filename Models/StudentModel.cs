using System.ComponentModel.DataAnnotations;

namespace Student.Models
{
    public class StudentModel
    {
        [Required(ErrorMessage = "Please enter a first name.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name.")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Please enter a grade.")]
        [Range(0, 100, ErrorMessage =
        "Grade must be between 0-100")]
        public int? Grade { get; set; }
    }
}
