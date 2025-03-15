using SKS_Yonetim_Backend.Models.Context;

namespace SKS_Yonetim_Backend.Interfaces.IEntityRepositories
{
          public interface IKullaniciDal : IEntityRepository<Kullanici>
          {
                    Kullanici GetKullaniciByEmailandSifre(string email, string sifre);
                    Kullanici GetKullaniciByEmail(string email);
          }
}