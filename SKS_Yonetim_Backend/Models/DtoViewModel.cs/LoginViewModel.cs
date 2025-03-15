using System.ComponentModel.DataAnnotations;

namespace SKS_Yonetim_Backend.Models.Context
{
          public class LoginViewModel
          {
                    [Required(ErrorMessage = "Kullanıcı adı gerekli.")]
                    public string? KullaniciAdi { get; set; }

                    [Required(ErrorMessage = "Şifre gerekli.")]
                    public string? Sifre { get; set; }
                    public required int Rol {  get; set; }

          }
}