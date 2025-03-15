using SKS_Yonetim_Backend.Models.Context;

namespace SKS_Yonetim_Backend.Interfaces.IEntityRepositories
{
          public interface IOgretmenDal : IEntityRepository<Ogretmen>
          {
                    Ogretmen GetOgretmenByKullaniciId(int kullaniciId);
          }
}