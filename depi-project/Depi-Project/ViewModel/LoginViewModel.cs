using System.ComponentModel.DataAnnotations;

namespace Depi_Project.ViewModel
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "*")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remmber Me")]
        public bool RemmberMe { get; set; }
    }
}
