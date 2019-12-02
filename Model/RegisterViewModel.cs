using System.ComponentModel.DataAnnotations;
namespace Model
{
    public class RegisterViewModel
    {

        [Required]
        [Display(Name = "Full Name")]
        public string Name { get; set; }
        
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


    }
}
