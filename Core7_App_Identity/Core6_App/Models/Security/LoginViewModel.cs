using System.ComponentModel.DataAnnotations;

namespace Core6_App.Models.Security
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
