using SKS_Yonetim_Backend.Models.DtoViewModels;

namespace SKS_Yonetim_Backend.Interfaces.IManagers
{
    public interface IAuthManager
    {
        TokenModel? GetTokenModel(LoginViewModel loginViewModel);
    }
}