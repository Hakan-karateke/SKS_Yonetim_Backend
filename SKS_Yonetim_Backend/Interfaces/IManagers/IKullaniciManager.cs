using SKS_Yonetim_Backend.Models.DtoViewModels;

namespace SKS_Yonetim_Backend.Interfaces.IManagers
{
    public interface IKullaniciManager
    {
        DtoProfilModel? GetDtoProfilModelById(int id);
        bool ChangePassword(ChangePasswordModel changePasswordModel);
        bool UpdateProfil(DtoProfilModel dtoProfilModel);
    }
}