using SKS_Yonetim_Backend.Models.Context;

namespace SKS_Yonetim_Backend.Interfaces.IEntityRepositories
{
    public interface IRandevuDal : IEntityRepository<Randevu>
    {
        public int GetAllRandevuCount();
        int GetRandevuCountByKullaniciId(int kullaniciId);
    }
}