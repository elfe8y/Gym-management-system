using System.ComponentModel.DataAnnotations;

namespace Depi_Project.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [MinLength(3)]
        public string? UserName { get; set; }
        [DataType(DataType.Password)]

        public string? Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string? ConfirmPassword { get; set; }
        [MaxLength(100)]
        public string? Address { get; set; }
    }
}
