using SKS_Yonetim_Backend.Helpers;
using SKS_Yonetim_Backend.Data;
using SKS_Yonetim_Backend.Interfaces.IEntityRepositories;
using SKS_Yonetim_Backend.Interfaces.IManagers;
using SKS_Yonetim_Backend.Models.DtoViewModels;
using SKS_Yonetim_Backend.Models.Context;

namespace SKS_Yonetim_Backend.Managers
{
          public class AuthManager : IAuthManager
          {
                    private readonly IKullaniciDal _kullaniciDal;
                    public AuthManager(IKullaniciDal kullaniciDal)
                    {
                              _kullaniciDal = kullaniciDal;
                    }
                    public TokenModel? GetTokenModel(LoginViewModel loginViewModel)
                    {
                              try
                              {
                                        var kullanici = _kullaniciDal.GetKullaniciByEmailandSifre(loginViewModel.Email, GeneralTools.ComputeSha1Password(loginViewModel.Sifre));
                                        if (kullanici == null)
                                        {
                                                  return null;
                                        }

                                        // result türüne göre TokenModel oluşturma
                                        TokenModel TokenModel = new()
                                        {
                                                  Id = kullanici.Id,
                                                  Email = kullanici.Email,
                                                  Ad = kullanici.Ad,
                                                  Soyad = kullanici.Soyad,
                                                  Rol = kullanici.Rol,
                                        };

                                        return TokenModel;
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Manager Katmaninda Hata", ex);
                              }
                    }
          }
}