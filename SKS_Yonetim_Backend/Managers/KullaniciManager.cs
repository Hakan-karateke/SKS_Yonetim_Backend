using SKS_Yonetim_Backend.Data;
using SKS_Yonetim_Backend.Helpers;
using SKS_Yonetim_Backend.Interfaces.IEntityRepositories;
using SKS_Yonetim_Backend.Interfaces.IManagers;
using SKS_Yonetim_Backend.Models.Context;
using SKS_Yonetim_Backend.Models.DtoViewModels;

namespace SKS_Yonetim_Backend.Managers
{
    public class KullaniciManager : IKullaniciManager
    {
        private readonly IKullaniciDal _kullaniciDal;
        private readonly IOgrenciDal _ogrenciDal;
        private readonly IPersonelDal _personelDal;
        private readonly IOgretmenDal _ogretmenDal;

        public KullaniciManager(IKullaniciDal kullaniciDal, IOgrenciDal ogrenciDal, IPersonelDal personelDal, IOgretmenDal ogretmenDal)
        {
            _kullaniciDal = kullaniciDal;
            _ogrenciDal = ogrenciDal;
            _personelDal = personelDal;
            _ogretmenDal = ogretmenDal;
        }
        public DtoProfilModel? GetDtoProfilModelById(int id)
        {
            try
            {
                Kullanici kullanici = _kullaniciDal.GetById(id);
                if (kullanici == null)
                {
                    return null;
                }
                DtoProfilModel dtoProfilModel = new DtoProfilModel(kullanici, (RolTip)kullanici.Rol);
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
                // result türüne göre DtoProfilModel oluşturma
                if (result is Ogrenci ogrenci)
                {
                    dtoProfilModel.Ogrenci = ogrenci;
                }
                else if (result is Personel personel)
                {
                    dtoProfilModel.Personel = personel;
                }
                else if (result is Ogretmen ogretmen)
                {
                    dtoProfilModel.Ogretmen = ogretmen;
                }
                return dtoProfilModel;
            }
            catch (Exception ex)
            {
                throw new Exception("Manager katmaninda hata", ex);
            }
        }

        public bool ChangePassword(ChangePasswordModel changePasswordModel)
        {
            try
            {
                Kullanici kullanici = _kullaniciDal.GetById(changePasswordModel.KullaniciId);
                if (kullanici == null || kullanici.Sifre != GeneralTools.ComputeSha1Password(changePasswordModel.OldPassword!))
                {
                    return false;
                }
                kullanici.Sifre = GeneralTools.ComputeSha1Password(changePasswordModel.NewPassword!);
                return _kullaniciDal.Update(kullanici);
            }
            catch (Exception ex)
            {
                throw new Exception("Manager katmaninda hata", ex);
            }
        }

        public bool UpdateProfil(DtoProfilModel dtoProfilModel)
        {
            try
            {
                Kullanici kullanici = dtoProfilModel.Kullanici;
                if (kullanici == null)
                {
                    return false;
                }
                using (var transaction = _kullaniciDal.BeginTransaction())
                {
                    try
                    {
                        switch ((RolTip)kullanici.Rol)
                        {
                            case RolTip.Ogrenci:
                                if (dtoProfilModel.Ogrenci != null)
                                {
                                    _ogrenciDal.Update(dtoProfilModel.Ogrenci);
                                }
                                break;
                            case RolTip.Personel:
                                if (dtoProfilModel.Personel != null)
                                {
                                    _personelDal.Update(dtoProfilModel.Personel);
                                }
                                break;
                            case RolTip.Ogretmen:
                                if (dtoProfilModel.Ogretmen != null)
                                {
                                    _ogretmenDal.Update(dtoProfilModel.Ogretmen);
                                }
                                break;
                            default:
                                throw new Exception("Geçersiz rol tipi.");
                        }
                        if (!_kullaniciDal.Update(kullanici))
                        {
                            throw new Exception("Kullanıcı güncellenemedi.");
                        }
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Manager katmaninda hata", ex);
            }
        }
    }
}