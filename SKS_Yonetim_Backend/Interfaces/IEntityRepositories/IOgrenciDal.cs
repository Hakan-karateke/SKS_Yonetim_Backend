using SKS_Yonetim_Backend.Models.Context;

namespace SKS_Yonetim_Backend.Interfaces.IEntityRepositories
{
          public interface IOgrenciDal : IEntityRepository<Ogrenci>
          {
                    Ogrenci GetOgrenciByOgrenciNo(string numara);
                    Ogrenci GetOgrenciByKullaniciId(int kullaniciId);
          }
}