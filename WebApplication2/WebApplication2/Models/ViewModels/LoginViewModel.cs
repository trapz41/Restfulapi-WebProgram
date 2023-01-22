using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models.ViewModels
{

    public class LoginViewModel
    {

        [Required]
        public string kullaniciadi { get; set; }

        [Required]
        public string sifre { get; set; }


    }
}
