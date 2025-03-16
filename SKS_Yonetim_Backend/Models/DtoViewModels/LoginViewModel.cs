using System.ComponentModel.DataAnnotations;

namespace SKS_Yonetim_Backend.Models.DtoViewModels
{
          public class LoginViewModel
          {
                    [Required(ErrorMessage = "Email gerekli.")]
                    public required string Email { get; set; }

                    [Required(ErrorMessage = "Şifre gerekli.")]
                    public required string Sifre { get; set; }

          }
}