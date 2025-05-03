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
                    private readonly IOgretmenDal _ogretmenDal;
                    private readonly IOgrenciDal _ogrenciDal;
                    private readonly IPersonelDal _personelDal;
                    public AuthManager(IKullaniciDal kullaniciDal, IOgretmenDal ogretmenDal, IOgrenciDal ogrenciDal, IPersonelDal personelDal)
                    {
                              _kullaniciDal = kullaniciDal;
                              _ogretmenDal = ogretmenDal;
                              _ogrenciDal = ogrenciDal;
                              _personelDal = personelDal;
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
                                                  BolumId = null,
                                                  OgrenciNo = null,
                                                  UnvanId = null
                                        };
                                        if (kullanici.Rol == RolTip.Admin.GetHashCode())
                                        {
                                                  // Admin için özel bir işlem yapabilirsiniz, örneğin sadece admin bilgilerini döndürebilirsiniz.
                                                  return TokenModel;
                                        }

                                        // Kullanıcının rolüne göre ilgili entity'yi alıyoruz.
                                        object? result = kullanici.Rol switch
                                        {
                                                  var rol when rol == RolTip.Ogrenci.GetHashCode() => _ogrenciDal.GetById(kullanici.Id),
                                                  var rol when rol == RolTip.Personel.GetHashCode() => _personelDal.GetById(kullanici.Id),
                                                  var rol when rol == RolTip.Ogretmen.GetHashCode() => _ogretmenDal.GetById(kullanici.Id),
                                                  _ => null
                                        };
                                        if (result is null)
                                        {
                                                  return null;
                                        }

                                        // Eğer result Ogrenci ise
                                        if (result is Ogrenci ogrenci)
                                        {
                                                  // Ogrenci'ye özgü ek alanlar varsa buraya ekleyebilirsiniz
                                                  TokenModel.OgrenciNo = ogrenci.OgrenciNo;
                                                  TokenModel.BolumId = ogrenci.BolumId.ToString();
                                                  TokenModel.UnvanId = null;
                                        }
                                        // Eğer result Personel ise
                                        else if (result is Personel personel)
                                        {
                                                  // Personel'e özgü ek alanlar varsa buraya ekleyebilirsiniz
                                                  TokenModel.OgrenciNo = null;
                                                  TokenModel.BolumId = personel.BolumId.ToString();
                                                  TokenModel.UnvanId = personel.UnvanId;

                                        }
                                        // Eğer result Ogretmen ise
                                        else if (result is Ogretmen ogretmen)
                                        {
                                                  // Ogretmen'e özgü ek alanlar varsa buraya ekleyebilirsiniz
                                                  TokenModel.OgrenciNo = null;
                                                  TokenModel.BolumId = ogretmen.BolumId.ToString();
                                                  TokenModel.UnvanId = null;
                                        }

                                        return TokenModel;
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("Manager Katmaninda Hata", ex);
                              }
                    }
          }
}