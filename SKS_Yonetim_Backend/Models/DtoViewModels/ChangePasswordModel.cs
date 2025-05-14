using System.ComponentModel.DataAnnotations;

namespace SKS_Yonetim_Backend.Models.DtoViewModels
{
          public class ChangePasswordModel
          {
                    public int KullaniciId { get; set; }
                    public string? Email { get; set; }

                    [Required]
                    [DataType(DataType.Password)]
                    [Display(Name = "Current password")]
                    public string? OldPassword { get; set; }

                    [Required]
                    [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
                    [DataType(DataType.Password)]
                    [Display(Name = "New password")]
                    public string? NewPassword { get; set; }
          }
}