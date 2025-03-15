using SKS_Yonetim_Backend.Models;
using SKS_Yonetim_Backend.Models.Context;

namespace SKS_Yonetim_Backend.Interfaces.IManagers
{
    public interface IAuthManager
    {
        DtoKullaniciModel? GetDtoKullaniciModel(LoginViewModel loginViewModel);
    }
}