using System.ComponentModel.DataAnnotations;

namespace Lancheria.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Informe o nome")]
        [Display(Name ="Usuario")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Informe a senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        public string ReturnURL { get; set; }
    }
}
