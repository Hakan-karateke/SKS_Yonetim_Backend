using SKS_Yonetim_Backend.Models.Context;

namespace SKS_Yonetim_Backend.Interfaces.IEntityRepositories
{
          public interface IPersonelDal : IEntityRepository<Personel>
          {
                    Personel GetPersonelByKullaniciId(int kullaniciId);
          }
}